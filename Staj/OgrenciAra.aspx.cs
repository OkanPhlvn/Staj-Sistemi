using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciAra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");
    public static MySqlDataReader dr;
    public static MySqlDataReader dr2;
    public static MySqlDataReader dr3;
    protected void arama_Click(object sender, EventArgs e)
    {

        int no = 0;
        if (int.TryParse(ogrenciNo.Text, out no))
        {
            string sorgu = "select * from ogrenci where OgrenciNo='" + ogrenciNo.Text + "'";
            string sorgu2 = "select * from dgsstaj where OgrenciNo='" + ogrenciNo.Text + "'";
            string sorgu3 = "select * from staj where OgrenciNo='" + ogrenciNo.Text + "'";


            MySqlCommand cmd = new MySqlCommand(sorgu, msc);
            MySqlCommand cmd2 = new MySqlCommand(sorgu2, msc);
            MySqlCommand cmd3 = new MySqlCommand(sorgu3, msc);

            if (msc.State != ConnectionState.Open)
                msc.Open();
           


            cmd.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);

            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();

            kayit.Text = ""; kayit2.Text = ""; kayit3.Text = ""; ogrenciBilgileri.Text = ""; DgsStajBilgileri.Text = ""; stajBilgileri.Text = ""; staj_tamamlandi_mi.Text = "";
            int toplam_gun = 0;

            try
            {
                while (dr.Read())
                {

                    ogrenciBilgileri.Text = "ÖGRENCİ BİLGİLERİ";
                    kayit.Text += "<br/>" + dr["OgrenciNo"].ToString() + " | ";
                    kayit.Text += dr["Ad"].ToString() + " | ";
                    kayit.Text += dr["Soyad"].ToString() + " | ";
                    kayit.Text += dr["Ogretim"].ToString() + " | ";
                    kayit.Text += dr["DgsVeyaYg"].ToString() + " | ";
                    kayit.Text += dr["TopKabulGun"].ToString() + "<br/>";
                    
                }

                dr.Close();
                dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    DgsStajBilgileri.Text = "DGS STAJ BİLGİLERİ";
                    kayit2.Text += "<br/>" + dr2["StajNo"].ToString() + " | ";
                    kayit2.Text += dr2["OgrenciNo"].ToString() + " | ";
                    kayit2.Text += dr2["OncekiOkul"].ToString() + " | ";
                    kayit2.Text += dr2["KurumAdi"].ToString() + " | ";
                    kayit2.Text += dr2["KabulEdilenGun"].ToString() + " | " + "<br/>";
                 toplam_gun += Convert.ToInt32(dr2["KabulEdilenGun"].ToString());

                }

                dr2.Close();
                dr3 = cmd3.ExecuteReader();

                while (dr3.Read())
                {
                    stajBilgileri.Text = "STAJ BİLGİLERİ";
                    kayit3.Text += "<br/>" + dr3["StajNo"].ToString() + " | ";
                    kayit3.Text += dr3["OgrenciNo"].ToString() + " | ";
                    kayit3.Text += dr3["Sinif"].ToString() + " | ";
                    kayit3.Text += dr3["KurumAdi"].ToString() + " | ";
                    kayit3.Text += dr3["Sehir"].ToString() + " | ";
                    kayit3.Text += dr3["BasTarih"].ToString() + " | ";
                    kayit3.Text += dr3["BitTarih"].ToString() + " | ";
                    kayit3.Text += dr3["TopGun"].ToString() + " | ";
                    kayit3.Text += dr3["KabulEdilenGun"].ToString() + " | ";
                    kayit3.Text += dr3["StajDegerlendirildiMi"].ToString() + " | " + "<br/>";
                   toplam_gun += Convert.ToInt32(dr3["TopGun"].ToString());
                }
               
                dr3.Close();
                dr = cmd.ExecuteReader();
                if (dr.Read() && toplam_gun >= 60 && Convert.ToInt32(dr["TopKabulGun"]) >= 57)
                {
                    staj_tamamlandi_mi.Text = "! " + " stajını tamamlamış" + " !" + "<br/>";
                }


                if (kayit.Text == "" && kayit2.Text == "" && kayit3.Text == "")
                {
                    ogrenciBilgileri.Text = "KAYIT BULUNAMADI";
                }
               
                msc.Close();
            }
            catch(Exception)
            {
                ogrenciBilgileri.Text = "KAYIT BULUNAMADI";
            }
        }
            
    }

}