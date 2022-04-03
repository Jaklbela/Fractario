
using System.Windows.Controls;

namespace Fractario
{
    /// <summary>
    /// Наследуемый класс, реализующий алгоритм отрисовки множества Кантора.
    /// </summary>
    internal class Kantor : Fractal
    {
        /// <summary>
        /// Переопределенный метод отрисовки фрактала для множества Кантора.
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
                double x2 = x1 + length;
                double x3 = x2 - (x2 - x1) / 3;

                CreateLine(canvas, (int)x1, (int)x2, (int)y1, (int)y1);

                depth++;

                Draw(x1, y1 + diff, angle, length / 3, canvas, depth, 0, 0, 0, diff);
                Draw(x3, y1 + diff, angle, length / 3, canvas, depth, 0, 0, 0, diff);
            }
        }
    }
}
