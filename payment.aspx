<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="DBProject.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />

     <br /><br />
       <h2>payment</h2>
    <p> <button class="button" onclick="location.href='BookTicket.aspx'"><span>go back</span></button></p>
    <p>
        <br />
        <br />
        Enter Card No: &nbsp;<br /> <asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        <%-- Here it shows different dropdown discount vouchers available acc to his payment user selects them add number and then pays--%>
  
 <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Pay" OnClick="Pay"  /><br /><br />
        <asp:Label ID="Status" runat="server"></asp:Label>
    </p>


</asp:Content>
