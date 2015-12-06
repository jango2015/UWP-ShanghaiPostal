using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ShanghaiPostal.Models;

namespace ShanghaiPostal
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnAbout_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (About));
        }

        private void GridDistricts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var district = GridDistricts.SelectedItem as District;
            if (null != district)
            {
                Frame.Navigate(typeof (DistrictDetail), district);
            }
            GridDistricts.SelectedItem = null;
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

        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (SearchForm));
        }
    }
}
