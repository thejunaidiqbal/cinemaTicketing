<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddRemoveCinema.aspx.cs" Inherits="DBProject.AddRemoveCinema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
         <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     <br />  <br />
       <h2>add/ remove cinema</h2>
   
    <p>
        <br />
        <br />
        
 <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add New Cinema" OnClick="RedirectToAdminCinema"  />&nbsp; &nbsp;
        
 <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Remove Old Cinema" OnClick="RedirectToRemoveCinema"  />  
         <br />
        <br /> <br />
        <br /> <br />
        <br /> <br />
        <br /> <br />
        <br /> <br />
        <br /> <br />
        <br />
       
    </p>
</asp:Content>
