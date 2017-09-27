using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFactors
{
    public partial class InsuaranceForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                { }
                else
                {
                    SearchData();
                    this.Server.Transfer("CRM_Dashboard.aspx");

                }
            }


        }
        public string OverallCRI
        {
            get
            {
                return OverallResultText.Text;
            }
        }
        public string Industrypass
        {
            get
            {
                return PService.Text;
            }
        }
       
        public void SearchData()
        {
            
            String title = DropDownList1.Text;
            
            String firstname = FName.Text;
            
            String lastname = LName.Text;
            String industry = PService.Text;
            String company = BusName.Text;
            String state = States.Text;
            CRI_States.Text = GetSelectedCRI();
            //Page_Load(null, null);
            //Response.Redirect("CRM_Dashboard.aspx");

            string cloud = CloudProvider.Text;
            double result = Convert.ToDouble(new DataTable().Compute(("4E-16*" + cloud + "*" + cloud + "-0.9545*" + cloud + "+10.727"), null));
            CRI_CloudPr.Text = result.ToString();

            string homework = HomeEmployee.Text;
            double result1 = Convert.ToDouble(new DataTable().Compute(("-1E-10*" + homework + "*" + homework + "-9E-05*" + homework + "+9.789"), null));
            CRI_HomeEmpl.Text = result1.ToString();
            //y = -1E-10x2 - 9E-05x + 9.789

           
            string review = SecurRev.Text;
            double result2 = Convert.ToDouble(new DataTable().Compute(("-0.016*" + review + "*" + review + "-0.3119*" + review + "+9.6176"), null));
            CRI_SecRev.Text = result2.ToString();
            // y = 6.781e-0.06x;

            double parttime = Convert.ToDouble(EmployeeN.Text);
            double log = Math.Log10(parttime);
            double result3 = Convert.ToDouble(new DataTable().Compute(("-0.791*" + log + "+9.8333"), null));
            CRI_Term_Empl.Text = result3.ToString();
            // y = -0.791ln(x) + 9.8333;

            string passwordage = PasswordAging.Text;
            double result4 = Convert.ToDouble(new DataTable().Compute(("-0.016*" + passwordage + "*" + passwordage + "-0.3119*" + passwordage + "+9.6176"), null));
            CRI_PasswordAging.Text = result4.ToString();
            //y =-0.016x2 - 0.3119x + 9.6176;

            string passwordterm = pass.Text;
            double result5 = Convert.ToDouble(new DataTable().Compute(("-0.016*" + passwordterm + "*" + passwordterm + "-0.3119*" + passwordterm + "+9.6176"), null));
            CRI_pass.Text = result5.ToString();
            //y =-0.016x2 - 0.3119x + 9.5676;

            string unusedsoft = UnusedSoft.Text;
            double result6 = Convert.ToDouble(new DataTable().Compute(("3E-18*" + unusedsoft + "*" + unusedsoft + "-0.1*" + unusedsoft + "+9.5"), null));
            CRI_UnusedSoft.Text = result6.ToString();
            //y = 3E-18x2 - 0.1x + 9.5

            double unlicensed = Convert.ToDouble(UnlicencedSoft.Text);
            double log1 = Math.Log10(unlicensed);
            double result7 = Convert.ToDouble(new DataTable().Compute(("-3.913*" + log1 + "+10.681"), null));
            CRI_UnlicencedSoft.Text = result7.ToString();

            string authsteps = AuthSteps.Text;
            double result8 = 10 - Convert.ToDouble(new DataTable().Compute(("-0.2541*" + authsteps + "*" + authsteps + "+2.9945*" + authsteps + "-0.8066"), null)); //Wrong formula -> The more number of steps -> less CRI
            CRI_AuthSteps.Text = result8.ToString();
            //y = -0.2541x2 + 2.9945x - 0.8066

            double accesstools = Convert.ToDouble(ACTools.Text);
            double log2 = Math.Log10(accesstools);
            double result9 = Convert.ToDouble(new DataTable().Compute(("3.8043*" + log2 + "-0.3257"), null));
            CRI_ACTools.Text = result9.ToString();
            //y = 3.8043ln(x) - 0.3257

            double prevattack = Convert.ToDouble(PrevAttack.Text);
            double log3 = Math.Log10(prevattack);
            double result10 = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log3 + "+ 10.3"), null));
            CRI_PrevAttack.Text = result10.ToString();
            //y = -1.01ln(x) + 10.3  

            double attackrecov = Convert.ToDouble(AttRecov.Text);
            double log4 = Math.Log10(attackrecov);
            double result11 = Convert.ToDouble(new DataTable().Compute(("-0.738*" + log4 + "+ 9.3"), null));
            CRI_AttRecov.Text = result11.ToString();
            //y = -0.738ln(x) + 9.3           

            string ports = NofPorts.Text;
            double result12 = (Convert.ToDouble(new DataTable().Compute(("15.031*" + ports + "-0.375"), null))) / 10; //Wrong formula -> CRI > 500
            CRI_NofPorts.Text = result12.ToString();
            //y = 15.031x-0.375

            string accesscard = EmplCard.Text;
            double result13 = 10 - Convert.ToDouble(new DataTable().Compute(("3E-26*" + accesscard + "*" + accesscard + "*" + accesscard + "*" + accesscard + "*" + accesscard + "- 3E-20*" + accesscard + "*" + accesscard + "*" + accesscard + "*" + accesscard +
                "+7E-15*" + accesscard + "*" + accesscard + "*" + accesscard + "-9E-10*" + accesscard + "*" + accesscard + "+ 2E-05 *" + accesscard + "+ 8.9045"), null)); //Wrong formula -> bigger n of Employees -> bigger CRI 
            CRI_EmplCard.Text = result13.ToString();
            //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045

            double os = Convert.ToDouble(OSCount.Text);
            double log5 = Math.Log10(os);
            double result14 = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log5 + "+ 10.2"), null));
            CRI_OS.Text = result14.ToString();
            //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045


            double browser = Convert.ToDouble(Browsers.Text);
            double log6 = Math.Log10(browser);
            double result15 = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log6 + "+ 10.3"), null));
            CRI_Browsers.Text = result15.ToString();
            //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045
            
            
                double router = Convert.ToDouble(wifi.Text);
                double log7 = Math.Log10(router);
                double result16 = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log7 + "+ 10.1"), null));
                CRI_wifi.Text = result16.ToString();
                //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045
           

                string antivirus = AntivProt.Text;
                double result17 = Convert.ToDouble(new DataTable().Compute(("-0.0001*" + antivirus + "*" + antivirus + "+0.1098*" + antivirus + "- 0.15"), null));
                CRI_AntivProt.Text = result17.ToString();
                //y = -0.0001x2 + 0.1098x - 0.15;   
           
                string backups = Replic.Text;
                double result18 = Convert.ToDouble(new DataTable().Compute(("-1.5*" + backups + "*" + backups + "+7.12*" + backups + "+ 1.22"), null));
                CRI_Replic.Text = result.ToString();
                //y = -1.5x2 + 7.12x + 1.22
          
                string acquisitions = Acquisitions.Text;
                double result19 = Convert.ToDouble(new DataTable().Compute(("-0.0064*" + acquisitions + "*" + acquisitions + "*" + acquisitions + "+0.1639*" + acquisitions + "*" + acquisitions + "+1.7348*" + acquisitions + "+ 7.9911"), null));
                CRI_Acquisitions.Text = result19.ToString();
                //y = -0.0064x3 + 0.1639x2 - 1.7348x + 7.9911           
          
                string projects = AppLaunch.Text;
                double result20 = Convert.ToDouble(new DataTable().Compute(("-0.0049*" + projects + "*" + projects + "*" + projects + "+0.134*" + projects + "*" + projects + "-1.5536*" + projects + "+ 7.9939"), null));
                CRI_AppLaunch.Text = result20.ToString();
                //y = -0.0049x3 + 0.134x2 - 1.5536x + 7.9939
           
                string fired = Reorganiz.Text;
                double result21 = Convert.ToDouble(new DataTable().Compute(("0.0296*" + fired + "*" + fired + "-0.861*" + fired + "+ 8.8133"), null));
                CRI_Reorganiz.Text = result21.ToString();
                //y = 0.0296x2 - 0.861x + 8.8133
          
                string suppliers = NewSuppl.Text;
                double result22 = Convert.ToDouble(new DataTable().Compute(("-0.0064*" + suppliers + "*" + suppliers + "*" + suppliers + "+0.1791*" + suppliers + "*" + suppliers + "-2.0378*" + suppliers + "+ 9.9847"), null));
                CRI_NewSuppl.Text = result.ToString();
                //y = -0.0064x3 + 0.1791x2 - 2.0378x + 9.9847
           
                string verticals = NewMarket.Text;
                double result23 = Convert.ToDouble(new DataTable().Compute(("0.0201*" + verticals + "*" + verticals + "- 0.6856*" + verticals + "+ 8.6558"), null));
                CRI_NewMarket.Text = result23.ToString();
                //y = 0.0201x2 - 0.6856x + 8.6558
            
                string services = NewServices.Text;
                double result24 = Convert.ToDouble(new DataTable().Compute(("0.0086*" + services + "*" + services + "- 0.422*" + services + "+ 8.4109"), null));
                CRI_NerServices.Text = result24.ToString();
                //y = 0.0086x2 - 0.422x + 8.4109
            
                string products = ProdLaunch.Text;
                double result25 = Convert.ToDouble(new DataTable().Compute(("-0.0016*" + products + "*" + products + "*" + products + "+0.0588*" + products + "*" + products + "-1.0084*" + products + "+ 7.9906"), null));
                CRI_ProdLaunch.Text = result25.ToString();
                //y = -0.0016x3 + 0.0588x2 - 1.0084x + 7.9906
            

           
                if (OrgSizeEmpl.SelectedIndex == 0)
                {
                    CRI_EmplOrgSize.Text = "8";
                }
                else if (OrgSizeEmpl.SelectedIndex == 1)
                {
                    CRI_EmplOrgSize.Text = "6";
                }
                else if (OrgSizeEmpl.SelectedIndex == 2)
                {
                    CRI_EmplOrgSize.Text = "4";
                }
                else if (OrgSizeEmpl.SelectedIndex == 3)
                {
                    CRI_EmplOrgSize.Text = "2";
                }
                else
                {
                    CRI_EmplOrgSize.Text = " ";
                }
           
                if (OrgSizeTurnover.SelectedIndex == 0)
                {
                    CRI_OrgSizeTurnover.Text = "8";
                }
                else if (OrgSizeTurnover.SelectedIndex == 1)
                {
                    CRI_OrgSizeTurnover.Text = "6";
                }
                else if (OrgSizeTurnover.SelectedIndex == 2)
                {
                    CRI_OrgSizeTurnover.Text = "4";
                }
                else if (OrgSizeTurnover.SelectedIndex == 3)
                {
                    CRI_OrgSizeTurnover.Text = "2";
                }
                else
                {
                    CRI_OrgSizeTurnover.Text = " ";
                }

            var overallresult = (result + result1 + result2 + result3 + result4 + result5 + result6 + result7 + result8 + result9 + result10 + result11 + result12 + result13 + result14 + result16 + result17 + result18 + result19 + result20 + result21 + result23 + result24 + result25)/26;
            OverallResultText.Text = overallresult.ToString();
            
        }

        public string GetSelectedCRI()
        {
            CRI_States.Text = "0";
            string constr = ConfigurationManager.ConnectionStrings["conString"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            string selectSQL = "SELECT CRI_State FROM STATES WHERE State like '%'+ @st + '%'";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.Parameters.AddWithValue("@st", States.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt?.Rows[0]?.ItemArray[0]?.ToString();
        }
        
        public void GetStates(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["conString"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("select * from States", con); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            States.DataTextField = ds.Tables[0].Columns["State"].ToString(); // text field name of table dispalyed in dropdown
            States.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            States.DataBind();  //binding dropdownlist
            States.SelectedItem.Text = "VA";

        }

      
      

        //protected void States_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CRI_States.Text = GetSelectedCRI();
        //}

        //protected void CloudProvider_TextChanged(object sender, EventArgs e)
        //{
        //    string x = CloudProvider.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("4E-16*" + x + "*" + x + "-0.9545*" + x + "+10.727"), null));
        //    CRI_CloudPr.Text = result.ToString();
        //    //y = 4E-16x2 - 0.9545x + 10.727;
        //}

        
        //protected void Unnamed2_TextChanged1(object sender, EventArgs e)
        //{
        //    string x = HomeEmployee.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("-1E-10*" + x + "*" + x + "-9E-05*" + x + "+9.789"), null));
        //    CRI_HomeEmpl.Text = result.ToString();
        //    //y = -1E-10x2 - 9E-05x + 9.789
        //}

        //protected void SecurRev_TextChanged(object sender, EventArgs e)
        //{
        //    double r = 6/100;
        //    string x = SecurRev.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("-0.016*" + x + "*" + x + "-0.3119*" + x + "+9.6176"), null));
        //    CRI_SecRev.Text = result.ToString();
        //    // y = 6.781e-0.06x;
        //}

        //protected void EmployeeN_TextChanged(object sender, EventArgs e)
        //{
        //    double x = Convert.ToDouble(EmployeeN.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("-0.791*"+ log + "+9.8333"), null)); 
        //    CRI_Term_Empl.Text = result.ToString();
        //    // y = -0.791ln(x) + 9.8333;
        //}

        //protected void PasswordAging_TextChanged(object sender, EventArgs e)
        //{
        //    string x = PasswordAging.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("-0.016*" + x + "*" + x + "-0.3119*" + x + "+9.6176"), null));
        //    CRI_PasswordAging.Text = result.ToString();
        //    //y =-0.016x2 - 0.3119x + 9.6176;
        //}

        //protected void pass_TextChanged(object sender, EventArgs e)
        //{
        //    string x = pass.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("-0.016*" + x + "*" + x + "-0.3119*" + x + "+9.6176"), null));
        //    CRI_pass.Text = result.ToString();
        //    //y =-0.016x2 - 0.3119x + 9.5676;
        //}

        //protected void UnusedSoft_TextChanged(object sender, EventArgs e)
        //{
        //    string x = UnusedSoft.Text;
        //    double result = Convert.ToDouble(new DataTable().Compute(("3E-18*" + x + "*" + x +"-0.1*" + x +"+9.5"), null));
        //    CRI_UnusedSoft.Text = result.ToString();
        //    //y = 3E-18x2 - 0.1x + 9.5
        //}

        //protected void UnlicencedSoft_TextChanged(object sender, EventArgs e)
        //{
        //    double x = Convert.ToDouble(UnlicencedSoft.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("-3.913*" + log + "+10.681"), null));
        //    CRI_UnlicencedSoft.Text = result.ToString();
        //    //y = -3.913ln(x) + 10.681
        //}

        //protected void AuthSteps_TextChanged(object sender, EventArgs e)
        //{
        //    string x = AuthSteps.Text;
        //    double result = 10 - Convert.ToDouble(new DataTable().Compute(("-0.2541*" + x + "*" + x + "+2.9945*" + x + "-0.8066"), null)); //Wrong formula -> The more number of steps -> less CRI
        //    CRI_AuthSteps.Text = result.ToString();
        //    //y = -0.2541x2 + 2.9945x - 0.8066
        //}

        //protected void ACTools_TextChanged(object sender, EventArgs e)
        //{
        //    double x = Convert.ToDouble(ACTools.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("3.8043*" + log + "-0.3257"), null));
        //    CRI_ACTools.Text = result.ToString();
        //    //y = 3.8043ln(x) - 0.3257
        //}

        //protected void PrevAttack_TextChanged(object sender, EventArgs e)
        //{
        //    double x = Convert.ToDouble(PrevAttack.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log + "+ 10.3"), null));
        //    CRI_PrevAttack.Text = result.ToString();
        //    //y = -1.01ln(x) + 10.3           
        //}

        //protected void AttRecov_TextChanged(object sender, EventArgs e)
        //{
        //    double x = Convert.ToDouble(AttRecov.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("-0.738*" + log + "+ 9.3"), null));
        //    CRI_AttRecov.Text = result.ToString();
        //    //y = -0.738ln(x) + 9.3                  
        //}

        //protected void NofPorts_TextChanged(object sender, EventArgs e)
        //{
        //    string x = NofPorts.Text;
        //    double result = (Convert.ToDouble(new DataTable().Compute(("15.031*" + x + "-0.375"), null)))/10; //Wrong formula -> CRI > 500
        //    CRI_NofPorts.Text = result.ToString();
        //    //y = 15.031x-0.375
        //}

        //protected void EmplCard_TextChanged(object sender, EventArgs e)
        //{
        //    string x = EmplCard.Text;
        //    double result = 10 - Convert.ToDouble(new DataTable().Compute(("3E-26*" + x + "*" + x + "*" + x + "*" + x + "*" + x + "- 3E-20*" + x + "*" + x + "*" + x + "*" + x +
        //        "+7E-15*" + x + "*" + x + "*" + x + "-9E-10*" + x + "*" + x + "+ 2E-05 *" + x + "+ 8.9045"), null)); //Wrong formula -> bigger n of Employees -> bigger CRI 
        //    CRI_EmplCard.Text = result.ToString();
        //    //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045
        //}

        //protected void OS_TextChanged(object sender, EventArgs e)
        //{
            
        //    double x = Convert.ToDouble(OSCount.Text);
        //    double log = Math.Log10(x);
        //    double result = Convert.ToDouble(new DataTable().Compute(("-1.01*" + log + "+ 10.2"), null));
        //    CRI_OS.Text = result.ToString();
        //    //y = 3E-26x5 - 3E-20x4 + 7E-15x3 - 9E-10x2 + 2E-05x + 8.9045
        //}
        
    }
}