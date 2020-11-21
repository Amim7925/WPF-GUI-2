using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core
{
    public class DBConnect
    {
        public const string ConnectionString = "server=localhost;user=root;database=car_simulation;port=3306;";

        public MySqlConnection conn = new MySqlConnection(ConnectionString);

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                if(ex.Number == 0)
                {
                    throw new Exception("Cannot connect to server.  Contact administrator");
                }
                else if(ex.Number == 1045)
                {
                    throw new Exception("Invalid username/password, please try again");
                }
                else
                {
                    throw new Exception("Unknown error please contatct the admin");
                }
               
            }
        }

        public bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
   


    }
}
