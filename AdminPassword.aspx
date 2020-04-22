<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminPassword.aspx.cs" Inherits="DBProject.AdminPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br /><br />
    <h2>change password</h2>
<p> <button type="button" class="button" onclick="location.href='AdminAccount.aspx'"><span>go back</span></button></p>

    <p> 
       <b>Old Password:</b>  &nbsp;<br /> <asp:TextBox ID="txtPasswordOld" CssClass="tb" TextMode="password" runat="server" ></asp:TextBox>
        <br />
        <br />
        <b>New Password:</b>  &nbsp; <br /><asp:TextBox ID="txtPasswordNew" CssClass="tb" TextMode="password" runat="server" ></asp:TextBox>
        <br />
        <br /> 
       
         <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Save Password"  OnClick="ChangePassword"  />
       <br />
       <br />
        <asp:Label ID="CheckChange" runat="server"></asp:Label>
        </p>
</asp:Content>
