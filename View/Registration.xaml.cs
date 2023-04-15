//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace FinalProject.View
//{
//    /// <summary>
//    /// Registration.xaml에 대한 상호 작용 논리
//    /// </summary>
//    public partial class Registration : UserControl
//    {
//        public Registration()
//        {
//            InitializeComponent();
//        }
//    }
//}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace FinalProject.View
{
    /// <summary>
    /// Registration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Registration : UserControl
    {
        List<string> imgList = new List<string>();
        List<Image> imgCtrolList = new List<Image>();
        public Registration()
        {
            InitializeComponent();
        }

        void btn_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                string fullPath = ofd.FileName;
                string fileName = ofd.SafeFileName;
                string path = fullPath.Replace(fileName, "");

                string[] files = Directory.GetFiles(path);

                imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 || x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0).Select(x => x).ToList();
            }

            CreateImage(imgList);
        }

        void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Image image = sender as Image;

            CreateBitmap(image, image.Source.ToString());

            ((image.Parent) as WrapPanel).Children.Clear();

            image.Stretch = Stretch.UniformToFill;
            uiCanvas_Image.Children.Clear();
            uiCanvas_Image.Children.Add(image);

            CreateImage(imgList);
        }

        void CreateImage(List<string> imgList)
        {
            for (int i = 0; i < imgList.Count; i++)
            {
                Image image = new Image();

                CreateBitmap(image, imgList[i]);

                imgCtrolList.Add(image);

                image.MouseDown += ImageButton_Click;
                uiWrap_Iamge.Children.Add(image);
            }
        }

        void CreateBitmap(Image image, string imageList)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnDemand;
            img.CreateOptions = BitmapCreateOptions.DelayCreation;
            img.DecodePixelWidth = 150;
            img.UriSource = new Uri(imageList.ToString());
            img.EndInit();
            image.Source = img;
        }
    }
}