using MySql.Data.MySqlClient;
using System;
using System.Data;

public partial class StajGiris : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getid();
        }
        ekleme();
    }

    public static MySqlDataReader rd;
    public static MySqlDataReader rd2;

    protected void ekleme()
    {

        MySqlDataReader reader;

        MySqlConnection conn = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        string sorgu = "SELECT StajKonusu FROM StajKonusu";
        MySqlCommand comm = new MySqlCommand(sorgu, conn);

        try
        {
            //Bağlantımı açıyorum.
            conn.Open();
            reader = comm.ExecuteReader();

            StajKonusu.DataSource = reader;
            StajKonusu.DataTextField = "StajKonusu";
            StajKonusu.DataBind();
            reader.Close();
        }

        catch
        {
            Response.Write("Bir hata oluştu");
        }

        finally
        {
            conn.Close();
        }
    }
    protected void getid() //id metodu
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        if (msc.State != ConnectionState.Open)
            msc.Open();

        MySqlCommand sorgu = new MySqlCommand("SELECT (MAX(StajNo)) FROM staj where StajNo<20000", msc);
        rd = sorgu.ExecuteReader();
        if (rd.Read())
        {
            string Value = rd[0].ToString();
            if (Value == "")
            {
                id.Text = "10000";
            }
            else
            {
                id.Text = rd[0].ToString();
                id.Text = (Convert.ToInt64(id.Text) + 1).ToString();
            }
        }
        msc.Close();
    }
    protected void stajKaydet_Click(object sender, EventArgs e)
    {

        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        string sorgu = "insert into staj(StajNo,OgrenciNo,Sinif,KurumAdi,Sehir,BasTarih,BitTarih,TopGun,StajKonusu) " +
            "values (@stajNo, @OgrenciNo,@Sinif,@KurumAdi,@Sehir,@BasTarih,@BitTarih,@TopGun,@StajKonusu)";

        
        MySqlCommand cmd = new MySqlCommand(sorgu, msc);

        
        if (msc.State != ConnectionState.Open)
        {
            msc.Open();
        }

        try
        {
             getid();

             Uyari.Text = " ";
            StajKonusu.Text = Convert.ToString(StajKonusu.SelectedValue);
            cmd.Parameters.AddWithValue("@StajNo", id.Text);
             cmd.Parameters.AddWithValue("@OgrenciNo", OgrenciNo.Text);
             cmd.Parameters.AddWithValue("@Sinif", Sinif.Text);
             cmd.Parameters.AddWithValue("@KurumAdi", KurumAdi.Text);
             cmd.Parameters.AddWithValue("@Sehir", Sehir.Text);
             cmd.Parameters.AddWithValue("@BasTarih", Convert.ToDateTime(BasTarih.Text));
             cmd.Parameters.AddWithValue("@BitTarih", Convert.ToDateTime(BitTarih.Text));
             cmd.Parameters.AddWithValue("@TopGun", TopGun.Text);
             cmd.Parameters.AddWithValue("@StajKonusu", StajKonusu.Text);


             if (Convert.ToInt64(TopGun.Text) < 15)
             {
               Uyari.Text = "15 günden az staj girdiniz yapması önerilmez!";
               cmd.ExecuteNonQuery();
             }
             else if (Convert.ToInt64(Sinif.Text)==2 && Convert.ToInt64(TopGun.Text) > 25)
             {
                Uyari.Text = "2.sinif öğrencisinin stajını 25 günden fazla yapması önerilmez!";
                cmd.ExecuteNonQuery();
             }
             else if (Convert.ToInt64(TopGun.Text) <= 40) { cmd.ExecuteNonQuery(); }

             else if (Convert.ToInt64(TopGun.Text) <= 60 && StajKonusu.Text == "ARGE" && StajKonusu.Text == "AR-GE" && StajKonusu.Text == "Arge") { cmd.ExecuteNonQuery(); }
 
             else
             {
                 SonucLabel.Text = "Hata oluştu, kaydedilemedi.";
             }
           
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
        }
    }
}