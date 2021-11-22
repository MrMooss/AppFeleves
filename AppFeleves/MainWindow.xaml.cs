using ImageFilter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace AppFeleves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap image = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "D:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == true)
            {
                var selectedName = dlg.FileName;
                FileNameLabel.Content = selectedName;
            }
        }

        private void EdgeButton_Click(object sender, RoutedEventArgs e)
        {
            image = BitmapFilter.Edge(BitmapFilter.bitmapGen(FileNameLabel.Content.ToString()));
            ImageControl.Source = BitmapFilter.ImageSourceFromBitmap(image);
        }
        private void Sharpen_Click(object sender, RoutedEventArgs e)
        {
            image = BitmapFilter.Sharpen(BitmapFilter.bitmapGen(FileNameLabel.Content.ToString()));
            ImageControl.Source = BitmapFilter.ImageSourceFromBitmap(image);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            image.Save(saveName.Text + ".jpg");
        }


    }
}
