using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edi.UWP.Helpers;
using GalaSoft.MvvmLight;
using ShanghaiPostal.Models;

namespace ShanghaiPostal.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<District> _districts;

        public ObservableCollection<District> Districts
        {
            get { return _districts; }
            set { _districts = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<PostalCode> _postalCodes;

        public ObservableCollection<PostalCode> PostalCodes
        {
            get { return _postalCodes; }
            set { _postalCodes = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            Districts = Repository.ShanghaiPostalContext.Instance.Districts.ToObservableCollection();
            PostalCodes = Repository.ShanghaiPostalContext.Instance.PostalCodes.ToObservableCollection();
        }
    }
}
