<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuaranceForm.aspx.cs" Inherits="WebFactors.InsuaranceForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> Cyber Resilience </title>
    <style type="text/css">
        #Select1 {
            height: 4px;
            width: 582px;
        }
        #Text1 {
            width: 560px;
        }
        .auto-style1 {
            width: 343px;
        }
        .auto-style2 {
            width: 66%;
        }
        .auto-style4 {
            width: 328px;
        }
        .auto-style5 {
            width: 382px;
        }
        .auto-style6 {
            height:55px;
            width: 50%;
        }
        .auto-style8 {
            margin-left: 0px;
        }
        .auto-style9 {
            width: 486px;
        }
        </style>
</head>
<body style="background-color: #000000">
    @using (Html.BeginForm("ActionMethodName","ControllerName"))

    <form id="form1" runat="server" defaultbutton="SubmitButton" method="post" onsubmit="SearchData">
    <div style="margin-left:auto;margin-right:auto; font-family: 'Verdana'; color: #FFFFFF;" class="auto-style2">
        
        <table cellpadding="4">
            <tr>
                <td class="auto-style1" colspan="2"> <h2> About your Organization </h2> 
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit"/>
                   <%-- <asp:Button ID="ClearButton" runat="server" Text="Reset" OnClick="clearSession"/>--%>
                </td>
            </tr>
            <tr>
            <td class="auto-style1">
               Title:
            </td>
              <td class="auto-style4">
               <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="378px">
                 <asp:ListItem Value="Small">Mr</asp:ListItem>
                        <asp:ListItem Value="Small-Medium">Ms</asp:ListItem>
                        <asp:ListItem Value="Medium">Mrs</asp:ListItem>
                        <asp:ListItem Value="Large ">Dr</asp:ListItem>
                   </asp:DropDownList>
            </td>
            </tr>
            <tr>
                <td class="auto-style1"> First name: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="FName" runat="server" Width="370px" Text="John"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Last name: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="LName" runat="server" Width="370px" Text="Doe"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Primary service: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="PService" runat="server" Width="370px" Text="Retailing"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Business name: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="BusName" runat="server" Width="370px" Text="Acme Corp"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2"> <h4>Business address:</h4> </td>
            </tr>
            <tr>
                <td class="auto-style1"> Street: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Street" runat="server" Width="370px" Text="7930 Jones Branch Dr"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Secondary street (optional): </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Street2" runat="server" Width="370px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1"> City: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="City" runat="server" Width="370px" Text="McLean"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1"> State: </td>
                <td class="auto-style4">
                    
                <asp:DropDownList ID="States" runat="server" Height="22px" Width="375px" OnInit="GetStates"> </asp:DropDownList>
                    <asp:Label ID="CRI_States" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style1"> Zip: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Zip" runat="server" Width="370px" Text="22102"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Telephone number: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Phone" runat="server" Width="370px" Text="+5712810100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Email address: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Email" runat="server" Width="370px" Text="john.doe@nesttech.com"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Confirm email address: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="Email2" runat="server" Width="370px" Text="john.doe@nesttech.com"></asp:TextBox>
                </td>
            </tr>

         </table>
        <br />

        <table cellpadding="4">
            <tr>
                <td class="auto-style6"> How many permanent employees are there in your organization?</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="OrgSizeEmpl" AutoPostBack="True" runat="server" Height="24px" Width="215px" CssClass="auto-style8">
                        <asp:ListItem Value="Small">0 - 99</asp:ListItem>
                        <asp:ListItem Value="Small-Medium">100 - 999</asp:ListItem>
                        <asp:ListItem Value="Medium">1000 - 999</asp:ListItem>
                        <asp:ListItem Value="Large ">10000 and more</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="CRI_EmplOrgSize" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many public cloud providers are you using? </td>
                <td class="auto-style9"> <asp:TextBox id="CloudProvider" runat="server" Width="209px" Text="4"></asp:TextBox>
                    <asp:Label ID="CRI_CloudPr" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many part-time employees are there in your organization? </td>
                <td class="auto-style9"> <asp:TextBox ID="EmployeeN" runat="server" Width="207px" Text="20"></asp:TextBox>
                    <asp:Label ID="CRI_Term_Empl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many employees work from home? </td>
                <td class="auto-style9"> <asp:TextBox ID="HomeEmployee" runat="server" Width="208px" Text="10"></asp:TextBox>
                    <asp:Label ID="CRI_HomeEmpl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> What is your annual turnover? </td>
                <td class="auto-style9"> 
                    <asp:DropDownList ID="OrgSizeTurnover" AutoPostBack="True" runat="server" Height="24px" Width="215px" CssClass="auto-style8">
                        <asp:ListItem Value="Small">  25000 and less </asp:ListItem>
                        <asp:ListItem Value="Small-Medium"> 25000 - 49999 </asp:ListItem>
                        <asp:ListItem Value="Medium"> 50000 - 499999 </asp:ListItem>
                        <asp:ListItem Value="Large "> 500000 and more</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="CRI_OrgSizeTurnover" runat="server"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td class="auto-style6"> What is your annual revenue? </td>
                <td class="auto-style9"> <asp:TextBox runat="server" Width="457px"></asp:TextBox></td>
            </tr>--%>
            <tr>
                <td class="auto-style6"> How often do you review your Cyber Security? (in months) </td>
                <td class="auto-style9"> <asp:TextBox ID="SecurRev" runat="server" Width="209px" Text="6"></asp:TextBox>
                    <asp:Label ID="CRI_SecRev" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many authentication steps are enforced to access the organization's cyber assets? </td>
                <td class="auto-style9"> <asp:TextBox ID="AuthSteps" runat="server" Width="208px" Text="2"></asp:TextBox>
                    <asp:Label ID="CRI_AuthSteps" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How often are change passwords enforced on the access to the organization's cyber asset? (in months) </td>
                <td class="auto-style9"> <asp:TextBox ID="PasswordAging" runat="server" Width="208px" Text="3"></asp:TextBox>
                    <asp:Label ID="CRI_PasswordAging" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> No of policy rules in place for new server login passwords? </td>
                <td class="auto-style9"> <asp:TextBox ID="pass" runat="server" Width="205px" Text="3"></asp:TextBox>
                    <asp:Label ID="CRI_pass" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> What is the percentage of unused software that is installed on the organization's devices? </td>
                <td class="auto-style9"> <asp:TextBox ID="UnusedSoft" runat="server" Width="204px" Text="25"></asp:TextBox>
                    <asp:Label ID="CRI_UnusedSoft" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> What is the percentage of unlicensed software installed on the organization's devices? </td>
                <td class="auto-style9"> <asp:TextBox ID="UnlicencedSoft" runat="server" Width="203px" Text="25"></asp:TextBox>
                    <asp:Label ID="CRI_UnlicencedSoft" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> What are the number of access control tools for the electronic devices used in the Organization? </td>
                <td class="auto-style9"> <asp:TextBox ID="ACTools" runat="server" Width="202px" Text="3"></asp:TextBox>
                    <asp:Label ID="CRI_ACTools" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> On an average, how many hours after an attack were previous attacks detected? </td>
                <td class="auto-style9"> <asp:TextBox ID="PrevAttack" runat="server" Width="201px" Text="4"></asp:TextBox>
                    <asp:Label ID="CRI_PrevAttack" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> What is the maximum time taken to recover from previous attacks? (in hours) </td>
                <td class="auto-style9"> <asp:TextBox ID="AttRecov" runat="server" Width="200px" Text="24"></asp:TextBox>
                    <asp:Label ID="CRI_AttRecov" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many ports are open on your organization's firewall? </td>
                <td class="auto-style9"> <asp:TextBox ID="NofPorts" runat="server" Width="200px" Text="6"></asp:TextBox>
                    <asp:Label ID="CRI_NofPorts" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many employees have physical access to the organization's cyber assets? </td>
                <td class="auto-style9"> <asp:TextBox ID="EmplCard" runat="server" Width="199px" Text="4"></asp:TextBox>
                    <asp:Label ID="CRI_EmplCard" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many different Operating Systems are used in the organization? </td>
                <td class="auto-style9"> <asp:TextBox ID="OSCount" runat="server" Width="200px" Text="3"></asp:TextBox>
                <asp:Label ID="CRI_OS" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style6"> What percentage of devices in the organization have updated antivirus protection? </td>
                <td class="auto-style9"> <asp:TextBox ID="AntivProt" runat="server" Width="202px" Text="50"></asp:TextBox>
                    <asp:Label ID="CRI_AntivProt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many different Browsers are used in the organization? </td>
                <td class="auto-style9"> <asp:TextBox ID="Browsers" runat="server" Width="202px" Text="4"></asp:TextBox>
                  <asp:Label ID="CRI_Browsers" runat="server"></asp:Label>  
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many redundant backups of organization data do you have? </td>
                <td class="auto-style9"> <asp:TextBox ID="Replic" runat="server" Width="203px" Text="2"></asp:TextBox>
                    <asp:Label ID="CRI_Replic" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many WiFi Routers are there in the organization's network? </td>
                <td class="auto-style9"> <asp:TextBox ID="wifi" runat="server" Width="203px" Text="5"></asp:TextBox>
                 <asp:Label ID="CRI_wifi" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many subsidiaries do you have? </td>
                <td class="auto-style9"> <asp:TextBox ID="Acquisitions" runat="server" Width="203px" Text="10"></asp:TextBox>
                    <asp:Label ID="CRI_Acquisitions" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many projects have you completed in the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="AppLaunch" runat="server" Width="203px"  Text="4"></asp:TextBox>
                    <asp:Label ID="CRI_AppLaunch" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many products have you launched in the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="ProdLaunch" runat="server" Width="203px" Text="15"></asp:TextBox>
                    <asp:Label ID="CRI_ProdLaunch" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> How many employees have you fired in the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="Reorganiz" runat="server" Width="204px"  Text="8"></asp:TextBox>
                    <asp:Label ID="CRI_Reorganiz" runat="server"> </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many new suppliers have you purchsed from in the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="NewSuppl" runat="server" Width="204px" Text="120"></asp:TextBox>
                    <asp:Label ID="CRI_NewSuppl" runat="server"> </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many significant new verticals have you entered in the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="NewMarket" runat="server" Width="204px" Text="0"></asp:TextBox>
                    <asp:Label ID="CRI_NewMarket" runat="server"> </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> How many new services are you offering since the past year? </td>
                <td class="auto-style9"> <asp:TextBox ID="NewServices" runat="server" Width="204px"  Text="2"></asp:TextBox>
                    <asp:Label ID="CRI_NerServices" runat="server"> </asp:Label>
                </td>
            </tr>
             <tr>
              
                   <asp:Label ID="OverallResultText" runat="server"> </asp:Label>
                
            </tr>
        </table>




        <br />
        <%-- <table cellpadding="4">
            <tr>
                <td class="auto-style6"> Is your business operated out of your home? </td>
                <td class="auto-style5"> 
                    <asp:RadioButton id="Radio1" Text="Yes" Checked="True" GroupName="RadioGroup0" runat="server" />    
                    <asp:RadioButton id="Radio2" Text="No" GroupName="RadioGroup0" runat="server"/><br />
                </td>
            </tr>
             <tr>
                <td class="auto-style6"> Other than the business address provided above, how many additional locations does your business own or rent? </td>
                <td class="auto-style5"> 
                    <asp:TextBox id="NLocations" runat="server" Width="314px"/>    
                </td>
            </tr>
            </table>

        <br/>
        <table cellpadding="4">
            <tr>
                <td class="auto-style6"> What best describes your business's ownership structure? </td>
                <td class="auto-style5"> 
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="322px" CssClass="auto-style8">
                       </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Including yourself, how many full-time, part-time, and temporary employees does your business have? (Do not include subcontractors.)
                </td>
                <td>
                    <asp:DropDownList AutoPostBack="True" runat="server" Height="16px" Width="322px" CssClass="auto-style8">
                        <asp:ListItem Value="Venture"> 1 - 4 </asp:ListItem>
                        <asp:ListItem Value="LLC"> 5 - 10 </asp:ListItem>
                        <asp:ListItem Value="Partn"> 11 - 20 </asp:ListItem>
                        <asp:ListItem Value="Trust "> 21 - 50  </asp:ListItem>
                        <asp:ListItem Value="Corp "> 51 - 100  </asp:ListItem>
                        <asp:ListItem Value="Corp "> 100 + </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Do you or your business supply, manufacture, or distribute any tangible goods or products?
                </td>
                <td>
                    <asp:RadioButton id="RadioButton1" Text="Yes" Checked="True" GroupName="RadioGroup1" runat="server" />    
                    <asp:RadioButton id="RadioButton2" Text="No" GroupName="RadioGroup1" runat="server"/>
                </td>
            </tr>
             <tr>
                <td>
                    Does your business perform any design, construction, installation, removal, or physical repair of any property or tangible good?
                </td>
                <td>
                    <asp:RadioButton id="RadioButton3" Text="Yes" Checked="True" GroupName="RadioGroup2" runat="server" />    
                    <asp:RadioButton id="RadioButton4" Text="No" GroupName="RadioGroup2" runat="server"/>
                </td>
            </tr>
             <tr>
                <td>
                    Does your business manufacture, design, or assist in the design of any hardware or components?
                </td>
                <td>
                    <asp:RadioButton id="RadioButton5" Text="Yes" Checked="True" GroupName="RadioGroup3" runat="server" />    
                    <asp:RadioButton id="RadioButton6" Text="No" GroupName="RadioGroup3" runat="server"/>
                </td>
            </tr>
            </table>

        <br/>
        <table cellpadding="4">
            <tr>
                <td class="auto-style6"> Do you currently have an insurance policy in effect for the coverage requested? </td>
                <td class="auto-style5"> 
                    <asp:RadioButton id="RadioButton7" Text="Yes" Checked="True" GroupName="RadioGroup4" runat="server" />    
                    <asp:RadioButton id="RadioButton8" Text="No" GroupName="RadioGroup4" runat="server"/>
                    <asp:RadioButton id="RadioButton9" Text="Prefer not to answer" GroupName="RadioGroup4" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"> If you purchase a policy, when would you like your coverage to start? </td>
                <td class="auto-style5">
                    <asp:Calendar runat="server" BackColor="White" >
                    </asp:Calendar>
                </td>
            </tr>
            </table>--%>

    </div>
    </form>
</body>
</html>
