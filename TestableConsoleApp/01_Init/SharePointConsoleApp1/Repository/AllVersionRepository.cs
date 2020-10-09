using SharePointConsoleApp1.SharePoint;
using System.Collections.Generic;

namespace SharePointConsoleApp1.Repository
{
    public class AllVersionRepository
    {
        private ISharePointAdapter sp;

        public AllVersionRepository(ISharePointAdapter sharePointAdapter)
        {
            sp = sharePointAdapter;
        }

        public List<Version> GetAllVersions()
        {
            return sp.GetVersions();
        }

    }
}
