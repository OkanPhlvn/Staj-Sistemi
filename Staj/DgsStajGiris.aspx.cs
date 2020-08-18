using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DgsStajGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getid();
        }
    }
  
    public static MySqlDataReader rd;
    public static MySqlDataReader rd2;

    protected void getid()
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

        if (msc.State != ConnectionState.Open)
            msc.Open();

        MySqlCommand sorgu = new MySqlCommand("SELECT (MAX(StajNo)) FROM dgsstaj", msc);
        rd = sorgu.ExecuteReader();

        if (rd.Read())
        {
            string Value = rd[0].ToString();
            if (Value == "")
            {
                id.Text = "20000";
            }
            else
            {
                id.Text = rd[0].ToString();
                id.Text = (Convert.ToInt64(id.Text) + 1).ToString();
            }
        }
        msc.Close();
    }

    protected void DgsKaydet_Click(object sender, EventArgs e)
    {
        MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");
        string sorgu = "insert into dgsStaj(StajNo,OgrenciNo,OncekiOkul,KurumAdi,KabulEdilenGun) values (@StajNo,@OgrenciNo,@OncekiOkul,@KurumAdi,@KabulEdilenGun)";

        MySqlCommand cmd = new MySqlCommand(sorgu, msc);

        if (msc.State != ConnectionState.Open)
            msc.Open();

        try
        {
             getid(); //uniq id atandı
             cmd.Parameters.AddWithValue("@StajNo", id.Text);
             cmd.Parameters.AddWithValue("@OgrenciNo", OgrenciNo.Text);
             cmd.Parameters.AddWithValue("@OncekiOkul", OncekiOkul.Text);
             cmd.Parameters.AddWithValue("@KurumAdi", KurumAdi.Text);
             cmd.Parameters.AddWithValue("@KabulEdilenGun", Convert.ToInt64(KabulEdilenGun.Text)/2);


            MySqlCommand kontrol_sorgu = new MySqlCommand("Select OgrenciNo,DgsVeyaYg from ogrenci where DgsVeyaYg = 1 and OgrenciNo like '" + OgrenciNo.Text + "%'", msc);
            
            rd = kontrol_sorgu.ExecuteReader();
        
            if (rd.Read())
            {
                if (Convert.ToInt64(KabulEdilenGun.Text)/2 < 15)
                {
                    Uyari.Text = "15 günden az staj girdiniz yapması önerilmez!"; 
                }

                rd.Close();
                cmd.ExecuteNonQuery();

                MySqlCommand ekleme_sorgu = new MySqlCommand("UPDATE ogrenci SET TopKabulGun='" + +Convert.ToInt64(KabulEdilenGun.Text)/2 + "' WHERE OgrenciNo='" + OgrenciNo.Text + "'", msc);
                rd2 = ekleme_sorgu.ExecuteReader();
                rd2.Close();

               

                SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
            }
            else
            {
                SonucLabel.Text = "Kayıt Yapılamadı, ogrenci numarasını doğru girdiğinize emin olun.";
            }
        }
        catch (Exception)
        {
            SonucLabel.Text = "Kayıt Yapılamadı, ogrencinin dgs öğrencisi olduğuna emin olun.";
        }
        finally
        {
            msc.Close();
        }

    }
}