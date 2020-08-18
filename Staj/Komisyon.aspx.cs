using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Komisyon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getid();
            ilkyazdirma();
        }
    }

    public static MySqlDataReader rd;
    public static MySqlDataReader rd2;

    protected void getid()
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        if (msc.State != ConnectionState.Open)
            msc.Open();

        MySqlCommand sorgu = new MySqlCommand("SELECT (MAX(KomisyonNo)) FROM komisyon", msc);
        rd = sorgu.ExecuteReader();
        if (rd.Read())
        {
            string Value = rd[0].ToString();
            if (Value == "")
            {
                kId.Text = "100";
            }
            else
            {
                kId.Text = rd[0].ToString();
                kId.Text = (Convert.ToInt64(kId.Text) + 1).ToString();
            }
        }
        msc.Close();
    }

    protected void ilkyazdirma()
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        baglanti.Open();
        string sorgu = "select * from Komisyon";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery();
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            
            Kayit.Text = Kayit.Text + "<table>" + "</tr>"+ "<br/>";
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:130px; \">" + dr["KomisyonNo"].ToString();
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:110px; \">" +dr["KomisyonAdi"].ToString() ;
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:100px; \">"+ dr["KomisyonSoyadi"].ToString() + "</table>" + "</tr>";
        }

        baglanti.Close();


    }

    protected void digyazdirma()
    {
       MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");
        int asd = Convert.ToInt32(kId.Text);
        baglanti.Open();
        string sorgu = "select * from Komisyon Where KomisyonNo='" + asd + "'";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery();
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {

            Kayit.Text = Kayit.Text + "<table>" + "</tr>"+ "<br/>";
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:130px; \">" + dr["KomisyonNo"].ToString();
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:100px; \">" + dr["KomisyonAdi"].ToString();
            Kayit.Text = Kayit.Text + "<td style=\"display: inline; margin-left:100px; \">" + dr["KomisyonSoyadi"].ToString() + "</table>" + "</tr>";
        }

        baglanti.Close();
    }
    protected void KomKaydet_Click(object sender, EventArgs e)
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

      string sorgu = "insert into komisyon(KomisyonNo,KomisyonAdi,KomisyonSoyadi) " +
            "values (@KomisyonNo, @KomisyonAdi,@KomisyonSoyadi)";
        MySqlCommand cmd = new MySqlCommand(sorgu, msc);
        if (msc.State != ConnectionState.Open)
        {
            msc.Open();
        }

        try
        {
            getid();
            cmd.Parameters.AddWithValue("@KomisyonNo", kId.Text);
            cmd.Parameters.AddWithValue("@KomisyonAdi", kAd.Text);
            cmd.Parameters.AddWithValue("@KomisyonSoyadi", kSoy.Text);
            cmd.ExecuteNonQuery();
            msc.Close();
            SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
    }
        catch
        {
            SonucLabel.Text = "Hata oluştu, kaydedilemedi.";
        }
        finally
        {

            msc.Close();
        digyazdirma();
        }
    }

    protected void KSil_Click(object sender, EventArgs e)
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        if (msc.State != ConnectionState.Open)
            msc.Open();
        int nw = Convert.ToInt32(KomisSil.Text);
        string srg = "DELETE FROM Komisyon WHERE KomisyonNo='" + nw + "'";
        MySqlCommand sorgu = new MySqlCommand(srg, msc);
        sorgu.ExecuteNonQuery();
        msc.Close();
        Kayit.Text = "";
        ilkyazdirma();
    }
}