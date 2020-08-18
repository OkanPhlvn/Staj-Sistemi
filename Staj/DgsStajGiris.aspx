<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DgsStajGiris.aspx.cs" Inherits="DgsStajGiris" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Dgs Staj</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
            <link href="css/mains.css" rel="stylesheet" type="text/css">

    </head> 
<body>
    <div align="center">
    <footer>
        <br/>
        <h1 class="input"> DGS veya YG Staj Giriş </h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>
    
        <form id="form1" runat="server">
            <div>
                    <span class="label">Staj ID:</span>
                    <asp:Label CssClass="label" ID="id" runat="server"></asp:Label>
            </div>
       
            <asp:Label CssClass="label" ID="Uyari" runat="server"></asp:Label>
       
            <div>
                <span class="input">Öğrenci Numrası</span>
                <br/>
                <asp:TextBox ID="OgrenciNo" runat="server" required="required"/>
            </div>
         
            <br/>
        
            <div>
                <span class="input">Önceki Okulu</span>
                <br/>
                <asp:TextBox ID="OncekiOkul" runat="server" required="required"/>
            </div>

            <br/>
        
            <div>
                <span class="input">Staj Yaptığı Kurumun Adı</span>
                <br/>
                <asp:TextBox ID="KurumAdi" runat="server" required="required"/>
            </div>
        
            <br/>
        
            <div>
                <span class="input">Kabul Edilen Staj Günü</span>
                <br/>
                <asp:TextBox ID="KabulEdilenGun" runat="server"/>
            </div>
       
            <br/>
        
            <div>
                <asp:Button ID="DgsKaydet" runat="server" Text="Dgs Girişi Kaydet" onclick="DgsKaydet_Click"/>
                <br/>
                <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
            </div>
        
            <br/>

         </form>
            
        </footer>
    </div>

</body>
   
</html>