namespace Scraper
{
    internal class BrowserHelper
    {
        public static bool InUse;

        public static string HTML
        {
            get;
            set;
        }

        public static string URL
        {
            get;
            set;
        }

        static BrowserHelper()
        {
            BrowserHelper.InUse = false;
        }

        public BrowserHelper()
        {
        }
    }
}