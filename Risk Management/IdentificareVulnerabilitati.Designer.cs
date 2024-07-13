namespace Risk_Management
{
    partial class IdentificareVulnerabilitati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentificareVulnerabilitati));
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Insert = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.panel_button = new System.Windows.Forms.Panel();
            this.textBox_Bun = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Nomenclator = new System.Windows.Forms.ComboBox();
            this.textBox_Vulnerabilitate = new System.Windows.Forms.TextBox();
            this.comboBox_Nivel = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "Vulnerabilitati:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(746, 248);
            this.dataGridView1.TabIndex = 21;
            // 
            // Insert
            // 
            this.Insert.BackColor = System.Drawing.Color.Black;
            this.Insert.ForeColor = System.Drawing.Color.White;
            this.Insert.Image = ((System.Drawing.Image)(resources.GetObject("Insert.Image")));
            this.Insert.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Insert.Location = new System.Drawing.Point(53, 25);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(68, 58);
            this.Insert.TabIndex = 4;
            this.Insert.Text = "Insert";
            this.Insert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Insert.UseVisualStyleBackColor = false;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Black;
            this.Export.ForeColor = System.Drawing.Color.White;
            this.Export.Image = ((System.Drawing.Image)(resources.GetObject("Export.Image")));
            this.Export.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Export.Location = new System.Drawing.Point(349, 25);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(68, 58);
            this.Export.TabIndex = 3;
            this.Export.Text = "Export";
            this.Export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.Black;
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Edit.Location = new System.Drawing.Point(275, 25);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(68, 58);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "Edit";
            this.Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Edit.UseVisualStyleBackColor = false;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Black;
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Delete.Location = new System.Drawing.Point(201, 25);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(68, 58);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Delete";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Black;
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Save.Location = new System.Drawing.Point(127, 25);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(68, 58);
            this.Save.TabIndex = 0;
            this.Save.Text = "Update";
            this.Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Update_Click);
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.Insert);
            this.panel_button.Controls.Add(this.Export);
            this.panel_button.Controls.Add(this.Edit);
            this.panel_button.Controls.Add(this.Delete);
            this.panel_button.Controls.Add(this.Save);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_button.Location = new System.Drawing.Point(0, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(770, 105);
            this.panel_button.TabIndex = 20;
            // 
            // textBox_Bun
            // 
            this.textBox_Bun.Location = new System.Drawing.Point(406, 202);
            this.textBox_Bun.Name = "textBox_Bun";
            this.textBox_Bun.Size = new System.Drawing.Size(121, 22);
            this.textBox_Bun.TabIndex = 51;
            this.textBox_Bun.TextChanged += new System.EventHandler(this.textBox_Bun_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(359, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 50;
            this.label5.Text = "Bun:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(359, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "Nivel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Vulnerabilitate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nomenclator vulnerabilitati:";
            // 
            // comboBox_Nomenclator
            // 
            this.comboBox_Nomenclator.Location = new System.Drawing.Point(210, 165);
            this.comboBox_Nomenclator.Name = "comboBox_Nomenclator";
            this.comboBox_Nomenclator.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Nomenclator.TabIndex = 46;
            this.comboBox_Nomenclator.SelectedIndexChanged += new System.EventHandler(this.comboBox_Nomenclator_SelectedIndexChanged);
            // 
            // textBox_Vulnerabilitate
            // 
            this.textBox_Vulnerabilitate.Location = new System.Drawing.Point(137, 199);
            this.textBox_Vulnerabilitate.Name = "textBox_Vulnerabilitate";
            this.textBox_Vulnerabilitate.Size = new System.Drawing.Size(194, 22);
            this.textBox_Vulnerabilitate.TabIndex = 44;
            this.textBox_Vulnerabilitate.TextChanged += new System.EventHandler(this.textBox_Vulnerabilitate_TextChanged);
            // 
            // comboBox_Nivel
            // 
            this.comboBox_Nivel.AutoCompleteCustomSource.AddRange(new string[] {
            "Mic",
            "Mare"});
            this.comboBox_Nivel.Items.AddRange(new object[] {
            "Mic",
            "Mare",
            "Mediu"});
            this.comboBox_Nivel.Location = new System.Drawing.Point(406, 162);
            this.comboBox_Nivel.Name = "comboBox_Nivel";
            this.comboBox_Nivel.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Nivel.TabIndex = 54;
            this.comboBox_Nivel.SelectedIndexChanged += new System.EventHandler(this.comboBox_Nivel_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Location = new System.Drawing.Point(-32, 117);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(834, 1);
            this.panel7.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(-11, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 1);
            this.panel1.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 605);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "Identificare Vulnerabilitati";
            // 
            // IdentificareVulnerabilitati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(770, 653);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox_Nivel);
            this.Controls.Add(this.textBox_Bun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Nomenclator);
            this.Controls.Add(this.textBox_Vulnerabilitate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel_button);
            this.Name = "IdentificareVulnerabilitati";
            this.Text = "Identificare_amenintari";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.TextBox textBox_Bun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Nomenclator;
        private System.Windows.Forms.TextBox textBox_Vulnerabilitate;
        private System.Windows.Forms.ComboBox comboBox_Nivel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}