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
using System.Net.Mail;

public partial class ContactUs : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovContactUs;
        this.contactTextTel.InnerHtml = Resources.Sodrzina.contactTextTel.ToString();
    }
    
}
