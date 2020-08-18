<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StajMulakat.aspx.cs" Inherits="StajMulakat" %>
<!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mulakat Giriş</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link href="css/mains.css" rel="stylesheet"/>
</head>
<body>
   <div align="center">
     <footer>
      
       <hr/>
         <h1 class="input">Mülakat Giriş</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>

        <form id="form1" runat="server">
            <div >
                <span class="input">Staj Numarası</span>
                <br/>
                <asp:TextBox ID="StajNo" runat="server" required="required"/>
            </div>
        
            <br/>
        
            <div >
                <span class="input">Devam</span>
                <br/>
                <asp:TextBox ID="Devam" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 5 arasında bir sayı giriniz</asp:Label></p>
            </div>
       
            <br/>
        
            <div>
                <span class="input">Çaba Ve Çalışma</span>
                <br/>
                <asp:TextBox ID="CabaVeCalisma" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 5 arasında bir sayı giriniz</asp:Label></p>
            </div>
        
            <br/>
        
            <div>
                <span class="input">İşi Vaktinde Yapma</span>
                <br/>
                <asp:TextBox ID="IsiVaktindeYapma" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 5 arasında bir sayı giriniz</asp:Label></p>
            </div>
       
            <br/>
        
            <div>
                <span  class="input">Amire Karşı Davranış</span>
                <br/>
                <asp:TextBox ID="AmireKarsiDavranis" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 5 arasında bir sayı giriniz</asp:Label></p>
            </div>
        
            <br/>
        
            <div>
                <span class="input">İş Arkadaslarina Karsi Davranış</span>
                <br/>
                <asp:TextBox ID="IsArkadaslarinaKarsiDavranıs" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 5 arasında bir sayı giriniz</asp:Label></p>
            </div>
        
            <br/>
        
            <div>
                <span class="input">Prova</span>
                <br/>
                <asp:TextBox ID="Prova" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 100 arasında bir sayı giriniz</asp:Label></p>
            </div>
        
            <br/>
        
            <div>
                <span class="input">Duzen</span>
                <br/>
                <asp:TextBox ID="Duzen" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 100 arasında bir sayı giriniz</asp:Label></p>
            </div>
       
            <br/>
        
            <div>
                <span class="input">Sunum</span>
                <br/>
                <asp:TextBox ID="Sunum" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 100 arasında bir sayı giriniz</asp:Label></p>
            </div>
       
            <br/>
        
            <div>
                <span class="input">İçerik</span>
                <br/>
                <asp:TextBox ID="Icerik" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 100 arasında bir sayı giriniz</asp:Label></p>
            </div>
        
            <br/>
        
            <div>
                <span class="input" >Mulakat</span>
                <br/>
                <asp:TextBox ID="Mulakat" runat="server" required="required"/>
                <p><asp:Label  Style="color:wheat; font-size:10px;" runat="server"> 0 ile 100 arasında bir sayı giriniz</asp:Label></p>
            </div>
   
            <br/>
       
            <div >
                <asp:Button ID="MulakatKaydet" runat="server" Text="Mulakatı Kaydet" OnClick="MulakatKaydet_Click" />
                <br/>
            </div>
        
            <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
        
            <br/>
       </form>

     </footer>
    </div>
</body>
   
</html>