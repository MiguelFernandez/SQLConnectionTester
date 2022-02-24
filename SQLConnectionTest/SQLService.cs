using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SQLConnectionTest.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SQLConnectionTest
{
    public class SQLService : ISQLService
    {
        private readonly IConfiguration _configuration;

        public SQLService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Connect(SQLTest sQLConnectionTest)
        {
            try
            {

                var maxRowsToFetch = _configuration["MaxRowsToFetch"];
                var maxColsToFetch = _configuration["MaxColsToFetch"];
                var connectionString = sQLConnectionTest.ConnectionString.FullConnectionString;
                string queryString = $"select top {maxRowsToFetch} * from {sQLConnectionTest.ConnectionString.TableName}";
                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                var columns = reader.FieldCount;
                var hasRows = reader.HasRows;
                var schemaTable = reader.GetSchemaTable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i > Convert.ToInt16(maxColsToFetch) - 1)
                    {
                        break;
                    }
                    sQLConnectionTest.ColumnNames.Add(reader.GetName(i));
                }


                if (reader.HasRows)
                {
                    reader.Read();
                    var tempRow = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        tempRow += reader[i].ToString() + ", ";
                    }
                    sQLConnectionTest.Rows.Add(tempRow);


                }
                else
                {
                    sQLConnectionTest.InformationMessage = "No rows found.";
                }
                reader.Close();
                connection.Close();

            }

            catch (Exception ex)
            {
                string errorJson = JsonConvert.SerializeObject(ex, Formatting.Indented);
                sQLConnectionTest.ErrorMessage = errorJson;
                
            }



        }
    }
}
