using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bavon_POS_System
{
    public partial class dataEnter : Form
    {
        public dataEnter()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            logLabel.Visible = false;

            string bardcode = bardcodeTextBox.Text.ToString();
            string itemCode =itemCodeTextBox.Text.ToString();       // nullable
            string itemName =itemNameTextBox.Text.ToString();
            string purshasePrice  =purchasePriceTextBox.Text.ToString();
            string percentage = percentageTextBox.Text.ToString();
            string salePrice = salePriceLabel.Text.ToString();
            string quantity =quantityTextBox.Text.ToString();
            string supplier =supplierTextBox.Text.ToString();      // nullable
            DateTime exiprationDate = expirationDatePicker.Value;
            DateTime purchaseDate = purchaseDatePicker.Value;    // nullable
            double extraPrice = (Double.Parse(percentage) / 100.0)*Double.Parse(purshasePrice);
            salePrice = (Double.Parse(purshasePrice) + extraPrice) + "";
            
            if (bardcode.Equals(""))
            {
                logLabel.Visible = true;
                logLabel.Text = "bardcode is empty";
                return;
            } 
            if (itemName.Equals(""))
            {
                logLabel.Visible = true;
                logLabel.Text = "Item name is empty";
                return;
            }
            if (purshasePrice.Equals(""))
            {
                logLabel.Visible = true;
                logLabel.Text = "Purchase price is empty";
                return;
            }
            if (salePrice.Equals("0"))
            {
                logLabel.Visible = true;
                logLabel.Text = "precentage  is empty";
                return;
            }
            if (quantity.Equals(""))
            {
                logLabel.Visible = true;
                logLabel.Text = "quantity is empty";
                return;
            }
            if (exiprationDate.Equals(DateTime.Today))
            {
                logLabel.Visible = true;
                logLabel.Text = "Expiration date can not be today date";
                return;
            }
            
            for (int i = 0; i < tableGrid.Rows.Count; i++)
            {

                string datag = "";
                if (tableGrid.Rows[i].Cells[0].Value != null)
                {
                    datag = tableGrid.Rows[i].Cells[0].Value.ToString();
                }
                datag = Regex.Replace(datag, @"\t|\n|\r| ", "");
                if (bardcode.Equals(datag))
                {
                    tableGrid.ClearSelection();
                    tableGrid.Rows[i].Selected = true;
                    logLabel.Visible = true;
                    logLabel.Text = "data exists already, update the data in the  selected row";
                    return;
                }


            }
            tableGrid.Rows.Add(bardcode, itemCode, itemName, purshasePrice, percentage, quantity, salePrice, supplier, purchaseDate,exiprationDate);
            resetRightSide();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string bardcode = bardcodeTextBox.Text.ToString();
            if (bardcode.Equals("")) return;
            for (int i = 0; i < tableGrid.Rows.Count; i++)
            {

                string datag = "";
                if (tableGrid.Rows[i].Cells[0].Value != null)
                {
                    datag = tableGrid.Rows[i].Cells[0].Value.ToString();
                }
                datag = Regex.Replace(datag, @"\t|\n|\r| ", "");
                if (bardcode.Equals(datag))
                {
                    tableGrid.ClearSelection();
                    tableGrid.Rows[i].Selected = true;
                    return;
                }


            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string bardcode = bardcodeTextBox.Text.ToString();
            if (bardcode.Equals("")) return;
            for (int i = 0; i < tableGrid.Rows.Count; i++)
            {

                string datag = "";
                if (tableGrid.Rows[i].Cells[0].Value != null)
                {
                    datag = tableGrid.Rows[i].Cells[0].Value.ToString();
                }
                datag = Regex.Replace(datag, @"\t|\n|\r| ", "");
                if (bardcode.Equals(datag))
                {
                    tableGrid.ClearSelection();
                    tableGrid.Rows[i].Selected = true;
                    tableGrid.Rows.RemoveAt(i);
                    return;
                }


            }
        }
        void activeOrDeactiveAll(bool state)
        {
            bardcodeTextBox.Enabled = state;
            itemCodeTextBox.Enabled = state;      // nullable
            itemNameTextBox.Enabled = state;
            purchasePriceTextBox.Enabled = state;
            percentageTextBox.Enabled = state;
            quantityTextBox.Enabled = state;
            supplierTextBox.Enabled = state;    // nullable
            expirationDatePicker.Enabled = state;
            purchaseDatePicker.Enabled = state;   // nullable
            addBtn.Enabled = state;
            deleteBtn.Enabled = state;
            searchBtn.Enabled = state;
            tableGrid.Enabled = state;


        }
        private void enterBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConstValues.sqlStringCon);
            connection.Open();
            activeOrDeactiveAll(false);
            for (int i = 0; i < tableGrid.Rows.Count - 1; i++)
            {


                string bardcode = tableGrid.Rows[i].Cells[0].Value.ToString();
                string itemCode = tableGrid.Rows[i].Cells[1].Value.ToString();    // nullable
                string itemName = tableGrid.Rows[i].Cells[2].Value.ToString();
                string purchasePrice = tableGrid.Rows[i].Cells[3].Value.ToString();
                string percentage = tableGrid.Rows[i].Cells[4].Value.ToString();
                string quantity = tableGrid.Rows[i].Cells[5].Value.ToString();
                string salePrice = tableGrid.Rows[i].Cells[6].Value.ToString();
                string supplier = tableGrid.Rows[i].Cells[7].Value.ToString();   // nullable
                DateTime purchaseDate = (DateTime)tableGrid.Rows[i].Cells[8].Value;  // nullable
                DateTime exiprationDate = (DateTime)tableGrid.Rows[i].Cells[9].Value;
            
                string selectStatatment = $"select {ItemDatabaseConst.BARCODE},{ItemDatabaseConst.QUANTITY} from {ItemDatabaseConst.TABLE_NAME} where {ItemDatabaseConst.BARCODE}= '{bardcode}'";
                SqlCommand selectCommand = new SqlCommand(selectStatatment, connection);

                bool dataUpdated = true;

                using (SqlDataReader selectReader = selectCommand.ExecuteReader())
                {
                    while (selectReader.Read())
                    {

                        int updatedQuantity = int.Parse((string)selectReader[$"{ItemDatabaseConst.QUANTITY}"]) + int.Parse(quantity);
                        string updateSatement = $"update {ItemDatabaseConst.TABLE_NAME} set {ItemDatabaseConst.QUANTITY}='{updatedQuantity.ToString()}' , {ItemDatabaseConst.SALEPRICE}='{salePrice}' , {ItemDatabaseConst.PURCHASEPRICE}='{purchasePrice}' , {ItemDatabaseConst.PERCENTAGE}='{percentage}' where {ItemDatabaseConst.BARCODE}='{bardcode}'";
                        SqlCommand updateCommand = new SqlCommand(updateSatement, connection);
                        selectReader.Close();
                        updateCommand.ExecuteNonQuery();
                        dataUpdated = false;
                        break;


                    }
                };
                if (dataUpdated)
                {
                    string insertStatement = $"insert into {ItemDatabaseConst.TABLE_NAME} ({ItemDatabaseConst.BARCODE}, {ItemDatabaseConst.ITEMCODE}, {ItemDatabaseConst.NAME}, {ItemDatabaseConst.PURCHASEPRICE}, {ItemDatabaseConst.SALEPRICE}, {ItemDatabaseConst.QUANTITY}, {ItemDatabaseConst.SUPPLIER}, {ItemDatabaseConst.EXPIRATIONDATE}, {ItemDatabaseConst.PURCHASEDATE}, {ItemDatabaseConst.PERCENTAGE})" +
                                                                                             $" values('{bardcode}', '{itemCode}', '{itemName}', '{purchasePrice}', '{salePrice}', '{quantity}', '{supplier}', '{exiprationDate.ToString("MM/dd/yyyy")}', '{purchaseDate.ToString("MM/dd/yyyy")}', '{percentage}');";

                    SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
                    insertCommand.ExecuteNonQuery();
                }


            }
            activeOrDeactiveAll(true);
            logLabel.Text = "All data has been uploaded to the Database";
            connection.Close();
            resetRightSide();
            tableGrid.Rows.Clear();
        }
        void resetRightSide()
        {
            bardcodeTextBox.Clear();
            itemCodeTextBox.Clear();
            itemNameTextBox.Clear();
            purchasePriceTextBox.Clear();
            percentageTextBox.Clear();
            salePriceLabel.Text = "0";
            quantityTextBox.Clear();
            supplierTextBox.Clear();
            expirationDatePicker.Value = DateTime.Now;
            purchaseDatePicker.Value = DateTime.Now;
        }
        private void percentageTextBox_TextChanged(object sender, EventArgs e)
        {
            string purshasePrice = purchasePriceTextBox.Text.ToString();
            string percentage = percentageTextBox.Text.ToString();
            double extraPrice = (Double.Parse(percentage) / 100.0) * Double.Parse(purshasePrice);
           string salePrice = (Double.Parse(purshasePrice) + extraPrice) + "";
            salePriceLabel.Text = salePrice;
        }
    }
}
