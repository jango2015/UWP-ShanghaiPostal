using System.Linq;
using GalaSoft.MvvmLight;
using ShanghaiPostal.Models;
using ShanghaiPostal.Repository;

namespace ShanghaiPostal.ViewModel
{
    public class PostalCodeDetailViewModel : ViewModelBase
    {
        private PostalCode _postalCode;

        public PostalCode PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; RaisePropertyChanged(); }
        }

        public PostalCodeDetailViewModel()
        {
            if (IsInDesignMode)
            {
                PostalCode = ShanghaiPostalContext.Instance.PostalCodes.First();
            }
        }

        public void InitData(string pCode)
        {
            if (!string.IsNullOrEmpty(pCode))
            {
                var postalCode = ShanghaiPostalContext.Instance.PostalCodes.FirstOrDefault(p => p.Code == pCode);
                if (null != postalCode)
                {
                    PostalCode = postalCode;
                }
            }
        }
    }
}
