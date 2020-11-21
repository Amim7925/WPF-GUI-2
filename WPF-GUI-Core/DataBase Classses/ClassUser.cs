using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core
{
    public class ClassUser
    {
        DBConnect db = new DBConnect();

        public List<User> LoadData()
        {
            List<User> list = new List<User>();
            if (db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * From user", db.conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    User data = new User
                    {
                        Id = (int)dataReader["Id"],
                        Name = dataReader["Name"].ToString(),
                        Role = dataReader["Role"].ToString()
                    };
                    list.Add(data);
                }

                dataReader.Close();

                db.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public void Insert(User argo)
        {
            if (db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user (Role, Name) VALUES (@argo.Role , @argo.Name)");
                cmd.Parameters.AddWithValue("argo.Name", argo.Name);
                cmd.Parameters.AddWithValue("argo.Role", argo.Role);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                db.CloseConnection();
            }
        }
        public void Edit(User argo)
        {
            if (db.OpenConnection())
            {
                var query = "UPDATE user SET Name=@argo.Name , Role=argo.Role WHERE Id=@argo.Id";

                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("argo.Name", argo.Name);
                cmd.Parameters.AddWithValue("argo.Role", argo.Role);
                cmd.Parameters.AddWithValue("argo.Id", argo.Id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                db.CloseConnection();   
            }
        }
        public void Delete(int id)
        {
            if (db.OpenConnection())
            {
                var query = "DELETE FROM user WHERE Id=@id";

                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                db.CloseConnection();
            }
        }
    }
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }


    }
}
