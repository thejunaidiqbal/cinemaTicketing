<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="RemoveDiscount.aspx.cs" Inherits="DBProject.RemoveDiscount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
<%--    Return Cinemas Added by that admin  in a drop down list
    and then click remove to remove it--%>
      <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     <br />  <br />
    <h2>Remove Discount </h2>
    <p> <button type="button" class="button"  onclick="location.href='AddRemoveDiscounts.aspx'"><span >go back</span></button></p>
    
    <p> 
        Discount: &nbsp; <br /><asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="GetDiscountDetail"  >
        </asp:DropDownList>
        <br /><br />
       DiscountPrice:<br /><asp:TextBox ID="TextBox1"  CssClass="tb"  runat="server" ></asp:TextBox>
        <br />
        <br />
        Minimum Amount: &nbsp;<asp:TextBox ID="TextBox2"  CssClass="tb"  runat="server" ></asp:TextBox>
        
       &nbsp;  &nbsp; Maximum Amount: &nbsp;<asp:TextBox ID="TextBox3"  CssClass="tb"  runat="server" ></asp:TextBox>
        <br />
        <br />
   <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Remove" OnClick="Remove" />
         <br />
        <br />
   <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Done" OnClick="Done" />
        <br />
        <br />
        <asp:Label ID="Status" runat="server"></asp:Label>

   </p> 

</asp:Content>
