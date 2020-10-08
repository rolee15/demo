using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;

namespace Pimsporter.Adapter
{
    public class SharePointAdapter : ISharePointAdapter
    {
        private ClientContext ctx;
        private List list;
        private string username;
        private SecureString password;

        public SharePointAdapter(string username, SecureString password)
        {
            this.username = username;
            this.password = password;
        }

        private void CreateContext()
        {
            ctx = new ClientContext(Constants.SharePoint.ROOT_URL.Href);
            ctx.Credentials = new NetworkCredential(username, password);
        }

        private void GetList()
        {
            Web web = ctx.Web;
            list = web.Lists.GetByTitle(Constants.AllVersions.TITLE);
            ctx.Load(list);
            ctx.ExecuteQuery();
        }

        public List<Version> GetVersions()
        {
            CreateContext();
            GetList();
            return CreateVersions();
        }

        private List<Version> CreateVersions()
        {
            List<Version> versions = new List<Version>();
            CamlQuery query = new CamlQuery
            {
                ViewXml = CAML.ViewQuery(ViewScope.DefaultValue, rowLimit: Constants.SharePoint.DEFAULT_QUERY_ROW_LIMIT)
            };
            ListItemCollectionPosition position = null;
            do
            {
                query.ListItemCollectionPosition = position;
                ListItemCollection items = list.GetItems(query);
                ctx.Load(items);
                ctx.ExecuteQuery();


                foreach (var item in items)
                {
                    versions.Add(new Version()
                    {
                        ProductNumber = Convert.ToString(item["ProductNumber"]),
                        VersionNumber = Convert.ToString(item["VersionNumber"]),
                        VersionName = Convert.ToString(item["Version_x0020_Name"])
                    });
                }
                position = items.ListItemCollectionPosition;

            } while (position != null);

            return versions;
        }

        private static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                }
            }
            return pwd;
        }
    }
}
