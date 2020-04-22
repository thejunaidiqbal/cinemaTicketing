<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="CinemaChanges.aspx.cs" Inherits="DBProject.CinemaChanges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />

     <br /><br />
       <h2>Cinema Editing</h2>
    <p>
        <br />
        <br />
        
 <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add Remove Food" OnClick="FoodItems"  />&nbsp;&nbsp;
        
 <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Add Remove Discount" OnClick="Discounts"  />  

<br />
        <br />
        
 <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Add Remove Screen" OnClick="Screens"  />  
       
    </p>
</asp:Content>
