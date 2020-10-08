namespace Pimsporter.Service
{
    public class SettingsService : ISettingsService
    {
        public string GetDefaultUsername()
        {
            return Properties.Settings.Default.DefaultUsername;
        }

        public void SaveDefaultUsername(string username)
        {
            Properties.Settings.Default.DefaultUsername = username;
            Properties.Settings.Default.Save();
        }
    }

    public interface ISettingsService
    {
        string GetDefaultUsername();

        void SaveDefaultUsername(string username);
    }
}
