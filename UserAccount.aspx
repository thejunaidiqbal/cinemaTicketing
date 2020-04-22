<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="DBProject.UserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
  <br /><br />  <h2>account</h2>
    
         
    <br />

    <p> Name: &nbsp;<br />
        <asp:TextBox ID="TextBox1" CssClass="tb" runat="server" placeholder=" Name"></asp:TextBox>  
        <br />
        <br />
        CNIC: &nbsp;<br /> <asp:TextBox ID="TextBox2" CssClass="tb" runat="server" placeholder=" CNIC" ></asp:TextBox> 
        <br />
        <br />
        City: &nbsp; <br />
        <asp:DropDownList ID="DropDownList1" CssClass="tb" runat="server" placeholder="City">
                <asp:ListItem text="Lahore" value="1"></asp:ListItem>
                <asp:ListItem Text= "Islamabad" Value ="2"></asp:ListItem>
                <asp:ListItem Text= "Karachi" Value ="3"></asp:ListItem>
                <asp:ListItem Text= "Faislabad" Value ="4"></asp:ListItem>
                <asp:ListItem Text= "Multan" Value ="5"></asp:ListItem>
            </asp:DropDownList>
  

       <br />
       <br />
        Movies Watched: &nbsp <br /><asp:Label ID="Label1"  runat="server" placeholder=" Name"></asp:Label>  
       <br />
       <br />
        Money Spent: &nbsp<asp:Label ID="Label2"  runat="server" placeholder=" Name"></asp:Label>  
       <br />
       <br />

       <asp:Button ID="Button2" CssClass="buttonCSS" runat="server" Text="Save Changes" OnClick="EditInfo" />
        <asp:Button ID="Button3" CssClass="buttonCSS" runat="server" Text="Change Password" OnClick="ChangeP"  />
       <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Delete Account" OnClick="DelAcc"  />
        <asp:Button ID="Button4" CssClass="buttonCSS" runat="server" Text="Edit" OnClick="Refresh"  />
       <br />
        <br />
        
        <asp:Label ID="CheckChange" runat="server"></asp:Label>

   </p> 
   <br />



</asp:Content>
