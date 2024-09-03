﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Utils
{
    public class DataBaseAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DataBaseAccess()
        {
            connection = new SqlConnection("");
            command = new SqlCommand();

        }

        public void setQuery(string Query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = Query;
        }

        public void excecuteQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void excecuteAction() //Excecutes actions as update, remove 
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setParameter(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }

        public void CloseConnection()
        {
            if (reader != null)
            {
                reader.Close();
            }
            connection.Close();
        }
    }
}
