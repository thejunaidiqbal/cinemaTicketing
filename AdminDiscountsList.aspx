<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminDiscountsList.aspx.cs" Inherits="DBProject.AdminDiscountsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <link rel="stylesheet" href="mbutton2.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" href="Grid.css" type="text/css" charset="utf-8" />

     <br /><br />
    <h2>discounts</h2>
    <p> <button type="button" class="button"  onclick="location.href='Lists.aspx'"><span >go back</span></button></p>
    <p>
 <asp:Label ID="Message" runat="server"></asp:Label>
        </p>
        <br />
        <br />
    <p><asp:GridView ID="DiscountsGrid" runat="server" CssClass="rnd1" Font-Bold="True" ForeColor="#333333" PagerStyle-HorizontalAlign="Right" CellPadding="4" EnableModelValidation="True" GridLines="None" 
        >
       
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
<PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
 </asp:GridView></p>
    
</asp:Content>
