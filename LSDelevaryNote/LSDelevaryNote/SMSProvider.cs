
namespace LSDelevaryNote
{
    using System.IO;
    using System.Net;
    public class SMSProvider
    {

        public void SMSSend()
        {
            WebClient client = new WebClient();
            string baseurl = "http://www.mshastra.com/sendurlcomma.aspx?user=profileid&pwd=xxxx&senderid=ABC&mobileno=9911111111&msgtext=Hello";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }
    }
}