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
                /*
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string imieCount = "select count(*) from ViewImionaK";
                string nazwiskoCount = "select count(*) from ViewNazwiskaK";
                //string imieCount = "select count(*) from ViewImionaK";
                //string nazwiskoCount = "select count(*) from ViewNazwiskaK";

                SqlCommand com = new SqlCommand(imieCount, conn);
                imieCountK = com.ExecuteScalar().ToString();
                LabelImieCountK.Text = imieCountK;
                SqlCommand com2 = new SqlCommand(nazwiskoCount, conn);
                nazwiskoCountK = com2.ExecuteScalar().ToString();
                LabelNazwiskoCountK.Text = nazwiskoCountK;
 
                conn.Close();*/
                LabelImieCountK.Text = PobierzWartoscSQL("count(*)", "ViewImionaK");
                LabelImieCountM.Text = PobierzWartoscSQL("count(*)", "ViewImionaM");
                LabelNazwiskoCountK.Text = PobierzWartoscSQL("count(*)", "ViewNazwiskaK");
                LabelNazwiskoCountM.Text = PobierzWartoscSQL("count(*)", "ViewNazwiskaM");
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonDodaniePac_Click(object sender, EventArgs e)
        {
            if (Losowanie(2) == 1)
                plec = "K";
            else
                plec = "M";


            LabelPlec.Text = Convert.ToString(Losowanie(3));
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
            conn.Open();
            //string imieCount = "select imie from ViewImiona where pozycja = " + (Losowanie(Convert.ToInt32(imieCountS)+1)).ToString();
            string imieCount = "select imie from ViewImiona where pozycja = " + (Losowanie(Convert.ToInt32(imieCountK) + 1)).ToString();
            string nazwiskoCount = "select nazwisko from ViewNazwiska where pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountK)+1)).ToString();

            SqlCommand com = new SqlCommand(imieCount, conn);
            SqlCommand com2 = new SqlCommand(nazwiskoCount, conn);
            //LabelPlec.Text = plec;
            LabelImie.Text = com.ExecuteScalar().ToString();
            LabelNazwisko.Text = com2.ExecuteScalar().ToString();
            LabelPlec.Text = PobierzWartoscSQL("count(*)", "ViewImionaK");
            conn.Close();

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
    }
}