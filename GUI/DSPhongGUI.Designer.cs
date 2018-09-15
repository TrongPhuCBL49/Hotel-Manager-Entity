namespace GUI
{
    partial class DSPhongGUI
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
            this.fllDSPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fllDSPhong
            // 
            this.fllDSPhong.Location = new System.Drawing.Point(20, 151);
            this.fllDSPhong.Name = "fllDSPhong";
            this.fllDSPhong.Size = new System.Drawing.Size(2181, 940);
            this.fllDSPhong.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Image = global::GUI.Properties.Resources.house__1_;
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Appearance.Options.UseImage = true;
            this.labelControl1.Appearance.Options.UseImageAlign = true;
            this.labelControl1.Location = new System.Drawing.Point(305, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(277, 34);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "              Phòng trống";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Image = global::GUI.Properties.Resources.home__1_;
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.Appearance.Options.UseImage = true;
            this.labelControl2.Appearance.Options.UseImageAlign = true;
            this.labelControl2.Location = new System.Drawing.Point(701, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(292, 34);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "              Phòng đã đặt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chú thích:";
            // 
            // DSPhongGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fllDSPhong);
            this.Name = "DSPhongGUI";
            this.Size = new System.Drawing.Size(2216, 1116);
            this.Load += new System.EventHandler(this.DSPhongGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fllDSPhong;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label1;
    }
}
