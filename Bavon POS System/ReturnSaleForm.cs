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
          /*  if (dataGridView1.Rows.Count - 1 > -1)
            {
                return;
            }*/
            string salecode = saleCodeTextBox.Text;
            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            string selectStatment = $"select {SaleDatabaseConst.BARCODE},{SaleDatabaseConst.NAME},{SaleDatabaseConst.QUANTITY},{SaleDatabaseConst.SALEPRICE} ,{SaleDatabaseConst.SALECODE} from {SaleDatabaseConst.TABLE_NAME } where {SaleDatabaseConst.SALECODE}= '{salecode}'";
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand(selectStatment, connection))
            {
                
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string bardcode = (string)reader[$"{SaleDatabaseConst.BARCODE}"];
                    string name = (string)reader[$"{SaleDatabaseConst.NAME}"];
                    string salePrice = (string)reader[$"{SaleDatabaseConst.SALEPRICE}"];
                    string quantity = (string)reader[$"{SaleDatabaseConst.QUANTITY}"];
                    string saleCode = (string)reader[$"{SaleDatabaseConst.SALECODE}"];
                    double totalPrice = Double.Parse(quantity) * Double.Parse(salePrice);
                    dataGridView1.Rows.Add(bardcode, name, salePrice, quantity, totalPrice, saleCode);


                }
            }
            connection.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 > -1)
            {
                SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
                connection.Open();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string bardcode = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string quantity = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string saleCode = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    string saleQuan = "";
                    string salePrice = "";
                    string selectSaleStat = $"select {SaleDatabaseConst.QUANTITY} , {SaleDatabaseConst.SALEPRICE} from {SaleDatabaseConst.TABLE_NAME} where {SaleDatabaseConst.BARCODE} = '{bardcode}' and {SaleDatabaseConst.SALECODE}= '{saleCode}' ;";
                    SqlCommand selecSaleCom = new SqlCommand(selectSaleStat, connection);
                    using (SqlDataReader saleReader = selecSaleCom.ExecuteReader())
                    {
                        while (saleReader.Read())
                        {
                            saleQuan = (string)saleReader[$"{SaleDatabaseConst.QUANTITY}"];
                            salePrice = (string)saleReader[$"{SaleDatabaseConst.SALEPRICE}"];
                            break;
                        }
                    }

                    double finalSaleQ = double.Parse(saleQuan) - double.Parse(quantity);
                    if (finalSaleQ > 0)
                    {
                        string totalSalePrice = (Double.Parse(salePrice) * finalSaleQ) + "";
                        string updateSaleStat = $"update {SaleDatabaseConst.TABLE_NAME} set {SaleDatabaseConst.QUANTITY}='{finalSaleQ.ToString()}' ,{SaleDatabaseConst.TOTALSALEPRICE}='' where {SaleDatabaseConst.BARCODE}='{bardcode}' and {SaleDatabaseConst.SALECODE}='{saleCode}'";
                        using (SqlCommand updateSaleCommand = new SqlCommand(updateSaleStat, connection))
                        {
                            updateSaleCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string deleteSaleStat = $"delete from {SaleDatabaseConst.TABLE_NAME} where {SaleDatabaseConst.BARCODE}='{bardcode}' , {SaleDatabaseConst.SALECODE}='{saleCode}'";
                    }






                    string itemQuan = "";

                    string selectItemStat = $"select {ItemDatabaseConst.QUANTITY} from {ItemDatabaseConst.TABLE_NAME} where {ItemDatabaseConst.BARCODE}='{bardcode}'";
                    SqlCommand selectItemCom = new SqlCommand(selectItemStat, connection);
                    using (SqlDataReader ItemReader = selectItemCom.ExecuteReader())
                    {
                        while (ItemReader.Read())
                        {
                            itemQuan = (string)ItemReader[$"{SaleDatabaseConst.QUANTITY}"];
                            break;
                        }
                    }

                    int finalItemQ = int.Parse(itemQuan) + int.Parse(quantity);

                    string updateItemStat = $"update {ItemDatabaseConst.TABLE_NAME} set {ItemDatabaseConst.QUANTITY}='{finalItemQ.ToString()}' where {ItemDatabaseConst.BARCODE}='{bardcode}'";
                    using (SqlCommand updateSaleCommand = new SqlCommand(updateItemStat, connection))
                    {
                        updateSaleCommand.ExecuteNonQuery();
                    }
                    
                }
                connection.Close();
                dataGridView1.Rows.Clear();
                MessageBox.Show("Item Returned");
                saleCodeTextBox.Clear();
            }
        }

        private void ReturnSaleForm_Load(object sender, EventArgs e)
        {

        }
    }
}

