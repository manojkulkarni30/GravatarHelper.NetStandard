namespace GravatarHelper.NetStandard.WinForm
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
            this.gravatarimage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qrcodeimage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gravatarimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrcodeimage)).BeginInit();
            this.SuspendLayout();
            // 
            // gravatarimage
            // 
            this.gravatarimage.Location = new System.Drawing.Point(66, 83);
            this.gravatarimage.Name = "gravatarimage";
            this.gravatarimage.Size = new System.Drawing.Size(250, 250);
            this.gravatarimage.TabIndex = 0;
            this.gravatarimage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gravatar Image";
            // 
            // qrcodeimage
            // 
            this.qrcodeimage.Location = new System.Drawing.Point(353, 83);
            this.qrcodeimage.Name = "qrcodeimage";
            this.qrcodeimage.Size = new System.Drawing.Size(250, 250);
            this.qrcodeimage.TabIndex = 2;
            this.qrcodeimage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gravatar Profile QR Code Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qrcodeimage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gravatarimage);
            this.Name = "Form1";
            this.Text = "GravatarHelper.NetStandard";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gravatarimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrcodeimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gravatarimage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox qrcodeimage;
        private System.Windows.Forms.Label label2;
    }
}

