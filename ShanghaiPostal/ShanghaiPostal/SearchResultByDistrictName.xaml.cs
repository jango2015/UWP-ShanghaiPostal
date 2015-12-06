using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using ShanghaiPostal.ViewModel;

namespace ShanghaiPostal
{
    public sealed partial class SearchResultByDistrictName : Page
    {
        public SearchResultByDistrictName()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var districtKeyword = e.Parameter as string;
            if (null != districtKeyword)
            {
                var vm = DataContext as SearchResultByDistrictNameViewModel;
                vm?.InitData(districtKeyword);
            }
            base.OnNavigatedTo(e);
        }

        private void BtnCopy_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
