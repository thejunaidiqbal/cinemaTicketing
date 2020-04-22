<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="DiscountsInCinema.aspx.cs" Inherits="DBProject.DiscountsInCinema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
         <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
    <br /><br /> <h2>Food Options In Cinemas</h2>
    <p> <button type="button" class="button"  onclick="location.href='CinemaChanges.aspx'"><span >go back</span></button></p>
   
    
    <p> 
        Cinemas: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="ListDiscounts"  >
        </asp:DropDownList>
        <br />
        <br />

        Discounts In Cinema: &nbsp;<br /> <asp:DropDownList ID="DropDownList2" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="GetDiscountDetail"  >
        </asp:DropDownList>
         <br />
        <br />
           Discount Price: &nbsp;<br /> <asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
           MinAmount: &nbsp;<br /> <asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br /><br />
        MaxAmount: &nbsp;<br /> <asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
  
        <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Remove" OnClick="Remove" />
         <br />
        <br />
        <br />
        Your Discount List: &nbsp;<br /> <asp:DropDownList ID="DropDownList3" AutoPostBack="true"  CssClass="tb"  runat="server"  OnSelectedIndexChanged=" AdminDiscountDetail" >
        </asp:DropDownList>
        <br /><br />
            Discount Price: &nbsp;<br /> <asp:TextBox ID="TextBox4" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
           MinAmount: &nbsp;<br /> <asp:TextBox ID="TextBox5" cssClass="tb" runat="server"></asp:TextBox>
        MaxAmount: &nbsp;<br /> <asp:TextBox ID="TextBox6" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add" OnClick="Add" />
        <br />
        <br />
        
        <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Done" OnClick="Done" />
         <br />
 
        
   </p> 
</asp:Content>
