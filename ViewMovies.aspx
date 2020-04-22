<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ViewMovies.aspx.cs" Inherits="DBProject.ViewMovies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="new.css" type="text/css" charset="utf-8" />
<%--    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>--%>

         

    <h2>home</h2>

  
    <br /><br /><br />
    <div class="slideshow-container">
     
<div class="mySlides fade">
  <%--<div class="numbertext">1 / 3</div>
  <img src="Plain.jpg" style="width:100%"/>
  <div class="text">Caption Text</div>--%>
  
   
    <p>
             <asp:DataList ID="Images" runat="server"  RepeatLayout="Flow" RepeatColumns="1"
           ItemStyle-Width="22%"  OnItemCommand="Redirect" AutoPostBack="false">
           
                 <ItemTemplate>
                     <center>
                      
                     <asp:ImageButton runat="server" ID="ImageButton1" Height="500px" Width="950px" 
                     ImageUrl = '<%# "data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %> '
             
                         CommandName="GetID" CommandArgument='<%# Eval("MovieID") %>'  /></div>
                              </center>

        
   
                 </ItemTemplate>
       
                     </asp:DataList>
       </p>
           
 
        
</div>


<%--<a class="prev" onclick="plusSlides(-1)">&#10094;</a>
<a class="next" onclick="plusSlides(1)">&#10095;</a>--%>

</div>
<br/>

<%--<div style="text-align:center">
  <span class="dot" onclick="currentSlide(1)"></span> 
  <span class="dot" onclick="currentSlide(2)"></span> 
  <span class="dot" onclick="currentSlide(3)"></span> 
</div>--%>

<script>
    var slideIndex = 1;
    showSlides(slideIndex);

    function plusSlides(n) {
        showSlides(slideIndex += n);
    }

    function currentSlide(n) {
        showSlides(slideIndex = n);
    }

    function showSlides(n) {
        var i;
        var slides = document.getElementsByClassName("mySlides");
        var dots = document.getElementsByClassName("dot");
        if (n > slides.length) { slideIndex = 1 }
        if (n < 1) { slideIndex = slides.length }
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";
    }
</script>


    </asp:Content>

    
                     