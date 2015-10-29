using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Opis : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void Nacrtaj(String NaslovGlaven, String NaslovSodrzina, String Sodrzina,String link)
    {
        if (link == null)
            link = "#";
        this.OpisNaslov.InnerText = NaslovGlaven;
        this.OpisNaslovSodrzina.InnerHtml += "<a href=\"" + link + "\">";
        this.OpisNaslovSodrzina.InnerHtml += NaslovSodrzina;
        this.OpisNaslovSodrzina.InnerHtml += "</a>";
        this.OpisSodrzina1.InnerText = Sodrzina;
    }

}
