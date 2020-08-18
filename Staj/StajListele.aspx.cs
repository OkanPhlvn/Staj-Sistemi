using System;
using System.Web;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class OgrenciBilgi : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        OgrenciGetir();


    }
    Document doc = new Document();
    PdfPTable table = new PdfPTable(11);
    private void OgrenciGetir()
    {
       MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        baglanti.Open();
        string sorgu = "select * from staj where StajDegerlendirildiMi=0";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery(); 
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Kayit.Text = Kayit.Text + "<hr/>" + "<hr/>" + "<table>" + "<tr>" +
           "<td style=\"display: inline; margin-left:60px; \">" + dr["StajNo"].ToString() + " | " + "</td>";
            PdfPCell cell = new PdfPCell(new Phrase(dr["StajNo"].ToString()));
            table.AddCell(cell);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px;  \">" + dr["OgrenciNo"].ToString() + "</td>";
            PdfPCell cell2 = new PdfPCell(new Phrase(dr["OgrenciNo"].ToString()));
            table.AddCell(cell2);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px;  \">" + " | " + dr["Sinif"].ToString() + "</td>";
            PdfPCell cell3 = new PdfPCell(new Phrase(dr["Sinif"].ToString()));
            table.AddCell(cell3);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px;  \">" + " | " + dr["KurumAdi"].ToString() + "</td>";
            PdfPCell cell4 = new PdfPCell(new Phrase(dr["KurumAdi"].ToString()));
            table.AddCell(cell4);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px; \">" + " | " + dr["Sehir"].ToString()+ "</td>";
            PdfPCell cell5 = new PdfPCell(new Phrase(dr["Sehir"].ToString()));
            table.AddCell(cell5);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px; \">" + " | " + dr["BasTarih"].ToString() + "</td>";
            PdfPCell cell6 = new PdfPCell(new Phrase(dr["BasTarih"].ToString()));
            table.AddCell(cell6);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:5px;\">" + " | " + dr["BitTarih"].ToString() + "</td>";

            PdfPCell cell7 = new PdfPCell(new Phrase(dr["BitTarih"].ToString()));
            table.AddCell(cell7);

            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px; \">" + " | " + dr["TopGun"].ToString()+ "</td>";
            PdfPCell cell8 = new PdfPCell(new Phrase(dr["TopGun"].ToString()));
            table.AddCell(cell8);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px; \">" + " | " + dr["StajKonusu"].ToString() + "</td>";
            PdfPCell cell9 = new PdfPCell(new Phrase(dr["StajKonusu"].ToString()));
            table.AddCell(cell9);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline;margin-left:5px; \">" + " | " + dr["KabulEdilenGun"].ToString() + "</td>";
            PdfPCell cell10 = new PdfPCell(new Phrase(dr["KabulEdilenGun"].ToString()));
            table.AddCell(cell10);
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:5px;\">" + " | " + dr["StajDegerlendirildiMi"].ToString()+ "</td>" + "</tr>"+ "</table>" +"<br/>";
            PdfPCell cell11 = new PdfPCell(new Phrase(dr["StajDegerlendirildiMi"].ToString()));
            table.AddCell(cell11);
        }
      
        baglanti.Close();


    }
    protected void pdf_Click(object sender, EventArgs e)
    {
        pdfOlustur();
    }
    private void pdfOlustur()
    {

        BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);
        Font fontNormal = new Font(STF_Helvetica_Turkish, 12, Font.NORMAL);
        Paragraph head = new Paragraph("Staj Tablosu");
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=STAJ_PDF.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(doc, Response.OutputStream);
        doc.Open();
        doc.Add(head);
        doc.Add(new Paragraph("\n")); // Alt satır ekliyoruz
        doc.Add(table);
        doc.Add(new Paragraph("\n"));
        doc.Close();
        Response.Write(doc);
        Response.End();
    }
}
