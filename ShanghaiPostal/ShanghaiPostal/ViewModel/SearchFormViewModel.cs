using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Edi.UWP.Helpers;
using GalaSoft.MvvmLight;
using ShanghaiPostal.Repository;

namespace ShanghaiPostal.ViewModel
{
    public class SearchFormViewModel : ViewModelBase
    {
        private string _districtTerm;

        public string DistrictTerm
        {
            get { return _districtTerm; }
            set { _districtTerm = value; RaisePropertyChanged(); }
        }

        private string _postalCodeTerm;

        public string PostalCodeTerm
        {
            get { return _postalCodeTerm; }
            set { _postalCodeTerm = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<string> _suggessedPostalCodeList;

        public ObservableCollection<string> SuggessedPostalCodeList
        {
            get { return _suggessedPostalCodeList; }
            set { _suggessedPostalCodeList = value; RaisePropertyChanged(); }
        }

        public SearchFormViewModel()
        {
            SuggessedPostalCodeList = new ObservableCollection<string>(new List<string>());

            var codes = ShanghaiPostalContext.Instance.PostalCodes.Select(s => s.Code).ToObservableCollection();

            if (codes.Any())
            {
                SuggessedPostalCodeList = codes;
            }
        }
    }
}
