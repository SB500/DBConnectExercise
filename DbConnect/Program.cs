using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnect
{
    public abstract class DbConnection
    {
        private string ConnectionString { get; set; }

        private TimeSpan TimeOut { get; set; }

        public DbConnection(string connectionString)
        {            
            Console.WriteLine($"Connection String = {connectionString}");
            this.ConnectionString = connectionString;
        }

        public abstract void OpenConnection();

        public abstract void CloseConnection();

    }


    public class SqlConnection : DbConnection
    {

        public SqlConnection(string connectionString)
            : base(connectionString)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Connection Opened: SQL");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Connection Closed: SQL");
        }
    }

    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString)
            : base(connectionString)
        {
        }
        public override void OpenConnection()
        {
            Console.WriteLine("Connection Opened: Oracle");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Connection Closed: Oracle");
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter DataBase name: sql || oracle");
                var connectionString = Console.ReadLine().ToLower();

                if (connectionString == "sql")                   
                    {
                        var sql = new SqlConnection(connectionString);
                        sql.OpenConnection();
                            Console.WriteLine("Type 'exit' to close connection");
                            var exit = Console.ReadLine().ToLower();
                            if (exit == "exit")
                            {
                                sql.CloseConnection();
                                Console.ReadLine();
                            }
                            else
                                throw new Exception("Input did not equal exit");
                            }
                else if (connectionString == "oracle")
                    {
                        var oracle = new OracleConnection(connectionString);
                        oracle.OpenConnection();
                            Console.WriteLine("Type 'exit' to close connection");
                            var exit = Console.ReadLine().ToLower();
                            if (exit == "exit")
                            {
                                oracle.CloseConnection();
                                Console.ReadLine();
                            }
                            else
                                throw new Exception("Input did not equal exit");
                            }
                else
                    { 
                        throw new NullReferenceException("In correct input");
                    }

                Console.Clear();
                Console.WriteLine("Exit 'ctrl c' ");
                continue;                
            }
        }
    }
}