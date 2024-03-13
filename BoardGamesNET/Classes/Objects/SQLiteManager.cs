using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    /// <summary>
    /// Class that manage the connection with the DataBase SQLite.
    /// </summary>
    public class SQLiteManager
    {
        #region ===== STRUCTS =====
        /// <summary>
        /// Struct with the information of data retrieved from DataBase.
        /// </summary>
        public struct DbResultStruct
        {
            /// <summary>
            /// Type of the element.
            /// </summary>
            public Type Type { get; init; }
            /// <summary>
            /// Value of the element.
            /// </summary>
            public object Value { get; init; }

            /// <summary>
            /// Initialize the struct.
            /// </summary>
            /// <param name="type">Type of the element.</param>
            /// <param name="value">Value of the element.</param>
            public DbResultStruct(Type type, object value)
            {
                Type = type;
                Value = value;
            }
        }
        #endregion

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private string _DbPath;
        #endregion

        /// <summary>
        /// Path of the SQLite DataBase.
        /// </summary>
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

        /// <summary>
        /// SQLite connection string.
        /// </summary>
        public string ConnectionString => $"Data Source={DbPath};";
        #endregion

        /// <summary>
        /// Initialize this class.
        /// </summary>
        /// <param name="dbPath">Path of the SQLite DataBase file.</param>
        public SQLiteManager(string dbPath)
        {
            DbPath = dbPath;
        }

        /// <summary>
        /// Execute a SQL query with reading result.
        /// </summary>
        /// <param name="sqlQuery">SQL query.</param>
        /// <param name="dbResult">(out) Result of the SQL query.</param>
        /// <returns><see langword="true"/> if query is executed correctly, otherwise <see langword="false"/>.</returns>
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

        /// <summary>
        /// Execute the SQL query without reading the result.
        /// </summary>
        /// <param name="sqlQuery">SQL query to execute.</param>
        /// <returns>Number of rows that are managed.</returns>
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

        /// <summary>
        /// Convert automatically the value retrieved from database.
        /// </summary>
        /// <param name="result">Database retrieved result.</param>
        /// <returns></returns>
        /// <exception cref="FormatException">The type retrieved from database is not managed.</exception>
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
