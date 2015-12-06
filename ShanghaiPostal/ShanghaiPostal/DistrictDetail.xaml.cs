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
    public sealed partial class DistrictDetail : Page
    {
        public DistrictDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var district = e.Parameter as District;
            if (null != district)
            {
                var vm = this.DataContext as DistrictDetailViewModel;
                vm?.InitData(district.Id);
            }
            base.OnNavigatedTo(e);
        }

        private async void BtnCopy_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = (this.DataContext as DistrictDetailViewModel);
            if (null != vm)
            {
                var sb = new StringBuilder();
                foreach (var pCode in vm.District.PostalCodes)
                {
                    sb.Append(pCode.Code + Environment.NewLine);
                }

                Edi.UWP.Helpers.Utils.CopyToClipBoard(sb.ToString());
                var dig = new MessageDialog("已复制", "提示");
                await dig.ShowAsync();
            }
        }

        private void GridPostalCodes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var postalCode = GridPostalCodes.SelectedItem as PostalCode;
            if (null != postalCode)
            {
                Frame.Navigate(typeof(PostalCodeDetail), postalCode);
            }
            GridPostalCodes.SelectedItem = null;
        }
    }
}
