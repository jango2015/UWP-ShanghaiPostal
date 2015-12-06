using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ShanghaiPostal.Models;
using ShanghaiPostal.ViewModel;

namespace ShanghaiPostal
{
    public sealed partial class SearchForm : Page
    {
        public SearchForm()
        {
            this.InitializeComponent();
        }

        private async void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AutoSuggestBoxPostalCodes.Text) && string.IsNullOrEmpty(DistrictTermBox.Text))
            {
                Frame.Navigate(typeof(PostalCodeDetail),
                    new PostalCode() { Code = AutoSuggestBoxPostalCodes.Text.Trim() });
            }
            else if (!string.IsNullOrEmpty(DistrictTermBox.Text))
            {
                Frame.Navigate(typeof(SearchResultByDistrictName), DistrictTermBox.Text.Trim());
            }
            else
            {
                await new MessageDialog("请输入关键词", "你TM在逗我?").ShowAsync();
            }
        }

        private void AutoSuggestBoxPostalCodes_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var vm = this.DataContext as SearchFormViewModel;
            if (null != vm)
            {
                var suggestions = vm.SuggessedPostalCodeList;

                string filter = sender.Text.ToUpper();
                AutoSuggestBoxPostalCodes.ItemsSource = suggestions.Where(s => s.Contains(filter));
            }
        }
    }
}
