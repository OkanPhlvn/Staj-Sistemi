<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StajGiris.aspx.cs" Inherits="StajGiris" %>
<!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Staj giris</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link href="css/mains.css" rel="stylesheet"/>
</head>

<body>
     <div align="center">
      <footer>
        <hr/>
        <h1 class="input">Staj Giriş</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>
        <form id="form2" runat="server"> 
            <div>
                 <span class="label">Staj ID</span>
                 <asp:Label CssClass="label" ID="id" runat="server"></asp:Label>
            </div>

            <asp:Label CssClass="label" ID="Uyari" runat="server"></asp:Label>
            
            <div>
                <span class="input">Ogrenci Numarası</span>
                <br/>
                <asp:TextBox ID="OgrenciNo" runat="server"></asp:TextBox>
            </div>
            
            <br/>
            
            <div>
                <span class="input">Ogrencinin Sınıfı</span>
                <br/>
                <asp:TextBox ID="Sinif"  runat="server"></asp:TextBox>
            </div>
            
            <br/>
            
            <div>   
               <span class="input">Staj Yapacağı Kurumun Adı</span>
               <br/>
               <asp:TextBox ID="KurumAdi" runat="server"></asp:TextBox>
            </div>
            
            <br/>
           
            <div>
              <span class="input">Kurumun Bulunduğu Şehir</span>
              <br/>
              <asp:TextBox ID="Sehir"  runat="server"></asp:TextBox>
            </div>
            
            <br/>
            
            <div>
                <span class="input" >Staja Başlama Tarihi</span>
                <br/>
                <asp:TextBox ID="BasTarih"  runat="server"></asp:TextBox>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server">YYYY-AY-GUN formatında giriniz</asp:Label></p>
   
            </div> 
            
            <br/>
            
            <div >
               <span class="input">Stajın Bitiş Tarihi</span>
               <br/>
               <asp:TextBox ID="BitTarih"  runat="server"></asp:TextBox>
               <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server">YYYY-AY-GUN formatında giriniz</asp:Label></p>
            </div>
          
            <br/>
            
            <div>
               <span class="input">Toplam Yapılacak Gün</span>
               <br/>
               <asp:TextBox ID="TopGun"  runat="server"></asp:TextBox>
            </div>
            
            <br/>
           
            <div>
                <span class="input">Stajın Konusu</span>
                <br />
               <%-- <asp:DropDownList ID="StajKonusu" runat="server" SelectedValue='<%# Eval("CategoryId")'> </asp:DropDownList>--%>
                 <asp:DropDownList ID="StajKonusu" runat="server" ></asp:DropDownList> 
            </div>
    
            <br/>     
            
            <div>
                <asp:Button CssClass="form" id="stajKaydet" text="Stajı Kaydet" runat="server" Onclick="stajKaydet_Click" />
                <br/>
                <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
            </div>
            <br/>   
         </form>
    </footer>

      
    </div>
    
</body>
   
</html>