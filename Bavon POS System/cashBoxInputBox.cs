using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bavon_POS_System
{
    public partial class cashBoxInputBox : Form
    {
        public cashBoxInputBox()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string ToDay=DateTime.Now.ToString("MM/dd/yyyy");
            string cash = cashTextBox.Text;
            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            string insertStat = $"insert into {cashDatabaseConst.TABLE_NAME} ({cashDatabaseConst.CASHBOX},{cashDatabaseConst.DATE},{cashDatabaseConst.USERNAME}) values('{cash}','{ToDay}','{PublicValues.USERNAME}');";
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(insertStat, connection))
            {
                sqlCommand.ExecuteNonQuery();
            };
            connection.Close();
            PublicValues.CASHBOX = cash;
            this.Close();

        }
    }
}
