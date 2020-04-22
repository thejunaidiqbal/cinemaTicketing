<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminCinemasList.aspx.cs" Inherits="DBProject.AdminCinemasList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="mbutton2.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" href="Grid.css" type="text/css" charset="utf-8" />

     <br /><br />
     <h2>cinemas</h2>
    <p> <button type="button" class="button"  onclick="location.href='Lists.aspx'"><span >go back</span></button></p>
    <p>
 <asp:Label ID="Message" runat="server"></asp:Label>
        </p>
        <br />
        <br />
   <p> <center>
   <asp:GridView ID="CinemaGrid" runat="server"  cssClass="rnd1" Font-Bold="True" HorizontalAlign="Center"  
       CellPadding="4" BackImageUrl="~/pics/helhel.jpg" CaptionAlign="Top" Width="100px" BackColor="White"  BorderWidth="0px">
       
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFFF" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle"/>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#FFFFFF" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
 </asp:GridView></center></p>
</asp:Content>
