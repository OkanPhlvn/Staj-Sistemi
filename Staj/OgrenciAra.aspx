<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OgrenciAra.aspx.cs" Inherits="OgrenciAra" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <link href="css/bilgis.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <meta charset="UTF-8"/>
    <title>Ogrenci Ara</title>
</head>
<body>
    <div align="center">
    <nav class="nav">,
        <h1 class="input">Ogrenci Ara</h1>
        <a class="input" href="AnaEkran.aspx">Ana Ekrana Dön</a>
        <hr/>
        <form id="form1" runat="server">
            <div>
         
<%--                <asp:Label ID="no" runat="server" Text="Label"></asp:Label>--%>
                <asp:TextBox ID="ogrenciNo" runat="server"></asp:TextBox>
                <br/>
                <br/>
                   <asp:Button ID="arama" runat="server" Text="Ara" OnClick="arama_Click" />
                <br/>
                <br />
                   <asp:Label style="color:skyblue; font-size:20px; font-weight:bold;" autosize="false" ID="ogrenciBilgileri" runat="server"></asp:Label>
                <br/>
                    <asp:Label style="color:white;" autosize="false" ID="kayit" runat="server"></asp:Label>
                 <span style="margin-left:10px;"></span>
                    <asp:Label style="color:white;" autosize="false" ID="staj_tamamlandi_mi" runat="server"></asp:Label>

                <br/>
                      <asp:Label style="color:skyblue; font-size:20px; font-weight:bold;" autosize="false" ID="stajBilgileri" runat="server"></asp:Label>
                <br/>
                    <asp:Label style="color:white;" autosize="false" ID="kayit3" runat="server"></asp:Label>
                <br />
                   <asp:Label style="color:skyblue; font-size:20px; font-weight:bold;" autosize="false" ID="DgsStajBilgileri" runat="server"></asp:Label>
                <br/>
                    <asp:Label style="color:white;" autosize="false" ID="kayit2" runat="server"></asp:Label>
                <br />
              

               
           
            </div>
        </form>
            
     </nav>
    </div>
</body>
</html>
