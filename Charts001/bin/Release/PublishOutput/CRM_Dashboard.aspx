<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRM_Dashboard.aspx.cs" Inherits="Charts001.JSON1" %> <!-- Inherits="BasicExample_BasicChart" -->
<%@ PreviousPageType VirtualPath="~/InsuaranceForm.aspx" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  <!-- <!DOCTYPE html> -->

<html >  <!-- xmlns="http://www.w3.org/1999/xhtml" -->
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Cyber Resilience Model</title>
<script type="text/javascript" src="../fusioncharts/fusioncharts.js"></script>
<script type="text/javascript" src="../fusioncharts/themes/fusioncharts.theme.fint.js"></script>
    
<!-- <script type="text/javascript" src="fusioncharts/js/themes/fusioncharts.theme.fint.js"></script> -->
<style type="text/css">
    #Select1 {
        height: 4px;
        width: 582px;
    }
    #Text1 {
        width: 560px;
    }
</style>
</head>
<body style="background-color: #000000">
<form id="form1" runat="server" style="vertical-align: middle; height: 389px; width: 100%; ">


        <div style="width:100%;"> 

    <div style="float:left; width:100%; font-family: Verdana; color: #000000;"> 
       <asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>.
       <asp:TextBox id="Text1" type="text" size="4" runat="server" OnLoad="Text1_TextChanged" Text="Walmart" BackColor="Black" ForeColor="Black" BorderColor="Black" BorderStyle ="none"/>
            
            <div style="float:left; width:100%; font-family: Verdana; color: #000000;">
        <div style="float:left; width:25%;">
            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                </div>
            <div style="float:left; width:25%;">
            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                    </div>
                <div style="float:left; width:25%">
            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </div>
                 <div style="float:left; width:25%">
            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                        </div>
                
                </div>
            &nbsp;<br /><br />
            <div style="float:left; width:100%; font-family: Verdana; color: #000000;">
                    <div style="float:left; width:25%;">
            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                    </div>
                
                        <div style="float:left; width:25%;">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
                <div style="float:left; width:25%;">
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </div>
                <div style="float:left; width:25%;">
                <iframe width="290" height="250"  scrolling="no" frameborder="0" src="http://map.norsecorp.com/#/"></iframe>
                    </div>
                </div>
            &nbsp; <br />
        <div style="float:left; width:60%; font-family: Verdana; color: #000000;">
                    <div style="float:left; width:33%;">
            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                </div>
                
                        <div style="float:left; width:33%;">
            <asp:Literal ID="Literal8" runat="server"></asp:Literal>
            </div>
                <div style="float:left; width:33%;">
        <asp:Literal ID="Literal9" runat="server"></asp:Literal>
            </div>
                </div>
               
    <div style="float:center; width:75%; font-family: Verdana; color: #000000;">
       
        <asp:Label ID="LabelEqn" runat="server" Text="Label" Font-Size="X-Large" ForeColor ="White"></asp:Label>
           
    </div>
            </div>
</form>
</body>
</html>