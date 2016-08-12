namespace Group3_FinalProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCompRatio = new System.Windows.Forms.TextBox();
            this.txtClearTxt = new System.Windows.Forms.TextBox();
            this.txtCipheredTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCipherTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstViewDictionaries = new System.Windows.Forms.ListView();
            this.colHeadLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadASCII = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadOccurence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadHuffman_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCompRatio);
            this.groupBox1.Controls.Add(this.txtClearTxt);
            this.groupBox1.Controls.Add(this.txtCipheredTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCipherTxt);
            this.groupBox1.Location = new System.Drawing.Point(583, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compression Ratio";
            // 
            // txtCompRatio
            // 
            this.txtCompRatio.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompRatio.Location = new System.Drawing.Point(109, 76);
            this.txtCompRatio.Name = "txtCompRatio";
            this.txtCompRatio.ReadOnly = true;
            this.txtCompRatio.Size = new System.Drawing.Size(100, 20);
            this.txtCompRatio.TabIndex = 5;
            // 
            // txtSClearTxt
            // 
            this.txtClearTxt.BackColor = System.Drawing.SystemColors.Window;
            this.txtClearTxt.Location = new System.Drawing.Point(109, 47);
            this.txtClearTxt.Name = "txtSClearTxt";
            this.txtClearTxt.ReadOnly = true;
            this.txtClearTxt.Size = new System.Drawing.Size(100, 20);
            this.txtClearTxt.TabIndex = 4;
            // 
            // txtSCipheredTxt
            // 
            this.txtCipheredTxt.BackColor = System.Drawing.SystemColors.Window;
            this.txtCipheredTxt.Location = new System.Drawing.Point(109, 17);
            this.txtCipheredTxt.Name = "txtSCipheredTxt";
            this.txtCipheredTxt.ReadOnly = true;
            this.txtCipheredTxt.Size = new System.Drawing.Size(100, 20);
            this.txtCipheredTxt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Compression Ratio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size Clear Text";
            // 
            // lblCipherTxt
            // 
            this.lblCipherTxt.AutoSize = true;
            this.lblCipherTxt.Location = new System.Drawing.Point(7, 20);
            this.lblCipherTxt.Name = "lblCipherTxt";
            this.lblCipherTxt.Size = new System.Drawing.Size(96, 13);
            this.lblCipherTxt.TabIndex = 0;
            this.lblCipherTxt.Text = "Size Ciphered Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the file you would like to run: ";
            // 
            // txtPathName
            // 
            this.txtPathName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPathName.Location = new System.Drawing.Point(196, 11);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.ReadOnly = true;
            this.txtPathName.Size = new System.Drawing.Size(293, 20);
            this.txtPathName.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(495, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(593, 8);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(674, 8);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(755, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstViewDictionaries
            // 
            this.lstViewDictionaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadLetter,
            this.colHeadASCII,
            this.colHeadOccurence,
            this.colHeadFrequency,
            this.colHeadHuffman_Code});
            this.lstViewDictionaries.Location = new System.Drawing.Point(16, 38);
            this.lstViewDictionaries.Name = "lstViewDictionaries";
            this.lstViewDictionaries.Size = new System.Drawing.Size(515, 509);
            this.lstViewDictionaries.TabIndex = 7;
            this.lstViewDictionaries.UseCompatibleStateImageBehavior = false;
            this.lstViewDictionaries.View = System.Windows.Forms.View.Details;
            // 
            // colHeadLetter
            // 
            this.colHeadLetter.Text = "Letter";
            this.colHeadLetter.Width = 97;
            // 
            // colHeadASCII
            // 
            this.colHeadASCII.Text = "ASCII";
            this.colHeadASCII.Width = 101;
            // 
            // colHeadOccurence
            // 
            this.colHeadOccurence.Text = "Occurence";
            this.colHeadOccurence.Width = 101;
            // 
            // colHeadFrequency
            // 
            this.colHeadFrequency.Text = "Frequency";
            this.colHeadFrequency.Width = 92;
            // 
            // colHeadHuffman_Code
            // 
            this.colHeadHuffman_Code.Text = "Huffman Code";
            this.colHeadHuffman_Code.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 559);
            this.Controls.Add(this.lstViewDictionaries);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPathName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCipherTxt;
        private System.Windows.Forms.TextBox txtCompRatio;
        private System.Windows.Forms.TextBox txtClearTxt;
        private System.Windows.Forms.TextBox txtCipheredTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lstViewDictionaries;
        private System.Windows.Forms.ColumnHeader colHeadLetter;
        private System.Windows.Forms.ColumnHeader colHeadASCII;
        private System.Windows.Forms.ColumnHeader colHeadOccurence;
        private System.Windows.Forms.ColumnHeader colHeadFrequency;
        private System.Windows.Forms.ColumnHeader colHeadHuffman_Code;
    }
}

