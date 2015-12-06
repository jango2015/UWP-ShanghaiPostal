using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edi.UWP.Helpers;
using GalaSoft.MvvmLight;
using ShanghaiPostal.Models;
using ShanghaiPostal.Repository;

namespace ShanghaiPostal.ViewModel
{
    public class DistrictDetailViewModel : ViewModelBase
    {
        private District _district;

        public District District
        {
            get { return _district; }
            set { _district = value; RaisePropertyChanged(); }
        }
        
        public DistrictDetailViewModel()
        {
            if (IsInDesignMode)
            {
                District = new District()
                {
                    Id = "1",
                    Name = "黄浦区",
                    PostalCodes = ShanghaiPostalContext.Instance.PostalCodes.OrderBy(c => c.Code).Take(10).ToObservableCollection()
                };
            }
        }

        public void InitData(string dId)
        {
            if (!string.IsNullOrEmpty(dId))
            {
                var district = ShanghaiPostalContext.Instance.Districts.FirstOrDefault(d => d.Id == dId);
                if (null != district)
                {
                    District = district;
                }
            }
        }
    }
}
