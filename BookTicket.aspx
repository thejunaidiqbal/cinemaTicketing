<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookTicket.aspx.cs" Inherits="DBProject.BookTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />

     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br /><br /><h2>book ticket</h2>
    
<p> <button type="button" class="button" onclick="location.href='UserHome.aspx'"><span>go back</span></button></p>
    
    <p> 
        Movie: &nbsp; <br /><asp:TextBox ID="Movie" CssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
         
        Cinema:  &nbsp; <br /><asp:DropDownList ID="DropDownList4"  AutoPostBack="true" CssClass="tb" runat="server" OnSelectedIndexChanged="CinemaDateTime">
            </asp:DropDownList> 
        <br />
        <br />
         Time: &nbsp; <br /><asp:DropDownList ID="DropDownList2" AutoPostBack="true" CssClass="tb" runat="server" OnSelectedIndexChanged="CinemaDateTimeScreen"  >
            </asp:DropDownList>
        <br />
        <br />
        Screen:  &nbsp; <br /><asp:DropDownList ID="DropDownList5" AutoPostBack="true" CssClass="tb" runat="server" OnSelectedIndexChanged="CalculateTickets">
            </asp:DropDownList>
       <br /> <br /> Available Tickets: &nbsp;<br /> <asp:TextBox ID="TextBox6" CssClass="tb" runat="server"></asp:TextBox> 


   <br />
   <br />
         Price: &nbsp; <br /><asp:TextBox ID="TextBox1" CssClass="tb" runat="server"></asp:TextBox> 
   <br /><br />
    
    No of Tickets: &nbsp;<br /> <asp:TextBox ID="TextBox5" CssClass="tb" runat="server"></asp:TextBox> 
   <br />
   <br />
         
   <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Book" OnClick="Book" />
         <br />
        <asp:Label ID="Status" runat="server"></asp:Label>

   </p> 
   <br />
    <script>
        function CinemasShowingMovieCall(elem) {
            CinemasShowingMovie();
        }
</script>
   

</asp:Content>


