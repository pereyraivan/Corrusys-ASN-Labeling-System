namespace Corrusys_ASN_Labeling_System.Formularios
{
    partial class frmGrillaASN
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
            this.btnNuevoASN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvASN = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvASN)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevoASN
            // 
            this.btnNuevoASN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoASN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(15)))));
            this.btnNuevoASN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoASN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNuevoASN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoASN.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoASN.ForeColor = System.Drawing.Color.White;
            this.btnNuevoASN.Location = new System.Drawing.Point(706, 582);
            this.btnNuevoASN.Name = "btnNuevoASN";
            this.btnNuevoASN.Size = new System.Drawing.Size(213, 33);
            this.btnNuevoASN.TabIndex = 29;
            this.btnNuevoASN.Text = "Crear nuevo";
            this.btnNuevoASN.UseVisualStyleBackColor = false;
            this.btnNuevoASN.Click += new System.EventHandler(this.btnNuevoASN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 26);
            this.label4.TabIndex = 28;
            this.label4.Tag = "";
            this.label4.Text = "ASN´s Enviados";
            // 
            // dgvASN
            // 
            this.dgvASN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvASN.BackgroundColor = System.Drawing.Color.White;
            this.dgvASN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvASN.Location = new System.Drawing.Point(19, 71);
            this.dgvASN.Name = "dgvASN";
            this.dgvASN.Size = new System.Drawing.Size(900, 491);
            this.dgvASN.TabIndex = 27;
            // 
            // frmGrillaASN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 637);
            this.Controls.Add(this.btnNuevoASN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvASN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGrillaASN";
            this.Text = "frmGrillaASN";
            this.Load += new System.EventHandler(this.frmGrillaASN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvASN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoASN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvASN;
    }
}