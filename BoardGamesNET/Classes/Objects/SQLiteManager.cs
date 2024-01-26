using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    public class SQLiteManager
    {
        public struct DbResultStruct
        {
            public Type Type { get; init; }
            public object Value { get; init; }

            public DbResultStruct(Type type, object value)
            {
                Type = type;
                Value = value;
            }
        }

        private string _DbPath;

        public string DbPath
        {
            get
            {
                return _DbPath;
            }
            init
            {
                _DbPath = value;
            }
        }
        public string ConnectionString => $"Data Source={DbPath};";

        public SQLiteManager(string dbPath)
        {
            DbPath = dbPath;
        }

        public bool ExecuteReaderQuery(string sqlQuery, out List<Dictionary<string, DbResultStruct>> dbResult)
        {
            dbResult = new List<Dictionary<string, DbResultStruct>>(0);

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Dictionary<string, DbResultStruct> row = new Dictionary<string, DbResultStruct>(0);

                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                string columnName = rdr.GetName(i);
                                Type type = rdr.GetFieldType(i);
                                object value = rdr.GetValue(i);

                                row.Add(columnName, new DbResultStruct(type, value));
                            }

                            dbResult.Add(row);
                        }

                        rdr.Close();
                    }

                    cmd.Dispose();
                }

                conn.Close();
                conn.Dispose();
            }

            return true;
        }

        public int ExecuteQuery(string sqlQuery)
        {
            int result = -1;

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    result = cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }

                conn.Close();
                conn.Dispose();
            }

            return result;
        }

        public static dynamic ConvertValue(DbResultStruct result)
        {
            switch (result.Type.ToString())
            {
                case "System.String":
                    return (string)result.Value;
                case "System.Int64":
                    return (long)result.Value;
                default:
                    throw new FormatException($"{result.Type} format not managed.");
            }
        }
    }
}
