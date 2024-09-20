using System;
using System.Security.Cryptography;
using System.Text;

namespace Laboratoire___Chiffrer_et_déchiffrer
{
    internal class cryptographieManager
    {

        /*
         * Un vecteur d'initialisation permet d'éviter d'obtenir des clé d'encryption 
         * similaire lorsque les valeurs à encrypter son similaire.
         */

        /* 
         * Les 2 functions se ressemble , mais RSA utilise la clé pour encrypter la valeur , tandis que DSA génère une seconde clé "signature"
         * qui est distinc de la valeur et permet de vérifier son authenticité. Il serait possible de crypter en RSA er ensuite générer une signature
         * pour s'assurer que les données encrypté n'ont pas été altéré.
         */

        /*
         * clé tripleDES vers AES = System.Security.Cryptography.CryptographicException : 'The input data is not a complete block.'
         * clé AES vers TripleDES = System.Security.Cryptography.CryptographicException : 'Padding is invalid and cannot be removed.'
         * Les données sont dans un format invalide.
         */

        public string cryptographieProcessing(string algorythm, string action, string key, string data)
        {
            string output = "";

            switch (algorythm)
            {
                case "Aucun":
                    output = data;
                    break;
                case "TripleDES":
                    output = TripleDES(action, key, data);
                    break;
                case "AES":
                    output = AES(action, key, data);
                    break;
                case "DSA":
                    output = DSA(action, key, data);
                    break;
                case "RSA":
                    output = RSA(action, key, data);
                    break;
            }

            return output;
        }
            
        public string GenerateTripleDESKey()
        {
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.GenerateKey();
                return Convert.ToBase64String(tripleDES.Key);
            }
        }

        public string GenerateAESKey()
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.GenerateKey();
                return Convert.ToBase64String(aes.Key);
            }
        }

        public string GenerateRSAKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                return rsa.ToXmlString(true); 
            }
        }

        public string GenerateDSAKey()
        {
            using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
            {
                return dsa.ToXmlString(true); 
            }
        }

        private string TripleDES(string action, string key, string data)
        {
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Key = Convert.FromBase64String(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;

                ICryptoTransform transform;
                if (action == "encrypt")
                {
                    transform = tripleDES.CreateEncryptor();
                    byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                    byte[] result = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(result);
                }
                else if (action == "decrypt")
                {
                    transform = tripleDES.CreateDecryptor();
                    byte[] inputBytes = Convert.FromBase64String(data);
                    byte[] result = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Encoding.UTF8.GetString(result);
                }
            }
            return string.Empty;
        }

        private string AES(string action, string key, string data)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Convert.FromBase64String(key);  
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform transform;
                if (action == "encrypt")
                {
                    transform = aes.CreateEncryptor();
                    byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                    byte[] result = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(result);
                }
                else if (action == "decrypt")
                {
                    transform = aes.CreateDecryptor();
                    byte[] inputBytes = Convert.FromBase64String(data);
                    byte[] result = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Encoding.UTF8.GetString(result);
                }
            }
            return string.Empty;
        }

        private string RSA(string action, string key, string data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);  

                if (action == "encrypt")
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                    byte[] encryptedBytes = rsa.Encrypt(inputBytes, false);
                    return Convert.ToBase64String(encryptedBytes);
                }
                else if (action == "decrypt")
                {
                    byte[] inputBytes = Convert.FromBase64String(data);
                    byte[] decryptedBytes = rsa.Decrypt(inputBytes, false);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            return string.Empty;
        }

        private string DSA(string action, string key, string data)
        {
            using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
            {
                dsa.FromXmlString(key);

                if (action == "encrypt") // sign
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    byte[] signature = dsa.SignData(dataBytes);
                    return Convert.ToBase64String(signature);
                }
                else if (action == "decrypt") // validate
                {

                    var parts = data.Split('|');
                    if (parts.Length != 2)
                    {
                        return "Invalid input format for verification. Use 'data|signature'.";
                    }

                    string originalData = parts[0];
                    byte[] signature = Convert.FromBase64String(parts[1]);

                    byte[] originalDataBytes = Encoding.UTF8.GetBytes(originalData);
                    bool isVerified = dsa.VerifyData(originalDataBytes, signature);
                    return isVerified ? "Verified" : "Not Verified";
                }
            }
            return string.Empty;
        }
    }
}
