using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StajMulakat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public static MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

    public static MySqlDataReader rd2;
    public static MySqlDataReader rd3;
    public static MySqlDataReader rd;
    public static MySqlDataReader rd4;
    public static MySqlDataReader rd5;

    protected void MulakatKaydet_Click(object sender, EventArgs e)
    {
        string sorgu = "insert into mulakat(StajNo,Devam,CabaVeCalisma,IsiVaktindeYapma,AmireKarsiDavranis,IsArkadaslarinaKarsiDavranıs,Prova,Duzen,Sunum,Icerik,Mulakat) values (@StajNo,@Devam,@CabaVeCalisma,@IsiVaktindeYapma,@AmireKarsiDavranis,@IsArkadaslarinaKarsiDavranıs,@Prova,@Duzen,@Sunum,@Icerik,@Mulakat)";

        MySqlCommand cmd = new MySqlCommand(sorgu, msc);

        if (msc.State != ConnectionState.Open)
            msc.Open();
        try
        {
            cmd.Parameters.AddWithValue("@StajNo", StajNo.Text);
            cmd.Parameters.AddWithValue("@Devam", Devam.Text);
            cmd.Parameters.AddWithValue("@CabaVeCalisma", CabaVeCalisma.Text);
            cmd.Parameters.AddWithValue("@IsiVaktindeYapma", IsiVaktindeYapma.Text);
            cmd.Parameters.AddWithValue("@AmireKarsiDavranis", AmireKarsiDavranis.Text);
            cmd.Parameters.AddWithValue("@IsArkadaslarinaKarsiDavranıs", IsArkadaslarinaKarsiDavranıs.Text);
            cmd.Parameters.AddWithValue("@Prova", Prova.Text);
            cmd.Parameters.AddWithValue("@Duzen", Duzen.Text);
            cmd.Parameters.AddWithValue("@Sunum", Sunum.Text);
            cmd.Parameters.AddWithValue("@Icerik", Icerik.Text);
            cmd.Parameters.AddWithValue("@Mulakat", Mulakat.Text);




            if (Convert.ToInt32(Devam.Text) <= 5 && Convert.ToInt32(Devam.Text) >= 0
                  && Convert.ToInt32(CabaVeCalisma.Text) <= 5 && Convert.ToInt32(CabaVeCalisma.Text) >= 0
                  && Convert.ToInt32(IsiVaktindeYapma.Text) <= 5 && Convert.ToInt32(IsiVaktindeYapma.Text) >= 0
                  && Convert.ToInt32(AmireKarsiDavranis.Text) <= 5 && Convert.ToInt32(AmireKarsiDavranis.Text) >= 0
                  && Convert.ToInt32(IsArkadaslarinaKarsiDavranıs.Text) <= 5 && Convert.ToInt32(IsArkadaslarinaKarsiDavranıs.Text) >= 0
                  && Convert.ToInt32(Prova.Text) <= 100 && Convert.ToInt32(Prova.Text) >= 0
                  && Convert.ToInt32(Duzen.Text) <= 100 && Convert.ToInt32(Duzen.Text) >= 0
                  && Convert.ToInt32(Sunum.Text) <= 100 && Convert.ToInt32(Sunum.Text) >= 0
                  && Convert.ToInt32(Icerik.Text) <= 100 && Convert.ToInt32(Icerik.Text) >= 0
                  && Convert.ToInt32(Mulakat.Text) <= 100 && Convert.ToInt32(Mulakat.Text) >= 0)
            {


                MySqlCommand ogrencinum = new MySqlCommand("select TopGun from staj WHERE ogrenciNo in ( select ogrenciNo from staj where StajNo='" + StajNo.Text + "')", msc);

                rd2 = ogrencinum.ExecuteReader();



                if (rd2.Read())
                {

                    string yaptigi_gun = rd2["TopGun"].ToString();
                    rd2.Close();

                    MySqlCommand kabul_edilen_staj_ogrenci = new MySqlCommand("select TopKabulGun from ogrenci WHERE ogrenciNo in ( select ogrenciNo from staj where StajNo='" + StajNo.Text + "')", msc);

                    rd3 = kabul_edilen_staj_ogrenci.ExecuteReader();
                    if (rd3.Read())
                    {
                        string kabul_edilen_gun = rd3["TopKabulGun"].ToString();
                        long kabul_edilen_gun_int = (Convert.ToInt32(kabul_edilen_gun));
                        rd3.Close();
                        //MySqlCommand gun_sayisi = new MySqlCommand("select ogrenciNo from staj where StajNo = '" + StajNo.Text + "'", msc);

                        long degerlendir;
                        degerlendir = (((Convert.ToInt64(Devam.Text) * 80)) + ((Convert.ToInt64(CabaVeCalisma.Text) * 80)) +
                        ((Convert.ToInt64(IsiVaktindeYapma.Text) * 80)) + ((Convert.ToInt64(AmireKarsiDavranis.Text) * 80)) +
                        ((Convert.ToInt64(IsArkadaslarinaKarsiDavranıs.Text) * 80)) +
                        ((Convert.ToInt64(Prova.Text) * 15)) + ((Convert.ToInt64(Duzen.Text) * 5)) +
                        ((Convert.ToInt64(Sunum.Text) * 5)) + ((Convert.ToInt64(Icerik.Text) * 15)) +
                        ((Convert.ToInt64(Mulakat.Text) * 40)));

                        MySqlCommand ekleme_sorgu = new MySqlCommand("UPDATE ogrenci SET TopKabulGun='" + Convert.ToInt32(((kabul_edilen_gun_int) + (((degerlendir) / 10000.00) * (Convert.ToInt64(yaptigi_gun))))) + "' WHERE ogrenciNo in ( select ogrenciNo from staj where StajNo='" + StajNo.Text + "')", msc); // %(5*80/100)
                        rd = ekleme_sorgu.ExecuteReader();
                        rd.Close();

                        //MySqlCommand staj_kabul_edilen_gun = new MySqlCommand("UPDATE staj SET KabulEdilenGun='" + Convert.ToInt32((((degerlendir) / 10000) * (Convert.ToInt64(yaptigi_gun))))+ "' WHERE StajNo in(select StajNo from mulakat StajNo='" + StajNo.Text + "')", msc);
                        MySqlCommand staj_kabul_edilen_gun = new MySqlCommand("UPDATE staj SET KabulEdilenGun='" + Convert.ToInt32((((degerlendir) / 10000.00) * (Convert.ToInt64(yaptigi_gun)))) + "' WHERE StajNo='" + StajNo.Text + "'", msc);
                        //if (rd4.Read())
                        //{ 
                        rd4 = staj_kabul_edilen_gun.ExecuteReader();
                        rd4.Close();
                        //}
                        MySqlCommand staj_degerlendirdimi = new MySqlCommand("UPDATE staj SET StajDegerlendirildiMi='" + 1 + "' WHERE StajNo='" + StajNo.Text + "'", msc);
                        rd5 = staj_degerlendirdimi.ExecuteReader();
                        rd5.Close();

                        cmd.ExecuteNonQuery();
                        msc.Close();
                        SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
                    }

                }
            }
        }



        catch (Exception)
        {
            SonucLabel.Text = "Kayıt Yapılamadı, Lütfen Tekrar Deneyin";
        }
        finally
        {
            msc.Close();
        }
    }
}
