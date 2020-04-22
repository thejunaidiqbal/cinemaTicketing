<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminDiscounts.aspx.cs" Inherits="DBProject.AdminDiscounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     <br />  <br />
     <h2>add discounts</h2>
<p> <button type="button" class="button"  onclick="location.href='AddRemoveDiscounts.aspx'"><span >go back</span></button></p>       
        <p>
        Add ID: &nbsp;<br /> <asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Add Discount Price: &nbsp;<br /> <asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Add Minimum Amount: &nbsp;<asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>
      &nbsp;&nbsp;
        Add Maximum Amount: &nbsp; <asp:TextBox ID="TextBox4" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add" OnClick="Add" />
       <br />
       <br /> 
        <asp:Label ID="Status" runat="server"></asp:Label>
        Returned ID: <br /> <asp:TextBox ID="TextBox5" cssClass="tb" runat="server"></asp:TextBox>  
        <br />
       <br />    
    </p>

</asp:Content>
