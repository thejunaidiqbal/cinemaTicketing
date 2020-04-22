<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserDiscount.aspx.cs" Inherits="DBProject.UserDiscount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />

  
    <h2>Discounts</h2>
    
    <br />
    
    <p> 
        Discounts Available: &nbsp; <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="GetDiscountPrice"  >
        </asp:DropDownList>
        <br />
        <br />
        Discount Price<asp:TextBox ID="TextBox6" CssClass="tb" runat="server"></asp:TextBox> 
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Confirm" OnClick="Insert" />
         <br />
     <asp:Label ID="Status" runat="server" ></asp:Label>
</asp:Content>
