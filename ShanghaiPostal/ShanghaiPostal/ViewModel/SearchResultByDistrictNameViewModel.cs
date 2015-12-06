using System.Collections.ObjectModel;
using System.Linq;
using Edi.UWP.Helpers;
using GalaSoft.MvvmLight;
using ShanghaiPostal.Models;
using ShanghaiPostal.Repository;

namespace ShanghaiPostal.ViewModel
{
    public class SearchResultByDistrictNameViewModel : ViewModelBase
    {
        private string _districtTerm;

        public string DistrictTerm
        {
            get { return _districtTerm; }
            set { _districtTerm = value; RaisePropertyChanged(); }
        }

        private IOrderedEnumerable<IGrouping<string, PostCodeSearchResult>> _groupedSearchResult;

        public IOrderedEnumerable<IGrouping<string, PostCodeSearchResult>> GroupedSearchResult
        {
            get { return _groupedSearchResult; }
            set { _groupedSearchResult = value; RaisePropertyChanged(); }
        }

        public SearchResultByDistrictNameViewModel()
        {
            if (IsInDesignMode)
            {
                DistrictTerm = "蓝村路";
            }
        }

        public void InitData(string districtTerm)
        {
            DistrictTerm = districtTerm;

            var result = ShanghaiPostalContext.Instance.PostalCodes
                                              .Where(p => p.Addresses.Any(a => a.Contains(districtTerm)));

            var postalCodes = result as PostalCode[] ?? result.ToArray();
            var postCodeSearchResults = (from postalCode in postalCodes
                                         from address in postalCode.Addresses.Where(a => a.Contains(districtTerm))
                                         select new PostCodeSearchResult()
                                         {
                                             Address = address,
                                             Code = postalCode.Code
                                         }).ToList();

            var r = from p in postCodeSearchResults
                group p by p.Code
                into g
                orderby g.Key
                select g;

            GroupedSearchResult = r;
        }
    }
}
