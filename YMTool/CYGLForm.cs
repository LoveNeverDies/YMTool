using System;
using System.Data;
using System.Windows.Forms;

namespace YMTool
{
    public partial class CYGLForm : Form
    {
        IAccessHelper accessHelper = null;
        Form2 form = null;
        public CYGLForm(Form2 f)
        {
            InitializeComponent();
            accessHelper = new AccessHelper();
            form = f;
            this.MaximizeBox = false;
        }

        public void ListViewInitialize()
        {
            this.listView1.Clear();
            //列表头创建（记得，需要先创建列表头）    
            this.listView1.Columns.Add("序号", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("QQ号", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("游戏昵称", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("备注", 120, HorizontalAlignment.Left);
        }

        /// <summary>
        /// 添加数据项
        /// </summary>
        /// <param name="data"></param>
        public void UpdateListView(DataTable data)
        {
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var item = data.Rows[i];
                //第一列
                ListViewItem list = new ListViewItem()
                {
                    Text = (i + 1).ToString()
                };
                //第二列
                list.SubItems.Add(item["QQNumber"].ToString());
                //第三列
                list.SubItems.Add(item["GameName"].ToString());
                //第四列
                list.SubItems.Add(item["Break"].ToString());
                //隐藏的列
                list.SubItems.Add(item["ID"].ToString());
                this.listView1.Items.Add(list);
            }
            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }

        private void Add_Click(object sender, EventArgs e)
        {
            new CYGLAddForm(this).ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SearchFunc();
        }

        public void SearchFunc()
        {
            ListViewInitialize();
            var res = accessHelper.ExecuteDataTable(string.Format("SELECT * FROM YM_USER WHERE GAMENAME LIKE '%{0}%' OR GAMEJIANPIN LIKE '%{0}%' OR GAMEQUANPIN LIKE '%{0}%';", SearchInput.Text));
            UpdateListView(res);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var selectListView = this.listView1.SelectedItems;
            if (selectListView.Count == 0)
            {
                MessageBox.Show(this, "请先选择一项！");
            }
            else
            {
                try
                {
                    if (MessageBox.Show(this, string.Format("是否要删除游戏昵称为【{0}】的这条数据？", selectListView[0].SubItems[selectListView[0].SubItems.Count - 3].Text), "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    var id = selectListView[0].SubItems[selectListView[0].SubItems.Count - 1].Text;
                    var res = accessHelper.ExecuteNonQuery(string.Format("DELETE FROM YM_USER WHERE [ID] = {0};", id));
                    if (res > 0)
                    {
                        SearchFunc();
                        //success
                    }
                }
                catch (Exception ex)
                {
                    Helper.ExMessage(ex);
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                new CYGLAddForm(this, int.Parse(listView1.SelectedItems[0].SubItems[listView1.SelectedItems[0].SubItems.Count - 1].Text)).ShowDialog();
            }
        }

        private void CYGLForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
    }
}
