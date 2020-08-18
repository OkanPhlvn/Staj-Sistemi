<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MulakatDegGiris.aspx.cs" Inherits="MulakatDegGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
          <link href="css/mains.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <meta charset="UTF-8"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mulakat Degerlendirildi Giriş</title>
</head>
<body>
   <div align="center">

      <footer>
        
        <hr/>
         <h1 class="input">Mulakat Giris</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>
        <form id="form2" runat="server"> 
           
            <div>
                <span class="input">Staj Numarası</span>
                <br/>
                <asp:TextBox ID="StajNo" runat="server" required="required"/>
            </div>
       
        <br/>
            <div >
                <span class="input">Mulakat Tarihi</span>
                <br/>
                 <asp:TextBox ID="MulakatTarihi" runat="server" required="required"/>
            </div>
        <br/>
        <%--       <div>
                <span class="input">Mulakat Saati</span>
                <br/>
                    <asp:TextBox ID="MulakatSaati" runat="server" />
            </div>
        <br/>--%>
            <p style="color:white;">Mulakat Saati : 12:00:00</p>
            <div>
                <span class="input">Kurul Üye 1 no</span>
                <br/>
                    <asp:TextBox ID="KomUye1" runat="server" required="required"/>
            </div>
        <br/>
             <div>
                <span class="input">Kurul Üye 2 no</span>
                <br/>
                    <asp:TextBox ID="KomUye2" runat="server" required="required"/>
            </div>
        <br/>
            <div>
                <asp:Button CssClass="form" id="Kaydet" text="Kaydet" runat="server" OnClick="Kaydet_Click" />
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
