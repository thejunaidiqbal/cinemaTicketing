<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="FoodItemsInCinema.aspx.cs" Inherits="DBProject.FoodItemsInCinema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%-- Drop down for showing cinemas List  --%>
    <%-- Drop Down to show FoodItems of selected Cinemas List Add or remove--%>
    <%-- Drop Down to show the admins added FoodItems  static--%>
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
      <link rel="stylesheet" href="mbutton.css" type="text/css" charset="utf-8" />
   <br /><br />  <h2>Food Options In Cinemas</h2>
    <p> <button type="button" class="button"  onclick="location.href='CinemaChanges.aspx'"><span >go back</span></button></p>
   
    <br />
    
    <p> 
        Cinemas: &nbsp;<br /> <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="ListItems"  >
        </asp:DropDownList>
        <br />
        <br />

        Food Items In Cinema: &nbsp; <br /><asp:DropDownList ID="DropDownList2" AutoPostBack="true"  CssClass="tb"  runat="server" OnSelectedIndexChanged="ItemDetails"  >
        </asp:DropDownList><br /><br />
           Name: &nbsp; <asp:TextBox ID="TextBox1" cssClass="tb" runat="server"></asp:TextBox>&nbsp;&nbsp;
           Price: &nbsp; <asp:TextBox ID="TextBox2" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
  
        <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Remove" OnClick="Remove" />
         <br />
        <br />
        <br />
        Your Items List: &nbsp; <br /><asp:DropDownList ID="DropDownList3" AutoPostBack="true"  CssClass="tb"  runat="server"  OnSelectedIndexChanged=" GetFoodDetail" >
        </asp:DropDownList><br /><br />
        
           Name: &nbsp; <asp:TextBox ID="TextBox3" cssClass="tb" runat="server"></asp:TextBox>&nbsp;&nbsp;
           Price: &nbsp; <asp:TextBox ID="TextBox4" cssClass="tb" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Add" OnClick="Add" />
         <br />
   <br />
        <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Done" OnClick="Done" />
        
   </p> 
</asp:Content>
