<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OgrenciGiris.aspx.cs" Inherits="OgrenciGiris" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <link href="css/mains.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <meta charset="UTF-8"/>
    <title>Ogrenci Giriş</title>
</head>
<body>
   <div align="center">

      <footer>
        
        <hr/>
         <h1 class="input">Ogrenci Giriş</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
         <br />
        <a class="input" href="StajGiris.aspx">Staj Giriş Ekranına Git</a>
        <hr/>
        <form id="form2" runat="server"> 
           
            <div>
                <span class="input">Ogrenci Numarası</span>
                <br/>
                <asp:TextBox ID="OgrenciNo" runat="server" required="required"/>
            </div>
        <br/>
            <div>  
                 <span  class="input">Ogrencinin Adı</span>
                <br/>
                 <asp:TextBox ID="Ad" runat="server" required="required"/>
            </div>
        <br/>
            <div>
                <span class="input" >Ogrencinin Soyadı</span>
                <br/>
                <asp:TextBox ID="Soyad" runat="server" required="required"/>
            </div> 
        <br/>
            <div >
                <span class="input">Ogrencinin Ogretimi</span>
                <br/>
                 <asp:TextBox ID="Ogretim" runat="server" required="required"/>
            </div>
        <br/>
               <div>
                <span class="input">Dgs Veya Yg Öğrencisi Mi?</span>
                <br/>
                  <asp:CheckBox CssClass="DgsVeyaYg" ID="DgsVeyaYg" runat="server"/>
                 <%--<asp:TextBox  ID="DgsVeyaYg" runat="server" required="required"/>--%>
            </div>
        <br/>
            <div>
                <asp:Button CssClass="form" id="ogrenciKaydet" text="Ogrenciyi Kaydet" runat="server" OnClick="ogrenciKaydet_Click" />
                <br/>
                <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
                <br />
                

                
            </div>
        <br/>   
            </form>
        
    </footer>

      
    </div>
    
  
    
</body>
</html>