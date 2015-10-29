using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovNews;
        this.newsText.InnerHtml = Resources.Sodrzina.newsPageText.ToString();

    }
}
