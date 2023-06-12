using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GammaСolorСorrectionParameters : IParameters
    {
        public double CoefficientR { get; set; }
        public double CoefficientG { get; set; }
        public double CoefficientB { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент для канала R",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.01
                },
                new ParameterInfo()
                {
                    Name = "Коэффициент для канала G",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Коэффициент для канала B",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.05
                }
            };
        }

        public void SetValues(double[] values)
        {
            CoefficientR = values[0];
            CoefficientG = values[1];
            CoefficientB = values[2];
        }
    }
}
