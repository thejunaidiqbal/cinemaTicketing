<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Lists.aspx.cs" Inherits="DBProject.Lists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <br /><br />
     <h2>Check Lists</h2>
    
     <br />
    <p> 
    <br />
     <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="FoodItems" OnClick="Food" />
 <br />
        <br />
        <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Discounts" OnClick="Discounts" />
        
    <br />
        <br />
     <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Cinemas" OnClick="Cinemas" />
<br />
        <br />
        <asp:Button ID="Button6" CssClass="buttonCSS" runat="server" Text="Revenue" OnClick="Revenues" />
        <br />
        <br />
     <asp:Button ID="Button4" CssClass="buttonCSS" runat="server" Text="Shows" OnClick="Shows" />
         <br />
        <br />    
         <asp:Button ID="Button5" CssClass="buttonCSS" runat="server" Text="Users" OnClick="Users" />
   </p> 
     <br />
        <br />     <br />
        <br />     <br />

     
</asp:Content>
