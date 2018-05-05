using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace PDFView
{
    public sealed partial class PageContainer : UserControl
    {

        public PageInfo pageInfo;

        public PageContainer()
        {   pageInfo = new PageInfo();
            pageInfo.ImageSrc = null;
            pageInfo.IsLastPageAble = true;
            pageInfo.IsNextPageAble = false;
            pageInfo.PageInfoBottom = "Bottom";
            pageInfo.PageInfoTop = "Top";

            pageInfo.PropertyChanged += ChangeProperty;
            this.InitializeComponent();

           

        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            pageInfo.PageInfoBottom += "20";
        }
        private void ChangeProperty(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ImageSource")
            {
                PageImage.Source = pageInfo.ImageSrc;
            }
            if (e.PropertyName == "PageInfoTop")
            {
                PageInfoTextBlockTop.Text = pageInfo.PageInfoTop;
            }
            if (e.PropertyName == "PageInfoBottom")
            {
                PageInfoTextBlockBottom.Text = pageInfo.PageInfoBottom;
            }
            if (e.PropertyName == "IsLastPageAble")
            {
                LastPageButton.IsEnabled = pageInfo.IsLastPageAble;
            }
            if (e.PropertyName == "IsLastPageAble")
            {
                NextPageButton.IsEnabled = pageInfo.IsNextPageAble;
            }
        }
      
    }
    public class PageInfo:INotifyPropertyChanged
    {
        private ImageSource imageSrc;
        public ImageSource ImageSrc { get { return imageSrc; } set { imageSrc = value; this.OnPropertyChanged("ImageSource"); } }

        private bool isNextPageAble;
        public bool IsNextPageAble { get { return isNextPageAble; } set { isNextPageAble = value; this.OnPropertyChanged("IsNextPageAble"); } }

        private bool isLastPageAble;
        public bool IsLastPageAble { get { return isLastPageAble; } set { isLastPageAble = value; this.OnPropertyChanged("IsLastPageAble"); } }

        private string pageInfoTop { get; set; }
        public string PageInfoTop { get { return pageInfoTop; } set { pageInfoTop = value; this.OnPropertyChanged("PageInfoTop"); } }

        private string pageInfoBottom { get; set; }
        public string PageInfoBottom { get { return pageInfoBottom; } set { pageInfoBottom = value; this.OnPropertyChanged("PageInfoBottom"); } }
        public event PropertyChangedEventHandler PropertyChanged=delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
