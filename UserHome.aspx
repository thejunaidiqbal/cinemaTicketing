<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="DBProject.UserHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <<link rel="stylesheet" href="MyCssFile.css" type="text/css" charset="utf-8" />
     <link rel="stylesheet" href="new.css" type="text/css" charset="utf-8" />

 <br /><br />
    <h2>home</h2>



       
      <asp:Repeater runat="server" ID="Images" OnItemCommand="Redirect">
             <ItemTemplate>
                 
          
                  
                   
                    <asp:label ID="Label" class="mySlides2" runat="server" Visible="true" Text='<%# Bind("MovieName") %>'
                                     style="font-size:40px; position:absolute; padding:10px;  font-variant:small-caps" > </asp:label>
    
                     <asp:ImageButton class="mySlides" runat="server" ID="ImageButton1" Height="500px" Width="950px" 
                     ImageUrl = '<%# "data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %> '
             
                         CommandName="GetID" CommandArgument='<%# Eval("MovieID") %>'  />
       
                    
                </ItemTemplate>
                   
    </asp:Repeater>
    <script>
        var slideIndex = 0;
        carousel();
        var slideIndex2 = 0;
        carousel2();

        function carousel() {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > x.length) { slideIndex = 1 }
            x[slideIndex - 1].style.display = "block";
            setTimeout(carousel, 3000); // Change image every 2 seconds
            
        }
        function carousel2() {
            var i;
            var x = document.getElementsByClassName("mySlides2");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            slideIndex2++;
            if (slideIndex2 > x.length) { slideIndex2 = 1 }
            x[slideIndex2 - 1].style.display = "block";
            setTimeout(carousel2, 3001); // Change image every 2 seconds

        }
    </script>


</asp:Content>
