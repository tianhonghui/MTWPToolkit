using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace MTWPToolkit.UIExtenstion {
    /// <summary>
    /// 用途：为控件添加FadeIn显示效果
    /// FadeLevel 表示FadeIn的级别，级别越高FadeIn的动画执行时间越长
    /// </summary>
    public class MTFadeIn {

        private const int MilliSecondsPerLevel = 350;

        public static readonly DependencyProperty FadeLevelProperty =
            DependencyProperty.RegisterAttached("FadeLevel",typeof(double),typeof(MTFadeIn),new PropertyMetadata(default(double),PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject e,DependencyPropertyChangedEventArgs args) {
            var element = e as FrameworkElement;
            if(element != null) {
                element.Opacity = 0;
                element.Loaded+=ElementOnLoaded;
            }
        }


        public static void SetFadeLevel(FrameworkElement element,double value) {
            element.SetValue(FadeLevelProperty,value);
        }

        public static double GetFadeLevel(FrameworkElement element) {
            return (double)element.GetValue(FadeLevelProperty);
        }

        private static async void ElementOnLoaded(object sender,RoutedEventArgs routedEventArgs) {
            var element = sender as FrameworkElement;
            if(element != null) {
                element.Loaded -= ElementOnLoaded;
                    var level = GetFadeLevel(element)*MilliSecondsPerLevel;
                    var sb = new Storyboard();
                    var anim = new DoubleAnimation {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromMilliseconds(level),
                        EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseIn }
                    };
                    Storyboard.SetTarget(anim,element);
                    Storyboard.SetTargetProperty(anim,new PropertyPath("Opacity"));
                    sb.Children.Add(anim);
                    sb.Begin();
            }
        }

    }
}
