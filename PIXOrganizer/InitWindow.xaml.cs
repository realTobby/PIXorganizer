using PIXOrganizer.Forms;
using PIXOrganizer.Logic;
using System.Windows;

namespace PIXOrganizer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class InitWindow : Window
    {
        private ConfigManager cfgManager;

        public InitWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Minimized;
            cfgManager = new ConfigManager();

            if (cfgManager.CheckConfig() == true)
            {
                // open mainwindow
                MainWindow mainWin = new MainWindow();
                mainWin.ShowDialog();
            }
            else
            {
                // open setupwindow
                SetupWindow setup = new SetupWindow();
                setup.ShowDialog();
            }
            this.Close();
        }
    }
}
