namespace Risk_Management
{
    partial class IntroducereRandTratare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroducereRandTratare));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.label_Nivel = new System.Windows.Forms.Label();
            this.textBox_MetodaTratare = new System.Windows.Forms.TextBox();
            this.label_MetodaTratare = new System.Windows.Forms.Label();
            this.textBox_CodRisc = new System.Windows.Forms.TextBox();
            this.label_Cod_risc = new System.Windows.Forms.Label();
            this.textBox_CategorieContramasuri = new System.Windows.Forms.TextBox();
            this.textBox_Tratat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.White;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cancel.Location = new System.Drawing.Point(248, 229);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(89, 30);
            this.button_Cancel.TabIndex = 49;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click_1);
            // 
            // button_Ok
            // 
            this.button_Ok.BackColor = System.Drawing.Color.White;
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.ForeColor = System.Drawing.Color.Black;
            this.button_Ok.Image = ((System.Drawing.Image)(resources.GetObject("button_Ok.Image")));
            this.button_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Ok.Location = new System.Drawing.Point(52, 229);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(67, 30);
            this.button_Ok.TabIndex = 48;
            this.button_Ok.Text = "Ok";
            this.button_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Ok.UseVisualStyleBackColor = false;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // label_Nivel
            // 
            this.label_Nivel.AutoSize = true;
            this.label_Nivel.BackColor = System.Drawing.Color.White;
            this.label_Nivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nivel.Location = new System.Drawing.Point(49, 117);
            this.label_Nivel.Name = "label_Nivel";
            this.label_Nivel.Size = new System.Drawing.Size(163, 18);
            this.label_Nivel.TabIndex = 47;
            this.label_Nivel.Text = "Categorie contramasuri";
            this.label_Nivel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_MetodaTratare
            // 
            this.textBox_MetodaTratare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MetodaTratare.Location = new System.Drawing.Point(248, 72);
            this.textBox_MetodaTratare.Name = "textBox_MetodaTratare";
            this.textBox_MetodaTratare.Size = new System.Drawing.Size(140, 24);
            this.textBox_MetodaTratare.TabIndex = 46;
            // 
            // label_MetodaTratare
            // 
            this.label_MetodaTratare.AutoSize = true;
            this.label_MetodaTratare.BackColor = System.Drawing.Color.White;
            this.label_MetodaTratare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MetodaTratare.Location = new System.Drawing.Point(49, 75);
            this.label_MetodaTratare.Name = "label_MetodaTratare";
            this.label_MetodaTratare.Size = new System.Drawing.Size(124, 18);
            this.label_MetodaTratare.TabIndex = 45;
            this.label_MetodaTratare.Text = "Metoda de tratare";
            // 
            // textBox_CodRisc
            // 
            this.textBox_CodRisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CodRisc.Location = new System.Drawing.Point(248, 28);
            this.textBox_CodRisc.Name = "textBox_CodRisc";
            this.textBox_CodRisc.Size = new System.Drawing.Size(140, 24);
            this.textBox_CodRisc.TabIndex = 44;
            // 
            // label_Cod_risc
            // 
            this.label_Cod_risc.AutoSize = true;
            this.label_Cod_risc.BackColor = System.Drawing.Color.White;
            this.label_Cod_risc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cod_risc.Location = new System.Drawing.Point(49, 31);
            this.label_Cod_risc.Name = "label_Cod_risc";
            this.label_Cod_risc.Size = new System.Drawing.Size(64, 18);
            this.label_Cod_risc.TabIndex = 43;
            this.label_Cod_risc.Text = "Cod risc";
            // 
            // textBox_CategorieContramasuri
            // 
            this.textBox_CategorieContramasuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CategorieContramasuri.Location = new System.Drawing.Point(248, 117);
            this.textBox_CategorieContramasuri.Name = "textBox_CategorieContramasuri";
            this.textBox_CategorieContramasuri.Size = new System.Drawing.Size(140, 24);
            this.textBox_CategorieContramasuri.TabIndex = 50;
            // 
            // textBox_Tratat
            // 
            this.textBox_Tratat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Tratat.Location = new System.Drawing.Point(248, 160);
            this.textBox_Tratat.Name = "textBox_Tratat";
            this.textBox_Tratat.Size = new System.Drawing.Size(140, 24);
            this.textBox_Tratat.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "Tratat";
            // 
            // IntroducereRandTratare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(409, 283);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Tratat);
            this.Controls.Add(this.textBox_CategorieContramasuri);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.label_Nivel);
            this.Controls.Add(this.textBox_MetodaTratare);
            this.Controls.Add(this.label_MetodaTratare);
            this.Controls.Add(this.textBox_CodRisc);
            this.Controls.Add(this.label_Cod_risc);
            this.Name = "IntroducereRandTratare";
            this.Text = "IntroducereRandTratare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Label label_Nivel;
        private System.Windows.Forms.TextBox textBox_MetodaTratare;
        private System.Windows.Forms.Label label_MetodaTratare;
        private System.Windows.Forms.TextBox textBox_CodRisc;
        private System.Windows.Forms.Label label_Cod_risc;
        private System.Windows.Forms.TextBox textBox_CategorieContramasuri;
        private System.Windows.Forms.TextBox textBox_Tratat;
        private System.Windows.Forms.Label label1;
    }
}