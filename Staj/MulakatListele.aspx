<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MulakatListele.aspx.cs" Inherits="MulakatListele" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bilgis.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mulakat Listele</title>
</head>
<body>
       <div align="center">
    <nav class="nav">     
         <h1 class="input">Mulakat Listele</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>    
        <form id="form1" runat="server">
        <ul>
              <li style="color:skyblue;">No</li>  |
              <li>Adı</li> |
              <li style="color:skyblue;">Soyad</li> |
              <li>Ogretim</li> |
              <li style="color:skyblue;">Mulakat Tarihi</li> |
              <li>Mulakat Saati</li> |
              <li style="color:skyblue;">KU1</li> |
              <li>KU2</li> |

          </ul>
        <asp:Label  Style="color:white;" autosize="false" ID="Kayit" runat="server"></asp:Label>
          <div>
              <br />
                <asp:Button ID="pdf" runat="server" Text="PDF Olarak İndir" OnClick="pdf_Click" />
            </div>    
        <br/>
      </form>
    </nav>
           
    </div>
          
</body>
</html>
