using System.Collections.Generic;

namespace SharePointConsoleApp1.SharePoint
{
    public interface ISharePointAdapter
    {
        List<Version> GetVersions();
    }
}
