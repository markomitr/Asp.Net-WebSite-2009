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

public partial class HardSoft : System.Web.UI.MasterPage 
{


    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public HtmlControl slikiZaSlide
    {
        get
        {
            return this.slikizaSlide;
        }
    }
    public ContentPlaceHolder Center
    {
        get
        {
            return this.centerCPH;
        }
    }
    public ContentPlaceHolder Left
    {
        get
        {
            return this.leftCPH;
        }
    }
    public String Language
    {
        get
        {
            return this.Master.Language;
        }
    }


}
