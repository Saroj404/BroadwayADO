using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.DesktopApp
{
    public partial class Form1 : Form
    {

        string connectionString = "Data Source=SAROJ-PC;Initial Catalog=ADO;"
            + "Integrated Security=true";
        public Form1()
        {
            InitializeComponent();
            Reloaddata();
        }
        private void ReadFromTable(SqlConnection connection)
        {
            string queryString = "select * from Tentent";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                List<Tentent> tentents = new List<Tentent>();
                while (reader.Read())
                {
                    tentents.Add(new Tentent
                    {
                        Id = (int)reader[0],
                        Name = reader[1].ToString(),
                        Phone = (long)reader[2],
                        Rent = (long)reader[3]
                    });
                }
                reader.Close();
                dataGridView1.DataSource = tentents;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

          


        }
        private void InsertIntoTable(SqlConnection connection)
        {
            
            var Name = textBox1.Text;
            var Phone = textBox2.Text;
            var Rent = textBox3.Text;

            string queryString = $"insert into Tentent (Name,Phone,Rent) values ('{Name}','{Phone}','{Rent}')";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }
        private void UpdateTable(SqlConnection connection)
        {
            Console.WriteLine("Enter the id of the record to update");
            var id = Console.ReadLine();
            Console.WriteLine("Enter name:");
            var Name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            var Phone = Console.ReadLine();
            Console.WriteLine("Enter rent:");
            var Rent = Console.ReadLine();

            string queryString = $"update Tentent set Name=('{Name}'),Phone=('{Phone}'),Rent=('{Rent}') where id=('{id}') ";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();



        }
        private void DeleteFromTable(SqlConnection connection)
        {
            Console.WriteLine("Enter the id of the record to be deleted");
            var id = Console.ReadLine();
            string queryString = $"delete from Tentent where id=('{id}')";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reloaddata();
        }
        void Reloaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                ReadFromTable(connection);




                connection.Close();
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                InsertIntoTable(connection);




                connection.Close();
                Reloaddata();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            MessageBox.Show($"Your Total Rent is: Rs.{sum.ToString()}");
        }
    }
    public class Tentent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public long Rent { get; set; }
    }

}
