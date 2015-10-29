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
using System.Globalization;
using System.Threading;

public partial class Software : Base
{
    Control levContent;
    HtmlControl pom;
    String slikiSlide;
    String id;
    String prodId;
    String langID;
    public  ASP.SoftwareControl programaControl;
    protected void Page_Load(object sender, EventArgs e)
    {

        pom = this.Master.slikiZaSlide;

        slikiSlide = "<div id=\"slikaHome\">\n";
        slikiSlide += "<img src=\"Images/SlikaPonuda.jpg\" alt=\"SlikaInfoBiro\"/>\n";
        slikiSlide += "<a href=\"News.aspx\"><img src=\"Images/TaggyG.jpg\" alt=\"SlikaTaggy\"/></a>";
        slikiSlide += "<img src=\"Images/SlikaSymbol.jpg\" alt=\"SlikaInfoBiro\"/>\n";
        //slikiSlide += "<img src=\"Images/SlikaResenija.jpg\" alt=\"SlikaInfoBiro\"/>\n";
        //slikiSlide += "<img src=\"Images/slikaIb.gif\" alt=\"SlikaInfoBiro\"/>\n";
        slikiSlide += "</div>\n";
        pom.Controls.Add((new LiteralControl(slikiSlide)));

      
        this.osnovna.Visible = false;
        this.levContent = this.Master.Left;
        id = null;
        prodId = null;
        langID = null;
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                id = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ProductId"] != null)
            {
                prodId = Request.QueryString["ProductId"].ToString();
            }

            if (Session["Lang"] != null)
            {
                this.langID = (String)Session["Lang"];
            }
            else
            {
                this.langID = "mk";
            }
            
        }
        catch (Exception)
        {
            //Treba da se nacrta Default Software
            NacrtajDefault(langID);
        }

        if (id == null)
        {
            NacrtajDefault(langID);
        }
        else
        {
            switch (id)
            {
                case "1":
                    {
                        //Smetkovodsveni applikacii ?Id=1
                        if (prodId == "1")
                        {
                            //CFMA
                            NacrtajCFMA(langID);
                        }
                        else
                        {
                            NacrtajDefault(langID);
                        }
                        break;
                    }
                case "2":
                    {
                        //POS applikacii ?Id=2
                        if (prodId == "1")
                        {
                            NacrtajIMOS(langID);
                        }
                        else
                        {
                            NacrtajDefault(langID);
                        }
                        break;
                    }
                case "3":
                    {
                        NacrtajRecepti(langID);
                        break;
                    }
                case "4":
                    {
                        NacrtajKadrovo(langID);
                        break;
                    };
                case "5":
                    {
                        NacrtajMagacinskoMob(langID);
                        break;
                    };
                case "6":
                    {
                        NacrtajOsnovniSredstva(langID);
                        break;
                    };
                case "7":
                    {
                        NacrtajSocijalnaMedicina(langID);
                        break;
                    };
                case "8":
                    {
                        NacrtajPopisMob(langID);
                        break;
                    };
                case "9":
                    {
                        NacrtajPlata(langID);
                        break;
                    };
                case "10":
                    {
                        NacrtajKafana(langID);
                        break;
                    };
                default:
                    {
                        NacrtajDefault(langID);
                        break;
                    }
            }
        }

    }
    public void NacrtajDefault(string lang)
    {
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovSoftware; 
        this.osnovna.Visible = true;
    }
    public void NacrtajCFMA(string lang)
    {
        this.osnovna.Visible = false;
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovCfma;
        this.programaControl = new ASP.SoftwareControl();
        programaControl =(ASP.SoftwareControl ) LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("CFMA", lang);
        this.Programa.Controls.Add(programaControl);


        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#div1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajIMOS(string lang)
    {
        this.osnovna.Visible = false;
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovImos;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("IMOS", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#idiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').hide(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).show(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajRecepti(string lang)
    {
        this.osnovna.Visible = false;
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovRecepti;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("Recepti", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#rdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').hide(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).show(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }

    public void NacrtajKadrovo(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovKadrovo;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("Kadrovo", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#kdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').hide(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).show(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajMagacinskoMob(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovMagacinsko;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("MagacinskoMob", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#mdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').hide(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).show(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajOsnovniSredstva(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovMagacinsko;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("OsnovniSredstva", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#osdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajSocijalnaMedicina(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovMedicina;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("Medicina", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#mddiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajPopisMob(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovPopisMob;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("PopisMob", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#mddiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajPlata(string lang)
    {
        this.osnovna.Visible = false;

        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovPlata;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("Plata", lang);
        this.Programa.Controls.Add(programaControl);

        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#pdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
    public void NacrtajKafana(string lang)
    {
        this.osnovna.Visible = false;
        this.Title = Resources.Page.Naslov + " - " + Resources.Page.NaslovKafana;
        this.programaControl = new ASP.SoftwareControl();
        programaControl = (ASP.SoftwareControl)LoadControl("SoftwareControl.ascx");
        programaControl.Nacrtaj("Kafana", lang);
        this.Programa.Controls.Add(programaControl);


        String rez;

        rez = "<script type=\"text/javascript\"> \n";
        rez += "$(document).ready(function() { \n";
        rez += "$('#kafdiv1').show('slow');\n";
        rez += "$('#meniH li').click(function() { \n";
        rez += "$(\".selected\").removeClass(\"selected\");\n";
        rez += "$(this).children(\"a\").addClass(\"selected\");\n";
        rez += " $('.tekst:visible').toggle(\"slow\");\n";
        rez += " var pom = $(this).attr('id').toLowerCase();\n";
        rez += "$('#'+pom).toggle(\"slow\")\n;";
        rez += " \n  }); \n";
        rez += "});</script> \n";

        this.Skripta.InnerHtml = rez;
    }
}
