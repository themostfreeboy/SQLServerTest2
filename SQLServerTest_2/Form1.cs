using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//数据库处理使用(SqlConnection)

namespace SQLServerTest_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            #region SQL Server 2008数据库处理
            string connectionString = @"server=JXL-PC\SQLEXPRESS;database=user;Trusted_Connection=Yes";//数据库连接字符串(Windows身份验证)
            SqlConnection myConnection = new SqlConnection(connectionString);//创建数据库连接对象
            try
            {
                myConnection.Open();//连接数据库
            }
            catch (SqlException ex)//异常处理
            {
                //throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
            string sql = string.Format("select * from userinfo");//查询sql语句
            SqlDataAdapter adapter = new SqlDataAdapter(sql, myConnection);//创建适配器对象
            DataSet ds = new DataSet();//创建数据集对象
            try
            {
                adapter.Fill(ds);//填充数据集
            }
            catch(SqlException ex)//异常处理
            {
                //throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
            try
            {
                this.dataGridView1.DataSource = ds.Tables[0];//将搜索出的内容加载到DataGridView中
            }
            catch(IndexOutOfRangeException ex)//异常处理
            {
                //throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
            myConnection.Close();//断开数据库
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“ds.userinfo”中。您可以根据需要移动或删除它。
            this.userinfoTableAdapter.Fill(this.ds.userinfo);

        }
    }
}
