using System;
using System.Windows.Forms;

namespace YMTool
{
    public partial class Form2 : Form
    {
        Form form = null;
        public Form2(Form f)
        {
            InitializeComponent();
            form = f;
            this.MaximizeBox = false;
        }
        public bool JudgeLogin()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(CurrentUser.UserName) || CurrentUser.LoginTime == DateTime.MinValue)
            {
                MessageBox.Show("请先登录！");
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Dispose();
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        private void GFJSButton_Click(object sender, EventArgs e)
        {
            if (JudgeLogin())
            {
                Hide();
                new GFJSForm(this).ShowDialog();
            }
        }

        private void CYGL_Click(object sender, EventArgs e)
        {
            if (JudgeLogin())
            {
                Hide();
                new CYGLForm(this).ShowDialog();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            form.Dispose();
        }
    }
}
