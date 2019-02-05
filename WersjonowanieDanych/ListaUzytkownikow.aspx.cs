using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WersjonowanieDanych
{
    public partial class ListaUzytkownikow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text = Session["New"].ToString();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void SqlDataSourceUzytkownicy_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}