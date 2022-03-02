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
using HandyControl;
using System.Threading;
namespace VTOL
{
    /// <summary>
    /// Interaction logic for Junk_Test_Page.xaml
    /// </summary>
    public partial class Zip_Install_Dialog

    {
       public int prog = 0;
        public Zip_Install_Dialog()
        {
            InitializeComponent();
        }
        public void Add_Progress(string Filename)
        {
           // Progress_Bar.Value = progress;
            Current_File_Label.Content = Filename;

        }

    }
}
