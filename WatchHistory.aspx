<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WatchHistory.aspx.cs" Inherits="DBProject.WatchHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" href="Grid.css" type="text/css" charset="utf-8" />
   <h2>Watch History</h2> <br /><br />
    <p>
 <asp:Label ID="Message" runat="server"></asp:Label>
        </p>
        <br />
        <br />
   <p>Watch History:</p> 
    <p> <center>
   <asp:GridView ID="WatchGrid" runat="server"  cssClass="rnd1" Font-Bold="True" HorizontalAlign="Center"  
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
