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

public partial class NovostiBar : System.Web.UI.UserControl
{
    private String rez;
    private String slika;
    private String naslov;
    private String sodrzina;
    private String imeDiv;
    private String sirina;
    private String visina;
    private String pozadinaGif;
    private String slikaGolema;
    String style;
    String slikiNiza;


    public String Sirina
    {
        get
        {
            return this.sirina;
        }
        set
        {
            this.sirina = value;
        }
    }
    public String Visina
    {
        get
        {
            return this.visina;
        }
        set
        {
            this.visina = value;
        }
    }
    public String PozadinaGif
    {
        get
        {
            return this.pozadinaGif;
        }
        set
        {
            this.pozadinaGif = value;
        }
    }
    public String Slika
    {
        set
        {
          this.slika = "<img src=\"" + value + "\" alt=\"Slika\"/>";
        }
        get
        {
            return this.slika;
        }
    }
    public String SlikaGolema
    {
        set
        {
            this.slikaGolema = "<img src=\"" + value + "\" alt=\"SlikaG\"  width=\"90px\" height=\"100px\" />";
        }
        get
        {
            return this.slikaGolema;
        }
    }
    public String Naslov
    {
        set
        {
            naslov = value;
        }
        get
        {
            return this.naslov;
        }

    }

    public String Sodrzina
    {
        get
        {
           return "<li>" + sodrzina + "</li>";
        }
        set
        {
            this.sodrzina = value;
        }
       
    }
    public String ImeDiv
    {
        get
        {
            return this.imeDiv;
        }
        set
        {
            this.imeDiv  = value;
        }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void Nacrtaj(String naslov, String slika, String imeProizvod, String sodrzina, String golemaSlika, String linkNaslov, String linkNovost)
    {
        String pom = "";

        this.novostTxt.InnerHtml = "<div id=\"Novosti\">\n";
        this.Slika = slika;
        this.SlikaGolema = golemaSlika;

        if (linkNaslov.Trim() != "")//Ako imame prefleno link togas kreirame link za naslovot
        {
            pom = "<a href=\"" + linkNaslov + "\" >" + naslov + "</a>";
            this.Naslov = pom;
        }
        else this.Naslov = naslov;

        if (linkNovost.Trim() != "")//Ako imame prefleno link togas kreirame link za novosta
        {
            pom = this.slikaGolema + "<a href=\"" + linkNovost + "\" >" + imeProizvod + "</a> <br />" + sodrzina;
            this.Sodrzina = pom;
        }
        else this.Sodrzina = this.slikaGolema + imeProizvod + "<br /> " + sodrzina;
        if (style != null)
            rez = "<ul style=\"" + style + "\">";
        else
            rez = "<ul>";

        rez += this.Slika + this.Naslov + this.Sodrzina;
        this.novostTxt.InnerHtml += rez + "\n</ul>\n</div>";
    }
    public void setSirinaVisina(String sirina, String visina)
    {

        style = "width:" + sirina + "px;";
        style += "height:" + visina + "px;";
    }
    public void NacrtajProduct(String naslov,String sodrzina, String golemaSlika, String linkNaslov,String[] SlikI)
    {
        String pom = "";
        rez = "";

        this.novostTxt.InnerHtml = "<div id=\"Novosti\">\n";
        this.SlikaGolema = golemaSlika;

        if (linkNaslov.Trim() != "")//Ako imame prefleno link togas kreirame link za naslovot
        {
            pom = "<a href=\"" + linkNaslov + "\" >" + naslov + "</a>";
            this.Naslov = pom;
        }
        else this.Naslov = naslov;

        this.Sodrzina = "<a rel=\"shadowbox[" + this.Naslov + "];options={counterType:'skip',continuous:true}\" href=\"" + golemaSlika + "\"/>" + this.slikaGolema + "</a>" +  sodrzina;
        
        if (style != null)
            rez = "<ul style=\"" + style + "\">";
        else
            rez = "<ul>";

        if (SlikI != null)
        {
            this.dodadiSliki(SlikI);
        }

        rez += this.Naslov +  this.Sodrzina;
        this.novostTxt.InnerHtml += rez + slikiNiza + "\n</ul>\n</div>";
    }
    public void dodadiSliki(String[] Sliki)
    {
        slikiNiza = "<div style=\"display:none;\">";
        for (int i = 0; i < Sliki.Length; i++)
        {
            slikiNiza += "<a rel=\"shadowbox[" + this.Naslov + "];options={counterType:'skip',continuous:true}\" href=\"" + Sliki[i].ToString() + "\"></a>";
        }
        slikiNiza += "</div>";
    }
}
