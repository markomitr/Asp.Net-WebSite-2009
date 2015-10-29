using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Default : Base
{
    public ASP.Opis [] Kontroli;
    public Control sodriznaControl;
    public Control headControl;
    public ArrayList CssArray;
    public String css;
    public String jazik;
    public String[] NaslovControli;


    protected void Page_Load(object sender, EventArgs e)
    {
        NaslovControli = new String[2];
        jazik = "";
        if (Session["Lang"] != null)
        {
            if (Session["Lang"].ToString() == "EN")
            {
                jazik = "_EN";
                NaslovControli[0] = "News";
                NaslovControli[1] = "Hardware";

            }
            else
            {
                jazik = "";
                NaslovControli[0] = "Новости";
                NaslovControli[1] = "Хардвер";
            }
        }
        else
        {
            NaslovControli[0] = "Новости";
            NaslovControli[1] = "Хардвер";
        }
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovHome;

        String cnString = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        String komanda = "Select * From Novosti where ( Aktivna='D' and Naslovna='D')";

        SqlConnection SqlCn = new SqlConnection(cnString);
        SqlCommand SqlCm = new SqlCommand(komanda, SqlCn);
        SqlDataReader dt;

        Kontroli = new ASP.Opis[6];
        CssArray = new ArrayList(10);
        
        for(int i=0;i<Kontroli.Length;i++)
        {
            Kontroli[i] = new ASP.Opis();
            Kontroli[i] = (ASP.Opis) LoadControl("Opis.ascx");    
        }
        sodriznaControl = Page.Master.FindControl("sodrzina");
        int j = 0;
        if (sodriznaControl != null)
        {
            try
            {
                SqlCn.Open(); 
                try
                {
                    dt = SqlCm.ExecuteReader();
                    while (dt.Read())
                    {
                        Kontroli[j].Nacrtaj(NaslovControli[0].ToString(), dt["Ime_Novost" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Link_Novost"].ToString());
                        sodriznaControl.Controls.Add(Kontroli[j]);
                        j++;
                    }
                    
                    this.sodriznaControl.Controls.Add(new LiteralControl("<div id=\"ReklamaNaslovna\" style=\"	background-image:url(Images/Reklama1.jpg);\"></div>"));
                    
                    dt.Close();
                    SqlCm.CommandText = "Select Top 3 * From Hardware Where Naslovna='D'";
                    dt = SqlCm.ExecuteReader();
                       
                     while(dt.Read())
                     {
                         Kontroli[j].Nacrtaj(NaslovControli[1].ToString(), dt["Ime_Proizvod" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Link_Naslov"].ToString());
                         sodriznaControl.Controls.Add(Kontroli[j]);
                         j++;
                     }
                  
                    dt.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            SqlCn.Close();
        }
        headControl = Page.Master.FindControl("head");

        //sodriznaControl.Controls.Add(new LiteralControl("<!--#include file=\"Proba.aspx\"-->"));
        
    }
}
