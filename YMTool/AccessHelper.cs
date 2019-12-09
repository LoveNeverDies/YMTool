﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace YMTool
{
    public interface IAccessHelper
    {
        int ExecuteNonQuery(string sql, params SqlParameter[] pms);
        object ExecuteScalar(string sql, params SqlParameter[] pms);
        OleDbDataReader ExecuteReader(string sql, params SqlParameter[] pms);
        DataTable ExecuteDataTable(string sql, params SqlParameter[] pms);
        DataSet ExecuteDataSet(string sql, params SqlParameter[] pms);
    }
    class AccessHelper : IAccessHelper
    {
        public AccessHelper(string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=YMTool.mdb")
        {
            ConnectionString = connection;
        }
        string ConnectionString { get; set; }

        //1.执行增、删、改的方法：ExecuteNonQuery
        int IAccessHelper.ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //2.封装一个执行返回单个对象的方法：ExecuteScalar()
        object IAccessHelper.ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }


        //3.执行查询多行多列的数据的方法：ExecuteReader
        OleDbDataReader IAccessHelper.ExecuteReader(string sql, params SqlParameter[] pms)
        {
            OleDbConnection con = new OleDbConnection(ConnectionString);
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //4.执行返回DataTable的方法
        DataTable IAccessHelper.ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, ConnectionString))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

        DataSet IAccessHelper.ExecuteDataSet(string sql, params SqlParameter[] pms)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    if (pms != null)
                    {
                        da.SelectCommand.Parameters.AddRange(pms);
                    }
                    da.Fill(dataSet);
                    return dataSet;
                }
            }
        }
    }
}
