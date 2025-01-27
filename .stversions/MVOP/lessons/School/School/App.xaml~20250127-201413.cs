using AsyncAwaitBestPractices;
using School.Database;

namespace School
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SqliteDatabase.InitializeDatabaseAsync().SafeFireAndForget();
            MainPage = new AppShell();
        }

    }
}