<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddShow.aspx.cs" Inherits="DBProject.AddShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<%--    admin Movies List admin Cinemas List respective screens of that cinema and also status='pending' and 'FilledSeats'==0 initially--%>
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />

   <br /> <br />  <h2>Register Show</h2>
    
    <br />
    
    <p> 
         ShowID: &nbsp; <br /> <asp:TextBox ID="TextBox1" CssClass="tb" runat="server"></asp:TextBox> 
        <br />
        <br />

        Movie: &nbsp;  <br /><asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="AdminCinemas"  >
        </asp:DropDownList>
        <br />
        <br />
         
        Cinema:  &nbsp;  <br /><asp:DropDownList ID="DropDownList2"  AutoPostBack="true" CssClass="tb" runat="server" >
            </asp:DropDownList> 
        <br />
        <br />
        
         Date/Time: &nbsp; <br /> <asp:TextBox ID="TextBox2" CssClass="tb" runat="server"> </asp:TextBox> 
        <br />
        <br />
         Screen: &nbsp; <br /> <asp:DropDownList ID="DropDownList3" AutoPostBack="true" CssClass="tb" runat="server"   >
            </asp:DropDownList> 
        <br />
        <br />
   
         
   <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Book" OnClick="AddShowtime" />
         <br />
        <asp:Label ID="Status" runat="server"></asp:Label>

   </p> 
</asp:Content>
