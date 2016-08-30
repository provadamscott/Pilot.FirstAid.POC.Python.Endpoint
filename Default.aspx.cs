using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    private string state;
    private static bool login = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            state = Request.QueryString["state"];
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (login)
        {
            string url = "https://demo.swedishexpresscare.org/api/account/login";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Credentials = new NetworkCredential("nassau.test@providence.org", "Mj!Test123");
            request.CookieContainer = new CookieContainer();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"Email\":\"" + UserBox.Text + "\",\"Password\":\"" + PassBox.Text + "\",\"RememberMe\":\"true\"}"; // nassau.test@providence.org, Mj!Test123
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                ResultLabel.Text = "Username and/or password is incorrect.";
                return;
            }

            String cookieName = "", cookieValue = "";
            foreach (Cookie cookie in response.Cookies)
            {
                cookieName = cookie.Name;
                cookieValue = cookie.Value;
            }

            ResultLabel.Text = "Login was successful.";
            URLLabel.Text = "https://pitangui.amazon.com/api/skill/link/M2E9NV9WGPLRMC#state=" + state + "&access_token=" + cookieValue + "&token_type=Bearer";
        }
        else
        {
            string url = "https://demo.swedishexpresscare.org/api/account/register";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            //request.Credentials = new NetworkCredential("nassau.test@providence.org", "Mj!Test123");
            request.CookieContainer = new CookieContainer();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"Email\":\"" + EmailBox.Text + "\",\"PreferredName\":\"" + PrefNameBox.Text + "\",\"Password\":\"" + RegPassBox.Text + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
                ResultLabel.Text = json;
            }

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                ResultLabel.Text = "Could not register user.";
                return;
            }
            String cookieName = "", cookieValue = "";
            foreach (Cookie cookie in response.Cookies)
            {
                cookieName = cookie.Name;
                cookieValue = cookie.Value;
            }
            ResultLabel.Text = "Register was successful.";
            URLLabel.Text = "https://pitangui.amazon.com/api/skill/link/M2E9NV9WGPLRMC#state=" + state + "&access_token=" + cookieValue + "&token_type=Bearer";
        }
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        if (login)
        {
            LoginDiv.Visible = false;
            RegisterDiv.Visible = true;
            LoginButton.Text = "Register";
            RegisterButton.Text = "Back to login";
            ResultLabel.Text = "";
            URLLabel.Text = "";
            login = false;
        }
        else
        {
            LoginDiv.Visible = true;
            RegisterDiv.Visible = false;
            LoginButton.Text = "Login";
            RegisterButton.Text = "New User? Click here.";
            ResultLabel.Text = "";
            URLLabel.Text = "";
            login = true;
        }
    }
}