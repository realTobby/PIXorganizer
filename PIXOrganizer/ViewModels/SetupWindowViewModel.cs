using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PIXOrganizer.ViewModels
{
    public class SetupWindowViewModel : INotifyPropertyChanged
    {
        private static BitmapImage step1;
        private static BitmapImage step2;
        private static BitmapImage step3;
        private static BitmapImage step4;
        private static BitmapImage step5;
        private static BitmapImage stepFinish;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BitmapImage currentStepImage;
        public BitmapImage CurrentStepImage
        {
            get { return currentStepImage; }
            set { currentStepImage = value; OnPropertyChanged(nameof(CurrentStepImage)); }
        }

        public void UpdateStepImage(int index)
        {
            switch (index)
            {
                case 1:
                    CurrentStepImage = step1;
                    break;
                case 2:
                    CurrentStepImage = step2; 
                    break;
                case 3:
                    CurrentStepImage = step3; 
                    break;
                case 4:
                    CurrentStepImage = step4; 
                    break;
                case 5:
                    CurrentStepImage = step5;
                    break;
                case 6:
                    CurrentStepImage = stepFinish;
                    break;
            }
        }


        public void PreLoadPictures()
        {
            step1 = ToBitmapImage(new Bitmap("Assets/SetupImages/setupStep1.png"));
            step2 = ToBitmapImage(new Bitmap("Assets/SetupImages/setupStep2.png"));
            step3 = ToBitmapImage(new Bitmap("Assets/SetupImages/setupStep3.png"));
            step4 = ToBitmapImage(new Bitmap("Assets/SetupImages/setupStep4.png"));
            step5 = ToBitmapImage(new Bitmap("Assets/SetupImages/setupStep5.png"));
            stepFinish = ToBitmapImage(new Bitmap("Assets/SetupImages/setupFinish.png"));

        }

        public BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

    }
}
