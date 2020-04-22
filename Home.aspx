<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DBProject.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="new.css" type="text/css" charset="utf-8" />
    
    <h2>home</h2>
        
    <br /><br />

<img class="mySlides" src="picst/Screen.jpg" style=" max-width: 1000px; position: relative; margin: auto; height:500px;width:950px" >
<img class="mySlides" src="picst/Food.jpg" style=" max-width:1000px; position: relative; margin: auto;height:500px;width:950px">
<img class="mySlides" src="picst/Movies.jpg" style=" max-width: 1000px;position: relative;margin: auto;height:500px;width:950px"> 
    
    <script>
        var slideIndex = 0;
        carousel();

        function carousel() {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > x.length) { slideIndex = 1 }
            x[slideIndex - 1].style.display = "block";
            setTimeout(carousel, 2000); // Change image every 2 seconds
        }
    </script>



</asp:Content>