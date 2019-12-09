namespace YMTool
{
    partial class Form2
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
            this.GFJSButton = new System.Windows.Forms.Button();
            this.CYGL = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.TJT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GFJSButton
            // 
            this.GFJSButton.Location = new System.Drawing.Point(12, 12);
            this.GFJSButton.Name = "GFJSButton";
            this.GFJSButton.Size = new System.Drawing.Size(92, 41);
            this.GFJSButton.TabIndex = 0;
            this.GFJSButton.Text = "攻防结算";
            this.GFJSButton.UseVisualStyleBackColor = true;
            this.GFJSButton.Click += new System.EventHandler(this.GFJSButton_Click);
            // 
            // CYGL
            // 
            this.CYGL.Location = new System.Drawing.Point(177, 12);
            this.CYGL.Name = "CYGL";
            this.CYGL.Size = new System.Drawing.Size(92, 41);
            this.CYGL.TabIndex = 1;
            this.CYGL.Text = "成员管理";
            this.CYGL.UseVisualStyleBackColor = true;
            this.CYGL.Click += new System.EventHandler(this.CYGL_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(194, 262);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // TJT
            // 
            this.TJT.Location = new System.Drawing.Point(12, 97);
            this.TJT.Name = "TJT";
            this.TJT.Size = new System.Drawing.Size(92, 41);
            this.TJT.TabIndex = 2;
            this.TJT.Text = "统计图";
            this.TJT.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 297);
            this.Controls.Add(this.TJT);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.CYGL);
            this.Controls.Add(this.GFJSButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GFJSButton;
        private System.Windows.Forms.Button CYGL;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button TJT;
    }
}