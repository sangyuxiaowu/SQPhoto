namespace TestSQPhoto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqPhoto1 = new SQPhoto.SQPhoto();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sqPhoto1
            // 
            this.sqPhoto1.AutoReSize = true;
            this.sqPhoto1.BackColor = System.Drawing.SystemColors.Control;
            this.sqPhoto1.CanMove = true;
            this.sqPhoto1.CanReSize = true;
            this.sqPhoto1.CanZoom = true;
            this.sqPhoto1.Image = global::TestSQPhoto.Properties.Resources.rev;
            this.sqPhoto1.Location = new System.Drawing.Point(13, 24);
            this.sqPhoto1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sqPhoto1.Name = "sqPhoto1";
            this.sqPhoto1.Size = new System.Drawing.Size(288, 246);
            this.sqPhoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sqPhoto1.TabIndex = 0;
            this.sqPhoto1.ZoomCenter = true;
            this.sqPhoto1.ZoomMin = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "放大";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(536, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "缩小";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(699, 397);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sqPhoto1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SQPhoto.SQPhoto sqPhoto1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}