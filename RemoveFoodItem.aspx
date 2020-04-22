<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="RemoveFoodItem.aspx.cs" Inherits="DBProject.RemoveFoodItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
<%--    Return Cinemas Added by that admin  in a drop down list
    and then click remove to remove it--%>
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
     <br />  <br />
    <h2>Remove Food Item </h2>
    
    <p> <button type="button" class="button"  onclick="location.href='AddRemoveFood.aspx'"><span >go back</span></button></p>
    
    <p> 
        ItemID: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="GetFoodDetail"  >
        </asp:DropDownList>
        <br />
        <br />
        ItemName:&nbsp;<br /><asp:TextBox ID="TextBox1"  CssClass="tb"  runat="server" ></asp:TextBox>
        
      <br /><br />Price:&nbsp;<br /><asp:TextBox ID="TextBox2"  CssClass="tb"  runat="server" ></asp:TextBox>
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
