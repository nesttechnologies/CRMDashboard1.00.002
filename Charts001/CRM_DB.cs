﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Charts001
{
    public class CRM_DB
    {
        /*
        static void Main(string[] args)
        {
            GetDBdata();
            Console.WriteLine();
            Console.ReadKey();

        }
        */

        //receive data from SQL Server -> store data as the model 
        public static string GetDBdata()  //IList<IndustrySequrModel> 
        {
            SqlConnection conn = new SqlConnection(@"Server= LAPTOP-JDV1D5J5\SQLEXPRESS; Database=CRM; User Id=sa; Password = 1234;");
            conn.Open();
            string querySelect = @"SELECT fort.ID, fort.Title, fort.Industry, fort.Sector, sec.SecurLevel FROM Fortune500 As fort, SecurityLevel As sec
                                     WHERE fort.INDUSTRYID = sec.ID";

            SqlCommand cmd = new SqlCommand(querySelect, conn);
            cmd.ExecuteNonQuery();

            // create data adapter
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);

            //query your database and return the result to your datatable
            DataTable dataTable = new DataTable();
            dataAdapt.Fill(dataTable);

            conn.Close();
            dataAdapt.Dispose();

            var industrySec = dataTable.MapTableToList<IndustrySequrModel>();
            Console.WriteLine("Data Received Successfully");



            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);

            //return industrySec;
        }
    }

    //Class Model in which data from SQL will be store 
    public class IndustrySequrModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public decimal SecurLevel { get; set; }
    }


    public static class ExtensionMethods
    {
        public static List<T> MapTableToList<T>(this DataTable table) where T : new()
        {
            List<T> result = new List<T>();
            var Type = typeof(T);

            foreach (DataRow row in table.Rows)
            {
                T item = new T();
                foreach (var property in Type.GetProperties())
                {
                    property.SetMethod.Invoke(item, new object[] { row[table.Columns[property.Name]] });
                }
                result.Add(item);
            }

            return result;
        }
    }
}
