<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="css/Custom.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; font-family:Calibri"><h2> Manage Data</h2></div>
    <div style="text-align:center">
    
       
        
        
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">

             <asp:ListItem Selected="True" Value="abc"> Website</asp:ListItem>
             <asp:ListItem  Value="Springer"> Springer </asp:ListItem>
                  <asp:ListItem Value="Elsevier"> Elsevier</asp:ListItem>
                  <asp:ListItem Value="ACM"> ACM </asp:ListItem>

        </asp:DropDownList>
    
        <asp:DropDownList ID="DropDownList2" runat="server" >
            
             

        </asp:DropDownList>
  
             
             

       
        <asp:Button ID="Button1"   runat="server" OnClick="RunButton_Click" Text="Run Search" />
        <asp:Button ID="Button3" runat="server" OnClick="ShowButton_Click" Text="Show Data" />
         <asp:Button ID="Button2" runat="server" OnClick="UpdateButton_Click" Text="Update Data" />
    
    </div>
        <div style="text-align:center; margin-top:15px; font-family:Calibri">

            <asp:Label ID="Label1" runat="server" Text="Keywords" Font-Names="Calibri" Font-Size="Large"></asp:Label>

            </div>
        <div >

            <asp:HyperLink  CssClass="margin-setting" ID="HyperLink1" runat="server" Font-Names="Consolas"  Font-Size="Medium" ForeColor="Blue">Go to journal homepage >></asp:HyperLink><br/>
            <asp:Label CssClass="margin-setting" ID="Website" runat="server" Text="Associated Website" Font-Size="Large" Font-Names="Calibri"></asp:Label><br/><br/><br/>
            <asp:Label CssClass="margin-setting" ID="KeywordsHeading" runat="server" Text="Keywords:" Font-Size="Large" Font-Names="Calibri"></asp:Label><br/>
            <asp:Label CssClass="margin-setting" ID="Keywords" Font-Names="Consolas" runat="server" Text="keywords"></asp:Label>
            <br /><br /><br /><br /> 
            <asp:Label ID="Label2" runat="server" Text="Log"></asp:Label>
            

            </div>
      
        

      
        

       </form>
</body>
</html>
