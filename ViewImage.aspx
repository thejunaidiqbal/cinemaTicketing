<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewImage.aspx.cs"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
 
    </title>
 
   <body  
     background: url(images/cinema.jpg) no-repeat center center fixed; 
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;>
</body>

 
</head>
<body>
 
    <form id="form1" runat="server">
    <div>
 
    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" Height="500px" Width="950px" />
    </div>
    </form>
</body>
</html>
