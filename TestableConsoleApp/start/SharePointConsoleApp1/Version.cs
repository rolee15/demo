using AngleSharp;

namespace SharePointConsoleApp1
{
    public class Version
    {
        public string ProductNumber { get; set; }
        public string VersionNumber { get; set; }
        public string VersionName { get; set; }
        public Url GetVersionUrl()
        {
            string relativeAddress = $"/products/{ProductNumber}/{VersionNumber}";
            return new Url(Constants.SharePoint.ROOT_URL, relativeAddress);
        }
    }
}
