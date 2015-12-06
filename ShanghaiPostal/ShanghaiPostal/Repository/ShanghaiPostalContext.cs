using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Edi.UWP.Helpers;
using ShanghaiPostal.Models;

namespace ShanghaiPostal.Repository
{
    public class ShanghaiPostalContext
    {
        #region Singleton

        private static volatile ShanghaiPostalContext _instance;
        private static readonly object ObjLock = new Object();

        private ShanghaiPostalContext()
        {
        }

        public static ShanghaiPostalContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (ObjLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ShanghaiPostalContext();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        public IEnumerable<District> Districts { get; set; }

        public IEnumerable<PostalCode> PostalCodes { get; set; }

        public bool HasDataInitialized { get; set; }

        private async Task<string> GetXmlStringFromFileAsync(string fileName)
        {
            var stream = await GetFileAsStream($"Assets/{fileName}");
            if (stream == null)
            {
                throw new FileNotFoundException("Could not find embedded mappings resource file.");
            }
            var reader = new StreamReader(stream);
            string s = reader.ReadToEnd();
            return s;
        }

        // TODO: integrate to Edi.UWP.Helpers.Utils
        private async Task<Stream> GetFileAsStream(string filePath)
        {
            var districtsXml = await Package.Current.InstalledLocation.GetFileAsync(filePath.Replace('/', '\\'));
            var districtFileStream = await districtsXml.OpenReadAsync();
            var districtStream = districtFileStream.AsStream();
            return districtStream;
        }

        public async Task InitDataAsync()
        {
            if (HasDataInitialized)
            {
                return;
            }

            string ps = await GetXmlStringFromFileAsync("PostalCodes.xml");
            var postalcodeDoc = XDocument.Parse(ps);

            var postCodes = from p in postalcodeDoc.Descendants("PostalCode")
                            select new PostalCode()
                            {
                                Code = (string)p.Attribute("Code"),
                                Addresses = from a in p.Descendants("Address")
                                            select (string)a.Attribute("Info")
                            };
            PostalCodes = postCodes.ToList();

            string ds = await GetXmlStringFromFileAsync("Districts.xml");
            var districtsDoc = XDocument.Parse(ds);
            var districts = from p in districtsDoc.Descendants("District")
                            select new District()
                            {
                                Id = (string)p.Attribute("Id"),
                                Name = (string)p.Attribute("Name"),
                                PostalCodes = this.PostalCodes.Where(pc => p.Descendants("PostalCodeRefernce")
                                                                            .Attributes("PostalCode")
                                                                            .Any(a => (string)a == pc.Code))
                                                              .ToObservableCollection()
                            };
            Districts = districts.ToList();
        }
    }
}
