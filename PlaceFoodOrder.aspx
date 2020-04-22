<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PlaceFoodOrder.aspx.cs" Inherits="DBProject.PlaceFoodOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
    
    <h2>Order Food</h2>
    
    <br />
      
    <p>
        <br />
        <br />
         Items: &nbsp; <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="GeneratePrice"  >
        </asp:DropDownList>
        Price:<asp:TextBox ID="TextBox1"  CssClass="tb"  runat="server" ></asp:TextBox>
        Quantity:<asp:TextBox ID="TextBox2"  CssClass="tb"  runat="server" ></asp:TextBox>
         <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add" OnClick="Add" />
        <br />
        <br />
        <br />
        <br />
          Your List: &nbsp; <asp:DropDownList ID="DropDownList2" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="QuantityOFItem"  >
        </asp:DropDownList>
         Your Quantity:<asp:TextBox ID="TextBox3"  CssClass="tb"  runat="server" ></asp:TextBox>
         <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Remove" OnClick="Remove" />
            
        
         <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Confirm" OnClick="Confirm" />
        <br />
        <br />
        <asp:Label  ID="Status" runat="server"></asp:Label>
</asp:Content>
