using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pimsporter;
using Pimsporter.Repository;
using Pimsporter.Adapter;
using System.Collections.Generic;

namespace PimsporterTest.Repository
{
    [TestClass]
    public class AllVersionRepositoryTest
    {
        [TestMethod]
        public void GetVersionsReturnsAllVersions()
        {
            // Arrange
            AllVersionRepository repository = new AllVersionRepository(new SharePointAdapterMock());

            // Act
            var versions = repository.GetAllVersions();

            // Assert
            for (int i = 0; i < versions.Count; i++)
            {
                Assert.AreEqual(versions[i].ProductNumber, "1");
                Assert.AreEqual(versions[i].VersionNumber, (i + 1).ToString());
                Assert.AreEqual(versions[i].VersionName, "MyVersion " + (i + 1).ToString());
            }
        }
    }

    class SharePointAdapterMock : ISharePointAdapter
    {
        public List<Version> GetVersions()
        {
            return new List<Version>
            {
                new Version() { ProductNumber = "1", VersionNumber = "1", VersionName = "MyVersion 1" },
                new Version() { ProductNumber = "1", VersionNumber = "2", VersionName = "MyVersion 2" },
                new Version() { ProductNumber = "1", VersionNumber = "3", VersionName = "MyVersion 3" }
            };
        }
    }
}
