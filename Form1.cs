namespace Laboratoire___Chiffrer_et_déchiffrer
{
    public partial class Form1 : Form
    {


        private void InitializeComponent()
        {
            algorithme = new CheckedListBox();
            entree = new Label();
            texteTransforme = new TextBox();
            texteUtilisateur = new TextBox();
            sortie = new Label();
            action = new CheckedListBox();
            key = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // algorithme
            // 
            algorithme.FormattingEnabled = true;
            algorithme.Items.AddRange(new object[] { "Aucun", "TripleDES", "AES", "DSA", "RSA" });
            algorithme.Location = new Point(12, 12);
            algorithme.Name = "algorithme";
            algorithme.Size = new Size(523, 114);
            algorithme.TabIndex = 0;
            algorithme.SelectedIndexChanged += algorithme_SelectedIndexChanged;
            // 
            // entree
            // 
            entree.AutoSize = true;
            entree.Location = new Point(7, 291);
            entree.Name = "entree";
            entree.Size = new Size(55, 20);
            entree.TabIndex = 1;
            entree.Text = "Sortie :";
            // 
            // texteTransforme
            // 
            texteTransforme.Location = new Point(68, 291);
            texteTransforme.Name = "texteTransforme";
            texteTransforme.Size = new Size(467, 27);
            texteTransforme.TabIndex = 2;
            // 
            // texteUtilisateur
            // 
            texteUtilisateur.Location = new Point(68, 220);
            texteUtilisateur.Name = "texteUtilisateur";
            texteUtilisateur.Size = new Size(467, 27);
            texteUtilisateur.TabIndex = 3;
            // 
            // sortie
            // 
            sortie.AutoSize = true;
            sortie.Location = new Point(4, 227);
            sortie.Name = "sortie";
            sortie.Size = new Size(58, 20);
            sortie.TabIndex = 4;
            sortie.Text = "Entrée :";
            // 
            // action
            // 
            action.FormattingEnabled = true;
            action.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            action.Location = new Point(12, 132);
            action.Name = "action";
            action.Size = new Size(523, 48);
            action.TabIndex = 5;
            // 
            // key
            // 
            key.Location = new Point(68, 187);
            key.Name = "key";
            key.Size = new Size(467, 27);
            key.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 196);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 7;
            label1.Text = "Clé :";
            // 
            // button1
            // 
            button1.Location = new Point(12, 253);
            button1.Name = "button1";
            button1.Size = new Size(523, 29);
            button1.TabIndex = 8;
            button1.Text = "Éxécuter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += executer;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(25, 333);
            label2.Name = "label2";
            label2.Size = new Size(502, 17);
            label2.TabIndex = 9;
            label2.Text = "* Séparez à l'aide du caractère \"|\" la valeur et la signature, lors de la Vérification DSA";
            // 
            // Form1
            // 
            ClientSize = new Size(547, 359);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(key);
            Controls.Add(action);
            Controls.Add(sortie);
            Controls.Add(texteUtilisateur);
            Controls.Add(texteTransforme);
            Controls.Add(entree);
            Controls.Add(algorithme);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}