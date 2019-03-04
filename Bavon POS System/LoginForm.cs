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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection Connection = new SqlConnection("Data Source=MSI;Initial Catalog=Bavon POS;Integrated Security=True"))
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand($@"SELECT {UserDatabaseConst.USERNAME},{UserDatabaseConst.PASSWORD},{UserDatabaseConst.Role} FROM [{UserDatabaseConst.USTER_TABLE}] 
                                        WHERE {UserDatabaseConst.USERNAME}=@uname and 
                                        {UserDatabaseConst.PASSWORD}=@pass", Connection);
                    cmd.Parameters.AddWithValue("@uname", userTextBox.Text);
                    cmd.Parameters.AddWithValue("@pass", passwordTextBox.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string username = (string)reader[$"{UserDatabaseConst.USERNAME}"];
                        string pass = (string)reader[$"{UserDatabaseConst.PASSWORD}"];
                        string role = (string)reader[$"{UserDatabaseConst.Role}"];

                        if (role.Equals(UserDatabaseConst.CASHIER_ROLE))
                        {
                            this.Hide();
                            POSForm form = new POSForm();
                            form.Show();
                        }
                        else if (role.Equals(UserDatabaseConst.STORAGE_ROLE))
                        {
                            this.Hide();
                            dataEnter form = new dataEnter();
                            form.Show();
                        }
                        else if (role.Equals(UserDatabaseConst.ADMIN_ROLE))
                        {

                        }
                        
                    }
                    else
                        MessageBox.Show("Incorrect login");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error:" + ex.Message);
                }
            }

        }
    }
}
