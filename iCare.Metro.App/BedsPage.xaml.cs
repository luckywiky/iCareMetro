using iCare.Metro.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “分组项页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234231 上提供

namespace iCare.Metro.App
{
    /// <summary>
    /// 显示分组的项集合的页。
    /// </summary>
    public sealed partial class BedsPage : iCare.Metro.App.Common.LayoutAwarePage
    {
        public BedsPage()
        {
            this.InitializeComponent();
            this.bedItemListView.ItemsSource = InitData();
        }

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="navigationParameter">最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的参数值。
        /// </param>
        /// <param name="pageState">此页在以前会话期间保留的状态
        /// 字典。首次访问页面时为 null。</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: 将可绑定项集合分配到 this.DefaultViewModel["Items"]
            this.DefaultViewModel["Beds"] = InitData();
           // this.DefaultViewModel["Beds"] = beds;
        }

        public List<Bed> InitData()
        {
            string[] sexArr = new string[] { "男", "女" };
            System.Collections.Generic.List<Bed> beds = new List<Bed>();
            for (int i = 0; i < 40; i++)
            {
                beds.Add(new Bed(string.Format("{0}床", i), string.Format("我叫{0}", i), sexArr[i % 2], i.ToString(),
                    string.Format("这是第{0}种病", i), string.Format("第{0}种护理", i)));
            }
            return beds;
        }
    }
}
