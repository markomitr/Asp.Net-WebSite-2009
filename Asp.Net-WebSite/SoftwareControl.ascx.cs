using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SoftwareControl : System.Web.UI.UserControl
{
    public void Nacrtaj(String div,String lang)
    {
        OcistiDiv();
        switch (lang)
        {
            case "EN":
                {
                    if (div == "CFMA")
                    {
                        this.CFMAEN.Visible = true;
                    }
                    else if (div == "IMOS")
                    {
                        this.IMOSEN.Visible = true;
                    }
                    else if (div == "Kadrovo")
                    {
                        this.KadrovoEN.Visible = true;
                    }
                    else if (div == "Recepti")
                    {
                        this.ReceptiEN.Visible = true;
                    }
                    else if (div == "MagacinskoMob")
                    {
                        this.MagacinMobEN.Visible = true;
                    }
                    else if (div == "OsnovniSredstva")
                    {
                        this.OsnovniSredstvaEN.Visible = true;
                    }
                    else if (div == "Medicina")
                    {
                        this.MedicinaEN.Visible = true;
                    }
                    else if (div == "PopisMob")
                    {
                        this.PopisMobEN.Visible = true;
                    }
                    else if (div == "Plata")
                    {
                        this.PlataEN.Visible = true;
                    }
                    else if (div == "Kafana")
                    {
                        this.KafanaEN.Visible = true;
                    }
                    break;
                };
            case "MK":
            default:
                {
                    {
                        if (div == "CFMA")
                        {
                            this.CFMA.Visible = true;
                        }
                        else if (div == "IMOS")
                        {
                            this.IMOS.Visible = true;
                        }
                        else if (div == "Kadrovo")
                        {
                            this.Kadrovo.Visible = true;
                        }
                        else if (div == "Recepti")
                        {
                            this.Recepti.Visible = true;
                        }
                        else if (div == "MagacinskoMob")
                        {
                            this.MagacinMob.Visible = true;
                        }
                        else if (div == "OsnovniSredstva")
                        {
                            this.OsnovniSredstva.Visible = true;
                        }
                        else if (div == "Medicina")
                        {
                            this.Medicina.Visible = true;
                        }
                        else if (div == "PopisMob")
                        {
                            this.PopisMob.Visible = true;
                        }
                        else if (div == "Plata")
                        {
                            this.Plata.Visible = true;
                        }
                        else if (div == "Kafana")
                        {
                            this.Kafana.Visible = true;
                        }
                    };
                    break;
                };
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void OcistiDiv()
    {
        this.CFMA.Visible = false;
        this.CFMAEN.Visible = false;
        this.IMOS.Visible = false;
        this.IMOSEN.Visible = false;
        this.Kadrovo.Visible = false;
        this.KadrovoEN.Visible = false;
        this.Recepti.Visible = false;
        this.ReceptiEN.Visible = false;
        this.MagacinMob.Visible = false;
        this.MagacinMobEN.Visible = false;
        this.OsnovniSredstva.Visible = false;
        this.OsnovniSredstvaEN.Visible = false;
        this.MedicinaEN.Visible = false;
        this.Medicina.Visible = false;
        this.PopisMobEN.Visible = false;
        this.PopisMob.Visible = false;
        this.Plata.Visible = false;
        this.PlataEN.Visible = false;
        this.Kafana.Visible = false;
        this.KafanaEN.Visible = false;
    }
}
