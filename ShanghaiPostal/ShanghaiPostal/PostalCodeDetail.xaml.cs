using System;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ShanghaiPostal.Models;
using ShanghaiPostal.ViewModel;

namespace ShanghaiPostal
{
    public sealed partial class PostalCodeDetail : Page
    {
        public PostalCodeDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var postalCode = e.Parameter as PostalCode;
            if (null != postalCode)
            {
                var vm = this.DataContext as PostalCodeDetailViewModel;
                vm?.InitData(postalCode.Code);
            }
            base.OnNavigatedTo(e);
        }

        private async void BtnCopy_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = (DataContext as PostalCodeDetailViewModel);
            if (null != vm)
            {
                var sb = new StringBuilder();
                foreach (var add in vm.PostalCode.Addresses)
                {
                    sb.Append(add + Environment.NewLine);
                }

                Edi.UWP.Helpers.Utils.CopyToClipBoard(sb.ToString());
                var dig = new MessageDialog("已复制", "提示");
                await dig.ShowAsync();
            }
        }
    }
}
