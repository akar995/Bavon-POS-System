using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bavon_POS_System
{
    public partial class DailySale : Form
    {
        public DailySale()
        {
            InitializeComponent();



        }

        private void DailySale_Load(object sender, EventArgs e)
        {


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            totalLabel.Text = "0";
            string startDate = startDatePicker.Value.ToString("MM/dd/yyyy");
            string toDate = toDatePicker.Value.ToString("MM/dd/yyyy");
            string selectAll = $"select * from {SaleDatabaseConst.TABLE_NAME} where {SaleDatabaseConst.DATE} BETWEEN '{startDate}' AND '{toDate}'";
            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand(selectAll, connection))
            {
                using (SqlDataReader selectReader = selectCommand.ExecuteReader())
                {
                    while (selectReader.Read())
                    {
                        string ID = (selectReader[$"{SaleDatabaseConst.ID}"]).ToString();
                        string bardcode = (string)selectReader[$"{SaleDatabaseConst.BARCODE}"];
                        string itemName = (string)selectReader[$"{SaleDatabaseConst.NAME}"];
                        string saleCode = (string)selectReader[$"{SaleDatabaseConst.SALECODE}"];
                        string quantity = (string)selectReader[$"{SaleDatabaseConst.QUANTITY}"];
                        string salePrice = (string)selectReader[$"{SaleDatabaseConst.SALEPRICE}"];
                        string totalPrice = (string)selectReader[$"{SaleDatabaseConst.TOTALSALEPRICE}"];
                        string date = (selectReader[$"{SaleDatabaseConst.DATE}"]).ToString();
                        string username = (string)selectReader[$"{SaleDatabaseConst.USERNAME}"];
                        dataGridView1.Rows.Add(ID, bardcode, itemName, saleCode, quantity, salePrice, totalPrice, date, username);
                    }
                };


            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string toDay = DateTime.Now.ToString("MM/dd/yyyy");
            string selectSat = $"SELECT COUNT(*) FROM {cashDatabaseConst.TABLE_NAME} where {cashDatabaseConst.DATE}='{toDay}'";
            int count = 0;

            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            connection.Open();

            using (SqlCommand cmdCount = new SqlCommand(selectSat, connection))
            {

                count = (int)cmdCount.ExecuteScalar();
            }


            if (count > 0)
            {
                string cashBox = "";
                string selectCash = $"select {cashDatabaseConst.DATE},{cashDatabaseConst.CASHBOX} from {cashDatabaseConst.TABLE_NAME} where {cashDatabaseConst.DATE}='{toDay}'";
                SqlCommand selectCashCom = new SqlCommand(selectCash, connection);
                using (SqlDataReader readerSelect = selectCashCom.ExecuteReader())
                {
                    while (readerSelect.Read())
                    {
                        cashBox = (string)readerSelect[$"{cashDatabaseConst.CASHBOX}"];
                        break;
                    }
                };
                PublicValues.CASHBOX = cashBox;
                cashboxLabel.Text = PublicValues.CASHBOX;

            }
            else
            {
                cashBoxInputBox inputBox = new cashBoxInputBox();
                inputBox.Show();

            }


        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double finalTotal = 0.0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (!dataGridView1.Rows[i].Cells[6].Value.ToString().Equals(""))
                    {
                        double tempTotal = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                        finalTotal += tempTotal;

                    }

                }

                finalTotal += Double.Parse(PublicValues.CASHBOX);
                totalLabel.Text = finalTotal + "";
            }
            catch { }
        }
    }
}
