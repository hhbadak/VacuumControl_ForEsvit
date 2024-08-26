namespace vacuumControl
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
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.tb_status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_number = new System.Windows.Forms.Label();
            this.dgv_controlList = new System.Windows.Forms.DataGridView();
            this.cb_fire = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_controlList)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_barcode
            // 
            this.tb_barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_barcode.Location = new System.Drawing.Point(28, 72);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(271, 47);
            this.tb_barcode.TabIndex = 0;
            this.tb_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_barcode_KeyDown);
            // 
            // tb_status
            // 
            this.tb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_status.Location = new System.Drawing.Point(336, 72);
            this.tb_status.Name = "tb_status";
            this.tb_status.Size = new System.Drawing.Size(284, 47);
            this.tb_status.TabIndex = 1;
            this.tb_status.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_status_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barkod Numarası";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(333, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kontrol Sonrası";
            // 
            // lbl_number
            // 
            this.lbl_number.AutoSize = true;
            this.lbl_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_number.Location = new System.Drawing.Point(667, 63);
            this.lbl_number.Name = "lbl_number";
            this.lbl_number.Size = new System.Drawing.Size(38, 55);
            this.lbl_number.TabIndex = 4;
            this.lbl_number.Text = ".";
            // 
            // dgv_controlList
            // 
            this.dgv_controlList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_controlList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_controlList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_controlList.Location = new System.Drawing.Point(1, 185);
            this.dgv_controlList.Name = "dgv_controlList";
            this.dgv_controlList.Size = new System.Drawing.Size(1279, 557);
            this.dgv_controlList.TabIndex = 6;
            // 
            // cb_fire
            // 
            this.cb_fire.AutoSize = true;
            this.cb_fire.Location = new System.Drawing.Point(30, 151);
            this.cb_fire.Name = "cb_fire";
            this.cb_fire.Size = new System.Drawing.Size(72, 17);
            this.cb_fire.TabIndex = 7;
            this.cb_fire.Text = "ISKARTA";
            this.cb_fire.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 754);
            this.Controls.Add(this.cb_fire);
            this.Controls.Add(this.dgv_controlList);
            this.Controls.Add(this.lbl_number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_status);
            this.Controls.Add(this.tb_barcode);
            this.Name = "Form1";
            this.Text = "Vakum Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_controlList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.TextBox tb_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_number;
        private System.Windows.Forms.DataGridView dgv_controlList;
        private System.Windows.Forms.CheckBox cb_fire;
    }
}

