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

            mainForm.AddFilter(new PixelFilter<ContrastParameters>(
                "Контраст",
                (pixel, parameters) =>
                {
                    return new Pixel(
                        parameters.AdjustContrast(pixel.R),
                        parameters.AdjustContrast(pixel.G),
                        parameters.AdjustContrast(pixel.B));
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч. с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Устранение чересстрочной развёртки (замена нечётных строк)",
                size =>
                {
                    if (size.Height % 2 == 0)
                        return size;
                    else
                        return new Size(size.Width, size.Height - 1);
                },

                (point, size) =>
                {

                    if (point.Y % 2 != 0)
                        return point;

                    else
                    {
                        int nextY = point.Y + 1;

                        if (nextY >= size.Height)
                            nextY = size.Height - 1;

                        return new Point(point.X, nextY);
                    }
                }
                ));

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол",
                new RotateTransformer()
                ));

            mainForm.AddFilter(new TransformFilter<LeanParameters>(
                "Скос вверх",
                new LeanTransformer()
                ));

            Application.Run(mainForm);
        }
    }
}
