using PIXOrganizer.Logic;
using PIXOrganizer.ViewModels;
using System.Management;
using System.Windows;

namespace PIXOrganizer.Forms
{
    /// <summary>
    /// Interaktionslogik für SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        private SetupWindowViewModel viewModel;

        private ConfigManager cfgManager;

        private ManagementEventWatcher usbWatcher;

        private int setupIndex = 1;
        private int maxStep = 6;
        public SetupWindow()
        {
            InitializeComponent();


            viewModel = new SetupWindowViewModel();
            this.DataContext = viewModel;

            viewModel.PreLoadPictures();

            viewModel.UpdateStepImage(1);

            cfgManager = new ConfigManager();

            usbWatcher = new ManagementEventWatcher();
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            usbWatcher.EventArrived += new EventArrivedEventHandler(OnConnected);
            usbWatcher.Query = query;
            usbWatcher.Start();
        }

        private void ResetProgress()
        {
            btn_nextStep.Content = "Next";
            setupProgress1.IsChecked = false;
            setupProgress2.IsChecked = false;
            setupProgress3.IsChecked = false;
            setupProgress4.IsChecked = false;
            setupProgress5.IsChecked = false;

        }

        public void UpdateSetupProgress()
        {
            if(setupIndex <= 0)
            {
                setupIndex = maxStep;
            }
            if(setupIndex > maxStep)
            {
                setupIndex = 1;
            }

            ResetProgress();
            switch(setupIndex)
            {
                case 1:
                    setupProgress1.IsChecked = true;
                    break;
                case 2:
                    setupProgress2.IsChecked = true;
                    break;
                case 3:
                    setupProgress3.IsChecked = true;
                    break;
                case 4:
                    setupProgress4.IsChecked = true;
                    break;
                case 5:
                    setupProgress5.IsChecked = true;
                    btn_nextStep.Content = "Finish";
                    break;
                case 6:
                    FinishSetup();
                    break;
            }
            viewModel.UpdateStepImage(setupIndex);
            img_steps.UpdateLayout();
        }

        private void FinishSetup()
        {
            usbWatcher.Stop();
            cfgManager.SaveConfig();
            MainWindow mainWin = new MainWindow();
            this.Close();
            mainWin.ShowDialog();
        }

        

        private void OnConnected(object sender, EventArrivedEventArgs e)
        {
            string driveName = e.NewEvent.Properties["EventType"].Value.ToString();


            MessageBox.Show("Phone connected successfully!");


            usbWatcher.Stop();
        }

        private void btn_previousStep_Click(object sender, RoutedEventArgs e)
        {
            setupIndex--;
            UpdateSetupProgress();
        }

        private void btn_nextStep_Click(object sender, RoutedEventArgs e)
        {
            setupIndex++;
            UpdateSetupProgress();
        }
    }
}
