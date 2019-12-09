using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YMTool
{
    public partial class GFJSAddForm : Form
    {
        IAccessHelper accessHelper = null;
        GFJSForm form = null;
        int EditId = 0;
        public GFJSAddForm(GFJSForm f, int Id = 0)
        {
            InitializeComponent();
            form = f;
            accessHelper = new AccessHelper();
            ComboxUserListInitialize();
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
                    ZhanjieInput.Text = res.Rows[0]["ZHANJIE"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(res.Rows[0]["CREATETIME"].ToString());
                    GoldInput.Text = res.Rows[0]["GOLD"].ToString();
                    BreakInput.Text = res.Rows[0]["BREAK"].ToString();
                    checkBoxJiesuan.Checked = bool.Parse(res.Rows[0]["JIESUAN"].ToString());
                    comboBoxUserList.Text = res.Rows[0]["YM_USER_ID"].ToString();
                }
            }
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

        IList<ComboBoxItem> list = new List<ComboBoxItem>();
        private void comboBoxUserList_TextUpdate(object sender, EventArgs e)
        {
            comboBoxUserList.Items.Clear();
            if (string.IsNullOrWhiteSpace(comboBoxUserList.Text))
            {
                comboBoxUserList.Items.AddRange(list.ToArray());
                comboBoxUserList.DroppedDown = true;
            }
            else
            {
                var input = comboBoxUserList.Text;
                var newList = list.Where(x => x.Text.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) != -1).ToArray();
                comboBoxUserList.Items.AddRange(newList);
                comboBoxUserList.Select(comboBoxUserList.Text.Length, 0);
                comboBoxUserList.DroppedDown = true;
                //保持鼠标指针形状  
                Cursor = Cursors.Default;
            }
        }

        public void ComboxUserListInitialize()
        {
            var res = accessHelper.ExecuteDataTable("SELECT * FROM YM_USER;");
            for (int i = 0; i < res.Rows.Count; i++)
            {
                var item = res.Rows[i];
                //new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString())
                list.Add(new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString()));
                this.comboBoxUserList.Items.Add(new ComboBoxItem(string.Format("{0}({1},{2})", item["GameName"], item["GameJianPin"], item["GameQuanPin"]), item["ID"].ToString()));
            }
            this.comboBoxUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBoxUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            var zjvalue = ZhanjieInput.Text;
            var goldvalue = GoldInput.Text;
            if (string.IsNullOrWhiteSpace(zjvalue) || string.IsNullOrWhiteSpace(goldvalue))
            {
                MessageBox.Show("战阶、金不能为空！");
            }
            else
            {
                var check = checkBoxJiesuan.Checked;
                var comValue = this.comboBoxUserList.SelectedItem as ComboBoxItem;
                int res = 0;
                //编辑
                if (EditId != 0)
                {
                    res = accessHelper.ExecuteNonQuery(string.Format("UPDATE YM_DETAIL SET [ZHANJIE] = {0}, [CREATETIME] = '{1}', [YM_USER_ID] = {2}, [GOLD] = {3}, [BREAK] = '{4}', [JIESUAN] = {5} WHERE [ID] = {6};", zjvalue, dateTimePicker1.Value, comValue.Values, goldvalue, string.IsNullOrWhiteSpace(BreakInput.Text) ? "" : BreakInput.Text, check ? 1 : 0, EditId));
                }
                //新增
                else
                {
                    res = accessHelper.ExecuteNonQuery(String.Format("INSERT INTO YM_DETAIL ([ZHANJIE], [CREATETIME], [YM_USER_ID], [GOLD], [BREAK], [JIESUAN]) VALUES ({0}, '{1}', {2}, {3}, '{4}', {5});", zjvalue, dateTimePicker1.Value, comValue.Values, goldvalue, string.IsNullOrWhiteSpace(BreakInput.Text) ? "" : BreakInput.Text, check ? 1 : 0));
                }
                if (res > 0)
                {
                    MessageBox.Show("操作成功！");
                    form.SearchFunc();
                    Dispose();
                }
            }
        }

        private void ZhanjieInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
            {
                e.Handled = true;
            }
        }

        private void GoldInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
            {
                e.Handled = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
