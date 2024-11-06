using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Scraper
{
    internal class DataUploader
    {
        public static string URL;

        static DataUploader()
        {
            DataUploader.URL = "https://unlimitedcharters.com/betacrm/new_lead.php";
            //DataUploader.URL = "https://r4z6r8k7.stackpathcdn.com/betacrm/new_lead.php";
        }

        public DataUploader()
        {
        }

        public static void Upload(string[] info)
        {
            WebClient webClient = new WebClient();
            try
            {
                Form1 mainForm = Initialize.MainForm;
                mainForm.AppendLog(string.Concat("uploading"));
                string[] stringSeparators = new string[] { "&nbsp;" };
                string[] clientname = info[8].Split(stringSeparators, StringSplitOptions.None);
                NameValueCollection nameValueCollection = new NameValueCollection()
                {
                    { "eventdate_c", info[1] },
                    { "pickuptime_c", info[4] },
                    { "eventtype_c", info[0] },
                    { "pickuplocation_c", info[2] },
                    { "location_c", info[3] },
                    { "description", info[7] },
                    { "numberofpassengers_c", info[6] },
                    { "first_name", clientname[0].Trim() },
                    { "last_name", clientname[1].Trim()  },
                    { "phone_mobile", info[11] },
                    { "email1",info[10].Trim() },
                    { "clientnotes_c", info[14].Trim() },
                    { "rate_c", info[12].Trim()}, //
                    { "servicelength_c", info[5].Replace(" hours","") },
                    { "lead_source", "DBlimo" } //"Gigmasters" 
                };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
                byte[] numArray = webClient.UploadValues(DataUploader.URL, nameValueCollection);
                Encoding.UTF8.GetString(numArray);
                mainForm.AppendLog(string.Concat(Encoding.ASCII.GetString(numArray)));
                mainForm.AppendLog(string.Concat(DataUploader.URL));
                if(mainForm.list.Count == 0)
                {
                    ((IDisposable)webClient).Dispose();
                }
                //else
                //{
                //    //mainForm.link = mainForm.list[0];
                //    mainForm.list.Clear();
                //    mainForm..CoreWebView2.Navigate("https://mcp.thebash.com/leads/unanswered");
                //}
                
            }
            finally
            {
                if (webClient != null)
                {
                    ((IDisposable)webClient).Dispose();
                }
            }
        }
    }
}