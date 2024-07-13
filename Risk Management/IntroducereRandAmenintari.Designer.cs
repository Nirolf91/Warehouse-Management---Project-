namespace Risk_Management
{
    partial class IntroducereRandAmenintari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroducereRandAmenintari));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.textBox_Nivel_maxim = new System.Windows.Forms.TextBox();
            this.label_Nivel_maxim = new System.Windows.Forms.Label();
            this.textBox_Nivel_minim = new System.Windows.Forms.TextBox();
            this.label_Nivel_minim = new System.Windows.Forms.Label();
            this.textBox_CodBun = new System.Windows.Forms.TextBox();
            this.label_Cod_bun = new System.Windows.Forms.Label();
            this.textBox_Amenintare = new System.Windows.Forms.TextBox();
            this.label_Amenintare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.White;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cancel.Location = new System.Drawing.Point(192, 211);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(89, 30);
            this.button_Cancel.TabIndex = 31;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Cancel.UseVisualStyleBackColor = false;
            // 
            // button_Ok
            // 
            this.button_Ok.BackColor = System.Drawing.Color.White;
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.ForeColor = System.Drawing.Color.Black;
            this.button_Ok.Image = ((System.Drawing.Image)(resources.GetObject("button_Ok.Image")));
            this.button_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Ok.Location = new System.Drawing.Point(51, 211);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(67, 30);
            this.button_Ok.TabIndex = 30;
            this.button_Ok.Text = "Ok";
            this.button_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Ok.UseVisualStyleBackColor = false;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click_1);
            // 
            // textBox_Nivel_maxim
            // 
            this.textBox_Nivel_maxim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nivel_maxim.Location = new System.Drawing.Point(190, 155);
            this.textBox_Nivel_maxim.Name = "textBox_Nivel_maxim";
            this.textBox_Nivel_maxim.Size = new System.Drawing.Size(140, 24);
            this.textBox_Nivel_maxim.TabIndex = 24;
            this.textBox_Nivel_maxim.TextChanged += new System.EventHandler(this.textBox_Nivel_maxim_TextChanged);
            // 
            // label_Nivel_maxim
            // 
            this.label_Nivel_maxim.AutoSize = true;
            this.label_Nivel_maxim.BackColor = System.Drawing.Color.White;
            this.label_Nivel_maxim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nivel_maxim.Location = new System.Drawing.Point(48, 161);
            this.label_Nivel_maxim.Name = "label_Nivel_maxim";
            this.label_Nivel_maxim.Size = new System.Drawing.Size(88, 18);
            this.label_Nivel_maxim.TabIndex = 23;
            this.label_Nivel_maxim.Text = "Nivel maxim";
            this.label_Nivel_maxim.Click += new System.EventHandler(this.label_Nivel_maxim_Click);
            // 
            // textBox_Nivel_minim
            // 
            this.textBox_Nivel_minim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nivel_minim.Location = new System.Drawing.Point(192, 113);
            this.textBox_Nivel_minim.Name = "textBox_Nivel_minim";
            this.textBox_Nivel_minim.Size = new System.Drawing.Size(140, 24);
            this.textBox_Nivel_minim.TabIndex = 22;
            // 
            // label_Nivel_minim
            // 
            this.label_Nivel_minim.AutoSize = true;
            this.label_Nivel_minim.BackColor = System.Drawing.Color.White;
            this.label_Nivel_minim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nivel_minim.Location = new System.Drawing.Point(48, 119);
            this.label_Nivel_minim.Name = "label_Nivel_minim";
            this.label_Nivel_minim.Size = new System.Drawing.Size(84, 18);
            this.label_Nivel_minim.TabIndex = 21;
            this.label_Nivel_minim.Text = "Nivel minim";
            this.label_Nivel_minim.Click += new System.EventHandler(this.label_Nivel_minim_Click);
            // 
            // textBox_CodBun
            // 
            this.textBox_CodBun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CodBun.Location = new System.Drawing.Point(192, 75);
            this.textBox_CodBun.Name = "textBox_CodBun";
            this.textBox_CodBun.Size = new System.Drawing.Size(140, 24);
            this.textBox_CodBun.TabIndex = 20;
            // 
            // label_Cod_bun
            // 
            this.label_Cod_bun.AutoSize = true;
            this.label_Cod_bun.BackColor = System.Drawing.Color.White;
            this.label_Cod_bun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cod_bun.Location = new System.Drawing.Point(48, 75);
            this.label_Cod_bun.Name = "label_Cod_bun";
            this.label_Cod_bun.Size = new System.Drawing.Size(64, 18);
            this.label_Cod_bun.TabIndex = 19;
            this.label_Cod_bun.Text = "Cod bun";
            this.label_Cod_bun.Click += new System.EventHandler(this.label_Cod_bun_Click);
            // 
            // textBox_Amenintare
            // 
            this.textBox_Amenintare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Amenintare.Location = new System.Drawing.Point(190, 32);
            this.textBox_Amenintare.Name = "textBox_Amenintare";
            this.textBox_Amenintare.Size = new System.Drawing.Size(140, 24);
            this.textBox_Amenintare.TabIndex = 18;
            // 
            // label_Amenintare
            // 
            this.label_Amenintare.AutoSize = true;
            this.label_Amenintare.BackColor = System.Drawing.Color.White;
            this.label_Amenintare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Amenintare.Location = new System.Drawing.Point(48, 35);
            this.label_Amenintare.Name = "label_Amenintare";
            this.label_Amenintare.Size = new System.Drawing.Size(82, 18);
            this.label_Amenintare.TabIndex = 17;
            this.label_Amenintare.Text = "Amenintare";
            this.label_Amenintare.Click += new System.EventHandler(this.label_Amenintare_Click);
            // 
            // IntroducereRandAmenintari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(370, 279);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_Nivel_maxim);
            this.Controls.Add(this.label_Nivel_maxim);
            this.Controls.Add(this.textBox_Nivel_minim);
            this.Controls.Add(this.label_Nivel_minim);
            this.Controls.Add(this.textBox_CodBun);
            this.Controls.Add(this.label_Cod_bun);
            this.Controls.Add(this.textBox_Amenintare);
            this.Controls.Add(this.label_Amenintare);
            this.Name = "IntroducereRandAmenintari";
            this.Text = "IntroducereRandAmenintari";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.TextBox textBox_Nivel_maxim;
        private System.Windows.Forms.Label label_Nivel_maxim;
        private System.Windows.Forms.TextBox textBox_Nivel_minim;
        private System.Windows.Forms.Label label_Nivel_minim;
        private System.Windows.Forms.TextBox textBox_CodBun;
        private System.Windows.Forms.Label label_Cod_bun;
        private System.Windows.Forms.TextBox textBox_Amenintare;
        private System.Windows.Forms.Label label_Amenintare;
    }
}