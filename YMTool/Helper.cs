using System;
using System.Windows.Forms;

namespace YMTool
{
    public static class Helper
    {
        public static void ExMessage(Exception ex)
        {
            MessageBox.Show(string.Format(@"程序出错，请将出错截图发给开发人员！
出错地址：{0}
错误原因：{1}"
            , ex.StackTrace, ex.Message));
        }
    }
}
