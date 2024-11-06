using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;


namespace Scraper
{
    public class Form1 : Form
    {
        private IContainer components = null;

        private RichTextBox txtLog;

        public WebBrowser botBrowser;

        //public static string[] links = new string[50];
        public List<string> list = new List<string>();

        public string[] olinks;

        public string link;
        private Button button1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button button2;
        public string olink;

        public bool locked
        {
            get;
            set;
        }

        public Form1()
        {
            this.InitializeComponent();
            SetWebViewEvents();
            Initialize.MainForm = this;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(600000); 
                    Application.Restart();
                }
            });
        }

        private void SetWebViewEvents()
        {
            this.webView.NavigationCompleted += WebView_NavigationCompleted;
            

            // this.webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            //this.webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
        }

        private void CoreWebView2_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            //Task<string> task = webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
            //BrowserHelper.HTML = task.Result;
            //BrowserHelper.URL = webView.CoreWebView2.Source.ToString();
            //this.AppendLog("default url :" + BrowserHelper.URL);
        }

        private async void WebView_BindingContextChanged(object sender, CoreWebView2DOMContentLoadedEventArgs arg)
        {
            string html = await GetHtml();

        }
        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            this.webView.CoreWebView2.DOMContentLoaded += WebView_BindingContextChanged;
            string html = await GetHtml();
            BrowserHelper.HTML = html;
            BrowserHelper.URL = webView.CoreWebView2.Source.ToString();
            this.AppendLog("default url :" + BrowserHelper.URL);

            //Step 1 to login
            if (BrowserHelper.URL== "https://www.thebash.com/login") // Do_Login
            {
                Do_Login();
            }

            //Step 2 after login
            if (BrowserHelper.URL == "https://mcp.thebash.com/dashboard") // after logged in 
            {
                if (!this.txtLog.Text.Contains("Logged In.."))
                {
                    this.AppendLog("Logged In..");
                }
                webView.CoreWebView2.Navigate("https://mcp.thebash.com/leads/unanswered");

            }

            // Step3 after moved to unanswered leads
            if (BrowserHelper.URL == "https://mcp.thebash.com/leads/unanswered" && html !="null")
            {
                Thread.Sleep(20000);
                ProcessUnanswered();
            }

            //Step 4, Process Individual request
            if (BrowserHelper.URL == this.link)
            {
                ProcessRequest();
                return;

            }

            if (BrowserHelper.URL.ToLower().Contains("https://mcp.thebash.com/submitbid"))
            {
                GetLeadvalues();
            }
        }

        private void Do_Login()
        {
            this.AppendLog("Logging In..");

            var inputEvent = @"
                        var setNativeValue = (element, value) => {
                            let lastValue = element.value;
                            element.value = value;
                            let event = new Event('input', { target: element, bubbles: true });
                            // React 15
                            event.simulated = true;
                                // React 16
                                let tracker = element._valueTracker;
                            if (tracker) {
                                tracker.setValue(lastValue);
                            }
                            element.dispatchEvent(event);
                            };
            ";

            webView.CoreWebView2.ExecuteScriptAsync(" " +
                inputEvent +
                "var input = document.getElementById('username'); setNativeValue(input, 'quotes@unlimitedcharters.com'); " +
                "input = document.getElementById('password'); setNativeValue(input, 'Bedbug123!@'); " +
                "[... document.querySelectorAll('button')].filter(el => el.textContent.includes('Log In'))[0].click(); ");


        }
        private async  void ProcessUnanswered()
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            string html = await GetHtml();

            // htmlDocument.LoadHtml(BrowserHelper.HTML);//[@valign='top']
            htmlDocument.LoadHtml(html);//[@valign='top']

            //HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div[@class='view-FolderLeads-ListItem-container MuiBox-root css-1g51owy']");
            HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div[@class='view-FolderLeads-ListItem-container MuiBox-root css-o2ve81']");


            int num1 = 0;
            //HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='view-FolderLeads-ListItem-container MuiBox-root css-1g51owy']");
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='view-FolderLeads-ListItem-container MuiBox-root css-o2ve81']");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (HtmlNode node in nodes)
                {
                    //num1++;
                    var input = node.InnerHtml;
                    //this.AppendLog(string.Concat("count : " + input));
                    Regex regex = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase);
                    Match match;
                    for (match = regex.Match(input); match.Success; match = match.NextMatch())
                    {
                        //Console.WriteLine("Found a href. Groups: ");
                        foreach (Group group in match.Groups)
                        {
                            if (group.ToString().Contains("href") != true)
                            {
                                //this.olink = "https://mcp.thebash.com" + slug.Replace("Bid","SubmitBid");
                                // this.link = "https://mcp.thebash.com" + group.ToString(); 
                                list.Add("https://mcp.thebash.com" + group.ToString());
                                num1++;


                            }
                        }
                    }/**/

                }

            }

            this.AppendLog("list count: " + list.Count);
            if (list.Count > 0)
            {
                this.link = list[0];
                if (this.link != this.olink)
                {
                    this.webView.CoreWebView2.Navigate(this.link);
                }
            }

        }

        private void ProcessRequest()
        {
            this.AppendLog(string.Concat(" list count " + list.Count));

            webView.CoreWebView2.ExecuteScriptAsync(" " +
                "document.getElementById('ResponseType').value='Yes';" +
                "document.getElementById('Rate').value='0';" +
                "document.getElementById('Notes').value='this is just test code after that we will send you the details of quote after seeing details.';" +
                @"$(""#submit-yes-bid-button"").click(); ");

        }

        private async Task<string> GetHtml()
        {
            var html = await webView.CoreWebView2.ExecuteScriptAsync("document.body.outerHTML");
            // this.AppendLog("Html : " + html);
            string sHtmlDecoded = System.Text.RegularExpressions.Regex.Unescape(html);

            return sHtmlDecoded;
        }

        public void AppendLog(string text)
        {
            Initialize.MainForm.txtLog.Invoke(new Action(() =>
            {
                RichTextBox mainForm = Initialize.MainForm.txtLog;
                mainForm.Text = string.Concat(new object[] { mainForm.Text, "[", DateTime.Now, "] >> ", text, Environment.NewLine });
            }));
        }

        private void botBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            BrowserHelper.HTML = this.botBrowser.Document.GetElementsByTagName("HTML")[0].OuterHtml;
            BrowserHelper.URL = this.botBrowser.Url.AbsoluteUri;
            this.AppendLog("default url :" + BrowserHelper.URL);
            /* if (BrowserHelper.URL == "http://unlimitedcharters.com/betacrm/index.php?action=Login&module=Users")
             {
                 this.botBrowser.Document.GetElementById("user_name").SetAttribute("value", "ahmed");
                 this.botBrowser.Document.GetElementById("user_password").SetAttribute("value", "Ahmed20191!!!");
             }*/
            if (BrowserHelper.URL == "https://www.thebash.com/login")
            {
                if (!this.txtLog.Text.Contains("Logging In.."))
                {
                    this.AppendLog("Logging In..");
                }
                this.botBrowser.Document.GetElementById("userNameInput").SetAttribute("value", "quotes@unlimitedcharters.com");
                this.botBrowser.Document.GetElementById("passwordInput").SetAttribute("value", "Bedbug123!@");
                //this.botBrowser.Document.All("submit").click;
                //this.botBrowser.Document.GetElementById("MainContent_btnLogin").InvokeMember("click");
                var elements = this.botBrowser.Document.GetElementsByTagName("button");
                foreach (HtmlElement item in elements)
                {
                    var title = item.GetAttribute("title");
                    this.AppendLog(title);
                    if (title == "Log In to GigMasters!")
                        item.InvokeMember("click");


                }



                /*foreach (HtmlElement form in this.botBrowser.Document.Forms)
					{ this.AppendLog(form.Name);
						form.InvokeMember("click");
						this.AppendLog("form submitted");
						break;
					}*/
            }
            this.AppendLog(BrowserHelper.URL);
            if (BrowserHelper.URL == "https://mcp.thebash.com/dashboard.aspx")
            {
                if (!this.txtLog.Text.Contains("Logged In.."))
                {
                    this.AppendLog("Logged In..");
                }
                this.botBrowser.Navigate("https://mcp.thebash.com/leads/unanswered");

            }
            this.botBrowser.ScriptErrorsSuppressed = true;
            if (BrowserHelper.URL == "https://mcp.thebash.com/leads/unanswered")
            {



                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(BrowserHelper.HTML);//[@valign='top']
                HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//tr");


                int num1 = 0;
                HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//tr");
                foreach (HtmlNode node in nodes)
                {
                    //num1++;
                    var input = node.InnerHtml;
                    //this.AppendLog(string.Concat("count " + input));
                    Regex regex = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase);
                    Match match;
                    for (match = regex.Match(input); match.Success; match = match.NextMatch())
                    {
                        //Console.WriteLine("Found a href. Groups: ");
                        foreach (Group group in match.Groups)
                        {
                            if (group.ToString().Contains("href") != true)
                            {
                                //this.olink = "https://mcp.thebash.com" + slug.Replace("Bid","SubmitBid");
                                // this.link = "https://mcp.thebash.com" + group.ToString(); 
                                list.Add("https://mcp.thebash.com" + group.ToString());
                                num1++;


                            }
                        }
                    }/**/
                }

                this.link = list[0];

                this.AppendLog("list count " + list.Count);
                if (this.link != this.olink)
                {
                    this.botBrowser.Navigate(this.link);
                }

                //this.NavigateURL(this.link);
            }
            if (BrowserHelper.URL == this.link)
            {
                this.AppendLog(string.Concat(" list count " + list.Count));
                this.botBrowser.Document.GetElementById("ResponseType").SetAttribute("value", "Yes");
                this.botBrowser.Document.GetElementById("Rate").SetAttribute("value", "0");
                this.botBrowser.Document.GetElementById("Notes").SetAttribute("value", "this is just test code after that we will send you the details of quote after seeing details.");
                //this.botBrowser.Document.All("submit").click;
                //this.botBrowser.Document.GetElementById("MainContent_btnLogin").InvokeMember("click");

                this.botBrowser.Document.GetElementById("submit-yes-bid-button").InvokeMember("click");
                //this.botBrowser.Refresh();
                // this.botBrowser.Navigate("https://mcp.thebash.com/ArchiveGigRequests.asp?folderID=1");


                return;

            }
            if (BrowserHelper.URL.ToLower().Contains("https://mcp.thebash.com/submitbid"))
            {
                GetLeadvalues();
            }


        }

        private void GetLeadvalues()
        {
            // this.botBrowser.Navigate(this.link+"?s=test");
            this.AppendLog(string.Concat(" function navigate url " + webView.CoreWebView2.Source.ToString()));
            this.AppendLog(string.Concat(" function navigate url " + this.link));
            this.AppendLog(string.Concat(" get values navigate url " + BrowserHelper.URL));

            HTMLParser.Parse();
            if (list.Count > 0)
            {
                list.RemoveAt(0);
            }

            if (list.Count > 0)
            {
                this.link = list[0];
                this.olink = this.link;
                this.webView.CoreWebView2.Navigate(this.link);
            }
            else
            {
                this.webView.CoreWebView2.Navigate("https://mcp.thebash.com/leads/unanswered");
            }
           
           
        }


        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? 0 : Convert.ToInt32(this.components != null)) != 0)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    //try
                    //{
                    //    WebClient webClient = new WebClient();
                    //    try
                    //    {
                    //        var res = webClient.DownloadString("http://unlimitedcharters.com/betacrm/killswitch.txt");
                    //        if (webClient.DownloadString("http://unlimitedcharters.com/betacrm/killswitch.txt") == "yes")
                    //        {
                    //            Environment.Exit(0);
                    //        }
                    //    }
                    //    finally
                    //    {
                    //        if (webClient != null)
                    //        {
                    //            ((IDisposable)webClient).Dispose();
                    //        }
                    //    }
                    //}
                    //catch
                    //{
                    //    Console.WriteLine("Unable to connect to the remote server.");
                    //}
                    Thread.Sleep(15000);
                }
            });
            this.AppendLog("Initializing Bot..");
            //this.botBrowser.Navigate("https://www.thebash.com/login");
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate("https://www.thebash.com/login");
            }
        }

        private void InitializeComponent()
        {
            this.botBrowser = new System.Windows.Forms.WebBrowser();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // botBrowser
            // 
            this.botBrowser.Location = new System.Drawing.Point(3, 275);
            this.botBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.botBrowser.Name = "botBrowser";
            this.botBrowser.ScriptErrorsSuppressed = true;
            this.botBrowser.Size = new System.Drawing.Size(738, 52);
            this.botBrowser.TabIndex = 0;
            this.botBrowser.Visible = false;
            this.botBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.botBrowser_DocumentCompleted);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtLog.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(8, 11);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(860, 258);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(880, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hide";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // webView
            // 
            this.webView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(-2, 95);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(976, 425);
            this.webView.Source = new System.Uri("https://www.thebash.com/login", System.UriKind.Absolute);
            this.webView.TabIndex = 3;
            this.webView.Visible = false;
            this.webView.ZoomFactor = 1D;
            this.webView.Click += new System.EventHandler(this.webView_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(880, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Full Screen";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1022, 326);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.botBrowser);
            this.Name = "Form1";
            this.Text = "Eye of Ender";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            webView.Left = 20;
            webView.Width = Form1.ActiveForm.Width - 40;
            webView.Height = Form1.ActiveForm.Height - 317;

            webView.Top = txtLog.Height + 10;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            webView.Left = 20;
            webView.Width = Form1.ActiveForm.Width - 40;
            webView.Height= Form1.ActiveForm.Height - 317;
            
            webView.Top = txtLog.Height + 10;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            webView.Left = 20;
            webView.Width = Form1.ActiveForm.Width - 40;
            webView.Height = Form1.ActiveForm.Height - 317;

            webView.Top = txtLog.Height + 10;
            webView.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            webView.Left = 20;
            webView.Width = Form1.ActiveForm.Width - 40;
            webView.Height = Form1.ActiveForm.Height - 317;

            webView.Top = txtLog.Height + 10;
            webView.Visible = true;
        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }


}

