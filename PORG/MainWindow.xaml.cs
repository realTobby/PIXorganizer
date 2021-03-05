using PORG.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PORG
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    private ViewModels.ViewModel myViewModel;

    private DirectoryAndFileSystem directoryAndFileSystem = new DirectoryAndFileSystem();

    public MainWindow()
    {
      InitializeComponent();

      myViewModel = new ViewModels.ViewModel();
      this.DataContext = myViewModel;

      directoryAndFileSystem.Init();
      myViewModel.CurrentGroups = directoryAndFileSystem.GroupNames;
    }

    private void btn_find_Click(object sender, RoutedEventArgs e)
    {
      myViewModel.CurrentDirectory = directoryAndFileSystem.GetMainDirectory();
      directoryAndFileSystem.LoadImagesFromDirectory(myViewModel.CurrentDirectory, "*.PNG,*.JPG,*.GIF");
      myViewModel.NextImagePath = directoryAndFileSystem.imagePaths[directoryAndFileSystem.currentImageIndex];
    }

    private void btn_add_group_Click(object sender, RoutedEventArgs e)
    {
      myViewModel.CurrentGroups = directoryAndFileSystem.AddGroup(myViewModel.CurrentGroups, textBox_newgroup.Text);
      CheckForInformations();
      textBox_newgroup.Text = string.Empty;
    }

    private void btn_rename_group_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_remove_group_Click(object sender, RoutedEventArgs e)
    {
      myViewModel.CurrentGroups = directoryAndFileSystem.RemoveGroup(myViewModel.CurrentGroups, listBox_groups.SelectedItem.ToString());
      CheckForInformations();
    }

    private void CheckForInformations()
    {
      if(directoryAndFileSystem.Message != string.Empty)
      {
        myViewModel.CurrentErrorMessage = directoryAndFileSystem.Message;
      }
      directoryAndFileSystem.Message = string.Empty;
    }

    private void btn_organize_Click(object sender, RoutedEventArgs e)
    {
      // determine group
      string groupToOrganizeTO = myViewModel.CurrentGroups[listBox_groups.SelectedIndex];
      directoryAndFileSystem.Organize(myViewModel.NextImagePath, groupToOrganizeTO);
      myViewModel.NextImagePath = directoryAndFileSystem.imagePaths[directoryAndFileSystem.currentImageIndex];
      CheckForInformations();
    }

    private void listBox_groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(listBox_groups.SelectedItems.Count == 1)
      {
        myViewModel.IsGroupNameSelected = true;
      }
      else
      {
        myViewModel.IsGroupNameSelected = false;
      }
    }
  }
}
