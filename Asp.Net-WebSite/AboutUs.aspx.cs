using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class AboutUs : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovAboutUs;
        //if (Session["Lang"] != null)
        //{
        //    if (Convert.ToString(Session["Lang"]) == "EN")
        //    {
        //        this.Mk.Visible = false;
        //        this.EN.Visible = true;
        //    }
        //    else
        //    {
        //        this.Mk.Visible = true;
        //        this.EN.Visible = false;
        //    }
        //}
        //else
        //{
        //    this.EN.Visible = false;
        //    this.Mk.Visible = true;
        //}
        this.NacartajAbout();
    }
    public void NacartajAbout()
    {
        String rez;
        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#infoteam').show('slow');\n";
        rez += "$('#meniBarAbout li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle();\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle()\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.scripta.InnerHtml = rez;
    }
}
