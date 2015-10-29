using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin : System.Web.UI.Page
{
    public Dictionary<String, String> podatoci;
    protected String cnString;
    protected String komanda;
    protected SqlCommand SqlCm;
    protected SqlConnection SqlCn;
    protected int pom;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.UserName.Focus();
        this.Rezultat.Visible = false;
        cnString = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();

        if (Session["Korisnik"] != null)//Korisnikot go ima vo Sesija znaci e veke logiran. Se zemaat podatocie od sesijata.
        {
            this.podatoci = (Dictionary<String, String>)Session["Korisnik"];

            UspesenLogin();
        }
        else //Korisnikot ne e logiran
        {
            this.AdminMeni.Visible = false;

            if (IsPostBack)//Znaci deka pravi Probuva da se logira .
            {
                String User = UserName.Text.Trim();
                String Pass = Password.Text.Trim();
                if (ProveriKorisnik(User, Pass))//Takov korisnik Postoi
                {
                    //Podatocite ze zapisuvaat vo Sesion["Korisnik"] kako array od podatoci 
                    this.LogOutLinkButton.Visible = true;
                    this.LoginButton.Visible = false;
                    Response.Redirect("Admin.aspx");
                }
                else//Podatocite za korinsikot ne se tocni . Toj ne moze da se logira .
                {
                    this.UserName.Text = "Грешен Корисник !";
                }
            } //Korisnikot ne e logiran, i ne probuva da se logira.
            else
            {
                this.LogOutLinkButton.Visible = false;   
                ////Se zema od URL samo imeto na stranta (Defaulat.aspx) bidejki na nea se pravi Redirect.
                ////Ako ne se stavi ova togas ke pravi beskonecen ciklus .
                //if (Request.Url.Segments[2].ToString().ToLower() != "default.aspx")
                //{
                //    Response.Redirect("Default.aspx");
                //}
            }
        }
    }
    public void UspesenLogin()
    {
        this.LoginDiv.Controls.Remove(this.LoginTable);
        this.AdminInfo.Controls.Add(this.LoginTable);

        this.AdminMeni.Visible = true;
        this.LogOutLinkButton.Visible = true;
        this.LoginButton.Visible = false;
        this.UserName.Text = this.podatoci["Ime"].ToString();
        this.UserName.ReadOnly = true;
        this.Password.Visible = false;

        
    }

    public Boolean  ProveriKorisnik(String User, String Pass)
    {
       
        komanda = "Select ID,Ime,Username,Password From Korisnici where Username='" + User + "' and Password='" + Pass + "' and Aktiven='D'";

        SqlCn = new SqlConnection(cnString);
        SqlCm = new SqlCommand(komanda, SqlCn);
        SqlDataReader dr;
        try
        {
            SqlCn.Open();
            dr = SqlCm.ExecuteReader();
            if (dr.Read())
            {
                this.podatoci = new Dictionary<string, string>();
                this.podatoci.Add("Ime", dr["Ime"].ToString());
                this.podatoci.Add("UserName", dr["Username"].ToString());
                this.podatoci.Add("Password", dr["Password"].ToString());
            }
            else
            {
                SqlCn.Close();
                return false;
            }

            Session["Korisnik"] = podatoci;
            SqlCn.Close();
            return true;
        }
        catch (Exception ex)
        {
            SqlCn.Close();
            Response.Write(ex.Message);
        }
        return false;
    }
    protected void Logout(object sender, EventArgs e)
    {
        if (Session["Korisnik"] != null)
        {
            Session.Remove("Korisnik");
            Response.Redirect("Admin.aspx");
        }
    }
    public void VnesiKomitent()
    {
        this.Rezultat.Visible = true;
    }
    protected void potvrdiBtn_Click(object sender, EventArgs e)
    {
        pom = 0;
        statusLbl.Text = "";
        try
        {
            SqlCn = new SqlConnection(cnString);
            komanda = "Select id from komintenti where Ime_Komintent=N'" + imeTexBox.Text.ToString().Trim() + "' and Dejnost_Id=" + this.dejnostTextBox.Text.ToString().Trim();
            SqlCm = new SqlCommand(komanda, SqlCn);
            SqlCn.Open();
            pom = Convert.ToInt32(SqlCm.ExecuteScalar());
            if (pom == 0)
            {

                if (urlTexBox.Text.Length > 1)
                {
                    komanda = "Insert into komintenti(Ime_Komintent,Web_Url,Dejnost_ID) values(" + "N'" + imeTexBox.Text.ToString().Trim() + "'" + "," + "'" + "http://" + urlTexBox.Text.ToString().Trim() + "'" + "," + dejnostTextBox.Text.Trim() + ")";
                }
                else
                {
                    komanda = "Insert into komintenti(Ime_Komintent,Dejnost_ID) values(" + "N'" + imeTexBox.Text.ToString().Trim() + "'" + "," + dejnostTextBox.Text.ToString().Trim() + ")";
                }

                SqlCm.CommandText = komanda;
                SqlCm.ExecuteNonQuery();

            }
            else
            {
                statusLbl.Text = "Корисникот веќе постои со таква дејност!!!";

            }

        }
        catch (Exception ex)
        {
            SqlCn.Close();
            statusLbl.Text = "Problemi so Konekcijata";

        }
        SqlCn.Close();
        if (pom == 0)
        {
            statusLbl.Text = "Додаден нов Корисник!";
            listaIminja.InnerHtml += "<li>" + imeTexBox.Text.ToString() + "</li>";
            imeTexBox.Text = "";
            urlTexBox.Text = "";
            dejnostTextBox.Text = "";
        }
    }
    protected void KomitentiBtn_Click(object sender, EventArgs e)
    {
        LinkButton pom = ((LinkButton)sender);
        if (pom != null)
        {
            if (pom.ID == "KomitentiBtn")
            {
                VnesiKomitent();
            }
        }
    }
    protected override void CreateChildControls()
    { 
      base.CreateChildControls(); 
      if( ScriptManagerAdmin.IsInAsyncPostBack )
      {
        string fromWhere = Request[ScriptManagerAdmin.ID];   
        if( fromWhere.Contains("potvrdiBtn") )
        {
            if (pom != 0)
                statusLbl.Text = "Корисникот веќе постои со таква дејност!!!";
            else
            {
                statusLbl.Text = "Додаден нов Корисник!";
                listaIminja.InnerHtml += "<li>" + imeTexBox.Text.ToString() + "</li>";
                imeTexBox.Text = "";
                urlTexBox.Text = "";
                dejnostTextBox.Text = "";
            }


        }
      }
    }
}
