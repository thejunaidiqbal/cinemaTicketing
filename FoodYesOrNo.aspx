<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FoodYesOrNo.aspx.cs" Inherits="DBProject.FoodYesOrNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br />
     <br />
       <h2>Order Food</h2>
    <p>
        <br />
        <br />
        
 <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Yes" OnClick="RedirectToPlaceFoodOrder"  />
        &nbsp;&nbsp;
 <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="No" OnClick="RedirectToPayment"  />  
       
    </p>
    <br />
        <br /><br />
        <br /><br />
        <br />

</asp:Content>
