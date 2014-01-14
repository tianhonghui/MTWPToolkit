using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MTWPToolkit.Controls {
    public class MTBulletControl : Control {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MTBulletControl),
                new PropertyMetadata(default(ImageSource)));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MTBulletControl),
                new PropertyMetadata("bulletControl"));

        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(MTBulletControl),
                new PropertyMetadata(24.0));

        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(MTBulletControl),
                new PropertyMetadata(24.0));

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(MTBulletControl),
                new PropertyMetadata(default(Thickness)));

        public static readonly DependencyProperty TextForegroundProperty =
            DependencyProperty.Register("TextForeground", typeof(Brush), typeof(MTBulletControl),
                new PropertyMetadata(Application.Current.Resources["PhoneForegroundBrush"], TextForegroundChanged));

        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register("TextFontSize", typeof(double), typeof(MTBulletControl),
                new PropertyMetadata(24.0, TextFontSizeChanged));

        public ImageSource ImageSource {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double ImageWidth {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public double ImageHeight {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public Thickness TextMargin {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public Brush TextForeground {
            get { return (Brush)GetValue(TextForegroundProperty); }
            set { SetValue(TextForegroundProperty, value); }
        }

        public double TextFontSize {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        public const string ContentTextBlockKey = "ContentTextBlock";
        public TextBox ContentTextBlock { get; set; }
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            ContentTextBlock = GetTemplateChild("ContentTextBlock") as TextBox;

        }

        public MTBulletControl() {
            DefaultStyleKey = typeof(MTBulletControl);
        }
        private static void TextForegroundChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs) {
            var control = dependencyObject as MTBulletControl;
            if (control != null)
                control.ContentTextBlock.Foreground = dependencyPropertyChangedEventArgs.NewValue as Brush;
        }

        private static void TextFontSizeChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs) {
            var control = dependencyObject as MTBulletControl;
            if (control != null)
                control.ContentTextBlock.FontSize = (double)dependencyPropertyChangedEventArgs.NewValue;
        }
    }
}