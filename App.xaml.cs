namespace Casino;

public partial class App : Application
{
    private static Database database;

    internal static Database Database
    {
        get
        {
            if (database == null)
            {
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));
            }

            return database;
        }
    }

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}
