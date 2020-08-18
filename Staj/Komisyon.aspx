<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Komisyon.aspx.cs" Inherits="Komisyon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/komisyonn.css" rel="stylesheet" />
<%--    <link href="css/main.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Staj Komisyonu</title>
</head>
<body>
      <form id="form1" runat="server">
        <div align="center">
        <nav>
            <hr/>
            <h1 class="input">Komisyon Ekle</h1>
              <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
            <hr/>
            <div>
                    <p class="label">ID</p>
                    <asp:Label CssClass="label" ID="kId" runat="server"></asp:Label>
            </div>
            <div>
                    <span class="input">Komisyon Üyesinin Adı</span>
                    <br/>
                    <asp:TextBox ID="kAd" runat="server"></asp:TextBox>
            </div>
                    <br/>
             <div>
                    <span class="input">Komisyon Üyesinin Soyadı</span>
                    <br/>
                    <asp:TextBox ID="kSoy"  runat="server"></asp:TextBox>
            </div>
             <br/>
            <div>
                <asp:Button id="KomKaydet" text="Üyeyi Kaydet" runat="server" onclick="KomKaydet_Click" />
                <br/>
                <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
            </div>
            <br />
       </nav>
            <br />
       <nav>
            <hr />
            <h1 class="input">Komisyon Listesi</h1>
             <hr/>    
               <ul>
                   <li>No</li>
                   <li>Adı</li>
                   <li>Soyad</li>
               </ul>
             <asp:Label  Style="color:white; padding-left:50px;" autosize="false" ID="Kayit" runat="server"></asp:Label>
        </nav>
            <br/>
            <nav>
            <hr />
            <h1 class="input">Komisyon Üyesi Sil</h1> 
              <hr />
            <div>
                <span class="input">Silmek istediğiniz Üyenin ID numarasını giriniz:</span>
                <br/>
                  <asp:TextBox ID="KomisSil" runat="server"></asp:TextBox>
                </div>
            <br />
             <div>
                 <asp:Button ID="KSil" runat="server" Text="Üyeyi Sil" OnClick="KSil_Click" />
                <br/>
                <asp:Label CssClass="label" ID="Sonuclbl" runat="server"></asp:Label>
            </div>
            <br/>
        </nav>
       
       </div>
   </form>
   
</body>
</html>
