﻿using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ExibitionDAL
{
    public class ExibitionDAL
    {
        private SqlConnection connect = null;
        public void OpenConnection(string connectionString)
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }
        public void CloseConnection()
        {
            connect.Close();
        }

        public void InsertAddress(int id, string city, string street, string house, string apartment)
        {
            // Оператор SQL
            string sql = string.Format("Insert Into Address" +
                "(id_address, city, street, house, apartment)" +
                "Values(@id_address, @city, @street, @house, @apartment)");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                // Добавить параметры
                cmd.Parameters.AddWithValue("@id_address", id);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@house", house);
                cmd.Parameters.AddWithValue("@apartment", apartment);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertOwner(string last_name, string first_name, string middle_name, int id_home_address, string telephone)
        {
            // Оператор SQL
            string sql = string.Format("Insert Into Owner" +
                "(last_name, first_name, middle_name, id_home_address, telephone)" +
                "Values('{0}', '{1}', '{2}', '{3}', '{4}')",
                last_name, first_name, middle_name, id_home_address, telephone);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                // Параметризированная команда
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@last_name";
                param.Value = last_name;
                param.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@first_name";
                param.Value = first_name;
                param.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@middle_name";
                param.Value = middle_name;
                param.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@id_home_address";
                param.Value = id_home_address;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@telephone";
                param.Value = telephone;
                param.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteContract(int id)
        {
            string sql = string.Format("DELETE FROM Contract WHERE id_contract = @id_contract");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_contract", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Ошибка при удалении контракта.", ex);
                    throw error;
                }
            }
        }

        public void DeleteProducts(int id)
        {
            string sql = string.Format("DELETE FROM Products WHERE id_products = @id_products");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_products", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Ошибка при удалении продукта.", ex);
                    throw error;
                }
            }
        }

        public void UpdateCompanyName(string id, string newName)
        {
            string sql = string.Format("UPDATE Company SET name = @newName WHERE id_company = @id_company");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_company", id);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProductsUnitPrice(string id, string newUnitPrice)
        {
            string sql = string.Format("UPDATE Products SET unit_price = @newUnitPrice WHERE id_products = @id_products");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@id_products", id);
                cmd.Parameters.AddWithValue("@newUnitPrice", newUnitPrice);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllDataAsDataTable(int maxRows, string tableName)
        {
            DataTable data = new DataTable();
            string sql = $"SELECT TOP (@maxRows) * FROM {tableName}";
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                cmd.Parameters.AddWithValue("@maxRows", maxRows);
                SqlDataReader dr = cmd.ExecuteReader();
                data.Load(dr);
                dr.Close();
            }
            return data;
        }

        public int CreateContract(string recipientCompanyID, string supplierCompanyID, string productID, DateTime dateOfConclusion, int deadline)
        {
            int newContractID = 0;

            using (SqlCommand cmd = new SqlCommand("CreateContract", connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Входные параметры
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@recipientCompanyID";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 4;
                param.Value = recipientCompanyID;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@supplierCompanyID";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 4;
                param.Value = supplierCompanyID;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@productID";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 4;
                param.Value = productID;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@dateOfConclusion";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dateOfConclusion;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@deadline"; 
                param.SqlDbType = SqlDbType.Int;
                param.Value = deadline;
                cmd.Parameters.Add(param);

                // Выходной параметр
                param = new SqlParameter();
                param.ParameterName = "@newContractID";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                // Получение выходного параметра
                newContractID = (int)cmd.Parameters["@newContractID"].Value;
            }

            return newContractID;
        }

        public void NonParticipatingProducts(bool throwEx, string id_products)
        {
            // Выборка названия компании по идентификатору продукта
            string id_company = string.Empty;

            SqlCommand cmdSelect = new SqlCommand(
                string.Format("SELECT * FROM Products WHERE id_products = '{0}'", id_products), connect);
            using (SqlDataReader dr = cmdSelect.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    id_company = (string)dr["id_company"];
                }
                else return;
            }

            // Создание объектов команд для каждого шага операции
            SqlCommand cmdRemove = new SqlCommand(
                string.Format("DELETE FROM Products WHERE id_products = '{0}'", id_products), connect);
            SqlCommand cmdRemoveContract = new SqlCommand(
                string.Format("DELETE FROM Contract WHERE id_product = '{0}'", id_products), connect);
            SqlCommand cmdInsert = new SqlCommand(
                string.Format("INSERT INTO NonParticipatingProducts (id_products, id_company) VALUES " +
                              "('{0}', '{1}')", id_products, id_company), connect);

            // Получение из объекта подключения
            SqlTransaction tx = null;
            try
            {
                tx = connect.BeginTransaction();
                // Включение команд в транзакцию
                cmdInsert.Transaction = tx;
                cmdRemoveContract.Transaction = tx;
                cmdRemove.Transaction = tx;
                // Выполнение команд
                cmdInsert.ExecuteNonQuery();
                cmdRemoveContract.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();
                // Имитация ошибки
                if (throwEx)
                {
                    throw new ApplicationException("Ошибка базы данных! Транзакция завершена неудачно.");
                }
                // Фиксация
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // При возникновении любой ошибки выполняется откат транзакции
                tx.Rollback();
            }
        }
    
    }
}
