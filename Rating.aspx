<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="DBProject.Rating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
  <br /><br />   <h2>Rate Cinema</h2>
   <br />
    <p>   
        <%-- Choose Cinema and Rate . Choose Movie and Rate --%>
         Cinema: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server"   >
        </asp:DropDownList>
         <br /><br />
         Rating: &nbsp;<br /> <asp:DropDownList ID="DropDownList3" AutoPostBack="true"  CssClass="tb"  runat="server"   >
             <asp:ListItem Text="1" Value="1"></asp:ListItem>
             <asp:ListItem Text="2" Value="2"></asp:ListItem>
             <asp:ListItem Text="3" Value="3"></asp:ListItem>
             <asp:ListItem Text="4" Value="4"></asp:ListItem>
             <asp:ListItem Text="5" Value="5"></asp:ListItem>
             
        </asp:DropDownList>
        <br />
        <br />
       
         <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Rate" OnClick="RateCinema" />
        <br />
        <br />
        <asp:Label ID="Status" runat="server"></asp:Label>
        </p>
</asp:Content>
