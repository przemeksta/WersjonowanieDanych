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
        string plec;
        string imieCountK;
        string imieCountM;
        string nazwiskoCountK;
        string nazwiskoCountM;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                // pobiera ilosc wierszy do losowania
                imieCountK = PobierzWartoscSQL("count(*)", "ViewImionaK");
                imieCountM = PobierzWartoscSQL("count(*)", "ViewImionaM");
                nazwiskoCountK = PobierzWartoscSQL("count(*)", "ViewNazwiskaK");
                nazwiskoCountM = PobierzWartoscSQL("count(*)", "ViewNazwiskaM");

                LabelImieCountK.Text = imieCountK;
                LabelImieCountM.Text = imieCountM;
                LabelNazwiskoCountK.Text = nazwiskoCountK;
                LabelNazwiskoCountM.Text = nazwiskoCountM;
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonDodaniePac_Click(object sender, EventArgs e)
        {
            // losujemy pleć
            if (Losowanie(3) == 1)
                plec = "K";
            else
                plec = "M";

            Response.Write(plec);
            LabelPlec.Text = plec;

            if (plec == "K")
            {
                LabelImie.Text = PobierzWartoscSQL("imie", "ViewImionaK", "pozycja = " + (Losowanie(Convert.ToInt32(imieCountK)).ToString()));
                LabelNazwisko.Text = PobierzWartoscSQL("nazwisko", "ViewNazwiskaK", "pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountK)).ToString()));
            }

            if (plec == "M")
            {
                LabelImie.Text = PobierzWartoscSQL("imie", "ViewImionaM", "pozycja = " + (Losowanie(Convert.ToInt32(imieCountM)).ToString()));
                LabelNazwisko.Text = PobierzWartoscSQL("nazwisko", "ViewNazwiskaM", "pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountM)).ToString()));
            }

           
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
                           //Response.Write(com);
                //Response.Write(com.BeginExecuteXmlReader());

                //SqlDataReader myReader = com.ExecuteReader();

                /*   while (myReader.Read())
                   {
                       Response.Write(myReader.GetString(0) + " \t" + myReader.GetInt64(1).ToString());
                   }*/
        }

        protected int Losowanie(int koniec)
        {
            System.Random x = new Random();
            return x.Next(1, koniec);
        }

        protected string PobierzWartoscSQL(string kolumna, string tabela)
        {
            string zapytanie = "select " + kolumna + " from " + tabela;
            string wynik = "error";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand com = new SqlCommand(zapytanie, conn);
                wynik = com.ExecuteScalar().ToString();
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
            return wynik;
        }

        protected string PobierzWartoscSQL(string kolumna, string tabela, string warunek)
        {
            string zapytanie = "select " + kolumna + " from " + tabela + " where " + warunek;
            string wynik = "error";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand com = new SqlCommand(zapytanie, conn);
                wynik = com.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
            return wynik;
        }
    }
}