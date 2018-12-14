using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            LabelIDPacjent.Text = DropDownPacjent.Text;
            LabelIDIzba.Text = DropDownIzba.Text;
            LabelIDOddzial.Text = DropDownOddzial.Text;
            LabelIDOddzial2.Text = DropDownOddzial2.Text;
        }

    }
}