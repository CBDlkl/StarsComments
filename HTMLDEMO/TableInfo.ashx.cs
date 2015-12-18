using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace HTMLDEMO
{
    /// <summary>
    /// TableInfo 的摘要说明
    /// </summary>
    public class TableInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StringBuilder strhtml = new StringBuilder();
            DataTable dt = CreatTable(); //配置数据源

            strhtml.Append("<table border='1'>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //行内内容
                strhtml.Append(string.Format("<tr style='width: 180px;'><td><label>{0}</label><label>{1}</label><label>{2}</label>", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2]));
                strhtml.Append(string.Format("<input type='button' value='点评' onclick=\"func('{0}');\" /><div id='div_{0}' class='div_' style='display: none; border: 10px;'>", dt.Rows[i][0]));
                //下拉框内的内容
                strhtml.Append(string.Format("<div id='div_Stars_{0}'></div><br />浮动下拉框<br />浮动下拉框<br />浮动下拉框<br />", i));
                strhtml.Append(string.Format("<input type='button' value='提交' onclick=\"func_hide('{0}')\" /></div></td></tr>", i));
            }
            strhtml.Append("</table>");
            context.Response.Write(strhtml.ToString());
        }

        /// <summary>
        /// 虚拟 DataTable内容
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatTable()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("First", typeof(string));
            datatable.Columns.Add("Second", typeof(string));
            datatable.Columns.Add("Thread", typeof(string));

            for (int i = 0; i < 10; i++)
            {
                DataRow row = datatable.NewRow();
                row["First"] = i;
                row["Second"] = "  222sfasdfwaefafasfsdafasd  ";
                row["Thread"] = "  3222221113  ";
                datatable.Rows.Add(row);
            }
            return datatable;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}