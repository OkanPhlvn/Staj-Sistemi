<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StajKonusu.aspx.cs" Inherits="StajKonusu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/komisyonn.css" rel="stylesheet" />
    <%--<link href="css/main.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Staj Konusu</title>
</head>
<body>
     <form id="form1" runat="server">
        <div align="center">
            <nav>
                <hr />
                <h1 class="input">Staj Konusu Ekle</h1>
                 <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
                <div>
                  <hr/> 
                    <span class="input">Staj Konusu Giriniz:</span>
                    <br /> 
                    <asp:TextBox ID="StajKonu"  runat="server"></asp:TextBox>
                 </div>
            <br/>
                 <div>
                   <asp:Button id="SKonu" text="Konu Kaydet" runat="server" OnClick="SKonu_Click"  />
                   <br/>
                   <asp:Label CssClass="label" ID="SonucLabel" runat="server"></asp:Label>
                <br />
                     </div>
            </nav>
            <br />
        <nav>
            <hr />
            <h1 class="input">Staj Konu Listesi</h1>
               <ul>
                   <li>Konular</li>
               </ul>
                <hr />
             <asp:Label  Style="color:white;" autosize="false" ID="Kayit" runat="server"></asp:Label>
             <br/>
        </nav>
            <br />
        <nav>
            <hr />
            <h1 class="input">StajKonusu Sil</h1> <hr />
            <div>
                <span class="input">Silmek istediğiniz Staj Konusunu giriniz:</span>
                <br/>
                  <asp:TextBox ID="KonuSil" runat="server"></asp:TextBox>
                </div>
            <br />
             <div>
                 <asp:Button ID="KoSil" runat="server" Text="Konuyu Sil" Onclick="KoSil_Click"/>
                <br/>
                <asp:Label CssClass="label" ID="Sonuclbl" runat="server"></asp:Label>
            <br />
             </div>
            
        </nav>
        </div>
    </form>
</body>
</html>
