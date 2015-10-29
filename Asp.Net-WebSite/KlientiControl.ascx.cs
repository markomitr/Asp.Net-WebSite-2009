using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KlientiControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {       
    }
    public void Nacrtaj(String Dejnost,String[] Iminja, String[] Url,String Objasnuvanje)
    {

        this.DejnostIme.InnerText = Dejnost;
        //if (Objasnuvanje != "" && Objasnuvanje != null )
        //{
        //    this.objasnuvanjeDejnost.InnerHtml= Objasnuvanje.ToString();
        //}

        int izborLista = 1;

        for (int i = 0; i < Iminja.Length; i++)
        {
            if (izborLista % 3 == 1)
            {
           
                if (Url[i] != "" && Url[i] != null)
                {
                    this.ListaPrva.InnerHtml += "<li><a href=\"" + Url[i].ToString() + "\" target=\"_blank\">" + Iminja[i].ToString() + "</a></li>";
                   
                }
                else
                {
                    this.ListaPrva.InnerHtml += "<li>" + Iminja[i].ToString() + "</li>";
                }
                izborLista = 2;

            }
            else if (izborLista % 3 == 2)
            {

                if (Url[i] != "" && Url[i] != null)
                {
                    this.ListaVtora.InnerHtml += "<li><a href=\"" + Url[i].ToString() + "\" target=\"_blank\">" + Iminja[i].ToString() + "</a></li>";

                }
                else
                {
                    this.ListaVtora.InnerHtml += "<li>" + Iminja[i].ToString() + "</li>";
                }
                izborLista = 3;
            }
            else
            {
                if (Url[i] != "" && Url[i] != null)
                {
                    this.ListaTreta.InnerHtml += "<li><a href=\"" + Url[i].ToString() + "\" target=\"_blank\">" + Iminja[i].ToString() + "</a></li>";

                }
                else
                {
                    this.ListaTreta.InnerHtml += "<li>" + Iminja[i].ToString() + "</li>";
                }
                izborLista = 1;
            }

        }
    }
}
