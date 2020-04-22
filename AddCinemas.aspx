<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddCinemas.aspx.cs" Inherits="DBProject.AddCinemas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br /><br />
     <h2>add Cinema</h2>
     <p> <button type="button" class="button"  onclick="location.href='AddRemoveCinema.aspx'"><span >go back</span></button></p>
    <p>     
     Name: &nbsp; <br /><asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        ID: &nbsp; <br /><asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Location: &nbsp;<br /> <asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Number Of Screens: &nbsp; <br /><asp:TextBox ID="TextBox4" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Contact: &nbsp; <br /><asp:TextBox ID="TextBox5" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Rating: &nbsp;<br /> <asp:TextBox ID="TextBox6" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Account No: &nbsp;<br /> <asp:TextBox ID="TextBox7" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
         Food Services: &nbsp; <br /><asp:DropDownList ID="Food" CssClass="tb" runat="server">
   <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
   <asp:ListItem Text="No" Value="N"></asp:ListItem>
   </asp:DropDownList> 
        <br /><br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add" OnClick="Add" />
       <br />
       <br /> 
        <asp:Label ID="Status" runat="server"></asp:Label>
        </p>
</asp:Content>
