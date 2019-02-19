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
    public partial class LogIN : System.Web.UI.Page
    {
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
            conn.Open();
            string sprawdzUzytkownika = "select count(*) from Uzytkownicy where Nazwa='" + TextBoxUzytkownik.Text + "'";
            SqlCommand com = new SqlCommand(sprawdzUzytkownika, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string sprawdzHaslo = "select haslo from Uzytkownicy where Nazwa='" + TextBoxUzytkownik.Text + "'";
                SqlCommand passCom = new SqlCommand(sprawdzHaslo, conn);
                string password = passCom.ExecuteScalar().ToString().Replace(" ", "");

                if (password == TextBoxHaslo.Text)
                {
                    Session["New"] = TextBoxUzytkownik.Text;
                    Response.Write("Hasło jest OK!");
                    Response.Redirect("Menu.aspx", false);
                }
                else
                {
                    Response.Write("Błędne hasło! Proszę wprowadzić hasło jeszcze raz.");
                }
                conn.Close();
            }
            else
            {
                Response.Write("Błędny uzytkownik! Proszę wprowadzic nazwę uzytkonika jeszcze raz.");
            }
        }
    }
}