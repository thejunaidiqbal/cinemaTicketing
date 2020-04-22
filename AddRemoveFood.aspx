<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddRemoveFood.aspx.cs" Inherits="DBProject.AddRemoveFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     
     <br />
        <br />
       <h2>edit Food items</h2>
    <p>
        <br />
        <br />
        
 <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add Food Item" OnClick="RedirectToAdminFood"  />&nbsp;&nbsp;
        
 <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Remove Food Item" OnClick="RedirectToRemoveFood"  />  
       
    </p>
        <br />
        <br />    <br />
        <br />    <br />
        <br />    <br />
        <br />    <br />
        <br />    <br />
        <br />    <br />
        
</asp:Content>
