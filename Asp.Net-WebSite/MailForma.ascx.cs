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
using System.Net.Mail;

public partial class MailForma : System.Web.UI.UserControl
{
    MailMessage mail;
    String[] status;
    protected void Page_Load(object sender, EventArgs e)
    {
        status = new String[2];

        if (Session["Lang"] != null)
        {
            if (Session["Lang"].ToString() == "EN")
            {
                this.imeLbl.Text = "Name";
                this.kompanijaLbl.Text = "Company";
                this.emailLbl.Text = "e-mail";
                this.subjcetLbl.Text = "Subject";
                this.porakaLbl.Text = "Message";
                this.statusLbl.Text = "";
                sendBtn.Text = "Send";
                status[0] = "<br/> Message <br/>  send";
                status[1] = "<br/> Message <br/> not send!";
            }
            else
            {
                this.imeLbl.Text = "Име";
                this.kompanijaLbl.Text = "Компанија";
                this.emailLbl.Text = "Емаил";
                this.subjcetLbl.Text = "Наслов";
                this.porakaLbl.Text = "Порака";
                this.statusLbl.Text = "";
                sendBtn.Text = "Испрати";
                status[0] = "<br/> Пораката <br/> е пратена";
                status[1] = "<br/> Пораката <br/> не  е пратена!";
            }
        }
        else
        {
            this.imeLbl.Text = "Име";
            this.kompanijaLbl.Text = "Компанија";
            this.emailLbl.Text = "Емаил";
            this.subjcetLbl.Text = "Наслов";
            this.porakaLbl.Text = "Порака";
            this.statusLbl.Text = "";
            sendBtn.Text = "Испрати";
            status[0] = "<br/> Пораката <br/> е пратена";
            status[1] = "<br/> Пораката <br/> не  е пратена!";
        }
      
        this.sodrzinaTxtbox.Width = Unit.Pixel(300);
        this.sodrzinaTxtbox.Height = Unit.Pixel(100);
    }
    protected void sendBtn_Click(object sender, EventArgs e)
    {
        // Na koja adresa da go pusta mailot(ke ja naprajme posle dinamicki)
            const string ToAddress = "";
            if (this.emailTxtbox.Text.ToString().Trim() != "")
            {

                //Kreirame poraka od Klasata MailMessage ( prethodno using System.Net.Mail;)
                mail = new MailMessage();
                mail.To.Add("igor.bulovski@gmail.com,marko.mitreski@gmail.com");

                mail.From = new MailAddress(this.emailTxtbox.Text);

                //Ove se properties za porakata
                mail.Subject = this.subjectTxtbox.Text;
                mail.Body = this.subjectTxtbox.Text + "\n \n" + this.sodrzinaTxtbox.Text + "\n \n" + this.kompanijaTxtbox.Text + " " + this.imeTxtbox.Text;
                mail.IsBodyHtml = false;

                // Kreirame objekt od klasat SmtpClient vo koi se cuvaa host(smtp server)
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

                // Send the MailMessage (zema parametri od  Web.config kade imame definirano hostot)

                smtp.Send(mail);
                this.imeTxtbox.Text = "";
                this.kompanijaTxtbox.Text = "";
                this.emailTxtbox.Text = "";
                this.subjectTxtbox.Text = "";
                this.sodrzinaTxtbox.Text = "";
                this.statusLbl.Text = status[0];
            }
            else
            {
                this.statusLbl.Text = status[1];
            }
       
    }
}
