using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;

/// <summary>
/// Summary description for Base
/// </summary>
public class Base: Page
{
	public Base()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected override void InitializeCulture()
    {
        String lang = (string)Session["Lang"];

        if (string.IsNullOrEmpty(lang))
        {
            lang = "mk";
        }

        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);



        base.InitializeCulture();
    }
}
