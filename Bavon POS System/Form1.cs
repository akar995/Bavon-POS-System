using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace Bavon_POS_System
{
    public partial class POSForm : Form
    {
        string printRe="";
        public POSForm()
        {
            InitializeComponent();
        }
        List<Row> rows = new List<Row>();
        TextBox textBox = new TextBox();

        private void button1_Click(object sender, EventArgs e)
        {
            resetSales();

        }

        SqlConnection con = new SqlConnection(ConstValues.sqlStringCon);
        void retrieveItem()
        {


            con.Open();
            string searchValue = barcodeTextBox.Text;

            string cleanedString = Regex.Replace(searchValue, @"\t|\n|\r| ", "");
            string selectStatement = $"SELECT {ItemDatabaseConst.BARCODE} ,{ItemDatabaseConst.NAME}, {ItemDatabaseConst.SALEPRICE} , {ItemDatabaseConst.QUANTITY} FROM {ItemDatabaseConst.TABLE_NAME} WHERE {ItemDatabaseConst.BARCODE}='{cleanedString}'";
            SqlCommand com = new SqlCommand(selectStatement, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string bardcode = (string)reader[$"{ItemDatabaseConst.BARCODE}"];
                string name = (string)reader[$"{ItemDatabaseConst.NAME}"];
                string salePrice = (string)reader[$"{ItemDatabaseConst.SALEPRICE}"];
                string quantity = (string)reader[$"{ItemDatabaseConst.QUANTITY}"];
                dataGridView1.Rows.Add(bardcode, name, "1", salePrice, salePrice);

            }

            con.Close();



        }

   

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OnDataChangeGridView(object sender, EventArgs e)
        {
            int TotalPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                TotalPrice += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            TotalMoneyLabel.Text = TotalPrice.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            changeTotalLabelValue();
        }




        public void refreshTotalInDataGridView()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int qn = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int price = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                int totalPrice = qn * price;
                dataGridView1.Rows[i].Cells[4].Value = totalPrice;
                dataGridView1.Rows[i].Cells[2].Value = qn;

            }

        }
        public void changeTotalLabelValue()
        {

            int TotalPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    TotalPrice += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                }
                catch (Exception eee) { }
            }
            TotalMoneyLabel.Text = TotalPrice.ToString();
        }


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            changeTotalLabelValue();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshTotalInDataGridView();
            }

            catch { }
            changeTotalLabelValue();

        }

        private void reciveMoneyTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int reciveMoney = int.Parse(reciveMoneyTextBox.Text.ToString());
                int TotalMoney = int.Parse(TotalMoneyLabel.Text.ToString());
                if (reciveMoney >= TotalMoney)
                {
                    changeLabel.Text = (reciveMoney - TotalMoney).ToString();
                    saleButton.Enabled = true;

                }
                else
                {
                    saleButton.Enabled = false;
                }
            }
            catch
            {
                reciveMoneyTextBox.Clear();
            }
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            printRe = "";
            printRe = "      LILY Mart\n" +
                      "**********************\n" +
                      "Name   QTY      Price\n";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                try
                {
                    string barcode = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string quantity = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string price = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string totalPrice = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string tableQunatity = getQuantity(barcode);




                    string saleCode = time.TotalMilliseconds.ToString();
                    string saleDate = DateTime.Now.ToString();

                    int finalQunatity = int.Parse(tableQunatity) - int.Parse(quantity);
                    //username
                    string username = "botan";
                    printRe += $"{name}   {quantity}   {totalPrice}\n";
                    con.Open();
                    string updateStatment = $"UPDATE {ItemDatabaseConst.TABLE_NAME}  SET {ItemDatabaseConst.QUANTITY} = {finalQunatity}";
                    SqlCommand cmd = new SqlCommand(updateStatment, con);
                    cmd.ExecuteNonQuery();

                    string insertdata = $"insert into {SaleDatabaseConst.TABLE_NAME} ({SaleDatabaseConst.BARCODE},{SaleDatabaseConst.SALECODE},{SaleDatabaseConst.NAME},{SaleDatabaseConst.SALEPRICE},{SaleDatabaseConst.QUANTITY},{SaleDatabaseConst.TOTALSALEPRICE},{SaleDatabaseConst.USERNAME},{SaleDatabaseConst.DATE}) values('{barcode}', '{saleCode}', '{name}','{price}', '{quantity}', '{totalPrice}', '{username}', '{saleDate}'); ";

                    cmd.CommandText = insertdata;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            printRe += "=========================\n" +
                $"Total  {TotalMoneyLabel.Text}\n" +
                $"saleID {time.TotalMilliseconds.ToString()}";
            printReceipt();

            resetSales();

            successLabel.Text = "Successful Sale";
            successLabel.Visible = true;

        }

        string getQuantity(string barcodestring)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"SELECT {ItemDatabaseConst.QUANTITY} FROM {ItemDatabaseConst.TABLE_NAME} WHERE {ItemDatabaseConst.BARCODE}='{barcodestring}'", con);
            SqlDataReader reader = com.ExecuteReader();
            string quantity = "0";
            while (reader.Read())
            {
               
                quantity = (string)reader[$"{ItemDatabaseConst.QUANTITY}"];

            }
            con.Close();
            return quantity;
        }
    

        void printReceipt()
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.Print();
        }

        void resetSales() {
            dataGridView1.Rows.Clear();
            reciveMoneyTextBox.Clear();
            changeLabel.Text = "0";
            TotalMoneyLabel.Text = "0";
            saleButton.Enabled = false;
            barcodeTextBox.Clear();

    
        }

        private void barcodeEntryEvent(object sender, EventArgs e)
        {

            string text = barcodeTextBox.Text;
            successLabel.Text = "";
            successLabel.Visible = false;
            if (text.Contains("\n"))
            {
                string searchValue = barcodeTextBox.Text;

                string t = Regex.Replace(searchValue, @"\t|\n|\r| ", "");
                if (barcodeTextBox.TextLength < 3)
                {
                    barcodeTextBox.Clear();
                    return;
                }

                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        string datag = "";
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            datag = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        }
                        datag = Regex.Replace(datag, @"\t|\n|\r| ", "");
                        if (t.Equals(datag))
                        {
                            int qn = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            int price = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            qn++;
                            int totalPrice = qn * price;
                            dataGridView1.Rows[i].Cells[4].Value = totalPrice;
                            dataGridView1.Rows[i].Cells[2].Value = qn;
                            barcodeTextBox.Clear();
                            return;
                        }


                    }
                }
                dataGridView1.MultiSelect = false;
                retrieveItem();
                barcodeTextBox.Clear();

            }
        }

     

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(printRe, new Font("Robot", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnSaleForm sale = new ReturnSaleForm();
            sale.Show();
        }
    }
}
