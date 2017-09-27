using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FusionCharts.Charts;
using System.Text;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;
using System.Web.Hosting;

namespace Charts001
{
    public partial class JSON1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] eqn = new string[10];
            long i = 0;
            eqn[1] = "Yp = 0.2*X1 + 0.2*X2 + 0.2*X3 + 0.2*X4 + 0.2*X5 +...- 1";
            eqn[2] = "Yp = 0.2*X1 + 0.2*X2 + 0.2*X3 + 0.2*X4 + 0.2*X5 +...- 0.0234";
            eqn[3] = "Yp = 0.35*X1 + 0.15*X2 + 0.1*X3 + 0.02*X4 + 0.28*X5 +...- 0.45";
            eqn[4] = "Yp = 0.35*X1 + 0.12*X2 + 0.13*X3 + 0.08*X4*X4 + 0.01*X4 - 0.32*X5 +...+ 0.0023";
            eqn[5] = "Yp = 0.25*eX1 + 0.22*X2 + 0.08*X4*X4 + 0.01*X4 - 0.31*X5 +...- 0.00213";
            eqn[6] = "Yp = 1.234*eX1 + 0.976*log(2*X2) + 0.0056*X4*X4 + 0.001*X4 - 0.3123*X5 +...- 0.00198";
            eqn[7] = "Yp = 1.496*eX1 + 0.976*log(2.567*X2) + 0.0056*X4*X4 + 0.001*X4 - 0.31167*X5 +...- 0.000287";
            eqn[8] = "Yp = 1.3647*e(0.67*X1) + 0.9563*log(2.217*X2) + 0.00492*X4*X4 + 0.00164*X4 - 0.30645*X5 +...- 0.000175";
            eqn[9] = "Yp = 1.3456*e(0.528*X1) + 0.8654*log(1.657*X2) + 0.0000123*X4*X4*X4 + 0.00062*X4*X4 + 0.000964*X4 - 0.27567*X5 +...- 0.000129";
            eqn[0] = "Yp = 1.3523*e(0.5186*X1) + 0.8958*log(1.831*X2) + 0.00000238*X4*X4*X4 + 0.000567*X4*X4 + 0.000876*X4 - 0.25412*X5 +...- 0.000012876";
            if (Convert.ToInt64(Session["refresh_count"]) < 9)
            {
                Session["refresh_count"] = Convert.ToInt64(Session["refresh_count"]) + 1;
                i = Convert.ToInt64(Session["refresh_count"]);
                LabelEqn.Text = eqn[i];
            }
           else
            {
                Session.Clear();
                LabelEqn.Text = eqn[0];
            }
            
            //1-Harini
            GetColorH();
            //string path = VirtualPathUtility.ToAbsolute("~/App_Data/Employee.json");
            //string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"../Charts001/JSON/Employee.json");

            Chart sales9 = new Chart("column2d", "myChartH", "320", "250", "jsonurl", "../Data/Employee.json", "000000", "100"); // ../Data/Data.json
                                                                                                               // Render the chart
            Literal1.Text = sales9.Render();
            //GetDataSourceH();


            // 2 -Ganesh

            GetColor_revenue();
            Chart sales = new Chart("column2d", "myChartG", "320", "250", "jsonurl", "../Data/json_revenue.json","000000", "100"); // ../Data/Data.json
            Literal2.Text = sales.Render();

            //Dariia
            //Build & Render the chart
            GetColor2();
            Chart barchart = new Chart("bar2d", "myChart1", "320", "250", "jsonurl", "../Data/barchart_top_10.json", "000000", "100");            
            Literal4.Text = barchart.Render();

            GetDataSource();
            Chart gaugeangular = new Chart("angulargauge", "myChart2", "320", "250", "jsonurl", "../Data/angular.json", "000000", "100"); 
            Literal10.Text = gaugeangular.Render();
            /*
                        Chart sales3 = new Chart("pyramid", "myChart3", "600", "350", "jsonurl", "../Data/pyramid.json"); // ../Data/Data.json
                        // Render the chart
                        Literal3.Text = sales3.Render();
                         */
            /*
Chart doughnutInd = new Chart("bar2d", "myChart4", "600", "350", "jsonurl", "../Data/new.json"); // ../Data/Data.json
// Render the chart doughnut2d
Literal4.Text = doughnutInd.Render();*/
            /*
            GetDataSource2();
            GetDataSource3();
            
            Chart cri_vs_industry = new Chart("mscolumn2d", "myChart3", "300", "250", "jsonurl", "../Data/barreslevel.json", "000000", "100"); //
            Literal2.Text = cri_vs_industry.Render();

            */

            /***************************************************/
            //Chenyang Feng
            /*
            GetColor();
            Chart correlationGraph = new Chart("bar3d", "myChart", "300", "250", "jsonurl", "../Data/CRBarForCompany.json", "000000", "100");
            // Render the chart
            Literal4.Text = correlationGraph.Render();
            GetData4();
            Chart companySample = new Chart("angulargauge", "myChart5", "300", "250", "jsonurl", "../Data/piChart.json", "000000", "100");
            Literal5.Text = companySample.Render();

            Chart databaseSeach = new Chart("column3d", "myChart4", "300", "250", "jsonurl", "../Data/CRbar.json", "000000", "100");
            // Render the chart
            Literal6.Text = databaseSeach.Render();
            */
            GetColor();

            Chart correlationGraph = new Chart("area2d", "myChart", "320", "250", "jsonurl", "../Data/CRBarForCompany.json", "000000", "100");
            Literal3.Text = correlationGraph.Render();

            //Vishakh


            GetDataSourceVS();
            nameChange();
            Chart sales2 = new Chart("bar2d", "myChartV", "320", "250", "jsonurl", "../Data/dtstojson.json", "000000", "100"); // ../Data/Data.json
            Literal6.Text = sales2.Render();


            GetColorVIS();
            Chart sales10 = new Chart("column2d", "myChartM", "320", "250", "jsonurl", "../Data/json_leak.json", "000000", "100"); // ../Data/Data.json
            //Chart sales11 = new Chart("column2d", "myChartH", "320", "250", "jsonurl", "../Data/json_Sensitivity.json", "000000", "100");                                                                                                                     // Render the chart
            // Chart sales12 = new Chart("column2d", "myChartH", "320", "250", "jsonurl", "../Data/json_Action.json", "000000", "100");
            Literal5.Text = sales10.Render();

        }


        //protected void SearchData(object sender, EventArgs e)
        //{
        //    Page_Load(null, null);
        //}

        private string GetDataSource()
        {
            var responseFromDb = "0";
            //if (Text1.Text != "")
            //{
                //var text = Text1.Text;
                responseFromDb = PreviousPage.OverallCRI;
                
            //}

            var json2Path = @"C:\Workfolder\CRMDashboard\Charts001\Data/angular.json";
            //ozapros w bazu, poluczili otwet
            //otkryli fail
            JObject o1 = JObject.Parse(File.ReadAllText(json2Path));
            //mieniajem znaczenie to czto tebe nożno 
            o1["dials"]["dial"][0]["value"] = string.Format("{0}", responseFromDb);
            //o1["categories"]["category"][0]["value"] = string.Format("{0}", responseFromDb);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(json2Path))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                o1.WriteTo(writer);
            }
            
            return json2Path;
        }

        private string GetdataDb(string text)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);

            string strQuery = @"SELECT CRI FROM Fortune500 WHERE Title like '%'+ @industry + '%'";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.AddWithValue("@industry", text.Trim());
            DataTable dt = GetData(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();
            //return "9";
        }

        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            //String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }







        private string GetDataSource2()//
        {
            var responseFromDb = "0";

           // var responseFromDb2 = "0";
            if (Text1.Text != "")
            {
                responseFromDb = GetdataFromDb2(Text1.Text);
               // responseFromDb2 = GetdataFromDb22(Text1.Text);
            }
            var json2Path = @"C:\Workfolder\CRMDashboard\Charts001\Data/barreslevel.json";
            
            JObject o1 = JObject.Parse(File.ReadAllText(json2Path));
           
            o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
           // o1["dataset"][1]["data"][0]["value"] = string.Format("{0}", responseFromDb2);
            // o1["categories"][0]["category"][0]["label"] = string.Format("{0}", responseFromDb);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(json2Path))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                o1.WriteTo(writer);
            }

            return json2Path;
        }
        private string GetdataFromDb2(string text)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            // SqlConnection conn = new SqlConnection(@"Server= tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password = sa#1234;");
            string industry = PreviousPage.Industrypass;
            string strQuery = @"SELECT sec.SecurLevel FROM SecurityLevel WHERE SecurIndustry like '%'"+ industry + "'%'";

            //, sec.SecurIndustry

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.AddWithValue(industry, text.Trim());
            DataTable dt = GetData2(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();
        }
        private string GetdataFromDb22(string text)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            //SqlConnection conn = new SqlConnection(@"Server= tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password = sa#1234;");
            
            // string strQuery = @"SELECT sec.BreachLevel FROM Fortune500 As fort inner join
            //                   SecurityLevel As sec ON fort.IndustryID = sec.ID WHERE fort.Title like '%'+ @industry + '%'";
            //, sec.SecurIndustry
             string strQuery = @"SELECT sec.BreachLevel FROM Fortune500 As fort inner join
                               SecurityLevel As sec ON fort.IndustryID = sec.ID WHERE fort.Title like '%'+ @industry + '%'";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.AddWithValue("@industry", text.Trim());
            DataTable dt = GetData22(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();
        }

        private DataTable GetData2(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        private DataTable GetData22(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        private string GetColor2()
        {
            var dataDB = GetdataFromDb3(Text1.Text);
            var jsonPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/barchart_top_10.json";
            if (dataDB != "Click 'GO' ")
            {
                //var dataDB = GetDataSource();
                //var x = decimal.Parse(dataDB, CultureInfo.InvariantCulture.NumberFormat);
                // var jsonPath = @"C:\Users\fcyfcy\Desktop\CRM_Subsidiaries\Charts001\Charts001\Data\json.json";

                JObject o1 = JObject.Parse(File.ReadAllText(jsonPath));
                for (int i = 0; i <=9; i++)
                {
                    var x =o1["data"][i]["label"]+"";
                    if(dataDB.Contains(x))
                    {
                        //o1["data"][i]["color"]= string.Format("{0}", "#E63287");//PINK
                        o1["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY

                    }
                    else
                    {
                        //o1["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                        o1["data"][i]["color"] = string.Format("{0}", "#1a8cff");//NEWBLUE
                    }
                    //int y = Convert.ToInt2(o1["dataset"][0]["data"][i]["label"]);
                    //int y2 = Convert.ToInt32(o1["dataset"][0]["data"][i - 1]["label"]);
                   /* if (y2 >= x && y < x)
                    {
                        o1["data"][i]["color"] = string.Format("{0}", "#cb1126");

                    }
                    else
                    {
                        o1["data"][i]["color"] = string.Format("{0}", "#0000ff");
                        // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                    }*/
                }
                using (StreamWriter file = File.CreateText(jsonPath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
            }

            return jsonPath;

            //o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
        }







        private string GetDataSource3()//
        {
            var responseFromDb = "0";
            if (Text1.Text != "")
            {
                responseFromDb = GetdataFromDb3(Text1.Text);
            }
            var json2Path = @"C:\Workfolder\CRMDashboard\Charts001\Data/barreslevel.json";
            //ozapros w bazu, poluczili otwet


            //otkryli fail
            JObject o1 = JObject.Parse(File.ReadAllText(json2Path));
            //mieniajem znaczenie to czto tebe nożno 
           // o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
            o1["categories"][0]["category"][0]["label"] = string.Format("{0}", responseFromDb);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(json2Path))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                o1.WriteTo(writer);
            }

            return json2Path;
        }
        private string GetdataFromDb3(string text)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            // SqlConnection conn = new SqlConnection(@"Server= tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password = sa#1234;");

            string strQuery = @"SELECT sec.SecurIndustry FROM Fortune500 As fort inner join
                                SecurityLevel As sec ON fort.IndustryID = sec.ID WHERE fort.Title like '%'+ @industry + '%'";

            //, sec.SecurIndustry

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.AddWithValue("@industry", text.Trim());
            DataTable dt = GetData3(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();
        }

        private DataTable GetData3(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            //SqlConnection con = new SqlConnection(@"Server= tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password = sa#1234;");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

       
        private string GetDataSource4()
        {
            var responseFromDb = "0";
            if (Text1.Text != "")
            {
                responseFromDb = GetdataFromDb4(Text1.Text);
            }
            else
            {
                responseFromDb = "Click 'GO' ";
            }
            return responseFromDb;

        }

        private string GetdataFromDb4(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            //string access_link = (@"Server=tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password = sa#1234;");
            // SqlConnection conn = new SqlConnection(access_link);
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string matchingPerson = "";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson = oReader["cyberResilience"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson;
        }



        protected void Text2_TextChanged(object sender, EventArgs e)
        {

        }
        private string GetData4()
        {
            var responseFromDb = GetDataSource4();
            var json2Path = @"C:\Workfolder\CRMDashboard\Charts001\Data/piChart.json";
            JObject o1 = JObject.Parse(File.ReadAllText(json2Path));
            o1["dials"]["dial"][0]["value"] = string.Format("{0}", responseFromDb);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(json2Path))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                o1.WriteTo(writer);
            }

            return json2Path;
        }
        private string GetColor()
        {
            var dataDB = GetDataSource4();
            var jsonPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/CRBarForCompany.json";
            if (dataDB != "Click 'GO' ")
            {
                //var dataDB = GetDataSource();
                var x = float.Parse(dataDB, CultureInfo.InvariantCulture.NumberFormat);
                // var jsonPath = @"C:\Users\fcyfcy\Desktop\CRM_Subsidiaries\Charts001\Charts001\Data\json.json";

                JObject o1 = JObject.Parse(File.ReadAllText(jsonPath));
                for (int i = 9; i > 0; i--)
                {
                    int y = Convert.ToInt32(o1["data"][i]["label"]);
                    int y2 = Convert.ToInt32(o1["data"][i - 1]["label"]);
                    if ((y2 <= x && y > x) || (y2 < x && y >= x) || (y2 < x && y > x))
                    {
                        // o1["data"][i]["anchorBgColor"] = string.Format("{0}", "#E63287");//PINK
                        o1["data"][i]["anchorBgColor"] = string.Format("{0}", "#1a8cff");//GREY
                        o1["data"][i]["anchorRadius"] = string.Format("{0}", "6");
                        

                    }
                    else
                    {
                        o1["data"][i]["anchorBgColor"] = string.Format("{0}", "#1a8cff");
                        // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                        o1["data"][i]["anchorRadius"] = string.Format("{0}", "2");

                    }
                }
                using (StreamWriter file = File.CreateText(jsonPath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
            }

            return jsonPath;

            //o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
        }


        private string[] GetdataFromDb_revenue(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            // string access_link = (@"Server=tcp:79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;"); //(@"Server=tcp:192.168.1.146,1433; Database=CRM; User Id=sa; Password =sa#1234;"); ---- sterling office
            // SqlConnection conn = new SqlConnection(access_link);
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);


            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string[] matchingPerson = new string[4];
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT CRI, Revenues_in_M, Profit_in_M, Avg_Budget_on_Security_in_M FROM CRM_Revenue As fort  WHERE fort.Company_Name = '' + @text + '' ";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson[0] = oReader["CRI"].ToString();
                        matchingPerson[1] = oReader["Revenues_in_M"].ToString();
                        matchingPerson[2] = oReader["Avg_Budget_on_Security_in_M"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson;
            /* DataTable dt = GetData(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();*/
        }
        //Server=GANESH-VAIO; Database=List_of_Public_Companies; User Id=sa; Password =1234
        private string GetColor_revenue()
        {
            var dataDB = GetdataFromDb_revenue(Text1.Text)[0];
            var dataDB1 = "Revenue Spent on Cybe Security " + GetdataFromDb_revenue(Text1.Text)[2] + " M";
            var jsonPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/json_revenue.json";

            if (dataDB != "Click 'GO' ")
            {
                //var dataDB = GetDataSource();
                var x = Convert.ToInt32(float.Parse(dataDB, CultureInfo.InvariantCulture.NumberFormat)) + "";
                // var jsonPath = @"C:\Users\fcyfcy\Desktop\CRM_Subsidiaries\Charts001\Charts001\Data\json.json";

                JObject o1 = JObject.Parse(File.ReadAllText(jsonPath));
                o1["annotations"]["groups"][0]["items"][1]["label"] = string.Format("{0}", dataDB1);
                for (int i = 0; i < 9; i++)
                {
                    var y = o1["data"][i]["label"] + "";
                    if (y == x)
                    {
                       // o1["data"][i]["color"] = string.Format("{0}", "#E63287");//pink
                        o1["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY

                    }
                    else
                    {
                       // o1["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                        o1["data"][i]["color"] = string.Format("{0}", "#1a8cff");//NEWBLUE
                        // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                    }
                }
                using (StreamWriter file = File.CreateText(jsonPath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
            }

            return jsonPath;

            //o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
        }

        protected void Text1_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetDataSourceVS()
        {
            string plottingData = "";
            string responseFromDb = "0";
            string[] data1 = new string[5];
            data1[0] = GetdataFromDbVS(Text1.Text);

            if (Text1.Text != "")
            {
                plottingData = GetPlottingValues(Text1.Text);
                responseFromDb = Convert.ToString(GetdataFromDbVS(Text1.Text));


                var json2Path = @"C:\Workfolder\CRMDashboard\Charts001\Data/json2.json";



                JObject o1 = JObject.Parse(File.ReadAllText(json2Path));

                o1["dials"]["dial"][0]["value"] = string.Format("{0}", responseFromDb);


                using (StreamWriter file = File.CreateText(json2Path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }


                var jsonBarGraphPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/dtstojson.json";

                using (StreamWriter tw = new StreamWriter(jsonBarGraphPath))
                {
                    tw.WriteLine(plottingData);
                }



                return json2Path;
            }
            return null;
        }

        private string GetdataFromDbVS2(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            //    string access_link = (@"Server=tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;");
            //  SqlConnection conn = new SqlConnection(access_link);
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);


            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string matchingPerson1 = "";
            string matchingPerson2 = "";
            string matchingPerson3 = "";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT RecordStolen,LeakedMethod,DataSensitivity FROM DataStolen As fort  WHERE fort.CompanyName like '%'+ @text + '%'";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson1 = oReader["RecordStolen"].ToString();
                        matchingPerson2 = oReader["LeakedMethod"].ToString();
                        matchingPerson3 = oReader["DataSensitivity"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson1 + "\n" + matchingPerson2 + "\n" + matchingPerson3;

        }


        //-----------------------------------------------Main Code----------------------------------------
        private string GetPlottingValues(string text)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            // string access_link = (@"Server=tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;");
            //SqlConnection conn = new SqlConnection(access_link);
            long max = 0;


            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();


            List<Data> dataArr = new List<Data>();
            for (int year = 2012; year < 2018; year++)
            {
                dataArr.Add(new Data(0.ToString(), year.ToString()));
            }

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select * from DataStolen where Industry = (select Industry from DataStolen where CompanyName = ''+ @text + '')";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader dataReader = oCmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Data newData = new Data(dataReader["RecordStolen"].ToString(), dataReader["Year"].ToString());
                        foreach (var item in dataArr)
                        {
                            if (item.label == newData.label)
                            {
                                item.value += newData.value;
                                if (item.value > max)
                                {
                                    max = item.value;
                                }
                            }
                        }
                    }
                }
                myConnection.Close();
                //max /= 10;  Decimal bound
            }

            StringBuilder strBuilt = new StringBuilder();
            //strBuilt.Append("{'chart':{'caption':'Targeted Industries','subcaption':'Based on number of Data Breach/ Data Stolen / Data Lost','yaxisname':'Number of Records Stolen','xaxisname':'Year','showBorder':'0','plotgradientcolor':'','rotatevalues':'0','canvasBgColor':'#000000','baseFontColor': '#FFFFFF','bgColor':'#000000','divlinecolor':'','showvalues':'1','valuefontbold':'1','yaxisnamefontsize':'12','labelsepchar':': ','labeldisplay':'AUTO','numberscalevalue':'1,5,15,20','numberscaleunit':' ','animation':'0','paletteColors': '#E63287'},'data':[");//PINK
            strBuilt.Append("{'chart':{'caption':'Targeted Industries','subcaption':'Based on number of Data Breach/ Data Stolen / Data Lost','yaxisname':'Number of Records Stolen','xaxisname':'Year','showBorder':'0','plotgradientcolor':'','rotatevalues':'0','canvasBgColor':'#000000','baseFontColor': '#FFFFFF','bgColor':'#000000','divlinecolor':'','showvalues':'1','valuefontbold':'1','yaxisnamefontsize':'12','labelsepchar':': ','labeldisplay':'AUTO','numberscalevalue':'1,5,15,20','numberscaleunit':' ','animation':'0','paletteColors': '#a6a6a6'},'data':[");//GREY

            foreach (var item in dataArr)
            {
                //item.value /= max; scaling to the decimal values
                strBuilt.Append("{'label':'" + item.label + "','value':" + item.value + "},");
            }
            strBuilt = strBuilt.Remove(strBuilt.Length - 1, 1);
            strBuilt.Append("]}");
            return strBuilt.ToString().Replace("'", "\"");
        }

        private string GetdataFromDbVS(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            //string access_link = (@"Server=tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;");
            // SqlConnection conn = new SqlConnection(access_link);

            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);

            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string matchingPerson = "";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT Industry FROM DataStolen As fort  WHERE fort.CompanyName like '%'+ @text + '%'";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson = oReader["Industry"].ToString();
                        //matchingPerson[1] = oReader["RecordStolen"].ToString();
                        //matchingPerson[2] = oReader["LeakMethod"].ToString();
                        //matchingPerson[3] = oReader["DataSensitivity"].ToString();
                        //matchingPerson[4] = oReader["Action"].ToString();


                    }

                }
                myConnection.Close();
                // myConnection.Dispose();
            }
            return matchingPerson;
            /* DataTable dt = GetData(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();*/
        }

        private string nameChange()
        {
            var dataDB = GetDataSourceVS();
            var jsonPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/dtstojson.json";
            JObject o3 = JObject.Parse(File.ReadAllText(jsonPath));
            //"caption":"Targeted Industries",
            o3["chart"]["caption"] = string.Format("{0}", "Targeted Industries " + GetdataFromDbVS(Text1.Text));
            using (StreamWriter file = File.CreateText(jsonPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                o3.WriteTo(writer);
            }
            return jsonPath;
        }

        public class Data
        {
            public long value;
            public string label;

            public Data(string recStole, string yr)
            {
                long.TryParse(recStole, out value);
                label = yr;
            }
        }


        private string GetDataSourceH()
        {
            var responseFromDb = "0";
            if (Text1.Text != "")
            {
                responseFromDb = GetdataFromDbH(Text1.Text)[0];
            }
            else
            {
                responseFromDb = "Click 'GO' ";
            }
            return responseFromDb;

        }


        private string[] GetdataFromDbH(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            // string access_link = (@"Server=TCP:79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;");
            //SqlConnection conn = new SqlConnection(access_link);
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);


            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string[] matchingPerson = new string[2];
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                // @"SELECT fortine1000list.employees FROM fortune1000list WHERE fortune1000list.Title like '%'+ @Title + '%'";
                string oString = "SELECT calc3, Employees FROM [CRM].[dbo].[CRM_EmployeeCount] WHERE [CRM].[dbo].[CRM_EmployeeCount].Title like '%'+ @Title + '%'";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@title", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson[0] = oReader["calc3"].ToString();
                        matchingPerson[1] = oReader["Employees"].ToString();
                        break;
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson;
            /* DataTable dt = GetData(cmd);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();*/
        }
        private string GetColorH()
        {
            var dataDB = GetdataFromDbH(Text1.Text)[0];
            var dataDB1 = "No. of Employees: " + GetdataFromDbH(Text1.Text)[1];
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"../Charts001/JSON/Employee.json");
            var jsonPath = @"C:\Workfolder\CRMDashboard\Charts001\Data/Employee.json";
            if (dataDB != "Click 'GO' ")
            {
                //var dataDB = GetDataSourceH();
                var x = (int)Math.Floor(float.Parse(dataDB, CultureInfo.InvariantCulture.NumberFormat));

                JObject o1 = JObject.Parse(File.ReadAllText(jsonPath));
                o1["annotations"]["groups"][0]["items"][1]["label"] = string.Format("{0}", dataDB1);
                for (int i = 10; i > -1; i--)
                {
                    int y = Convert.ToInt32(o1["data"][i]["label"]);
                    if (y == x)
                    {
                       // o1["data"][i]["color"] = string.Format("{0}", "#E63287");//PINK
                        o1["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY


                    }
                    else
                    {
                        //o1["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                        o1["data"][i]["color"] = string.Format("{0}", "#1a8cff");//NEWBLUE
                    }
                }
                using (StreamWriter file = File.CreateText(jsonPath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
            }

            return jsonPath;

            //o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
        }


        private string[] GetdataFromDbVS3(string text)
        {
            // string strQuery = @"SELECT SubsidiaryCyber.cyberResilience FROM SubsidiaryCyber WHERE SubsidiaryCyber.CompanyName like '%'+@text+'%'";
            //string access_link = (@"Server=tcp: 79.30.2.148,1433; Database=CRM; User Id=sa; Password =sa#1234;");
            //SqlConnection conn = new SqlConnection(access_link);
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);


            var con = ConfigurationManager.ConnectionStrings["conString"].ToString();

            string[] matchingPerson = new string[4];
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT RecordStolen,LeakedMethod,DataSensitivity, Action FROM DataStolen As fort  WHERE fort.CompanyName = ''+ @text + ''";
                SqlCommand oCmd = new SqlCommand(oString, conn);
                oCmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson[0] = oReader["RecordStolen"].ToString();
                        matchingPerson[1] = oReader["LeakedMethod"].ToString();
                        matchingPerson[2] = oReader["DataSensitivity"].ToString();
                        matchingPerson[3] = oReader["Action"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson;

        }
        private string[] GetColorVIS()
        {
            var dataDB = GetdataFromDbVS3(Text1.Text);
            String dataDB1 = "The number of data records stolen " + dataDB[0];
            String dataDB2 = "The number of data records stolen " + dataDB[0];
            String dataDB3 = "The number of data records stolen " + dataDB[0];
            String[] jsonPath = new string[3];
            jsonPath[0] = @"C:\Workfolder\CRMDashboard\Charts001\Data/json_leak.json";
            jsonPath[1] = @"C:\Workfolder\CRMDashboard\Charts001\Data/json_Sensitivity.json";
            jsonPath[2] = @"C:\Workfolder\CRMDashboard\Charts001\Data/json_Action.json";

            if (dataDB[0] != "Click 'GO' ")
            {
                //var dataDB = GetDataSourceH();
                int x, x1, x2;
                if (dataDB[1] != null)
                {
                    x = (int)Math.Floor(float.Parse(dataDB[1], CultureInfo.InvariantCulture.NumberFormat)); // leak

                }
                else
                {
                    x = 0;
                }
                if (dataDB[2] != null)
                {
                    x1 = (int)Math.Floor(float.Parse(dataDB[2], CultureInfo.InvariantCulture.NumberFormat)); //sensitivity
                }
                else
                {
                    x1 = 0;
                }
                if (dataDB[3] != null)
                {
                    x2 = (int)Math.Floor(float.Parse(dataDB[3], CultureInfo.InvariantCulture.NumberFormat)); //action
                }
                else
                {
                    x2 = 0;
                }

                JObject o1 = JObject.Parse(File.ReadAllText(jsonPath[0]));
                JObject o2 = JObject.Parse(File.ReadAllText(jsonPath[1]));
                JObject o3 = JObject.Parse(File.ReadAllText(jsonPath[2]));
                o1["annotations"]["groups"][0]["items"][1]["label"] = string.Format("{0}", dataDB1);
                o2["annotations"]["groups"][0]["items"][1]["label"] = string.Format("{0}", dataDB2);
                o3["annotations"]["groups"][0]["items"][1]["label"] = string.Format("{0}", dataDB3);

                //                o1["data"][0]["color"] = string.Format("{0}", Convert.ToString(Math.Log10(Convert.ToInt64(dataDB[0])*Convert.ToInt64(dataDB[1])*Convert.ToInt64(dataDB[2]))));




                for (int i = 0; i < 5; i++)
                {
                    int y = Convert.ToInt32(o1["data"][i]["label"]);
                    int y1 = Convert.ToInt32(o2["data"][i]["label"]);


                    if (y == x && x != 0)
                    {
                        o1["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * i + 1 * Convert.ToInt64(dataDB[2]) * Convert.ToInt64(dataDB[3]))));

                       // o1["data"][i]["color"] = string.Format("{0}", "#E63287");//PINK
                        o1["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY

                    }
                    else
                    {
                        o1["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * i + 1 * Convert.ToInt64(dataDB[2]) * Convert.ToInt64(dataDB[3]))));

                        // o1["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                        o1["data"][i]["color"] = string.Format("{0}", "#1a8cff");//NEWBLUE
                        // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                    }

                    if (y1 == x1 && x1 != 0)
                    {
                        o2["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * Convert.ToInt64(dataDB[1]) * i + 1 * Convert.ToInt64(dataDB[3]))));

                       // o2["data"][i]["color"] = string.Format("{0}", "#E63287");//PINK
                        o2["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY


                    }
                    else
                    {
                        o2["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * Convert.ToInt64(dataDB[1]) * i + 1 * Convert.ToInt64(dataDB[3]))));

                        //o2["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                        o2["data"][i]["color"] = string.Format("{0}", "#1a8cff");//NEWBLUE

                        // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                    }
                    if (i < 3)
                    {
                        int y2 = Convert.ToInt32(o3["data"][i]["label"]);
                        switch (i)
                        {
                            case 1:
                                o3["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * Convert.ToInt64(dataDB[1]) * Convert.ToInt64(dataDB[2]) * 1)));
                                break;
                            case 2:
                                o3["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * Convert.ToInt64(dataDB[1]) * Convert.ToInt64(dataDB[2]) * 5)));
                                break;
                            case 3:
                                o3["data"][i]["value"] = string.Format("{0}", Convert.ToString(10 - Math.Log10(Convert.ToInt64(dataDB[0]) * Convert.ToInt64(dataDB[1]) * Convert.ToInt64(dataDB[2]) * 10)));
                                break;
                        }

                        if (y2 == x2 && x2 != 0)
                        {


                           // o3["data"][i]["color"] = string.Format("{0}", "#E63287");//PINK
                            o3["data"][i]["color"] = string.Format("{0}", "#a6a6a6");//GREY

                        }
                        else
                        {

                            // o3["data"][i]["color"] = string.Format("{0}", "#2E59E5");//OLDBLUE
                            o3["data"][i]["color"] = string.Format("{0}", "#1A8CFF");//NEWBLUE
                            
                            // o1["data"][i - 1]["color"] = string.Format("{0}", "#0000ff");
                        }
                    }
                }
                using (StreamWriter file = File.CreateText(jsonPath[0]))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
                using (StreamWriter file1 = File.CreateText(jsonPath[1]))
                using (JsonTextWriter writer1 = new JsonTextWriter(file1))
                {
                    o2.WriteTo(writer1);
                }
            }

            return jsonPath;

            //o1["dataset"][0]["data"][0]["value"] = string.Format("{0}", responseFromDb);
        }


    }
}                
        

     