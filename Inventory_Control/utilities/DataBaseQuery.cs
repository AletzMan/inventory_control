using Inventory_Control.pages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Control.utilities
{
    class DataBaseQuery
    {
        MySqlConnection ConnectioDB = new MySqlConnection("Server=localhost;Database=inventary_app;Uid=root;Pwd=;SslMode = none");
        private DataTable queryResult = new DataTable();
        private Exception queryError;

        async private void DatabaseConnectionAndQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, ConnectioDB);
                ConnectioDB.Open();
                DbDataReader dataRead = await command.ExecuteReaderAsync();
                queryResult.Clear();
                queryResult.Reset();
                queryResult.TableName = "";
                queryResult.Load(dataRead);
                dataRead.Close();
                ConnectioDB.Close();
            }
            catch (MySqlException error)
            {
                queryError = error;
            }

        }

        public string GetAllUser(out List<User> usersData)
        {
            string result;
            string query = $"SELECT * FROM users";
            DatabaseConnectionAndQuery(query);
            result = queryResult.Rows.Count.ToString();
            usersData = new List<User>();
            if (Convert.ToInt32(result) != 0)
            {
                for (int index = 0; index < queryResult.Rows.Count; index++)
                {
                    User newUser = new User
                    {
                        ID = Convert.ToInt32(queryResult.Rows[index].ItemArray.GetValue(0)),
                        Name = queryResult.Rows[index].ItemArray.GetValue(1).ToString(),
                        Email = queryResult.Rows[index].ItemArray.GetValue(2).ToString(),
                        Permission = queryResult.Rows[index].ItemArray.GetValue(3).ToString(),
                    };
                    usersData.Add(newUser);
                }
            }

            return result;
        }

        public string GetUser(int idUser, out Array userData)
        {
            userData = null;
            string result;
            string query = $"SELECT * FROM users WHERE id='{idUser}'";
            DatabaseConnectionAndQuery(query);
            result = queryResult.Rows.Count.ToString();
            if (Convert.ToInt32(result) != 0)
            {
                userData = queryResult.Rows[0].ItemArray;
            }
            return result;
        }

        public void AddUser(User userData)
        {
            ConnectioDB.Open();
            string query = $"INSERT INTO users(name, email, permissions) VALUES('{userData.Name}', '{userData.Email}', '{userData.Permission}')";
            MySqlCommand command = new MySqlCommand(query, ConnectioDB);
            MySqlDataAdapter miAdapter = new MySqlDataAdapter();
            command.ExecuteNonQuery();
            ConnectioDB.Close();
        }

        public void EditUser(int idUser, User userData)
        {
            ConnectioDB.Open();
            string query = $"UPDATE users SET name='{userData.Name}', email='{userData.Email}', permissions='{userData.Permission}' WHERE id={idUser}";
            MySqlCommand command = new MySqlCommand(query, ConnectioDB);
            MySqlDataAdapter miAdapter = new MySqlDataAdapter();
            command.ExecuteNonQuery();
            ConnectioDB.Close();
        }

        public void DeleteUser(int idUser)
        {
            string query = $"DELETE FROM users WHERE id={idUser}";
            DatabaseConnectionAndQuery(query);
        }

        #region SUPPLIERS QUERIES

        public string GetAllSuppliers(out List<Supplier> suppliersData)
        {
            string result;
            string query = $"SELECT * FROM suppliers";
            DatabaseConnectionAndQuery(query);
            result = queryResult.Rows.Count.ToString();
            suppliersData = new List<Supplier>();
            if (Convert.ToInt32(result) != 0)
            {
                for (int index = 0; index < queryResult.Rows.Count; index++)
                {
                    Supplier newSupplier = new Supplier
                    {
                        ID = Convert.ToInt32(queryResult.Rows[index].ItemArray.GetValue(0)),
                        Name = queryResult.Rows[index].ItemArray.GetValue(1).ToString(),
                        RFC = queryResult.Rows[index].ItemArray.GetValue(2).ToString(),
                        Address = queryResult.Rows[index].ItemArray.GetValue(3).ToString(),
                        Contact = queryResult.Rows[index].ItemArray.GetValue(4).ToString(),
                        Email = queryResult.Rows[index].ItemArray.GetValue(5).ToString(),
                        Phone = queryResult.Rows[index].ItemArray.GetValue(6).ToString(),
                    };
                    suppliersData.Add(newSupplier);
                }
            }

            return result;
        }

        public string GetSupplier(int idSupplier, out Array supplierData)
        {
            supplierData = null;
            string result;
            string query = $"SELECT * FROM suppliers WHERE id='{idSupplier}'";
            DatabaseConnectionAndQuery(query);
            result = queryResult.Rows.Count.ToString();
            if (Convert.ToInt32(result) != 0)
            {
                supplierData = queryResult.Rows[0].ItemArray;
            }
            return result;
        }

        public void AddSupplier(Supplier supplierData)
        {
            ConnectioDB.Open();
            string query = $"INSERT INTO suppliers(name, rfc, address, contact, email, phone) VALUES('{supplierData.Name}', '{supplierData.RFC}','{supplierData.Address}', '{supplierData.Contact}', '{supplierData.Email}', '{supplierData.Phone}')";
            MySqlCommand command = new MySqlCommand(query, ConnectioDB);
            MySqlDataAdapter miAdapter = new MySqlDataAdapter();
            command.ExecuteNonQuery();
            ConnectioDB.Close();
        }

        public void EditSupplier(int idSupplier, Supplier supplierData)
        {
            ConnectioDB.Open();
            string query = $"UPDATE suppliers SET name='{supplierData.Name}', name='{supplierData.RFC}', address='{supplierData.Address}', contact='{supplierData.Contact}', email='{supplierData.Email}', phone='{supplierData.Phone}' WHERE id={idSupplier}";
            MySqlCommand command = new MySqlCommand(query, ConnectioDB);
            MySqlDataAdapter miAdapter = new MySqlDataAdapter();
            command.ExecuteNonQuery();
            ConnectioDB.Close();
        }

        public void DeleteSupplier(int idSupplier)
        {
            string query = $"DELETE FROM suppliers WHERE id={idSupplier}";
            DatabaseConnectionAndQuery(query);
        }

        #endregion
    }


}
