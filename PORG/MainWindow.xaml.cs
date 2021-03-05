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

    private DirectoryAndFileSystem dafs = new DirectoryAndFileSystem();

    public MainWindow()
    {
      InitializeComponent();

      myViewModel = new ViewModels.ViewModel();
      this.DataContext = myViewModel;
    }

    private void btn_find_Click(object sender, RoutedEventArgs e)
    {
      myViewModel.CurrentDirectory = dafs.GetMainDirectory();
    }

    private void btn_add_group_Click(object sender, RoutedEventArgs e)
    {
      myViewModel.CurrentGroups = dafs.AddGroup(myViewModel.CurrentGroups, textBox_newgroup.Text);
    }

    private void btn_rename_group_Click(object sender, RoutedEventArgs e)
    {
    }

    private void btn_remove_group_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
