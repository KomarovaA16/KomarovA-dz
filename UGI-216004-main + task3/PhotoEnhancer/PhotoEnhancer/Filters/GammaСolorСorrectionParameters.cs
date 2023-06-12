using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GammaСolorСorrectionParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент для канала R",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.01)]
        public double CoefficientR { get; set; }

        [ParameterInfo(Name = "Коэффициент для канала G",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.01)]
        public double CoefficientG { get; set; }

        [ParameterInfo(Name = "Коэффициент для канала B",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.01)]
        public double CoefficientB { get; set; }
    }
}
