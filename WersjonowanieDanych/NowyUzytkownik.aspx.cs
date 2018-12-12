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
    public partial class NowyUzytkownik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text += Session["New"].ToString();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonZapisz_Click(object sender, EventArgs e)
        {
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

                    com2.Parameters.AddWithValue("@uzytkownik", TextBoxUzytkownik.Text);
                    com2.Parameters.AddWithValue("@haslo", TextBoxHaslo.Text);

                    com2.ExecuteNonQuery();
                    Response.Write("Rejestracja udana");
                    Response.Redirect("ListaUzytkownikow.aspx");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }
    }
}