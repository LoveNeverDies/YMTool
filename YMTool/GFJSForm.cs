using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YMTool
{
    public partial class GFJSForm : Form
    {
        Form form = null;
        IAccessHelper accessHelper = null;
        public GFJSForm(Form f)
        {
            InitializeComponent();
            form = f;
            accessHelper = new AccessHelper();
            ComboxUserListInitialize();
            this.MaximizeBox = false;
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Values { get; set; }
            public ComboBoxItem(string _Text, string _Values)
            {
                Text = _Text;
                Values = _Values;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        IList<ComboBoxItem> listComBox = new List<ComboBoxItem>();
        public void ComboxUserListInitialize()
        {
            var res = accessHelper.ExecuteDataTable("SELECT * FROM YM_USER;");
            for (int i = 0; i < res.Rows.Count; i++)
            {
                var item = res.Rows[i];
                //new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString())
                listComBox.Add(new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString()));
                this.comboBoxUserList.Items.Add(new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString()));
            }
            this.comboBoxUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBoxUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public void ListViewDetailInitialize()
        {
            this.listViewDetails.Clear();
            //列表头创建（记得，需要先创建列表头）    
            this.listViewDetails.Columns.Add("序号", 50, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("成员", 120, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("战阶", 100, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("时间", 120, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("金", 100, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("是否结算", 90, HorizontalAlignment.Left);
            this.listViewDetails.Columns.Add("备注", 100, HorizontalAlignment.Left);
        }

        public void UpdateListViewDetail(DataTable data)
        {
            this.listViewDetails.View = View.Details;
            this.listViewDetails.FullRowSelect = true;
            this.listViewDetails.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var item = data.Rows[i];
                //第一列
                ListViewItem list = new ListViewItem()
                {
                    Text = (i + 1).ToString()
                };
                //第二列
                list.SubItems.Add(item["Zhanjie"].ToString());
                list.SubItems.Add(listComBox.FirstOrDefault(p => p.Values == item["YM_USER_ID"].ToString()).Text);
                list.SubItems.Add(item["CreateTime"].ToString());
                list.SubItems.Add(item["Gold"].ToString());
                list.SubItems.Add(item["Break"].ToString());
                list.SubItems.Add(item["Jiesuan"].ToString());
                //隐藏的列
                list.SubItems.Add(item["ID"].ToString());
                this.listViewDetails.Items.Add(list);
            }
            this.listViewDetails.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }
        private void Search_Click(object sender, EventArgs e)
        {
            SearchFunc();
        }
        public void SearchFunc()
        {
            ListViewDetailInitialize();
            StringBuilder sb = new StringBuilder("SELECT * FROM YM_DETAIL WHERE 1 = 1");
            var comValue = this.comboBoxUserList.SelectedItem as ComboBoxItem;
            if (comValue != null && string.IsNullOrWhiteSpace(comValue.Values) == false)
            {
                sb.AppendFormat(" AND YM_USER_ID = {0}", comValue.Values);
            }
            if (this.dateTimePickerStart.Checked)
            {
                sb.AppendFormat(" AND CREATETIME <= '{0}'", this.dateTimePickerStart.Value);
            }
            if (this.dateTimePickerEnd.Checked)
            {
                sb.AppendFormat(" AND CREATETIME >= '{0}'", this.dateTimePickerEnd.Value);
            }
            sb.Append(";");
            DataTable res = accessHelper.ExecuteDataTable(sb.ToString());
            UpdateListViewDetail(res);
        }

        private void comboBoxUserList_TextUpdate(object sender, EventArgs e)
        {
            comboBoxUserList.Items.Clear();
            if (string.IsNullOrWhiteSpace(comboBoxUserList.Text))
            {
                comboBoxUserList.Items.AddRange(listComBox.ToArray());
                comboBoxUserList.DroppedDown = true;
            }
            else
            {
                var input = comboBoxUserList.Text;
                var newList = listComBox.Where(x => x.Text.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) != -1).ToArray();
                comboBoxUserList.Items.AddRange(newList);
                comboBoxUserList.Select(comboBoxUserList.Text.Length, 0);
                comboBoxUserList.DroppedDown = true;
                //保持鼠标指针形状  
                Cursor = Cursors.Default;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            new GFJSAddForm(this).ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var selectListView = this.listViewDetails.SelectedItems;
            if (selectListView.Count == 0)
            {
                MessageBox.Show(this, "请先选择一项！");
            }
            else
            {
                try
                {
                    if (MessageBox.Show(this, string.Format("是否要删除游戏昵称为【{0}】的这项数据？", selectListView[0].SubItems[selectListView[0].SubItems.Count - 3].Text), "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    var id = selectListView[0].SubItems[selectListView[0].SubItems.Count - 1].Text;
                    var res = accessHelper.ExecuteNonQuery(string.Format("DELETE FROM YM_DETAIL WHERE [ID] = {0};", id));
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

        private void GFJSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void listViewDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listViewDetails.SelectedItems.Count > 0)
            {
                new GFJSAddForm(this, int.Parse(listViewDetails.SelectedItems[0].SubItems[listViewDetails.SelectedItems[0].SubItems.Count - 1].Text)).ShowDialog();
            }
        }
    }
}
