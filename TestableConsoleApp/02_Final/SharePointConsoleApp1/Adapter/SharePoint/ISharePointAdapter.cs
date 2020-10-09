using System.Collections.Generic;

namespace Pimsporter.Adapter
{
    public interface ISharePointAdapter
    {
        List<Version> GetVersions();
    }
}
