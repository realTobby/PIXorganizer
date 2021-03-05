using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PORG.ViewModels
{
  public class BaseViewModel : INotifyPropertyChanged
  {

    #region INotifyChangeProperty  

    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChange(string propertyname)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
      }
    }
    #endregion
  }
}
