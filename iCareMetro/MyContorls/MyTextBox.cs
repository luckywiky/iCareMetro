using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace iCareMetro.MyContorls
{
    public class MyTextBox : TextBox
    {
        //水印状态 
        private Brush _redColor = new SolidColorBrush(Colors.Red); private double _halfOpacity = 0.5;
        //正常状态 
        private Brush _userColor; private double _userOpacity; 
        public string WaterMarkText { get; set; }
        public MyTextBox()
        {
            SizeChanged += new SizeChangedEventHandler(MyTextBox_SizeChanged);
        }
        void MyTextBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _userColor = this.Foreground;
            _userOpacity = this.Opacity; if (WaterMarkText != "")
            {
                this.Foreground = _redColor; this.Opacity = _halfOpacity; this.Text = WaterMarkText;
            }
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (this.Text == WaterMarkText)
            {
                this.Text = ""; this.Foreground = _userColor; this.Opacity = _userOpacity;
            } base.OnGotFocus(e);
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (this.Text.Length < 1)
            {
                this.Text = WaterMarkText; this.Foreground = _redColor; this.Opacity = _halfOpacity;
            } base.OnLostFocus(e);
        }
    }
}
