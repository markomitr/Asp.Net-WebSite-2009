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

public partial class ProizvodControl : System.Web.UI.UserControl
{
    private String sodrzina;
    private String naslov;
    private String sirinaSlika;
    private String visinaSlika;
    private String CSS; //CSS za prviot DIV
    private String CSSSliki;//CSS za vtoriot DIV - so sliki mali
    private String CSSMaliSliki;//CSS za goleminata na malite sliki

    public String Sirina
    {
        get
        {
            return this.sirinaSlika;
        }
        set
        {
            this.sirinaSlika = value;
        }
    }
    public String Visina
    {
        get
        {
            return this.visinaSlika;
        }
        set
        {
            this.visinaSlika = value;
        }
    }
    public String Sodrzina
    {
        set
        {
            this.sodrzina = value;
        }
        get
        {
            return this.sodrzina;
        }
    }
    public String Naslov
    {
        set
        {
            this.naslov = value;
        }
        get
        {
            return this.naslov;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Tekst.InnerHtml = "<img src=\"Images/Iblogo.gif\" style=\"float:right;\" alt=\"Slika\" />";
    }
    public void Nacartaj(String NasloV, String SodrzinA, String SlikA, String[] SlikI)
    {
        this.Sodrzina = SodrzinA;
        this.Naslov = NasloV;
        this.TekstDiv.InnerHtml  = "\n<div class=\"bl\"> \n <div class=\"br\"> \n <div class=\"tl\"> \n <div class=\"tr\">";
        this.TekstDiv.InnerHtml += "\n <div id=\"tekstS\" " + this.VratiStyle() + " >";
        this.TekstDiv.InnerHtml += "<a rel=\"shadowbox[" + this.Naslov + "];options={counterType:'skip',continuous:true}\" href=\"" + SlikA + "\">" + "<img src=\"" + SlikA + "\" style=\"float:right; height:70px; width:70px;\" alt=\"Slika\" />" + "</a>\n";
        this.TekstDiv.InnerHtml += "<span class=\"naslovProdukt\">" + Naslov + "</span>";
        this.TekstDiv.InnerHtml += Sodrzina;
        this.TekstDiv.InnerHtml += " </div>";
        if (SlikI != null)
        {
            this.dodadiSliki(SlikI);
        }
        this.TekstDiv.InnerHtml +=  "\n</div>\n</div>\n</div>\n</div>";

    }
    public void dodadiSliki(String[] Sliki)
    {
        this.SlikiDiv.InnerHtml = "\n <div id=\"slikiS\" "+ this.VratiStyleSliki()+" >";
        for (int i = 0; i < Sliki.Length; i++)
        {
            this.SlikiDiv.InnerHtml += "<a rel=\"shadowbox[" + this.Naslov + "];options={counterType:'skip',continuous:true}\" href=\"" + Sliki[i].ToString() + "\"><img src=\"" /*+ Sliki[i].ToString()*/ + "\"alt=\"\" "+ CSSMaliSliki +" /></a>\n";
        }
        this.SlikiDiv.InnerHtml += " </div>";
    }

    public void SetCSS(String sirina, String visina,String sirinaSlika,String visinaSlika)
    {
        String vrati = " style=\" ";
        if (sirina.Trim() != "")
        {
            vrati += "width:" + sirina + "px; ";
            CSSSliki = " style=\" width:" + sirina + "px; ";
        }

        if (visina.Trim() != "")
        {
            vrati += "min-height:" + visina + "px; ";
        }
        if (sirinaSlika.Trim() != "")
        {
            CSSMaliSliki = " width=\""+sirinaSlika +"\"";
        }
        if (visinaSlika.Trim() != "")
        {
           if(CSSMaliSliki==null)
           {
               CSSMaliSliki = " width=\"60\"";
           }
            CSSMaliSliki += " height=\""+visinaSlika+"\"";
        }

        vrati += " display:block; padding:5px; \"";
        if (CSSSliki == null)
        {
            CSSSliki = " style=\" width:400px; ";
        }
        CSSSliki += " display:block; padding:5px; \" ";

        if(CSSMaliSliki==null)
        {
            CSSMaliSliki=" width=\"60\" height=\"50\" ";
        }
        CSS = vrati;
    }
    public String VratiStyle()
    {
        if (CSS != null) //Znaci deka stilot e sitiran preku SetStyle();
        {
            return CSS;
        }
        else //Go pisuvame stilot racno
        {
            CSS = " style=\" ";
            CSS += " width:400px;  min-height:120px; padding:5px; background:#FFFFFF; \" ";
            return CSS;
        }
    }
    public String VratiStyleSliki()
    {
        if (CSSMaliSliki == null)
        {
            CSSMaliSliki = " display:none;  width=\"80\" height=\"50\" ";
        }
        if (CSSSliki != null) //Znaci deka stilot e sitiran preku SetStyle();
        {
            return CSSSliki;
        }
        else //Go pisuvame stilot racno
        {
            CSSSliki = " style=\" ";
            CSSSliki += " width:400px; display:none; padding:5px; \" ";
            return CSSSliki;
        }


    }
}