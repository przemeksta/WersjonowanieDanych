using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WersjonowanieDanych
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text = "Witam " + Session["New"].ToString();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonSzukaj_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();

                /*string sprawdzUzytkownika = "select hos.ID_Hospitalizacji, pac.Imie + ' ' + pac.Nazwisko as Pacjent, pac.KodPocztowy + ' ' + pac.Miasto + ' ' + pac.Ulica as Adres," +
                    "szp.Nazwa, szp2.Nazwa, szp3.Nazwa from((((SLOWNIK.dbo.Hospitalizacja hos INNER JOIN SLOWNIK.dbo.Pacjenci pac on hos.FK_ID_Pacjenta = pac.ID_Pacjenta) " +
                    "INNER JOIN SLOWNIK.dbo.Szpital szp on hos.FK_ID_Pobyt_izba = szp.ID_Oddzialu) INNER JOIN SLOWNIK.dbo.Szpital szp2 on hos.FK_ID_Pobyt_odd1 = szp2.ID_Oddzialu)" +
                    "INNER JOIN SLOWNIK.dbo.Szpital szp3 on hos.FK_ID_Pobyt_odd1 = szp3.ID_Oddzialu) where hos.ID_Hospitalizacji = " + DropDownListPacjent.Text;
                    */
                string sprawdzUzytkownika = "select hos.ID_Hospitalizacji, pac.Imie + ' ' + pac.Nazwisko as Pacjent, pac.KodPocztowy + ' ' + pac.Miasto + ' ' + pac.Ulica as Adres, " +
                    "szp.Nazwa, szp2.Nazwa, szp3.Nazwa, Convert(varchar(10), hos.DATA_Od, 105) as Data1, Convert(varchar(10), hos.DATA_Do, 105) as Data2, kod.KodChoroby + '-' + kod.NazwaChoroby as Choroba, " +
                    "kod2.KodChoroby + '-' + kod2.NazwaChoroby as Choroba2, " +
                    "pro1.NrKatSzczegolowe + '-' + pro1.NazwaKatSzczegolowe as Procedura1," +
                    "pro2.NrKatSzczegolowe + '-' + pro2.NazwaKatSzczegolowe as Procedura2, " +
                    "pro3.NrKatSzczegolowe + '-' + pro3.NazwaKatSzczegolowe as Procedura3," +
                    "pro4.NrKatSzczegolowe + '-' + pro4.NazwaKatSzczegolowe as Procedura4," +
                    "pro5.NrKatSzczegolowe + '-' + pro5.NazwaKatSzczegolowe as Procedura5 " +
                    "from SLOWNIK.dbo.Hospitalizacja hos INNER JOIN SLOWNIK.dbo.Pacjenci pac on hos.FK_ID_Pacjenta = pac.ID_Pacjenta " +
                    "INNER JOIN SLOWNIK.dbo.Szpital szp on hos.FK_ID_Pobyt_izba = szp.ID_Oddzialu " +
                    "INNER JOIN SLOWNIK.dbo.Szpital szp2 on hos.FK_ID_Pobyt_odd1 = szp2.ID_Oddzialu " +
                    "INNER JOIN SLOWNIK.dbo.Szpital szp3 on hos.FK_ID_Pobyt_odd1 = szp3.ID_Oddzialu " +
                    "INNER JOIN SLOWNIK.dbo.KodChoroby kod on hos.FK_ID_KodChoroby1 = kod.ID_KodChoroby " +
                    "INNER JOIN SLOWNIK.dbo.KodChoroby kod2 on hos.FK_ID_KodChoroby2 = kod2.ID_KodChoroby " +
                    "INNER JOIN SLOWNIK.dbo.Procedury pro1 on hos.FK_ID_Procedury1 = pro1.ID_Procedury " +
                    "INNER JOIN SLOWNIK.dbo.Procedury pro2 on hos.FK_ID_Procedury2 = pro2.ID_Procedury " +
                    "INNER JOIN SLOWNIK.dbo.Procedury pro3 on hos.FK_ID_Procedury3 = pro3.ID_Procedury " +
                    "INNER JOIN SLOWNIK.dbo.Procedury pro4 on hos.FK_ID_Procedury4 = pro4.ID_Procedury " +
                    "INNER JOIN SLOWNIK.dbo.Procedury pro5 on hos.FK_ID_Procedury5 = pro5.ID_Procedury " +
                    "where hos.ID_Hospitalizacji = " + DropDownListPacjent.Text;

                SqlCommand com = new SqlCommand(sprawdzUzytkownika, conn);


                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //Response.Write(reader[0]);
                    LabelID_Hospitalizacji.Text = reader[0].ToString();
                    LabelPacjebt_adres.Text = reader[1].ToString();
                    LabelIzba_Przyjec.Text = reader[2].ToString();
                    LabelOddzial.Text = reader[4].ToString();
                    LabelOddzial2.Text = reader[5].ToString();
                    LabelData_od.Text = reader[6].ToString();
                    LabelData_od.Text = reader[7].ToString();
                    LabelKod_choroby.Text = reader[8].ToString();
                    LabelKod_choroby2.Text = reader[9].ToString();
                    LabelProcedura1.Text = reader[10].ToString();
                    LabelProcedura2.Text = reader[11].ToString();
                    LabelProcedura3.Text = reader[12].ToString();
                    LabelProcedura4.Text = reader[13].ToString();
                    LabelProcedura5.Text = reader[14].ToString();
                }

                reader.Close();
                conn.Close();
                Response.Write("Sukces!!!");
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }
    }
}