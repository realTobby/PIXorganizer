using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf = System.Windows.Forms;
using System.Linq;

namespace PORG.Logic
{
  public class DirectoryAndFileSystem
  {
    public string GetMainDirectory()
    {
      var fbd = new wf.FolderBrowserDialog();
      fbd.ShowDialog();
      return fbd.SelectedPath;
    }

    public ObservableCollection<string> AddGroup(ObservableCollection<string> collection, string newGroup)
    {
      if(collection.Where(x=>x == newGroup).FirstOrDefault() == null)
      {
        collection.Add(newGroup);
      }

      return collection;
    }
  }
}
