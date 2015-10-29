using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Clients : Base
{
    protected Control sodrzinaCentar;
   protected  Control headControl;
   protected  ArrayList CssArray;
   protected  String cnString;
   protected  String komanda;
   protected  SqlDataReader dt;
   protected  SqlCommand SqlCm;
   protected  SqlConnection SqlCn;
   protected String jazik;
    protected void Page_Load(object sender, EventArgs e)
    {
        cnString = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovClients;
        sodrzinaCentar = this.Master.SodrzinaC;
        jazik = "";
        if (Session["Lang"] != null)
        {
            if (Session["Lang"].ToString() == "EN")
            {
                jazik = "_EN";
            }
            else
            {
                jazik = "";
            }
        }

        this.sodrzinaCentar.Controls.Add(new LiteralControl(Resources.Sodrzina.textClients.ToString()));
        this.Nacrtaj();
    }
    public void Nacrtaj()
    {
        List<Int16>dejnosti = new List<Int16>(10);
        List<String> nizaKomintenti= new List<string>(100);
        List<String> nizaURL= new List<string>(100);
        SqlCn = new SqlConnection(cnString);

        
        if (sodrzinaCentar!= null)
        {
          try
	            {
                    SqlCn.Open();
	             String komandaDejnost = "sp_VratiDejnosti";
	             SqlCommand SqlCmDejnost = new SqlCommand(komandaDejnost,SqlCn);

	             SqlCmDejnost.CommandType = CommandType.StoredProcedure;

	             SqlDataReader dtDejnost = SqlCmDejnost.ExecuteReader();
                
	             while (dtDejnost.Read())
	             {
                    komanda = "sp_KomintentInfoDejnost";
			        SqlCm = new SqlCommand(komanda, SqlCn);
			        SqlCm.CommandType = CommandType.StoredProcedure;

        		   
			        SqlParameter param = new SqlParameter("@dejnost", SqlDbType.Int);
                    SqlCm.Parameters.Add(param).Value = Convert.ToInt16(dtDejnost["ID"].ToString());
			      try
			       {

					    dt = SqlCm.ExecuteReader();
					    nizaKomintenti.Clear();
					    nizaURL.Clear();
					    while (dt.Read())
						 {
        				   nizaKomintenti.Add(dt["Ime_Komintent"+jazik].ToString());
						   nizaURL.Add(dt["Web_Url"].ToString());
						 }
				         dt.Close();
                       if (nizaKomintenti.ToArray().Length > 0)
                       {
                        KlientiControl pom = new KlientiControl();
					    pom = (KlientiControl)LoadControl("KlientiControl.ascx");
                        pom.Nacrtaj(dtDejnost["Ime_Dejnost" + jazik].ToString(), nizaKomintenti.ToArray(), nizaURL.ToArray(), dtDejnost["Opis_Dejnost"].ToString());
					    this.sodrzinaCentar.Controls.Add(pom);
                       }                        

				    }
			       catch (Exception ex)
			       {

					    Response.Write(ex.Message);
				    }

	     }

	     dtDejnost.Close();
         SqlCn.Close();

	     }
		 catch (Exception ex)
	     {
	     Response.Write("sp_VratiDejnosti : " + ex.Message);
	     }
     }//od if
    }
}
