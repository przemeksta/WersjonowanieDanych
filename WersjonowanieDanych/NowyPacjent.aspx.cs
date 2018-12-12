﻿using System;
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
        string adresCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text += Session["New"].ToString();

                // pobiera ilosc wierszy do losowania
                imieCountK = PobierzWartoscSQL("count(*)", "ViewImionaK");
                imieCountM = PobierzWartoscSQL("count(*)", "ViewImionaM");
                nazwiskoCountK = PobierzWartoscSQL("count(*)", "ViewNazwiskaK");
                nazwiskoCountM = PobierzWartoscSQL("count(*)", "ViewNazwiskaM");
                adresCount = PobierzWartoscSQL("count(*)", "ViewAdresy");

                LabelImieCountK.Text = imieCountK;
                LabelImieCountM.Text = imieCountM;
                LabelNazwiskoCountK.Text = nazwiskoCountK;
                LabelNazwiskoCountM.Text = nazwiskoCountM;
                LabelAdresCount.Text = adresCount;
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonDodaniePac_Click(object sender, EventArgs e)
        {
            // pola do inserta
            string poleImie = "0";
            string poleNazwisko = "0";
            string poleAdrKod = "0";
            string poleAdrMiasto = "0";
            string poleAdrUlica = "0";

            // losujemy pleć
            if (Losowanie(3) == 1)
                plec = "K";
            else
                plec = "M";

            //Response.Write(plec);
            LabelPlec.Text = plec;

            if (plec == "K")
            {
                poleImie = PobierzWartoscSQL("imie", "ViewImionaK", "pozycja = " + (Losowanie(Convert.ToInt32(imieCountK)).ToString()));
                LabelImie.Text = poleImie;
                poleNazwisko = PobierzWartoscSQL("nazwisko", "ViewNazwiskaK", "pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountK)).ToString()));
                LabelNazwisko.Text = poleNazwisko;
            }

            if (plec == "M")
            {
                poleImie = PobierzWartoscSQL("imie", "ViewImionaM", "pozycja = " + (Losowanie(Convert.ToInt32(imieCountM)).ToString()));
                LabelImie.Text = poleImie;
                poleNazwisko = PobierzWartoscSQL("nazwisko", "ViewNazwiskaM", "pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountM)).ToString()));
                LabelNazwisko.Text = poleNazwisko;
            }

            //Adres pacjenta
            string adresTym = Losowanie(Convert.ToInt32(adresCount)).ToString();
            poleAdrKod = PobierzWartoscSQL("KodPocztowy", "ViewAdresy", "pozycja = " + adresTym);
            LabelAdresKod.Text = poleAdrKod;
            poleAdrMiasto = PobierzWartoscSQL("Miasto", "ViewAdresy", "pozycja = " + adresTym);
            LabelAdresMiasto.Text = poleAdrMiasto;
            poleAdrUlica = PobierzWartoscSQL("Ulica", "ViewAdresy", "pozycja = " + adresTym);
            LabelAdresUlica.Text = poleAdrUlica;
            
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into Pacjenci(Imie, Nazwisko, Plec, KodPocztowy, Miasto, Ulica) values (@Imie, @Nazwisko, @Plec, @KodPocztowy, @Miasto, @Ulica)";
                SqlCommand com2 = new SqlCommand(insertQuery, conn);

                com2.Parameters.AddWithValue("@Imie", poleImie);
                com2.Parameters.AddWithValue("@Nazwisko", poleNazwisko);
                com2.Parameters.AddWithValue("@Plec", plec);
                com2.Parameters.AddWithValue("@KodPocztowy", poleAdrKod);
                com2.Parameters.AddWithValue("@Miasto", poleAdrMiasto);
                com2.Parameters.AddWithValue("@Ulica", poleAdrUlica);

                com2.ExecuteNonQuery();

                conn.Close();
                Response.Write("Sukces!!!");

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
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