using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                    return new Pixel(lightness, lightness, lightness);
                }));
            mainForm.AddFilter(new PixelFilter<GammaСolorСorrectionParameters>(
                "Гамма-фильтр",
                (pixel, parameters) =>
                {
                    var lightnessR = Math.Pow(pixel.R, Math.Pow(parameters.CoefficientR, -1));
                    var lightnessG = Math.Pow(pixel.G, Math.Pow(parameters.CoefficientG, -1));
                    var lightnessB = Math.Pow(pixel.B, Math.Pow(parameters.CoefficientB, -1));
                    return new Pixel(lightnessR, lightnessG, lightnessB);
                }));

            Application.Run(mainForm);
        }
    }
}
