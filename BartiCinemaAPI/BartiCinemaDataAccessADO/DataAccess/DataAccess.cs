using BartiCinemaDataAccessADO.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public List<U> LoadData<U>(string connectionString, string functionName)
        {
            List<U> result = new List<U>();

            Type dataType = typeof(U);
            PropertyInfo[] dataTypeProperties = dataType.GetProperties();

            int propertyCount = dataTypeProperties.Length;
            Type[] dataTypePropertiesTypes = new Type[propertyCount];
            for (int i = 0; i < propertyCount; i++)
            {
                dataTypePropertiesTypes[i] = dataTypeProperties[i].PropertyType;
            }

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {functionName}()", cnn);
                command.CommandType = System.Data.CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object[] UObjectConstructorParameters = new object[propertyCount];
                    for (int i = 0; i < propertyCount; i++)
                    {
                        UObjectConstructorParameters[i] = reader[$"{dataTypeProperties[i].Name}"]; ;
                    }

                    ConstructorInfo constructor = dataType.GetConstructor(dataTypePropertiesTypes);
                    object dataInstance = constructor.Invoke(UObjectConstructorParameters);
                    result.Add((U)dataInstance);

                }
            }

            return result;
        }
    }
}
