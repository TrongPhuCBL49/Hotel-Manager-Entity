namespace GUI
{
    partial class DoiMatKhauGUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPassMoi = new DevExpress.XtraEditors.TextEdit();
            this.txtPassCu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtXacNhanPass = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassCu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Location = new System.Drawing.Point(460, 262);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.Size = new System.Drawing.Size(368, 42);
            this.txtPassMoi.TabIndex = 2;
            // 
            // txtPassCu
            // 
            this.txtPassCu.Location = new System.Drawing.Point(460, 170);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(368, 42);
            this.txtPassCu.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(128, 266);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(190, 34);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu mới: ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(128, 174);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(164, 34);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Mật khẩu cũ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(128, 362);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(317, 34);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Xác nhận mật khẩu mới: ";
            // 
            // txtXacNhanPass
            // 
            this.txtXacNhanPass.Location = new System.Drawing.Point(460, 354);
            this.txtXacNhanPass.Name = "txtXacNhanPass";
            this.txtXacNhanPass.Size = new System.Drawing.Size(368, 42);
            this.txtXacNhanPass.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtXacNhanPass);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtPassMoi);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtPassCu);
            this.panelControl2.Location = new System.Drawing.Point(46, 46);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1004, 553);
            this.panelControl2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 48);
            this.label1.TabIndex = 6;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(460, 444);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(200, 56);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DoiMatKhauGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "DoiMatKhauGUI";
            this.Size = new System.Drawing.Size(1103, 655);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassCu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPassMoi;
        private DevExpress.XtraEditors.TextEdit txtPassCu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtXacNhanPass;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
