using System;
using System.Windows.Forms;

namespace YMTool
{
    public partial class CYGLAddForm : Form
    {
        IAccessHelper accessHelper = null;
        CYGLForm form = null;
        int EditId = 0;
        public CYGLAddForm(CYGLForm f, int Id = 0)
        {
            InitializeComponent();
            accessHelper = new AccessHelper();
            form = f;
            EditId = Id;
            Edit();
            this.MaximizeBox = false;
        }

        public void Edit()
        {
            if (EditId != 0)
            {
                var res = accessHelper.ExecuteDataTable(string.Format("SELECT * FROM YM_USER WHERE [ID] = {0};", EditId));
                if (res.Rows.Count > 0)
                {
                    QQNumber.Text = res.Rows[0]["QQNUMBER"].ToString();
                    GameUserName.Text = res.Rows[0]["GAMENAME"].ToString();
                    Break.Text = res.Rows[0]["BREAK"].ToString();
                }
            }
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.QQNumber.Text) || string.IsNullOrWhiteSpace(this.GameUserName.Text))
            {
                MessageBox.Show("游戏昵称、QQ号不能为空！");
            }
            else if (long.TryParse(QQNumber.Text, out long num) == false)
            {
                MessageBox.Show("QQ号只能为数字！");
            }
            else if (QQNumber.Text.Length < 5 || QQNumber.Text.Length > 10)
            {
                MessageBox.Show("QQ号位数为5-10位！");
            }
            else
            {
                string gameusernameshortpinyin = PYHelper.GetShortPY(GameUserName.Text);
                string gameusernamepinyin = PYHelper.GetPY(GameUserName.Text);
                int res = 0;
                //编辑
                if (EditId != 0)
                {
                    res = accessHelper.ExecuteNonQuery(string.Format("UPDATE YM_USER SET [GAMENAME] = '{0}', [QQNUMBER] = '{1}', [BREAK] = '{2}', [GAMEJIANPIN] = '{3}', [GAMEQUANPIN] = '{4}' WHERE [ID] = {5};", GameUserName.Text, QQNumber.Text, string.IsNullOrWhiteSpace(Break.Text) ? "" : Break.Text, gameusernameshortpinyin, gameusernamepinyin, EditId));
                }
                else
                {
                    res = accessHelper.ExecuteNonQuery(string.Format("INSERT INTO YM_USER ([GAMENAME], [QQNUMBER], [BREAK], [GAMEJIANPIN], [GAMEQUANPIN]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", GameUserName.Text, QQNumber.Text, string.IsNullOrWhiteSpace(Break.Text) ? "" : Break.Text, gameusernameshortpinyin, gameusernamepinyin));
                }
                if (res > 0)
                {
                    MessageBox.Show("操作成功！");
                    form.SearchFunc();
                    Dispose();
                }
            }
        }

        private void QQNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
            {
                e.Handled = true;
            }
        }
    }
}
