using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Parallax.WPF
{
    public class ParallaxEffect : Behavior<FrameworkElement>
    {
        #region Dependency
        public static readonly DependencyProperty UseParallaxProperty = DependencyProperty.RegisterAttached("UseParallax", typeof(bool), typeof(ParallaxEffect), new PropertyMetadata(false));
        public static readonly DependencyProperty ParentProperty = DependencyProperty.RegisterAttached("Parent", typeof(UIElement), typeof(ParallaxEffect), new PropertyMetadata(null));
        public static readonly DependencyProperty IsBackgroundProperty = DependencyProperty.RegisterAttached("IsBackground", typeof(bool), typeof(ParallaxEffect), new PropertyMetadata(false));

        public static bool GetUseParallax(DependencyObject obj) => (bool)obj.GetValue(UseParallaxProperty);
        public static void SetUseParallax(DependencyObject obj, bool value) => obj.SetValue(UseParallaxProperty, value);
        public static bool GetIsBackground(DependencyObject obj) => (bool)obj.GetValue(IsBackgroundProperty);
        public static void SetIsBackground(DependencyObject obj, bool value) => obj.SetValue(IsBackgroundProperty, value);
        public static UIElement GetParent(DependencyObject obj) => (UIElement)obj.GetValue(ParentProperty);
        public static void SetParent(DependencyObject obj, UIElement value) => obj.SetValue(ParentProperty, value);
        public static readonly DependencyProperty XOffsetProperty = DependencyProperty.RegisterAttached("XOffset", typeof(int), typeof(ParallaxEffect), new PropertyMetadata(120));
        public static readonly DependencyProperty YOffsetProperty = DependencyProperty.RegisterAttached("YOffset", typeof(int), typeof(ParallaxEffect), new PropertyMetadata(120));

        public static int GetXOffset(DependencyObject obj) => (int)obj.GetValue(XOffsetProperty);
        public static void SetXOffset(DependencyObject obj, int value) => obj.SetValue(XOffsetProperty, value);
        public static int GetYOffset(DependencyObject obj) => (int)obj.GetValue(YOffsetProperty);
        public static void SetYOffset(DependencyObject obj, int value) => obj.SetValue(YOffsetProperty, value);
        #endregion


        protected override void OnAttached()
        {
            if (!GetIsBackground(AssociatedObject))
            {
                AssociatedObject.MouseMove += MouseMoveHandler;
            }
            else
            {
                GetParent(AssociatedObject).MouseMove += MouseMoveHandler;
            }


        }

        protected override void OnDetaching()
        {
            if (!GetIsBackground(AssociatedObject))
            {
                AssociatedObject.MouseMove -= MouseMoveHandler;
            }
            else
            {
                GetParent(AssociatedObject).MouseMove -= MouseMoveHandler;
            }
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            var mouse = e.GetPosition(AssociatedObject);




            int xoffset = GetXOffset(AssociatedObject);
            int yoffset = GetYOffset(AssociatedObject);

            double newX = AssociatedObject.ActualHeight - ((mouse.X / xoffset)) - AssociatedObject.ActualHeight;
            double newY = AssociatedObject.ActualWidth - ((mouse.Y / yoffset)) - AssociatedObject.ActualWidth;

            if (!(AssociatedObject.RenderTransform is TranslateTransform))
                AssociatedObject.RenderTransform = new TranslateTransform(newX, newY);
            else
            {
                TranslateTransform transform = (TranslateTransform)AssociatedObject.RenderTransform;
                if (xoffset > 0)
                    transform.X = newX;
                if (yoffset > 0)
                    transform.Y = newY;

            }
        }
    }
}
