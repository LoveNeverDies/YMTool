namespace YMTool
{
    partial class GFJSAddForm
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
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ZhanjieInput = new System.Windows.Forms.TextBox();
            this.BreakInput = new System.Windows.Forms.TextBox();
            this.GoldInput = new System.Windows.Forms.TextBox();
            this.checkBoxJiesuan = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxUserList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(93, 379);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(218, 379);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ZhanjieInput
            // 
            this.ZhanjieInput.Location = new System.Drawing.Point(93, 52);
            this.ZhanjieInput.Name = "ZhanjieInput";
            this.ZhanjieInput.Size = new System.Drawing.Size(200, 21);
            this.ZhanjieInput.TabIndex = 2;
            this.ZhanjieInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZhanjieInput_KeyPress);
            // 
            // BreakInput
            // 
            this.BreakInput.Location = new System.Drawing.Point(93, 184);
            this.BreakInput.Multiline = true;
            this.BreakInput.Name = "BreakInput";
            this.BreakInput.Size = new System.Drawing.Size(200, 143);
            this.BreakInput.TabIndex = 5;
            // 
            // GoldInput
            // 
            this.GoldInput.Location = new System.Drawing.Point(93, 140);
            this.GoldInput.Name = "GoldInput";
            this.GoldInput.Size = new System.Drawing.Size(200, 21);
            this.GoldInput.TabIndex = 4;
            this.GoldInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GoldInput_KeyPress);
            // 
            // checkBoxJiesuan
            // 
            this.checkBoxJiesuan.AutoSize = true;
            this.checkBoxJiesuan.Location = new System.Drawing.Point(209, 349);
            this.checkBoxJiesuan.Name = "checkBoxJiesuan";
            this.checkBoxJiesuan.Size = new System.Drawing.Size(84, 16);
            this.checkBoxJiesuan.TabIndex = 6;
            this.checkBoxJiesuan.Text = "是否已结算";
            this.checkBoxJiesuan.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(93, 96);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "战阶：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "应给金：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "备注：";
            // 
            // comboBoxUserList
            // 
            this.comboBoxUserList.FormattingEnabled = true;
            this.comboBoxUserList.Location = new System.Drawing.Point(93, 12);
            this.comboBoxUserList.Name = "comboBoxUserList";
            this.comboBoxUserList.Size = new System.Drawing.Size(200, 20);
            this.comboBoxUserList.TabIndex = 12;
            this.comboBoxUserList.TextUpdate += new System.EventHandler(this.comboBoxUserList_TextUpdate);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "成员：";
            // 
            // GFJSAddForm
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(324, 417);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxUserList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBoxJiesuan);
            this.Controls.Add(this.BreakInput);
            this.Controls.Add(this.GoldInput);
            this.Controls.Add(this.ZhanjieInput);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GFJSAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GFJSAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox ZhanjieInput;
        private System.Windows.Forms.TextBox BreakInput;
        private System.Windows.Forms.TextBox GoldInput;
        private System.Windows.Forms.CheckBox checkBoxJiesuan;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxUserList;
        private System.Windows.Forms.Label label5;
    }
}