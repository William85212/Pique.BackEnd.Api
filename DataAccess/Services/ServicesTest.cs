using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;

namespace DataAccess.Services
{
    public class ServicesTest : IServicesTest
    {
        private Connection _connection;
        private string _connString;

        public ServicesTest(IConfiguration config)
        {
            _connString = config.GetConnectionString("_connS");
            _connection = new Connection(SqlClientFactory.Instance, _connString);
        }

        public IEnumerable<TestModel> GetMessage()
        {
            Command cmd = new Command("SELECT * FROM dbo.TableTest");

            _connection.Open();
            IEnumerable<TestModel> messages = _connection.ExecuteReader(cmd, ConverteurMessage).ToList();
            _connection.Close();

            return messages;
        }

        public TestModel ConverteurMessage(IDataReader reader)
        {
            return new TestModel
            {
                Id = (int)reader["Id"],
                MessageTest = reader["MessageTest"].ToString()
            };
        }
    }
}

