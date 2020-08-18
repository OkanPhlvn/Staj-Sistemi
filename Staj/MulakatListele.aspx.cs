using System;
using System.Web;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class MulakatListele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MulakatListe();
    }

    Document doc = new Document();
    PdfPTable table = new PdfPTable(8);
    private void MulakatListe()
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        baglanti.Open();
        string sorgu = "select o.OgrenciNo,o.Ad,o.Soyad,o.Ogretim,m.MulakatTarihi,m.MulakatSaati,m.KomUye1,m.KomUye2 from MulakatDeg m,Ogrenci o, staj s  where o.OgrenciNo = s.OgrenciNo and m.StajNo = s.StajNo and s.StajDegerlendirildiMi = false; ";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery();
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Kayit.Text = Kayit.Text + "<hr/>";
            Kayit.Text = Kayit.Text + dr["OgrenciNo"].ToString() + "<span style=\"margin-left:10px; position:relative; outline: none;\" ></span>";
            PdfPCell cell = new PdfPCell(new Phrase(dr["OgrenciNo"].ToString()));
            table.AddCell(cell);
            Kayit.Text = Kayit.Text + dr["Ad"].ToString() + "<span style=\"padding-left:10px; position:relative; outline: none;\" ></span>";
            PdfPCell cell2 = new PdfPCell(new Phrase(dr["Ad"].ToString()));
            table.AddCell(cell2);
            Kayit.Text = Kayit.Text + dr["Soyad"].ToString() + "<span style=\"padding-left:10px;  position:relative; outline: none;;\" ></span>";
            PdfPCell cell3 = new PdfPCell(new Phrase(dr["Soyad"].ToString()));
            table.AddCell(cell3);
            Kayit.Text = Kayit.Text + dr["Ogretim"].ToString() + "<span style=\"padding-left:10px;  position:relative; outline: none;\" ></span>";
            PdfPCell cell4 = new PdfPCell(new Phrase(dr["Ogretim"].ToString()));
            table.AddCell(cell4);
            Kayit.Text = Kayit.Text + dr["MulakatTarihi"].ToString() + "<span style=\"padding-left:10px;  position:relative; outline: none;\" ></span>";
            PdfPCell cell5 = new PdfPCell(new Phrase(dr["MulakatTarihi"].ToString()));
            table.AddCell(cell5);
            Kayit.Text = Kayit.Text + dr["MulakatSaati"].ToString() + "<span style=\"padding-left:10px;  position:relative; outline: none;\" ></span>";
            PdfPCell cell6 = new PdfPCell(new Phrase(dr["MulakatSaati"].ToString()));
            table.AddCell(cell6);
            Kayit.Text = Kayit.Text + dr["KomUye1"].ToString() + "<span style=\"margin-left:10px; position:relative; outline: none;\" ></span>";
            PdfPCell cell7 = new PdfPCell(new Phrase(dr["KomUye1"].ToString()));
            table.AddCell(cell7);
            Kayit.Text = Kayit.Text + dr["KomUye2"].ToString() + "<span style=\"padding-left:10px; position:relative; outline: none;\" ></span>" +"<br/>";
            PdfPCell cell8 = new PdfPCell(new Phrase(dr["KomUye2"].ToString()));
            table.AddCell(cell8);

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
        Paragraph head = new Paragraph("Mülakat Tablosu");
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Mulakat_PDF.pdf");
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