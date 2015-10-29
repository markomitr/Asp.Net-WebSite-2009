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

public partial class Hardware : Base
{
   protected  ASP.NovostiBarControl[] Kontroli;
   protected  ASP.NovostiBarControl[] KontroliP;
   protected  Control sodriznaControl;
   protected  Control headControl;
   protected  String cnString;
   protected  String komanda;
   protected  SqlDataReader dt;
   protected  SqlCommand SqlCm;
   protected  SqlConnection SqlCn;
   protected HtmlControl pom;
   protected String slikiSlide;
   public String jazik;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovHardware;
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

        pom = this.Master.slikiZaSlide;

        slikiSlide = "<div id=\"slikaHome\">\n";
        slikiSlide += "<a href=\"Hardware.aspx?ID=2\"><img src=\"Images/MsiWin.jpg\" alt=\"SlikaMsi\"/></a>";
        slikiSlide += "<a href=\"News.aspx\"><img src=\"Images/TaggyG.jpg\" alt=\"SlikaTaggy\"/></a>";
        slikiSlide += "<img src=\"Images/SlikaSymbol.jpg\" alt=\"SlikaInfoBiro\"/>\n";
        slikiSlide += "</div>\n";
        pom.Controls.Add((new LiteralControl(slikiSlide)));

        cnString = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        Zapocni();
    }

    public void Zapocni()
    {
        NacrtajMeni();
        String id;
        try 
	    {
            id = Request.QueryString[0].ToString();
            Nacrtaj(id);
	    }
	    catch (Exception)
	    {
            //Treba da se nacrta Default Hardware
            NacrtajDefault();
	    }

    }
    public void Nacrtaj(String id)
    {
        KontroliP = new ASP.NovostiBarControl[10];
        Int16 i = 0;

        List<String> nizaSliki = new List<string>(5);
        komanda = "sp_HardwareInfoKategorija";

        SqlCn = new SqlConnection(cnString);
        SqlCm = new SqlCommand(komanda, SqlCn);

        SqlCm.CommandType = CommandType.StoredProcedure;
        SqlParameter param = new SqlParameter("@kategorija", SqlDbType.Int);
        SqlCm.Parameters.Add(param).Value = Convert.ToInt32(id);

        sodriznaControl = this.Master.Center;
        if (sodriznaControl != null)
        {
            try
            {
                SqlCn.Open();

                dt = SqlCm.ExecuteReader();

                while (dt.Read())
                {
                    nizaSliki.Clear();
                    KontroliP[i] = new ASP.NovostiBarControl();
                    KontroliP[i] = (ASP.NovostiBarControl)LoadControl("NovostiBarControl.ascx");
                    try
                    {
                        String komandaSliki = "sp_VratiSliki";
                        SqlCommand SqlCmSliki = new SqlCommand(komandaSliki, SqlCn);

                        SqlCmSliki.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramSliki = new SqlParameter("@ID", SqlDbType.Int);
                        SqlCmSliki.Parameters.Add(paramSliki).Value = Convert.ToInt32(dt["ID"].ToString());

                        SqlDataReader dtSliki = SqlCmSliki.ExecuteReader();

                        while (dtSliki.Read())
                        {
                            nizaSliki.Add(dtSliki["Lokacija"].ToString());
                        }

                        dtSliki.Close();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("sp_VratiSliki : " + ex.Message);
                    }
                    if(id=="4")
                    KontroliP[i].setSirinaVisina("750", "170");
                    else if (id=="3")
                        KontroliP[i].setSirinaVisina("350", "200");
                    else
                        KontroliP[i].setSirinaVisina("350", "180");

                    KontroliP[i].NacrtajProduct(dt["Ime_Proizvod" + jazik].ToString(), dt["Dolg_Opis" + jazik].ToString(), dt["Slika_Golema"].ToString(), "", nizaSliki.ToArray());
                    sodriznaControl.Controls.Add(KontroliP[i]);
                }
                dt.Close();
                SqlCn.Close();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }



    }
    public void NacrtajDefault()
    {
        Kontroli = new ASP.NovostiBarControl[4];

        for (int i = 0; i < Kontroli.Length; i++)
        {
            Kontroli[i] = new ASP.NovostiBarControl();
            Kontroli[i] = (ASP.NovostiBarControl)LoadControl("NovostiBarControl.ascx");
            Kontroli[i].setSirinaVisina("350", "175");
            Kontroli[i].ImeDiv = "Novosti";
        }
        SqlCn = new SqlConnection(cnString);

        komanda = "sp_PodatociHardware";
        SqlCm = new SqlCommand(komanda, SqlCn);
        SqlCm.CommandType = CommandType.StoredProcedure;
        SqlParameter param = new SqlParameter("@kategorija",SqlDbType.Int);
        SqlCm.Parameters.Add(param).Value = 1;

        sodriznaControl = this.Master.Center;
        if (sodriznaControl != null)
        {
            try
            {
                SqlCn.Open();

                dt = SqlCm.ExecuteReader();

                if (dt.Read())
                {
                    Kontroli[0].Nacrtaj(dt["Ime_Kategorija" + jazik].ToString(), "Images/hardware.gif", dt["Ime_Proizvod" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Slika_Golema"].ToString(), dt["Link_Naslov"].ToString(), dt["Link_Sodrzina"].ToString());
                }
                else
                {
                    Kontroli[0].Nacrtaj("Сервер", "Images/news.gif", "Нема Новости", "Во момемтов нема последни новости  од хардвер.", "", "", "");
                }
                sodriznaControl.Controls.Add(Kontroli[0]);
                dt.Close();

                SqlCm.Parameters["@kategorija"].Value = 2;
                dt = SqlCm.ExecuteReader();
                if (dt.Read())
                {
                    Kontroli[1].Nacrtaj(dt["Ime_Kategorija" + jazik].ToString(), "Images/hardware.gif", dt["Ime_Proizvod" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Slika_Golema"].ToString(), dt["Link_Naslov"].ToString(), dt["Link_Sodrzina"].ToString());
                }
                else
                {
                    Kontroli[1].Nacrtaj("Станица", "Images/news.gif", "Нема Новости", "Во момемтов нема последни новости  од хардвер.", "", "", "");
                }
                sodriznaControl.Controls.Add(Kontroli[1]);
                dt.Close();
                SqlCm.Parameters["@kategorija"].Value = 3;
                dt = SqlCm.ExecuteReader();
                if (dt.Read())
                {
                    Kontroli[2].Nacrtaj(dt["Ime_Kategorija" + jazik].ToString(), "Images/hardware.gif", dt["Ime_Proizvod" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Slika_Golema"].ToString(), dt["Link_Naslov"].ToString(), dt["Link_Sodrzina"].ToString());
                }
                else
                {
                    Kontroli[2].Nacrtaj("POS Опрема", "Images/news.gif", "Нема Новости", "Во момемтов нема последни новости  од хардвер.", "", "", "");
                }
                sodriznaControl.Controls.Add(Kontroli[2]);
                dt.Close();
                SqlCm.Parameters["@kategorija"].Value = 4;
                dt = SqlCm.ExecuteReader();
                if (dt.Read())
                {
                    Kontroli[3].Nacrtaj(dt["Ime_Kategorija" + jazik].ToString(), "Images/hardware.gif", dt["Ime_Proizvod" + jazik].ToString(), dt["Kratok_Opis" + jazik].ToString(), dt["Slika_Golema"].ToString(), dt["Link_Naslov"].ToString(), dt["Link_Sodrzina"].ToString());
                }
                else
                {
                    Kontroli[3].Nacrtaj("Мобилни уреди", "Images/news.gif", "Нема Новости", "Во момемтов нема последни новости  од хардвер.", "", "", "");
                }
                sodriznaControl.Controls.Add(Kontroli[3]);
                dt.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
    public void NacrtajMeni()
    {
        try
        {
            SqlCn = new SqlConnection(cnString);
            komanda = "sp_VratiKategorii";
            SqlCm = new SqlCommand(komanda, SqlCn);
            SqlCm.CommandType = CommandType.StoredProcedure;
            SqlCn.Open();
            dt = SqlCm.ExecuteReader();
            while (dt.Read())
            {
                this.meniHardware.InnerHtml += "<li class=\"HardmeniHli\"><a href=\"Hardware.aspx?ID=" + dt["ID"].ToString() + "\" >" + dt["Ime_Kategorija" + jazik].ToString() + "</a></li>";
            }
            SqlCn.Close();
        }
        catch (Exception ex)
        {
            SqlCn.Close();
            Response.Write("Категорија " + ex.Message);
        }
           
    }
}
