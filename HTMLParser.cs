using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Scraper
{
    internal class HTMLParser
    {


        public HTMLParser()
        {
        }

        //public WebBrowser botBrowser;

        public static void FetchData(Client client)
        {
            //Form1 mainForm = Initialize.MainForm;
            string[] strArrays = new string[] { "Fetching ", client.Name.Replace("&nbsp;", " "), " (", null, null };
            string[] str = strArrays;
            str[3] = client.People.ToString();
            str[4] = " passengers)";
            //mainForm.AppendLog(string.Concat(str));
            //string str1 = client.Link.Replace("<a href=\"javascript:", "");
            //str1 = str1.Replace("\">View&nbsp;Lead</a>", "");
            //str1 = str1.Replace("__doPostBack('", "");
            //str1 = str1.Replace("','')", "");
            //object[] objArray = new object[] { str1, "" };
            //Initialize.MainForm.botBrowser.Invoke(new Action(() => Initialize.MainForm.botBrowser.Document.InvokeScript("__doPostBack", objArray)));
            Thread.Sleep(6000);
            HTMLParser.ScrapeClientPage(client);
        }

        public static void Callagain()
        {
            Form1 mainForm = Initialize.MainForm;
            mainForm.botBrowser.Document.GetElementById("ResponseType").SetAttribute("value", "Yes");
            mainForm.botBrowser.Document.GetElementById("Rate").SetAttribute("value", "0");
            mainForm.botBrowser.Document.GetElementById("Notes").SetAttribute("value", "this is just test code after that we will send you the details of quote after seeing details.");
            //this.botBrowser.Document.All("submit").click;
            //this.botBrowser.Document.GetElementById("MainContent_btnLogin").InvokeMember("click");

            mainForm.botBrowser.Document.GetElementById("submit-yes-bid-button").InvokeMember("click");
            // mainForm.botBrowser.Navigate(mainForm.botBrowser.Url.AbsoluteUri);
            // mainForm.Bidsubmit();
            string newurl = BrowserHelper.URL;
            var slug = newurl.Replace("Bid", "SubmitBid");
            mainForm.botBrowser.Navigate(newurl);
            if (BrowserHelper.URL == newurl)
            {
                Parse();
            }

        }


        public static void Parse()
        {


            Form1 mainForm = Initialize.MainForm;
            //mainForm.botBrowser.Refresh();
            //mainForm.AppendLog(string.Concat("aa gian aay anni diay parse"));

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(BrowserHelper.HTML);//[@valign='top']
            HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//dd");
            int num = 0;
            string[] strArrays = new string[20];
            //// mainForm.AppendLog(string.Concat("aa gian aay anni diay "+htmlNodeCollection.Count));
            if ((htmlNodeCollection == null ? 0 : Convert.ToInt32(htmlNodeCollection.Count > 0)) == 0)
            {
                return;
            }
            foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>)htmlNodeCollection)
            {

                mainForm.AppendLog("HTML Nodes " + string.Concat(htmlNode.InnerText + htmlNodeCollection.Count + num));
                strArrays[num] = htmlNode.InnerText.Replace("\n","");
               // mainForm.AppendLog("why not showing " + string.Concat(strArrays[num]));
               if(num<16)
                num++;

            }
            //string cstr = '(Revealed once you submit a "Yes" quote)';

            //  strArrays[10] = strArrays[10].Substring(0, (strArrays[10].Length -14));
            // mainForm.AppendLog(strArrays[10] + "out");
            
                DataUploader.Upload(strArrays);
           

           
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }




        public static void ScrapeClientPage(Client client)
        {
            bool flag = false;
            Initialize.MainForm.botBrowser.Invoke(new Action(() => BrowserHelper.HTML = Initialize.MainForm.botBrowser.Document.GetElementsByTagName("HTML")[0].OuterHtml));
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(BrowserHelper.HTML);
            HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//tr[@id='MainContent_rowOrderDetails']//td//table//tbody//tr");
            if ((htmlNodeCollection == null ? 1 : Convert.ToInt32(htmlNodeCollection.Count <= 0)) == 0)
            {
                foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>)htmlNodeCollection)
                {
                    HtmlNodeCollection htmlNodeCollection1 = htmlNode.SelectNodes("//td");
                    File.WriteAllText(string.Concat("C:/Users/", Environment.UserName, "/Desktop/nig.txt"), htmlNodeCollection1[0].InnerText);
                    flag = true;
                }
            }
            else
            {
                HTMLParser.ScrapeClientPage(client);
            }
            if (flag)
            {

                FileParser.Parse();
            }
        }
    }
}