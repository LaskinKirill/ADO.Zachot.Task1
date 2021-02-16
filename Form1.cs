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
namespace ADO.Zachot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (sqlConnection1)
            {
                sqlConnection1.Open();
            String Dt1;
            String Dt2;
            Dt1 = Convert.ToString(dateTimePicker1.Value);
            Dt1 = Dt1.Substring(3, 3) + Dt1.Substring(0, 3) + Dt1.Substring(6, 4);
            Dt2= Convert.ToString(dateTimePicker2.Value);
            Dt2 = Dt2.Substring(3, 3) + Dt2.Substring(0, 3) + Dt2.Substring(6, 4);

            textBox1.Text = "EXEC spSalesByPeriod " + "'"+Dt1 + "', '" + Dt2+"'";
            StringBuilder results = new StringBuilder();
            sqlCommand1.Parameters["@Beginning_Date"].Value = dateTimePicker1.Value;
            sqlCommand1.Parameters["@Ending_Date"].Value = dateTimePicker2.Value;
            
               
                SqlDataReader reader = sqlCommand1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Append(reader[i].ToString() + "\t");
                    }
                    results.Append(Environment.NewLine);
                }
                textBox2.Text = results.ToString();
            }
            sqlConnection1.Close();
        }
    }
}
