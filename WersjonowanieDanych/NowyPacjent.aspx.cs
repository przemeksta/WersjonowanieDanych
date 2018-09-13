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
        string imieCountS;
        string nazwiskoCountS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string imieCount = "select count(*) from ViewImiona";
                string nazwiskoCount = "select count(*) from ViewNazwiska";

                SqlCommand com = new SqlCommand(imieCount, conn);
                imieCountS = com.ExecuteScalar().ToString();
                LabelImieCount.Text = imieCountS;
                SqlCommand com2 = new SqlCommand(nazwiskoCount, conn);
                nazwiskoCountS = com2.ExecuteScalar().ToString();
                LabelNazwiskoCount.Text = nazwiskoCountS;
 
                conn.Close();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonDodaniePac_Click(object sender, EventArgs e)
        {
            System.Random x = new Random();
            //LabelImie.Text = (Losowanie(Convert.ToInt32(imieCountS))).ToString();
            //LabelNazwisko.Text = (Losowanie(Convert.ToInt32(nazwiskoCountS))).ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
            conn.Open();
            string imieCount = "select imie from ViewImiona where pozycja = " + (Losowanie(Convert.ToInt32(imieCountS))).ToString();
            string nazwiskoCount = "select nazwisko from ViewNazwiska where pozycja = " + (Losowanie(Convert.ToInt32(nazwiskoCountS))).ToString();

            SqlCommand com = new SqlCommand(imieCount, conn);
            LabelImie.Text = com.ExecuteScalar().ToString();
            SqlCommand com2 = new SqlCommand(nazwiskoCount, conn);
            LabelNazwisko.Text = com2.ExecuteScalar().ToString();


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

        protected int Losowanie( int koniec)
        {
            System.Random x = new Random();

            return x.Next(1, koniec);
        }
    }
}