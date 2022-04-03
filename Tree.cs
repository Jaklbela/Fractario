using System;
using System.Windows.Controls;

namespace Fractario
{
    /// <summary>
    /// Наследуемый класс, реализующий алгоритм отрисовки дерева Пифагора.
    /// </summary>
    class Tree : Fractal
    {

        /// <summary>
        /// Переопределенный метод отрисовки фрактала для дерева Пифагора.
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
                length *= coeff;
                double x2 = Math.Round(x1 + (length * Math.Cos(angle)));
                double y2 = Math.Round(y1 - (length * Math.Sin(angle)));

                CreateLine(canvas, (int)x1, (int)x2, (int)y1, (int)y2);

                x1 = x2;
                y1 = y2;

                depth++;

                Draw(x1, y1, angle + Math.PI / (180 / leftCorner), length, canvas, depth, coeff, leftCorner, rightCorner, 0);
                Draw(x1, y1, angle - Math.PI / (180 / rightCorner), length, canvas, depth, coeff, leftCorner, rightCorner, 0);
            }
        }
    }
}
