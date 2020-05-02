using Bakalauras_2020.StaticClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakalauras_2020.Utility
{
    static class Sql
    {
        public static bool UseTransaction = false;

        public static readonly string LogActionSql = "LogAction";

        //public static SqlConnection conn = new SqlConnection(@"server=192.168.5.61\MSSQL2012;User ID=Terra ERP;password=numKvA1s7vGl;database=Ryterna Modul TEST;Integrated Security=False;"/*Globals.ConnectionString*/);        
        public static SqlConnection conn = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=Bakalauras;Trusted_Connection=True;");
        public static SqlTransaction transaction = null;

        public static string ErrorLogLoc = "../../Data/ErrorLog.txt";
        public static string SqlLogLoc = "../../Data/SqlLog.txt";

        public static void LogError(string errorMsg, string Command, object[] Args = null, string Elapsed = "")
        {
            try
            {
                using (StreamWriter writer = File.AppendText(ErrorLogLoc))
                {
                    int i = 0;
                    string errorInput = string.Empty;
                    errorInput += "[" + DateTime.Now + "] <Error: " + errorMsg + ">" + " Used Sql: " + Command + " Used arguments: ";
                    if (Args != null)
                    {
                        if ((Args != null) && (Args.Length > 0))
                        {
                            while (i < Args.Length)
                            {
                                errorInput += Args[i].ToString() + ":" + NullCheck.IsNullString(Args[i + 1]) + " ";
                                i = i + 2;
                            }
                        }
                    }
                    writer.WriteLine(errorInput);
                }
            }
            catch(Exception e)
            {

            }
        }

        public static void LogSql(string Command, object[] Args = null, string Elapsed = "")
        {
            try
            {
                using (StreamWriter writer = File.AppendText(SqlLogLoc))
                {
                    int i = 0;
                    string sqlInput = string.Empty;
                    sqlInput += $"[{DateTime.Now}   Elapsed: {string.Format("{0,10}", Elapsed + "ms")} User: {string.Format("{0,8}", GlobalUser.Username)}] {Command}(";
                    if (Args != null)
                    {
                        if ((Args != null) && (Args.Length > 0))
                        {
                            while (i < Args.Length)
                            {
                                sqlInput += Args[i].ToString() + ":" + NullCheck.IsNullString(Args[i + 1]) + " ";
                                i = i + 2;
                            }
                        }
                    }
                    writer.WriteLine(sqlInput + ");");
                }
            }
            catch (Exception e)
            {

            }
        }

        public static void OpenConn()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public static DataTable GetTable(string CommandName, object[] Args)
        {
            try
            {
                OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(CommandName, conn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (UseTransaction) sda.SelectCommand.Transaction = transaction;
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i].ToString(), Args[i + 1]);
                        sda.SelectCommand.Parameters.Add(param);
                        i = i + 2;
                    }
                }
                DataTable dt = new DataTable();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sda.Fill(dt);
                stopwatch.Stop();
                LogSql(CommandName, Args, stopwatch.ElapsedMilliseconds.ToString());
                return dt;
            }
            catch (Exception E)
            {
                LogError(E.Message, CommandName, Args);
                return null;
            }
        }

        public static DataTable GetTable(string Query)
        {
            try
            {
                OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
                sda.SelectCommand.CommandType = CommandType.Text;
                if (UseTransaction) sda.SelectCommand.Transaction = transaction;
                DataTable dt = new DataTable();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sda.Fill(dt);
                stopwatch.Stop();
                LogSql(Query, Elapsed:stopwatch.ElapsedMilliseconds.ToString());
                return dt;
            }
            catch (Exception E)
            {
                LogError(E.Message, Query);
                return null;
            }
        }

        public static int ExecuteCmd(string SqlStatement)
        {
            try
            {
                OpenConn();
                SqlCommand comm = new SqlCommand(SqlStatement, conn);
                comm.CommandType = CommandType.Text;
                if (UseTransaction) comm.Transaction = transaction;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int res = comm.ExecuteNonQuery();
                stopwatch.Stop();
                LogSql(SqlStatement, Elapsed:stopwatch.ElapsedMilliseconds.ToString());
                return res;
            }
            catch (Exception E)
            {
                LogError(E.Message, SqlStatement);
                return 0;
            }
        }

        public static int ExecuteCmd(string CommandName, object[] Args)
        {
            try
            {
                OpenConn();
                SqlCommand comm = new SqlCommand(CommandName, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (UseTransaction) comm.Transaction = transaction;
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i].ToString(), Args[i + 1]);
                        comm.Parameters.Add(param);
                        i = i + 2;
                    }
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int res = comm.ExecuteNonQuery();
                stopwatch.Stop();
                LogSql(CommandName, Args, stopwatch.ElapsedMilliseconds.ToString());
                return res;
            }
            catch (Exception E)
            {
                LogError(E.Message, CommandName, Args);
                return 0;
            }
        }

        public static int LogAction(object[] Args)
        {
            try
            {
                OpenConn();
                SqlCommand comm = new SqlCommand(LogActionSql, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (UseTransaction) comm.Transaction = transaction;
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i].ToString(), Args[i + 1]);
                        comm.Parameters.Add(param);
                        i = i + 2;
                    }
                }
                int res = comm.ExecuteNonQuery();
                return res;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return 0;
            }
        }

        public static string ExecuteIdentCmd(string CommandName, string[] Args)
        {
            try
            {
                OpenConn();
                SqlCommand comm = new SqlCommand(CommandName, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (UseTransaction) comm.Transaction = transaction;
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i], Args[i + 1]);
                        comm.Parameters.Add(param);
                        i = i + 2;
                    }
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                object res = comm.ExecuteNonQuery();
                stopwatch.Stop();
                LogSql(CommandName, Args, stopwatch.ElapsedMilliseconds.ToString());
                if (res != null) return res.ToString();
                else return "0";
            }
            catch (Exception E)
            {
                LogError(E.Message, CommandName, Args);
                return "0";
            }
        }

        public static string ExecuteScalar(string CommandName, object[] Args)
        {
            try
            {
                OpenConn();
                SqlCommand comm = new SqlCommand(CommandName, conn);
                if (UseTransaction) comm.Transaction = transaction;
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i].ToString(), Args[i + 1]);
                        comm.Parameters.Add(param);
                        i = i + 2;
                    }
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                object res = comm.ExecuteNonQuery();
                stopwatch.Stop();
                LogSql(CommandName, Args, stopwatch.ElapsedMilliseconds.ToString());
                if (res != null) return res.ToString();
                else return "";
            }
            catch (Exception E)
            {
                LogError(E.Message, CommandName, Args);
                return "";
            }
        }

        public static int ExecuteCmd(string CommandName, string[] Args, string[] FileNames)
        {
            //iterpia i DB paprastus parametrus Args, ir Image tipo parametrus FileName
            try
            {
                OpenConn();
                SqlCommand cmd = new SqlCommand(CommandName, conn);

                if (UseTransaction) cmd.Transaction = transaction;

                // add parameters
                int i = 0;
                if ((Args != null) && (Args.Length > 0))
                {
                    while (i < Args.Length)
                    {
                        SqlParameter param = new SqlParameter(Args[i], Args[i + 1]);
                        cmd.Parameters.Add(param);
                        i = i + 2;
                    }
                }

                i = 0;
                // add files

                if ((FileNames != null) && (FileNames.Length > 0))
                {
                    while (i < FileNames.Length)
                    {
                        FileStream file = new FileStream(FileNames[i + 1], FileMode.Open, FileAccess.Read);
                        int len = Convert.ToInt32(file.Length);
                        byte[] stream = new byte[len];
                        file.Read(stream, 0, len);
                        cmd.Parameters.AddWithValue(FileNames[i], stream);
                        i = i + 2;
                    }
                }

                // execute query
                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return 0;
            }
        }

        public static int ExecuteCmd(string CommandName, List<string> Args, List<string> FileNames)
        {
            //iterpia i DB paprastus parametrus Args, ir Image tipo parametrus FileName
            try
            {
                OpenConn();
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (UseTransaction) cmd.Transaction = transaction;

                // add parameters
                int i = 0;
                if ((Args != null) && (Args.Count > 0))
                {
                    while (i < Args.Count)
                    {
                        SqlParameter param = new SqlParameter(Args[i], Args[i + 1]);
                        cmd.Parameters.Add(param);
                        i = i + 2;
                    }
                }

                i = 0;
                // add files

                if ((FileNames != null) && (FileNames.Count > 0))
                {
                    while (i < FileNames.Count)
                    {
                        if (FileNames[i + 1] != null)
                        {
                            FileStream file = new FileStream(FileNames[i + 1], FileMode.Open, FileAccess.Read);
                            int len = Convert.ToInt32(file.Length);
                            byte[] stream = new byte[len];
                            file.Read(stream, 0, len);
                            cmd.Parameters.AddWithValue(FileNames[i], stream);
                            i = i + 2;
                        }
                        else
                        {
                            //cmd.Parameters.Add(FileNames[i], SqlDbType.NVarChar);
                            //cmd.Parameters.Add(null, SqlDbType.Image);
                            cmd.Parameters.AddWithValue(FileNames[i], null);
                            i = i + 2;
                        }
                    }
                }

                // execute query
                int result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (SqlException E)
            {
                Console.WriteLine(E.Message);
                return 0;
            }
        }

        public static string GetString(string Query)
        {
            return GetString(Query, true);
        }

        public static string GetString(string Query, bool showEx)
        {
            try
            {
                OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                sda.SelectCommand.CommandType = CommandType.Text;
                if (UseTransaction) sda.SelectCommand.Transaction = transaction;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                object res = sda.SelectCommand.ExecuteScalar().ToString();
                stopwatch.Stop();
                LogSql(Query, Elapsed:stopwatch.ElapsedMilliseconds.ToString());
                if (res != null) return res.ToString();
                else return string.Empty;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                LogError(E.Message,Query);
                return string.Empty;
            }
        }
    }
}
