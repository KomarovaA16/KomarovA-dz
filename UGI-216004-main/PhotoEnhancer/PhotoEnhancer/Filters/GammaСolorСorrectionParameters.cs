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
        public double GammaR { get; set; }
        public double GammaG { get; set; }
        public double GammaB { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {

                Name = "Гамма канала R",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.01
                },
                new ParameterInfo()
                {
                    Name = "Гамма канала G",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Гамма канала B",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefaultValue = 1,
                    Increment = 0.05
                }
            };
        }

        public void SetValues(double[] values)
        {
            GammaR = values[0];
            GammaG = values[1];
            GammaB = values[2];
        }
    }
}
