using Pimsporter.Adapter;
using System.Collections.Generic;

namespace Pimsporter.Repository
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
