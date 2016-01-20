<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>




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
    <asp:DropDownList ID="DropDownList3" runat="server" >
         <asp:ListItem Selected="True" Value="abc"> Search Depth</asp:ListItem>
             <asp:ListItem  Value="x1"> 1x </asp:ListItem>
                  <asp:ListItem Value="x2"> 2x</asp:ListItem>
                  <asp:ListItem Value="x3"> 3x </asp:ListItem>
             
             

        </asp:DropDownList>
        <asp:Button ID="Button1"   runat="server" OnClick="RunButton_Click" Text="Run Search" />
        <asp:Button ID="Button3" runat="server" OnClick="ShowButton_Click" Text="Show Data" />
         <asp:Button ID="Button2" runat="server" OnClick="UpdateButton_Click" Text="Update Data" />
    
    </div>
        <div style="text-align:center; margin-top:15px; font-family:Calibri">

            <asp:Label ID="Label1" runat="server" Text="Keywords"></asp:Label>

            </div>
        <div >

            <asp:Label ID="OutputLabel" runat="server" Text="Label" Font-Names="Consolas" Font-Size="Small"></asp:Label>

            </div>
      
        

      
        

       </form>
</body>
</html>
