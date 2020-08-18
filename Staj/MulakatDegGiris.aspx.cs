using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class MulakatDegGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static MySqlConnection msc = new MySqlConnection("server=localhost; user id=root; password=a; database=stajbilgisistemi; pooling=false");

    protected void Kaydet_Click(object sender, EventArgs e)
    {
        string sorgu = "insert into MulakatDeg(StajNo,MulakatTarihi,MulakatSaati,KomUye1,KomUye2) values ( @StajNo,@MulakatTarihi,@MulakatSaati,@KomUye1,@KomUye2)";

        MySqlCommand cmd = new MySqlCommand(sorgu, msc);



        if (msc.State != ConnectionState.Open)
            msc.Open();
        try
        {
            cmd.Parameters.AddWithValue("@StajNo", StajNo.Text);
            cmd.Parameters.AddWithValue("@MulakatTarihi", Convert.ToDateTime(MulakatTarihi.Text));
            cmd.Parameters.AddWithValue("@MulakatSaati","120000");
            cmd.Parameters.AddWithValue("@KomUye1", KomUye1.Text);
            cmd.Parameters.AddWithValue("@KomUye2", KomUye2.Text);

            cmd.ExecuteNonQuery();
            msc.Close();
            SonucLabel.Text = "Başarıyla Kayıt Yapıldı";
        }

        catch (Exception)
        {
            SonucLabel.Text = "Kayıt Yapılamadı, Lütfen Tekrar Deneyin";
        }


    }
}