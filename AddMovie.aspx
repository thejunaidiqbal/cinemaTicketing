<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="DBProject.AddMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     <br /><br /> <h2>add movies</h2>
     
   <p> <button type="button" class="button" onclick="location.href='AdminHome.aspx'"><span>go back</span></button></p>
    
    <p>
        <asp:Label ID="Status" runat="server"></asp:Label>
        Select From List: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server"   >
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add from List" OnClick="ADDFromList" />
       &nbsp;&nbsp;
         <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Add New" OnClick="Unlock" />
        <br />
        <br />
       
        Add name: &nbsp; <br /><asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Add genre: &nbsp;<br /> <asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Add category: &nbsp; <br /><asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        Add MovieID: &nbsp; <br /><asp:TextBox ID="TextBox4" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
<br /><br />
<asp:Button ID="btnUpload" runat="server" CssClass="buttonCSS" Text="Upload" OnClick="btnUpload_Click" />
<br /><br />
<asp:Label ID="lblMessage" runat="server"></asp:Label>
<br /><br />
<asp:HyperLink ID="hyperlink" runat="server">View Uploaded Image</asp:HyperLink><br /><br />
         <asp:Button ID="Adding" CssClass="buttonCSS" runat="server" Text="Add Movie" OnClick="Add" />
     
     
       <br />
       <br />
       
        
    </p>

</asp:Content>
