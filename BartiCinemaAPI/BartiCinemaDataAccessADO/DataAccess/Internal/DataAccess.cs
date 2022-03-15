using BartiCinemaDataAccessADO.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    internal class DataAccess : IDataAccess
    {
        // Load any DAL entity
        public List<U> LoadData<U>(string connectionString, SqlMessage sqlMessage)
        {
            List<U> result = new List<U>();

            // Get all U's properties info necessary to buid an instance of U using reflection

            // Get all properties info
            Type dataType = typeof(U);
            PropertyInfo[] dataTypeProperties = dataType.GetProperties();

            // Get type of each U's property
            int propertyCount = dataTypeProperties.Length;
            Type[] dataTypePropertiesTypes = new Type[propertyCount];
            for (int i = 0; i < propertyCount; i++)
            {
                dataTypePropertiesTypes[i] = dataTypeProperties[i].PropertyType;
            }

            // Open connection to the DB
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                // Construct SqlCommand based on sqlMessage
                SqlCommand command = ConstructSqlCommand(cnn, sqlMessage);

                // Iterate through reader
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Fill array with one record of values from table matching U Type
                    // IMPORTANT!!! U Type properties have do be defined exactly in the same order as column in coresponding DB table
                    object[] UObjectConstructorParameters = new object[propertyCount];
                    for (int i = 0; i < propertyCount; i++)
                    {
                        UObjectConstructorParameters[i] = reader[$"{dataTypeProperties[i].Name}"]; ;
                    }

                    // Find constractor for U type based on properties
                    ConstructorInfo constructor = dataType.GetConstructor(dataTypePropertiesTypes);

                    // Instantiate U type using constructor and parameters values
                    object dataInstance = constructor.Invoke(UObjectConstructorParameters);
                    result.Add((U)dataInstance);

                }
            }

            return result;
        }

        private SqlCommand ConstructSqlCommand(SqlConnection cnn, SqlMessage sqlMessage)
        {
            SqlCommand result = new SqlCommand();
            result.Connection = cnn;

            // Check if sqlCommand is query, function or stored procedure
            switch (sqlMessage.Type)
            {
                case SqlMessageType.Query:
                    {
                        break;
                    }
                case SqlMessageType.UserDefinedFunction:
                    {
                        result.CommandType = System.Data.CommandType.Text;
                        result.Connection = cnn;

                        // Check for parameters
                        if(sqlMessage.Parameters.Length < 0)
                        {
                            // In case of zero parameters query is just as simple
                            result.CommandText = "SELECT * FROM " + sqlMessage.SqlBody + "()";
                        }
                        else
                        {
                            // Collect info about function's paramters
                            SqlObjectInfo ufnInfo = GetSqlObjectInfo(cnn, sqlMessage.SqlBody);

                            result.CommandText = "SELECT * FROM " + sqlMessage.SqlBody + "(";
                            foreach(SqlObjectParameter parameter in ufnInfo.Parameters)
                            {
                                // Pass parameters exactly in a way defined by function definition
                                // Order of parameters in ufnInfo is correct order of passing parameters to the function
                                SqlMessageParameter sqlMessageParameter = sqlMessage.Parameters.Where(p => p.Name.ToUpper() == parameter.ParameterName.ToUpper()).FirstOrDefault();
                                result.CommandText += sqlMessageParameter.Value != null ? sqlMessageParameter.Value is string ? $"'{sqlMessageParameter.Value}', " : $"{sqlMessageParameter.Value}, " : "NULL, ";
                            }

                            // Cut additional ", " from query
                            result.CommandText = result.CommandText.Substring(0, result.CommandText.Length - 2);
                            result.CommandText += ")";
                        }
                        break;
                    }
                case SqlMessageType.UserDefinedStoredProcedure:
                    {
                        result.CommandType = System.Data.CommandType.StoredProcedure;
                        result.CommandText = sqlMessage.SqlBody;
                        if(sqlMessage.Parameters.Length > 0)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            foreach(object messageParameter in sqlMessage.Parameters)
                            {
                                sqlParameter.Value = messageParameter;
                            }
                        }
                        break;
                    }
                default:
                    {
                        throw new MissingFieldException("No SqlMessegeType provided");
                    }
            }

            return result;
        }

        private SqlObjectInfo GetSqlObjectInfo(SqlConnection cnn, string objectName)
        {
            SqlObjectInfo objectInfo = new SqlObjectInfo();

            objectName = objectName.Split(".").Last();

            // Get info about SQL Objcet
            SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[ufn_GetObjectInfo]('{objectName}')", cnn);
            command.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            if (reader["ObjectName"] == null)
                throw new ArgumentException("Invalid ObjectName");

            objectInfo.Schema = (string)reader["Schema"];
            objectInfo.ObjectName = (string)reader["ObjectName"];
            objectInfo.ObjectType = (string)reader["ObjectType"];
            objectInfo.Parameters = new List<SqlObjectParameter>();

            do
            {
                if ((string)reader["ObjectName"] != objectInfo.ObjectName)
                    throw new ArgumentException("Multiple object of the same name");

                // List of parameters is constructed in order in which they are meant to be passed to the function/stored procedure
                objectInfo.Parameters.Add(new SqlObjectParameter()
                {
                    ParameterId = (int)reader["ParameterId"],
                    ParameterName = (string)reader["ParameterName"],
                    ParameterDataType = (string)reader["ParameterDataType"],
                    ParameterMaxBytes = (Int16)reader["ParameterMaxBytes"],
                    IsOutputParameter = (bool)reader["IsOutputParameter"]
                });
            } while (reader.Read());

            reader.Close();
            reader.DisposeAsync();

            return objectInfo;
        }
    }
}
