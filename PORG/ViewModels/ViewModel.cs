using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PORG.ViewModels
{
  public class ViewModel : BaseViewModel
  {
    private string currentDirectory = "";
    private string nextImagePath = "";
    private ObservableCollection<string> currentGroups = new ObservableCollection<string>();

    public string CurrentDirectory
    {
      get
      {
        return currentDirectory;
      }
      set
      {
        currentDirectory = value;
        base.RaisePropertyChange(nameof(CurrentDirectory));
      }
    }

    public string NextImagePath
    {
      get
      {
        return nextImagePath;
      }
      set
      {
        nextImagePath = value;
        base.RaisePropertyChange(nameof(NextImagePath));
      }
    }
    public BitmapImage CurrentImageSource
    {
      get
      {
        if(NextImagePath != string.Empty)
          return new BitmapImage(new Uri(NextImagePath));
        return new BitmapImage();
      }
    }

    public ObservableCollection<string> CurrentGroups
    {
      get
      {
        return currentGroups;
      }
      set
      {
        currentGroups = value;
        base.RaisePropertyChange(nameof(CurrentGroups));
      }
    }

  }
}
