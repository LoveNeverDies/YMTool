using System;
using System.Windows.Forms;

namespace YMTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AccountInput.Select();
            PasswordInput.PasswordChar = '*';
            this.MaximizeBox = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountInput.Text) || string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                MessageBox.Show("帐号或密码不能为空");
            }
            else
            {
                bool flag = false;
                if (AccountInput.Text == "admin" && PasswordInput.Text == "admin")
                {
                    flag = true;
                }
                else
                {
                    flag = true;
                }

                if (flag)
                {
                    CurrentUser.UserName = AccountInput.Text;
                    CurrentUser.LoginTime = DateTime.Now;
                    Hide();
                    new Form2(this).ShowDialog();
                }
                else
                {

                }
            }
        }
    }
}
