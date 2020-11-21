using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_GUI_Core.Property_Classes;

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
                MySqlCommand cmd = new MySqlCommand("SELECT * From tbluser", db.conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    User data = new User
                    {
                        Id = (int)dataReader["Id"],
                        UserName = dataReader["UserName"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        CreatedBy = dataReader["Created_By"].ToString(),
                        CreatedDateTime = (DateTime)(dataReader["Created_Datetime"]),
                        PhoneNumber = dataReader["PhoneNumber"].ToString(),
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
                MySqlCommand cmd = new
                    MySqlCommand("INSERT INTO tbluser (UserName , Password , Created_by , Created_Datetime , Email , PhoneNumber ) VALUES (@argo.UserName , @argo.Password , @argo.CreatedBy , @argo.CreatedDateTime , @argo.Email , @argo.PhoneNumber)", db.conn);
                cmd.Parameters.AddWithValue("argo.UserName", argo.UserName);
                cmd.Parameters.AddWithValue("argo.Password", argo.Password);
                cmd.Parameters.AddWithValue("argo.PhoneNumber", argo.PhoneNumber);
                cmd.Parameters.AddWithValue("argo.Email", argo.Email);
                cmd.Parameters.AddWithValue("argo.CreatedDateTime", argo.CreatedDateTime);
                cmd.Parameters.AddWithValue("argo.CreatedBy", argo.CreatedBy);
                cmd.Parameters.AddWithValue("argo.Id", argo.Id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
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
                var query = "UPDATE tbluser SET UserName=@argo.UserName , Password=argo.Password , PhoneNumber=argo.PhoneNumber , Email=argo.Email , CreatedDateTime=argo.CreatedDateTime , CreatedBy=argo.CreatedBy WHERE Id=@argo.Id";

                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("argo.UserName", argo.UserName);
                cmd.Parameters.AddWithValue("argo.Password", argo.Password);
                cmd.Parameters.AddWithValue("argo.PhoneNumber", argo.PhoneNumber);
                cmd.Parameters.AddWithValue("argo.Email", argo.Email);
                cmd.Parameters.AddWithValue("argo.CreatedDateTime", argo.CreatedDateTime);
                cmd.Parameters.AddWithValue("argo.CreatedBy", argo.CreatedBy);
                cmd.Parameters.AddWithValue("argo.Id", argo.Id);

                cmd.Connection = db.conn;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
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
                var query = "DELETE FROM tbluser WHERE Id=@id";

                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Connection = db.conn;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                db.CloseConnection();
            }
        }

        public UserVerification UserLogin(string UserName, string Password)
        {
            UserVerification user = null;
            if (db.OpenConnection())
            {
               
                MySqlCommand cmd = new MySqlCommand("SELECT UserName,Password,Role from tbluser WHERE UserName = @UserName and Password=@Password", db.conn);
                cmd.Parameters.AddWithValue("UserName", UserName);
                cmd.Parameters.AddWithValue("Password", Password);
                try
                {
                    MySqlDataReader datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                         user = new UserVerification
                        {
                            UserName = datareader["UserName"].ToString(),
                            Password = datareader["Password"].ToString(),
                            Role = datareader["Role"].ToString()
                        };
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception em)
                {
                    throw new Exception(em.Message);
                }
                if (user!=null)
                {
                    db.CloseConnection();
                    return user;
                }
                else
                {
                    db.CloseConnection();
                    throw new Exception("Invalid username or password");
                }
              
            }
            else
            {
                return user;

            }
           

        }
 
    }

}
