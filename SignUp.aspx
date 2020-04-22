<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="DBProject.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
  <br /><br />  <h2>sign up</h2>
    
    <br />

    <p> 
        Enter Name: &nbsp;    
    <br />
        <asp:TextBox ID="TextBox1" CssClass="tb" runat="server" placeholder=" Name"></asp:TextBox>  
        <br />
        <br />
        Enter CNIC: &nbsp;    
    <br /> <asp:TextBox ID="TextBox2" CssClass="tb" runat="server" placeholder=" CNIC"></asp:TextBox> 
        <br />
        <br /> 
    Enter Password:  &nbsp;     
    <br /><asp:TextBox ID="txtPassword" CssClass="tb" TextMode="password" runat="server" placeholder=" Password"></asp:TextBox>
    <br />
    <br />

    Login type: &nbsp;    
    <br /> <asp:DropDownList ID="Type" CssClass="tb" runat="server">
   <asp:ListItem Text="User" Value="U"></asp:ListItem>
   <asp:ListItem Text="Administrator" Value="A"></asp:ListItem>
   </asp:DropDownList> 

   <br />
   <br />
    
    City: &nbsp;     
    <br />(User Only) &nbsp;    
    <br /> <asp:DropDownList ID="DropDownList2" CssClass="tb" runat="server" placeholder="City">
                <asp:ListItem text="Lahore" value="1"></asp:ListItem>
                <asp:ListItem Text= "Islamabad" Value ="2"></asp:ListItem>
                <asp:ListItem Text= "Karachi" Value ="3"></asp:ListItem>
                <asp:ListItem Text= "Faislabad" Value ="4"></asp:ListItem>
                <asp:ListItem Text= "Multan" Value ="5"></asp:ListItem>
            </asp:DropDownList>



   <br />
   <br />
   <asp:Button ID="Button1" CssClass="buttonCSS" runat="server" Text="Sign Up" OnClick="Sign_Up"  />
         <br />
        
    <asp:Label ID ="Message1" runat="server"></asp:Label>

   </p> 
   <br />
   
</asp:Content>