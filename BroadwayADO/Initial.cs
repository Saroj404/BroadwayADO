//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Broadway.Projects
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string connectionString =
//            "Data Source=SAROJ-PC;Initial Catalog=ADO;"
//            + "Integrated Security=true";

//            // Provide the query string with a parameter placeholder.
//            string queryString =
//                "select * from Tentent";

//            // Specify the parameter value.
//            //int paramValue = 5;

//            // Create and open the connection in a using block. This
//            // ensures that all resources will be closed and disposed
//            // when the code exits.
//            using (SqlConnection connection =
//                new SqlConnection(connectionString))
//            {
//                // Create the Command and Parameter objects.
//                SqlCommand command = new SqlCommand(queryString, connection);
//                //command.Parameters.AddWithValue("@pricePoint", paramValue);

//                // Open the connection in a try/catch block.
//                // Create and execute the DataReader, writing the result
//                // set to the console window.
//                connection.Open();
//                try
//                {
//                    Console.WriteLine("Name\tPhone\tRent");
//                    SqlDataReader reader = command.ExecuteReader();
//                    while (reader.Read())
//                    {

//                        var readers = new string[] { reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };

//                        Console.WriteLine("\t{1}\t{2}\t{3}\t",
//                            readers);
//                    }
//                    reader.Close();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                finally
//                {
//                    connection.Close();
//                }
//                Console.ReadLine();
//            }
//        }
//    }
//}
