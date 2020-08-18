using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StajKonusu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ilkyazdirma();
        }

    }
    protected void ilkyazdirma()
    {

        MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        baglanti.Open();
        string sorgu = "select * from StajKonusu";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery();
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {

            Kayit.Text = Kayit.Text+ "<p>";
            Kayit.Text = Kayit.Text + dr["StajKonusu"].ToString() + "<td style=\"display: inline; margin-left:130px; \">" + "</p>";
        }
        baglanti.Close();
    }
    protected void digyazdirma()
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        baglanti.Open();
        string sorgu = "select * from StajKonusu Where StajKonusu='" + StajKonu.Text + "'";
        MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
        cmd.ExecuteNonQuery();
        MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Kayit.Text = Kayit.Text + "<p>";
            Kayit.Text = Kayit.Text + dr["StajKonusu"].ToString() + "<td style=\"display: inline; margin-left:130px; \">" + "</p>";
        }

        baglanti.Close();
    }
    protected void SKonu_Click(object sender, EventArgs e)
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        string sorgu = "insert into StajKonusu(StajKonusu) " +
            "values (@StajKonusu)";
        MySqlCommand cmd = new MySqlCommand(sorgu, msc);
        if (msc.State != ConnectionState.Open)
        {
            msc.Open();
        }

        try
        {
            cmd.Parameters.AddWithValue("@StajKonusu", StajKonu.Text);
            cmd.ExecuteNonQuery();
            msc.Close();
            SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
            digyazdirma();
        }
        catch
        {
            SonucLabel.Text = "Hata oluştu, kaydedilemedi.";
        }
        finally
        {

            msc.Close();
           
        }
    }

    protected void KoSil_Click(object sender, EventArgs e)
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        if (msc.State != ConnectionState.Open)
            msc.Open();

        string srg = "DELETE FROM StajKonusu WHERE StajKonusu='" + KonuSil.Text + "'";
        MySqlCommand sorgu = new MySqlCommand(srg, msc);
        sorgu.ExecuteNonQuery();
        msc.Close();
        Kayit.Text = "";
        ilkyazdirma();
    }





}
