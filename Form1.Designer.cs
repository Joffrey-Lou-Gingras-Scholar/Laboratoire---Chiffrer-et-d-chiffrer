using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratoire___Chiffrer_et_déchiffrer
{
    public partial class Form1 : Form
    {
        public enum NomAlgorithme
        {
            Aucun, TripleDES, AES, DSA, RSA
        }

        String algo { get; set; } = null; // Permet de conserver la clé intacte entre les opérations
        byte[] hash { get; set; } = null; // Utile pour l'algorithme DSA

        cryptographieManager cryptographieManager = new cryptographieManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void algorithme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                this.key.Text = "";
                algo = null;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                this.key.Text = cryptographieManager.GenerateTripleDESKey();
                algo = this.key.Text;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                this.key.Text = cryptographieManager.GenerateAESKey();
                algo = this.key.Text;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                this.key.Text = cryptographieManager.GenerateDSAKey();
                algo = this.key.Text;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                this.key.Text = cryptographieManager.GenerateRSAKey();
                algo = this.key.Text;
            }
        }

        private void executer(object sender, EventArgs e)
        {
            if(this.algorithme.SelectedItem != null && this.action.SelectedItem != null)
            {
                this.texteTransforme.Text = cryptographieManager.cryptographieProcessing((string)this.algorithme.SelectedItem, ((string)this.action.SelectedItem).ToLower(), algo, this.texteUtilisateur.Text);
            }
        }

        private CheckedListBox algorithme;
        private Label entree;
        private TextBox texteTransforme;
        private TextBox texteUtilisateur;
        private Label sortie;
        private CheckedListBox action;
        private TextBox key;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}
