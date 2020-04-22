<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="DBProject.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
    
   <br /><br /> <h2>sign in</h2>
    <br />
    <br />
    <p>
        CNIC: &nbsp     
    <br /><asp:TextBox ID="TextBox1" CssClass="tb"  runat="server" placeholder=" CNIC"></asp:TextBox> 
    <br />
    <br />

    Password: &nbsp;    
    <br /> <asp:TextBox ID="txtPassword" CssClass="tb" TextMode="password" runat="server" placeholder=" Password"></asp:TextBox>
    <br />
    <br />
    Login as: &nbsp;    
    <br />
    <asp:DropDownList ID="DropDownList1" CssClass="tb" runat="server">
                <asp:ListItem Text="Admin" value="A"></asp:ListItem>
                <asp:ListItem Text= "User" Value ="U"></asp:ListItem>
            </asp:DropDownList>
    <br />
    <br />
        <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Sign In" OnClick="Sign_In" />
         <br />
    <br />
        <asp:LinkButton ID="LinkButton1"  PostBackUrl="~/SignUp.aspx" runat="server">Sign up in case of no account!</asp:LinkButton>
        <br /><br />
        
    <asp:Label ID ="Message1" runat="server" ></asp:Label>
    <br />



    
    <br />
        </p>
</asp:Content>

