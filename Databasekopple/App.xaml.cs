using Databasekopple.Data;

namespace Databasekopple
{
    public partial class App : Application
    {
        public static RunRepository RunRepository { get; private set; }
        public App(RunRepository runRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();

            RunRepository = runRepository;
        }
    }
}