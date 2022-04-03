using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractario
{
    /// <summary>
    /// Наследуемый класс, реализующий алгоритм отрисовки ковра Серпинского.
    /// </summary>
    class Carpet : Fractal
    {
        /// <summary>
        /// Переопределенный метод отрисовки фрактала для ковра Серпинского.
        /// </summary>
        /// <param name="x1">Первая координата х.</param>
        /// <param name="y1">Первая коордмната у.</param>
        /// <param name="angle">Угол поворота для вычисления координат.</param>
        /// <param name="length">Длина линии.</param>
        /// <param name="canvas">Канва, на которой проходит отрисовка.</param>
        /// <param name="depth">Глубина рекурсии.</param>
        /// <param name="coeff">Отношение длин отрезков (для дерева).</param>
        /// <param name="leftCorner">Размер левого угла (для дерева).</param>
        /// <param name="rightCorner">Размер правого угла (для дерева).</param>
        /// <param name="diff">Расстояние между итерациями(для множества).</param>
        public override void Draw(double x1, double y1, double angle, double length, Canvas canvas, int depth, double coeff, double leftCorner, double rightCorner, int diff)
        {
            if (depth != maxDepth)
            {
                double x2 = x1 + length / 3;
                double y2 = y1 + length / 3;


                Rectangle rectBig = new();
                rectBig.Width = length;
                rectBig.Height = length;
                rectBig.Fill = Brushes.BlueViolet;

                Canvas.SetTop(rectBig, y1 + length);
                Canvas.SetLeft(rectBig, x1);

                Rectangle rectSmall = new();
                rectSmall.Width = length / 3;
                rectSmall.Height = length / 3;
                rectSmall.Fill = Brushes.AliceBlue;

                Canvas.SetTop(rectSmall, y2 + length);
                Canvas.SetLeft(rectSmall, x2);

                canvas.Children.Add(rectBig);
                canvas.Children.Add(rectSmall);

                depth++;

                Draw(x1, y1 + 2 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x1, y2 + 2 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x1, y1 + 4 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x2, y1 + 2 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x2, y1 + 4 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x1 + 2 * (length / 3), y1 + 2 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x1 + 2 * (length / 3), y2 + 2 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x1 + 2 * (length / 3), y2 + 3 * (length / 3), angle, length / 3, canvas, depth, 0, 0, 0, 0);
            }
        }
    }
}
