using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;



public partial class OgrenciGiris : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");
   

    protected void ogrenciKaydet_Click(object sender, EventArgs e)
    {
        string sorgu = "insert into ogrenci(OgrenciNo,Ad,Soyad,Ogretim,DgsVeyaYg) values ( @OgrenciNo, @Ad, @Soyad, @Ogretim, @DgsVeyaYg)";

        MySqlCommand cmd = new MySqlCommand(sorgu, msc);



        if (msc.State != ConnectionState.Open)
            msc.Open();
        try
        {
            cmd.Parameters.AddWithValue("@OgrenciNo", OgrenciNo.Text);
            cmd.Parameters.AddWithValue("@Ad", Ad.Text);
            cmd.Parameters.AddWithValue("@Soyad", Soyad.Text);
            cmd.Parameters.AddWithValue("@Ogretim", Ogretim.Text);
            cmd.Parameters.AddWithValue("@DgsVeyaYg", DgsVeyaYg.Checked);

            cmd.ExecuteNonQuery();
            msc.Close();
            SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
        }



        catch(Exception)
        {
            SonucLabel.Text = "Kayıt Yapılamadı, Lütfen Tekrar Deneyin";
        }
        
        
    }
}