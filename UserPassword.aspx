<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="DBProject.UserPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br /><br />
    <h2>change password</h2>

   <p> <button type="button" class="button"  onclick="location.href='UserAccount.aspx'"><span >go back</span></button></p>
   
    

    <p> 
        Old Password: &nbsp;<br /> <asp:TextBox ID="txtPasswordOld" CssClass="tb" TextMode="password" runat="server" ></asp:TextBox>
        <br />
        <br />
        New Password: &nbsp; <br /><asp:TextBox ID="txtPasswordNew" CssClass="tb" TextMode="password" runat="server" ></asp:TextBox>
        <br />
        <br /> 
       
         <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Save Password"  OnClick="ChangePassword"  />
       <br />
       <br />
        <asp:Label ID="CheckChange" runat="server"></asp:Label>
        </p>
</asp:Content>
