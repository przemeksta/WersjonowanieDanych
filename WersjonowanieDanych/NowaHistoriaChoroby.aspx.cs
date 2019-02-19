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

    public partial class HistoriaChoroby : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            // pola do inserta
            string pacjent = DropDownPacjent.Text;
            string izba = DropDownIzba.Text;
            string oddzial1 = DropDownOddzial1.Text;
            string oddzial2 = DropDownOddzial2.Text;
            string rozpoznanie1 = DropDownRozpoznanie1.Text;
            string rozpoznanie2 = DropDownRozpoznanie2.Text;
            string procedura1 = DropDownProcedura1.Text;
            string procedura2 = DropDownProcedura2.Text;

            //wyswietlanie ID pól
            LabelIDPacjent.Text = pacjent;
            LabelIDIzba.Text = izba;
            LabelIDOddzial.Text = oddzial1;
            LabelIDOddzial2.Text = oddzial2;
            LabelIDRozpoznanie.Text = rozpoznanie1;
            LabelIDRozpoznanie2.Text = rozpoznanie2;
            LabelIDProcedura.Text = procedura1;
            LabelIDProcedura2.Text = procedura2;

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into Hospitalizacja(FK_ID_Pacjenta, DATA_Od, DATA_Do,FK_ID_Pobyt_izba, FK_ID_Pobyt_odd1, FK_ID_Pobyt_odd2, FK_ID_KodChoroby1, FK_ID_KodChoroby2, " +
                    "FK_ID_Procedury1, FK_ID_Procedury2, FK_ID_Procedury3, FK_ID_Procedury4, FK_ID_Procedury5, Epikryza, Zalecenia_lek, DATA_Autoryzacji, FK_ID_Uzytkownika)" +
                    "values (@Pacjent, GETDATE(), GETDATE(), @Izba, @Oddzial1, @Oddzial2, @Rozpoznanie1, @Rozpoznanie2, @Procedura1, @Procedura2, @Procedura3, @Procedura4, @Procedura5, " +
                    "'Test12345', 'Test56789', GETDATE(), @Uzytkownik)";
                SqlCommand com2 = new SqlCommand(insertQuery, conn);

                string selectQuery = "select ID_Uzytkownika from Uzytkownicy where Nazwa='" + Session["New"].ToString() + "'";

                SqlCommand com = new SqlCommand(selectQuery, conn);

                /*
                com2.Parameters.AddWithValue("@Pacjent", pacjent);
                com2.Parameters.AddWithValue("@Izba", izba);
                com2.Parameters.AddWithValue("@Oddzial1", oddzial1);
                com2.Parameters.AddWithValue("@Oddzial2", oddzial2);
                com2.Parameters.AddWithValue("@Rozpoznanie1", rozpoznanie1);
                com2.Parameters.AddWithValue("@Rozpoznanie2", rozpoznanie2);
                com2.Parameters.AddWithValue("@Procedura1", procedura1);
                com2.Parameters.AddWithValue("@Procedura2", procedura2);*/


                com2.Parameters.AddWithValue("@Pacjent", "10");
                com2.Parameters.AddWithValue("@Izba", "2");
                com2.Parameters.AddWithValue("@Oddzial1", "4");
                com2.Parameters.AddWithValue("@Oddzial2", "5");
                com2.Parameters.AddWithValue("@Rozpoznanie1", "6");
                com2.Parameters.AddWithValue("@Rozpoznanie2", "7");
                com2.Parameters.AddWithValue("@Procedura1", "97");
                com2.Parameters.AddWithValue("@Procedura2", "98"); 


                com2.Parameters.AddWithValue("@Procedura3", "99");
                com2.Parameters.AddWithValue("@Procedura4", "100");
                com2.Parameters.AddWithValue("@Procedura5", "101");
                com2.Parameters.AddWithValue("@Uzytkownik", com.ExecuteScalar().ToString());

                LabelWitam.Text += com.ExecuteScalar().ToString();

                //co to jest
                com2.ExecuteNonQuery();

                conn.Close();
                Response.Write("Sukces!!!");

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("c:/szblon/test.xml");
            dataSet.WriteXml("c:/szblon/test2.xml");
        }
    }
}