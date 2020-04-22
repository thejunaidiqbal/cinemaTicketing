<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ScreensInCinema.aspx.cs" Inherits="DBProject.ScreensInCinema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
      <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />

     <br /><br /> <h2>screens In Cinemas</h2>
    <p> <button type="button" class="button"  onclick="location.href='CinemaChanges.aspx'"><span >go back</span></button></p>
   
    <p>
        Cinema: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true" CssClass="tb" runat="server"    >
            </asp:DropDownList> 
    <br /><br />
        Screen: &nbsp; <br /><asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Price: &nbsp;<br /> <asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        TotalSeats: &nbsp; <br /><asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
   
 <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Add" OnClick="AddScreen"  />  
       

    <br />
    <br />
        <asp:Label ID="Status" runat="server"></asp:Label>

<%-- <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Remove" OnClick="RemoveScreen"  />--%>  
    </p>
</asp:Content>
