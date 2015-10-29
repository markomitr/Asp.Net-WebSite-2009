using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    String lang;
    public String Language
    {
        set
        {
            this.lang = value;
        }
        get
        {
            return this.lang;
        }
    }
    public ContentPlaceHolder SodrzinaC
    {
        get
        {
            return this.sodrzina;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!Page.IsPostBack)
        //this.proveriBrowser();    
    }
    public void proveriBrowser()
    {
        String ime = Request.Browser.Browser.ToString();
        String verzija = Request.Browser.Version.ToString();
        if (ime == "IE" || ime == "Firefox")
        {
            if (ime == "IE")
            {
                if (Convert.ToInt16(verzija[0].ToString()) < 7)
                    Server.Transfer("Greska.aspx");

            }
            else
            {
                if (Convert.ToInt16(verzija[0].ToString()) < 3)
                    Server.Transfer("Greska.aspx");
            }

        }
        else
        {
            Server.Transfer("Greska.aspx");
        }
    }
    protected void SmeniJazik(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;


        if (Session["Lang"] != null)
        {
            Session["Lang"] = link.ID;
        }
        else
        {
            Session.Add("Lang", link.ID);
        }

        Server.Transfer(Request.Path);
    }
}
