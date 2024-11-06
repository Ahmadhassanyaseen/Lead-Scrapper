using System;
using System.IO;
using System.Linq;

namespace Scraper
{
    internal class FileParser
    {
        public FileParser()
        {
        }

        public static void Parse()
        {
            string str;
            string str1;
            char[] chrArray;
            string str15;
            string[] strArrays = File.ReadAllLines(string.Concat("C:/Users/", Environment.UserName, "/Desktop/nig.txt"));
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            Form1 mainForm = Initialize.MainForm;

            for (int i = 0; i < strArrays.Count<string>(); i++)
            {
                if (strArrays[i].Contains("Request Date:"))
                {
                    str2 = strArrays[i + 1].Replace("&nbsp;", " ");
                }
                if (strArrays[i].Contains("Start Service Date:"))
                {
                    str3 = strArrays[i + 1].Replace("&nbsp;", " ");
                }
                if (strArrays[i].Contains("Service Type:"))
                {
                    str4 = strArrays[i + 1].Replace("&nbsp;&nbsp;-&nbsp;&nbsp;", " ").Replace(" hours(s)", "").Replace(" or Bachelorette Party", "").Replace(" / Sporting Event", "").Replace(" Transfer", "");
                }
                if (strArrays[i].Contains("Start Location:"))
                {
                    str5 = strArrays[i + 1].Replace("&nbsp;", " ").Replace("UNITED STATES", "USA");
                }
                if (strArrays[i].Contains("End Location:"))
                {
                    str6 = strArrays[i + 1].Replace("&nbsp;", " ").Replace("UNITED STATES", "USA");
                }
                if (strArrays[i].Contains("Vehicle:"))
                {
                    str7 = strArrays[i + 1].Replace("&nbsp;", " ").Replace("Preferred vehicle ", "").Replace(" or similar", "");
                }
                if (strArrays[i].Contains("Passengers:"))
                { //mainForm.AppendLog(string.Concat(str8));
                    str8 = strArrays[i + 1].Replace("&nbsp;", " ");
                    str8 = str8.Replace(@"+", "");//mainForm.AppendLog(string.Concat(str8));
                }
                if (strArrays[i].Contains("First Name:"))
                {
                    str9 = strArrays[i + 1].Replace("&nbsp;&nbsp;&nbsp; Last Name:", "");
                }
                if (strArrays[i].Contains("Contact Method:"))
                {
                    str10 = strArrays[i + 1].Replace("Phone&nbsp;&nbsp;&nbsp; Email: ", "").Replace("&nbsp;&nbsp;&nbsp; Phone:", "").Replace("&nbsp;&nbsp;&nbsp; ", "").Replace("EmailEmail:", "");
                }
                if (strArrays[i].Contains("Special Instructions:"))
                {
                    str11 = strArrays[i + 1].Replace("&nbsp;", " ");
                }
                if (str6.Contains("n/a"))
                {
                    chrArray = new char[] { ',' };
                    string str16 = str5.Split(chrArray)[1];
                    chrArray = new char[] { ',' };
                    str6 = string.Concat(str16, ", ", str5.Split(chrArray)[2]);
                }
            }
            Initialize.MainForm.botBrowser.Navigate("http://bestlimodb.com/MCPOrders.aspx");
            Query query = new Query(str7, Convert.ToInt32(str8));
            chrArray = new char[] { ' ' };
            string str12 = str3.Split(chrArray)[0];
            string str13 = "";
            chrArray = new char[] { '/' };
            string[] strArrays1 = str12.Split(chrArray);
            str13 = (strArrays1[0].Length != 1 ? string.Concat(str13, strArrays1[0], "/") : string.Concat(str13, "0", strArrays1[0], "/"));
            str13 = (strArrays1[1].Length != 1 ? string.Concat(str13, strArrays1[1], "/") : string.Concat(str13, "0", strArrays1[1], "/"));
            str13 = string.Concat(str13, strArrays1[2]);
            chrArray = new char[] { ' ' };
            if (str10.Split(chrArray)[1].Contains("@"))
            {
                chrArray = new char[] { ' ' };
                str1 = str10.Split(chrArray)[1];
                chrArray = new char[] { ' ' };
                str = str10.Split(chrArray)[0];
            }
            else
            {
                chrArray = new char[] { ' ' };
                str1 = str10.Split(chrArray)[0];
                chrArray = new char[] { ' ' };
                str = str10.Split(chrArray)[1];
            }
            string str14 = "";
            try
            {
                chrArray = new char[] { ' ' };
                if (!str4.Split(chrArray)[1].Contains("Service"))
                {
                    chrArray = new char[] { ' ' };
                    str15 = str4.Split(chrArray)[1];
                }
                else
                {
                    str15 = "1";
                }
                str14 = str15;
                if ((query.OurTypes != "Sedan" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 2)) != 0)
                {
                    str14 = "2";
                }
                if ((query.OurTypes != "SUV" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 2)) != 0)
                {
                    str14 = "2";
                }
                if ((query.OurTypes != "Stretch Limo" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 3)) != 0)
                {
                    str14 = "3";
                }
                if ((query.OurTypes != "Stretch SUV" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Party Bus" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Van" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 2)) != 0)
                {
                    str14 = "2";
                }
                if ((query.OurTypes != "Motor Coach" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 5)) != 0)
                {
                    str14 = "5";
                }
                if ((query.OurTypes != "Mini Bus" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Entertainer / Sleeper / Tour Bus" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 5)) != 0)
                {
                    str14 = "5";
                }
                if ((query.OurTypes != "Executive Coach" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "School Bus" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Trolley" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Double Decker Bus" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if ((query.OurTypes != "Vintage / Antique Car" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 3)) != 0)
                {
                    str14 = "3";
                }
                if ((query.OurTypes != "Other" ? 0 : Convert.ToInt32(Convert.ToInt32(str14) < 4)) != 0)
                {
                    str14 = "4";
                }
                if (query.Vehicle == "Any Vehicle")
                {
                    str14 = "3";
                }
            }
            catch
            {
                str14 = "1";
            }
            string[] strArrays2 = new string[14];
            strArrays2[0] = str13;
            chrArray = new char[] { ' ' };
            strArrays2[1] = str3.Split(chrArray)[1];
            chrArray = new char[] { ' ' };
            strArrays2[2] = str4.Split(chrArray)[0];
            strArrays2[3] = str5;
            strArrays2[4] = str6;
            strArrays2[5] = string.Concat(query.Vehicle, " ", query.OurTypes);
            strArrays2[6] = str8;
            chrArray = new char[] { ' ' };
            strArrays2[7] = str9.Split(chrArray)[0];
            chrArray = new char[] { ' ' };
            strArrays2[8] = str9.Split(chrArray)[1];
            strArrays2[9] = str;
            strArrays2[10] = str1;
            strArrays2[11] = str11;
            strArrays2[12] = query.Price.ToString();
            strArrays2[13] = str14;

            //Form1 mainForm = Initialize.MainForm;
            /*mainForm.AppendLog(string.Concat(str1));
			mainForm.AppendLog(string.Concat(str2));
			mainForm.AppendLog(string.Concat(str3));
			mainForm.AppendLog(string.Concat(str4));

			mainForm.AppendLog(string.Concat(str5));
			
			mainForm.AppendLog(string.Concat(str6));
			mainForm.AppendLog(string.Concat(str7));
			mainForm.AppendLog(string.Concat(str8));
			mainForm.AppendLog(string.Concat(str9));
			mainForm.AppendLog(string.Concat(str10));
			mainForm.AppendLog(string.Concat(str11));
			mainForm.AppendLog(string.Concat(str13));
			mainForm.AppendLog(string.Concat(str14));*/
            if (!str5.ToLower().Contains("canada"))
            {
                mainForm.AppendLog(string.Concat(str5));
                DataUploader.Upload(strArrays2);
            }
        }
    }
}