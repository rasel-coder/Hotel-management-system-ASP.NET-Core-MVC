using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.ViewModel
{
    public class FeatureModel
    {
        public int FeatureID { get; set; }

        [DisplayName("Feature Name")]
        public string FeatureName { get; set; }
        public string Icon { get; set; }
    }
}
