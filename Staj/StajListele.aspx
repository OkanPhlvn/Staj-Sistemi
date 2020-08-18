<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StajListele.aspx.cs" Inherits="OgrenciBilgi" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <link href="css/bilgis.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <meta charset="UTF-8"/>
    <title>Değerlendirilmeyen Stajlar</title>
</head>

<body>
     <div align="center">
    <nav class="nav">        
         <h1 class="input">Değerlendirilmeyen Stajlar</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>  
         <form id="form1" runat="server">
        <ul >
              <li>Staj No</li> |
              <li style="color:skyblue;">Ogrenci No</li> |  
              <li>Sinif</li> |
              <li style="color:skyblue;">Kurum Adi</li> |
              <li>Sehir</li> |
              <li style="color:skyblue;">Bas.Tarih</li> |
              <li>Bit.Tarih</li> |
              <li style="color:skyblue;">Top Gun</li> |
              <li>Staj Konu</li> |
              <li style="color:skyblue;">Kabul Edilen Gun</li> |
              <li>Staj Deg. Mi</li> 
          </ul>
        <asp:Label  Style="color:white;" autosize="false" ID="Kayit" runat="server"></asp:Label>
               <div>
                   <br />
                <asp:Button ID="pdf" runat="server" Text="PDF Olarak İndir" OnClick="pdf_Click" />
                   
            </div>
              <br />
        </form>
    </nav>
    </div>
          
</body>
</html>
