using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ShanghaiPostal.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DistrictDetailViewModel>();
            SimpleIoc.Default.Register<PostalCodeDetailViewModel>();
            SimpleIoc.Default.Register<SearchFormViewModel>();
            SimpleIoc.Default.Register<SearchResultByDistrictNameViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public DistrictDetailViewModel DistrictDetail => ServiceLocator.Current.GetInstance<DistrictDetailViewModel>();

        public PostalCodeDetailViewModel PostalCodeDetail => ServiceLocator.Current.GetInstance<PostalCodeDetailViewModel>();

        public SearchFormViewModel SearchForm => ServiceLocator.Current.GetInstance<SearchFormViewModel>();

        public SearchResultByDistrictNameViewModel SearchResultByDistrictName => ServiceLocator.Current.GetInstance<SearchResultByDistrictNameViewModel>();

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public static void Cleanup()
        {
        }
    }
}