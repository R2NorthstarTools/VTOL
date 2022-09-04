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
using System.Windows.Shapes;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Window_Tool_Image_Editor_Wizard.xaml
    /// </summary>
    public partial class Window_Tool_Image_Editor_Wizard : Window
    {
        public bool IsClosed { get; set; } = false;
        public string Last_Saved_Skin_Path { get; set; }

        public Window_Tool_Image_Editor_Wizard()
        {
            InitializeComponent();
       
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        //private void Sf_Img_ImageSaved(object sender, Syncfusion.UI.Xaml.ImageEditor.ImageSavedEventArgs e)
        //{
        //    Last_Saved_Skin_Path = e.Location;
        //    Console.WriteLine("Saved To - " + e.Location);
           

        //}
    }
}
