﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Manage.aspx.cs" Inherits="WebApplication1.Manage" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage</title>
    <link href="css/Custom.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server"  style=" background-image:url('img/background.png'); height: 1000px; margin-left: -10px; margin-top: -20px;">
        <div style="text-align:center; font-family:Calibri"><h2> Manage Data</h2></div>
    <div style="text-align:center">
    
       
        
        
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  AutoPostBack="True">

             <asp:ListItem Selected="True" Value="abc"> Website</asp:ListItem>
             <asp:ListItem  Value="Springer"> Springer </asp:ListItem>
                  <asp:ListItem Value="Emerald"> Emerald</asp:ListItem>
                  <asp:ListItem Value="ACM"> ACM </asp:ListItem>

        </asp:DropDownList>
    
        <asp:DropDownList ID="DropDownList2" runat="server" >
            
             

        </asp:DropDownList>
  
             
             

       
      
    
    </div>
        <div style="text-align:center; margin-top:15px; font-family:Calibri">

           

            </div>
        <div >

            <asp:HyperLink  CssClass="margin-setting" ID="HyperLink1" runat="server" Font-Names="Consolas"  Font-Size="Medium" ForeColor="Blue">Go to journal homepage >></asp:HyperLink><br/>
            <asp:Label CssClass="margin-setting" ID="Website" runat="server" Text="Associated Website" Font-Size="Large" Font-Names="Calibri"></asp:Label><br/><br/><br/>
            <asp:Label CssClass="margin-setting" ID="KeywordsHeading" runat="server" Text="Keywords:" Font-Size="Large" Font-Names="Calibri"></asp:Label><br/>
            <asp:Label CssClass="margin-setting" ID="Keywords" Font-Names="Consolas" runat="server" Text="keywords"></asp:Label>
            <br /><br /><br /><br /> 
            <asp:Label ID="Label2" runat="server" Text="Log"></asp:Label>
            

            </div>
      
        <br /><br /><br /><br /><br /><br />
         <div style="text-align:center; font-family:Calibri"><h2> New Search</h2></div>
        <div style="text-align:center">
          <asp:Button ID="Button1"   runat="server" Text="Run Search" />
         <asp:Button ID="Button2" runat="server"  Text="Update Data" />
       
             <asp:DropDownList  CssClass="with-dropdown" OnSelectedIndexChanged="JournalDrop_SelectedIndexChanged" ID="JournalDrop" runat="server"  AutoPostBack="True">

             <asp:ListItem Selected="True" Value="abc">Search by:</asp:ListItem>
             <asp:ListItem  Value="JournalLinks">Link to List of Journal Links </asp:ListItem>
                  <asp:ListItem Value="JournalHome"> Link to Single Journal</asp:ListItem>
           

        </asp:DropDownList>
            <asp:Label  ID="Label1" CssClass="label" Font-Names="Consolas" runat="server" Text="Link: "></asp:Label>
               <asp:TextBox ID="TextBox1" runat="server" TextMode="Url"></asp:TextBox>
               <asp:DropDownList  CssClass="with-dropdown" ID="JournalLinksBy" runat="server" AutoPostBack="True">

             <asp:ListItem Selected="True" Value="abc">Search Journal Links by:</asp:ListItem>
             <asp:ListItem  Value="Tag">Tag </asp:ListItem>
                  <asp:ListItem Value="Class"> Class</asp:ListItem>
           <asp:ListItem Value="ID">ID</asp:ListItem>

        </asp:DropDownList>
               <asp:Label  ID="JournalValue" CssClass="label" Font-Names="Consolas" runat="server" Text="Value:"></asp:Label>
                <asp:TextBox ID="JournalTextbox" runat="server" ></asp:TextBox>
               <asp:DropDownList  CssClass="with-dropdown" ID="KeywordDropdown" runat="server"  AutoPostBack="True">

             <asp:ListItem Selected="True" Value="abc">Search Keyword by:</asp:ListItem>
             <asp:ListItem  Value="Tag">Tag </asp:ListItem>
                  <asp:ListItem Value="Class"> Class</asp:ListItem>
                     <asp:ListItem Value="ID"> ID</asp:ListItem>
           

        </asp:DropDownList>
              <asp:Label  ID="KeywordValue" CssClass="label" Font-Names="Consolas" runat="server" Text="Value:"></asp:Label>
                <asp:TextBox ID="KeywordTextbox" runat="server" ></asp:TextBox>
           

        
        </div>
        
      
       

       </form>
</body>
</html>
