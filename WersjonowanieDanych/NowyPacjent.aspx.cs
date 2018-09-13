using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WersjonowanieDanych
{
    public partial class NowyPacjent : System.Web.UI.Page
    {
        int imieCount = 0;
        int nazwiskoCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                Response.Redirect("LogIN.aspx");

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string sprawdzImiona = "select count(*) from UzytkownicyRAN ";
                //string sprawdzImiona = "select Nazwa, Pozycja  from UzytkownicyRAN ";
                SqlCommand com = new SqlCommand(sprawdzImiona, conn);
                //Response.Write(com);
                //Response.Write(com.BeginExecuteXmlReader());

                //SqlDataReader myReader = com.ExecuteReader();

                /*   while (myReader.Read())
                   {
                       Response.Write(myReader.GetString(0) + " \t" + myReader.GetInt64(1).ToString());
                   }*/
                conn.Close();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonDodaniePac_Click(object sender, EventArgs e)
        {
            string imie;
            string nazwisko;
            string pesel;
            System.Random x = new Random();
            int liczba = x.Next(1, 100);
            int liczba2 = x.Next(1, 100);
            int liczba3 = x.Next(1, 100);

            /*
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();

                string sprawdzUzytkownika = "select count(*) from Uzytkownicy where Nazwa='" + TextBoxUzytkownik.Text + "'";
                SqlCommand com = new SqlCommand(sprawdzUzytkownika, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("Użytkownik instanieje");
                    conn.Close();
                }
                else
                {
                    string insertQuery = "insert into Uzytkownicy (Nazwa, Haslo) values (@uzytkownik, @haslo)";
                    SqlCommand com2 = new SqlCommand(insertQuery, conn);

                    com.Parameters.AddWithValue("@uzytkownik", TextBoxUzytkownik.Text);
                    com.Parameters.AddWithValue("@haslo", TextBoxHaslo.Text);

                    com.ExecuteNonQuery();
                    Response.Redirect("lista.aspx");
                    Response.Write("Rejestracja udana");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
            */
        }
    }
}