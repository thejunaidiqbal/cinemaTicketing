<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteUserAccount.aspx.cs" Inherits="DBProject.DeleteUserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
<br />
    <br />    <h2>Delete Account?</h2>
   <p> <button type="button" class="button"  onclick="location.href='UserAccount.aspx'"><span >go back</span></button></p>
   
    <p>
    <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Yes" OnClick="DelAcc"  />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="No" OnClick="NotDelAcc"  />
    <br />
    <br />
    <asp:Label ID="Status" runat="server"></asp:Label>
        </p>
</asp:Content>



