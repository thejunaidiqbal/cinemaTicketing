<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminAccount.aspx.cs" Inherits="DBProject.AdminAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br />
    <br />
  <h2>account</h2>
   
    <br />

    <p> 
         Name: &nbsp;<br />
        <asp:TextBox ID="TextBox1" CssClass="tb" runat="server" placeholder=" Name"></asp:TextBox>  
        <br />
        <br />
        CNIC: &nbsp;<br /> <asp:TextBox ID="TextBox2" CssClass="tb" runat="server" placeholder=" CNIC" ></asp:TextBox> 
        <br />
        <br /> 
        <br />
        <br /> 

       
        <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Save Changes" OnClick="EditAInfo" /> &nbsp;
         <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Change Password" OnClick="ChangeP" />&nbsp;
         <asp:Button ID="Button4" CssClass="buttonCSS" runat="server" Text="Edit" OnClick="Refresh"  />
        <br />
        <br />
        <asp:Label ID="CheckChange" runat="server"> </asp:Label>
   </p> 
   <br />
    
</asp:Content>
