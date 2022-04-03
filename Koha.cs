using System;
using System.Windows.Controls;

namespace Fractario
{
    /// <summary>
    /// Наследуемый класс, реализующий алгоритм отрисовки кривой Коха.
    /// </summary>
    class Koha : Fractal
    {
        /// <summary>
        /// Переопределенный метод отрисовки фрактала для кривой Коха.
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
            double x2 = x1 + length / 3 * Math.Cos(angle);
            double x3 = x2 + length / 3 * Math.Cos(angle + Math.PI / 3);
            double x4 = x1 + length / 3 * Math.Cos(angle) * 2;
            double x5 = x1 + length * Math.Cos(angle);


            double y2 = y1 - length / 3 * Math.Sin(angle);
            double y3 = y2 - length / 3 * Math.Sin(angle + Math.PI / 3);
            double y4 = y1 - length / 3 * Math.Sin(angle) * 2;
            double y5 = y1 - length * Math.Sin(angle);


            if (depth == maxDepth - 1)
            {
                CreateLine(canvas, (int)x1, (int)x2, (int)y1, (int)y2);
                CreateLine(canvas, (int)x2, (int)x3, (int)y2, (int)y3);
                CreateLine(canvas, (int)x3, (int)x4, (int)y3, (int)y4);
                CreateLine(canvas, (int)x4, (int)x5, (int)y4, (int)y5);
            }
            else
            {
                depth++;
                Draw(x1, y1, angle, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x2, y2, angle + Math.PI / 3, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x3, y3, angle - Math.PI / 3, length / 3, canvas, depth, 0, 0, 0, 0);
                Draw(x4, y4, angle, length / 3, canvas, depth, 0, 0, 0, 0);
            }
        }
    }
}
