
namespace LSDelevaryNote
{
    using System;
    using System.IO;
    using System.Net;
    public class SMSProvider:IDisposable
    {
        /*
         http://www.mshastra.com/sendurlcomma.aspx?user=profileid&pwd=xxxx&senderid=ABC&mobileno=9911111111&msgtext=Hello
             */
        readonly string baseurl = "http://www.mshastra.com/sendurlcomma.aspx?user={0}&pwd={1}&senderid={2}&mobileno={3}&msgtext={4}";
        public string Profile { get; private set; }
        public string Password { get; private set; }
        public string Sender { get; private set; }

        public SMSProvider(string profileid, string pwd,string sender) {

            this.Profile = profileid;this.Password = pwd;
            this.Sender = sender;
        }
        public void SMSSend(string phone,  string message)
        {
            WebClient client = new WebClient();
            string url = string.Format(baseurl, this.Profile, this.Password, this.Sender, phone, message.Trim());
            UriBuilder uriBuilder = new UriBuilder(url);


            Stream data = client.OpenRead(uriBuilder.Uri);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }

        public void Dispose()
        {

        }
    }
}