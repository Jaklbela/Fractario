using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Fractario
{
    /// <summary>
    /// Базовый класс, в котором содержится максимальная возможная рекурсия и базовые методы для всех фракталов.
    /// </summary>
    class Fractal
    {
        // Максимальная возможная рекурсия.
        public int maxDepth = 10;

        /// <summary>
        /// Метод отрисовки фрактала без параметров.
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
        public virtual void Draw(double x1, double y1, double angle, double length, Canvas canvas, int depth, double coeff, double leftCorner, double rightCorner, int diff) { }

        /// <summary>
        /// Метод отрисовки линии.
        /// </summary>
        /// <param name="canvas">Канва, на которой происходит отрисовка.</param>
        /// <param name="x1">Первая координата х.</param>
        /// <param name="x2">Вторая координата х.</param>
        /// <param name="y1">Первая координата у.</param>
        /// <param name="y2">Вторая координата у.</param>
        /// 
        protected static void CreateLine(Canvas canvas, int x1, int x2, int y1, int y2)
        {
            Line line = new();
            canvas.Children.Add(line);
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 1;
        }
    }
}
