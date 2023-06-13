using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

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
                    var lightnessR = Math.Pow(pixel.R, Math.Pow(parameters.GammaR, -1));
                    var lightnessG = Math.Pow(pixel.G, Math.Pow(parameters.GammaG, -1));
                    var lightnessB = Math.Pow(pixel.B, Math.Pow(parameters.GammaB, -1));
                    return new Pixel(lightnessR, lightnessG, lightnessB);
                }));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 180°",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, size.Height - point.Y - 1)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч. с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол",
                new RotateTransformer()
                ));

            mainForm.AddFilter(new TransformFilter<SkewUpParameters>(
                "Скос вверх",
                new SkewUpTransformer()
                ));

            Application.Run(mainForm);
        }
    }
}
