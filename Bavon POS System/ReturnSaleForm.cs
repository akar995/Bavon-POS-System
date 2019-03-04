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

namespace Bavon_POS_System
{
    public partial class ReturnSaleForm : Form
    {
        public ReturnSaleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count-1>-1)
            {
                return;
            }
            string salecode = saleCodeTextBox.Text;
            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            string selectStatment = $"select {SaleDatabaseConst.BARCODE},{SaleDatabaseConst.NAME},{SaleDatabaseConst.QUANTITY},{SaleDatabaseConst.SALEPRICE} from {SaleDatabaseConst.TABLE_NAME } where {SaleDatabaseConst.SALECODE}= '{salecode}'";
            SqlCommand selectCommand = new SqlCommand(selectStatment, connection);
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                string bardcode = (string)reader[$"{SaleDatabaseConst.BARCODE}"];
                string name = (string)reader[$"{SaleDatabaseConst.NAME}"];
                string salePrice = (string)reader[$"{SaleDatabaseConst.SALEPRICE}"];
                string quantity = (string)reader[$"{SaleDatabaseConst.QUANTITY}"];
                int totalPrice = int.Parse(quantity) * int.Parse(salePrice);
                dataGridView1.Rows.Add(bardcode, name, salePrice, quantity, totalPrice);


            }
            connection.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 > -1)
            {
              /*  for(int i=0; i<dataGridView1.Rows.Count - 1; i++)
                {
                    string bardcode = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string quantity = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);

                    string itemQuan ="";

                    string selectItemStat = $"select {ItemDatabaseConst.QUANTITY} from {ItemDatabaseConst.TABLE_NAME} where {ItemDatabaseConst.BARCODE}='{bardcode}'";
                    SqlCommand selectItemCom = new SqlCommand(selectItemStat, connection);
                    connection.Open();
                    SqlDataReader ItemReader = selectItemCom.ExecuteReader();
                    while (ItemReader.Read())
                    {
                        itemQuan = (string)ItemReader[$"{ItemDatabaseConst.QUANTITY}"];
                        break;
                    }
                    connection.Close();
                    int finalItemQ = int.Parse(itemQuan) - int.Parse(quantity);
                    if (finalItemQ> 0)
                    {

                    }
                    string updateItem = $"update {ItemDatabaseConst.TABLE_NAME} set {ItemDatabaseConst.QUANTITY}='{quantity}' where {ItemDatabaseConst.BARCODE}='{bardcode}'";
                    connection.Open();
                    SqlCommand updateItemCommand = new SqlCommand(updateItem,connection);
                    updateItemCommand.ExecuteNonQuery();
                    connection.Close();
                    string updateSale = $"update {SaleDatabaseConst.TABLE_NAME} set {SaleDatabaseConst.QUANTITY} ='{}'";
                    */
                }
            }
        }
    }

