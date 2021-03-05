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
    private const string BASE_DIRECTORY = "PORG";

    public string Message = string.Empty;

    public ObservableCollection<string> imagePaths = new ObservableCollection<string>();
    public int currentImageIndex = 0;


    public ObservableCollection<string> GroupNames = new ObservableCollection<string>();
    public void Init()
    {
      // read folder strucutre
      if (!System.IO.Directory.Exists(BASE_DIRECTORY))
        System.IO.Directory.CreateDirectory(BASE_DIRECTORY);

      foreach(string groupDirectory in System.IO.Directory.GetDirectories(BASE_DIRECTORY))
      {
        string groupDirectoryFolderName = System.IO.Path.GetFileName(groupDirectory);
        GroupNames.Add(groupDirectoryFolderName);
      }
    }

    public string GetMainDirectory()
    {
      var fbd = new wf.FolderBrowserDialog();
      fbd.ShowDialog();
      return fbd.SelectedPath;
    }

    public ObservableCollection<string> AddGroup(ObservableCollection<string> collection, string newGroup)
    {
      if(newGroup != string.Empty)
      {
        if (collection.Where(x => x == newGroup).FirstOrDefault() == null)
        {
          if(!System.IO.Directory.Exists(BASE_DIRECTORY + "/" + newGroup))
          {
            System.IO.Directory.CreateDirectory(BASE_DIRECTORY + "/" + newGroup);
          }
          collection.Add(newGroup);
          Message = string.Format("Hinweis: Gruppe '{0}' wurde erfolgreich hinzugefügt!", newGroup);
        }
        else
        {
          Message = string.Format("Es existiert bereits eine Gruppe mit den Namen '{0}'!", newGroup);
        }
      }
      else
      {
        Message = "Error: Gruppennamen dürfen nicht leer sein!";
      }
      return collection;
    }

    public ObservableCollection<string> RemoveGroup(ObservableCollection<string> collection, string groupName)
    {
      if(collection.Where(x=>x == groupName).FirstOrDefault() != null)
      {
        collection.Remove(groupName);
        if (System.IO.Directory.Exists(BASE_DIRECTORY + "/" + groupName))
        {
          System.IO.Directory.Delete(BASE_DIRECTORY + "/" + groupName, true);
        }
        Message = string.Format("Hinweis: Gruppe '{0}' wurde erfolgreich gelöscht!", groupName);
      }

      return collection;
    }

    public void LoadImagesFromDirectory(string path, string searchPattern)
    {
      string[] sp = searchPattern.Split(',');

      foreach(string seatchOption in sp)
      {
        var results = System.IO.Directory.GetFiles(path, seatchOption, System.IO.SearchOption.TopDirectoryOnly);
        foreach (var res in results)
        {
          imagePaths.Add(res);
        }
      }

      currentImageIndex = 0;
      
    }

    public void Organize(string imagePath, string targetDirectory)
    {
      string fileName = System.IO.Path.GetFileName(imagePath);
      System.IO.File.Copy(imagePath, BASE_DIRECTORY + "/" + targetDirectory + "/" + fileName);
      currentImageIndex++;
      if(currentImageIndex >= imagePath.Count())
      {
        Message = "Hinweis: alle Bilder im Verzeichnis wurden verarbeitet!";
        currentImageIndex = 0;
      }
    }
  }
}
