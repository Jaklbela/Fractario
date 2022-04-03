
using System;
using System.Windows.Controls;

namespace Fractario
{
    /// <summary>
    /// Наследуемый класс, реализующий алгоритм отрисовки треугольника Серпинского.
    /// </summary>
    class Triangle : Fractal
    {
        /// <summary>
        /// Переопределенный метод отрисовки фрактала для треугольника Серпинского.
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
                double x2 = x1 + length / 2;
                double x3 = x1 + length;
                double y2 = y1 - length * Math.Sin(Math.PI / 3);

                CreateLine(canvas, (int)x1, (int)x2, (int)y1, (int)y2);
                CreateLine(canvas, (int)x2, (int)x3, (int)y2, (int)y1);
                CreateLine(canvas, (int)x3, (int)x1, (int)y1, (int)y1);

                double xBottom = x1 + (x3 - x1) / 2;
                double xRight = x1 + (x3 - x2) / 2;
                double ySide = y1 + (y2 - y1) / 2;

                depth++;

                Draw(x1, y1, angle, length / 2, canvas, depth, 0, 0, 0, 0);
                Draw(xRight, ySide, angle, length / 2, canvas, depth, 0, 0, 0, 0);
                Draw(xBottom, y1, angle, length / 2, canvas, depth, 0, 0, 0, 0);
            }
        }
    }
}
