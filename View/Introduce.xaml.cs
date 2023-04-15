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
using System.Windows.Media.Animation;

namespace FinalProject.View
{
    /// <summary>
    /// Introduce.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Introduce : UserControl
    {
        public Introduce()
        {
            InitializeComponent();
            StartFlyObjectAnimation();
        }

        private void StartFlyObjectAnimation()
        {
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = 360;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            rotateAnimation.AutoReverse = true;

            Storyboard.SetTarget(rotateAnimation, flyObject);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin();
        }

    }
}
