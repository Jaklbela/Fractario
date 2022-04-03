using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fractario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Глубина рекурсии, выбранная пользователем.
        private int depth;

        /// <summary>
        /// Конструктор, инициализирующий вызов окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик смены фрактала.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnFractalChanged(object sender, SelectionChangedEventArgs e) => FractalChanged();

        /// <summary>
        /// Метод, вызываемый при смене фрактала.
        /// </summary>
        private void FractalChanged()
        {
            switch (chooseFractal.SelectedIndex)
            {
                case 0:
                    DrawTree();
                    break;
                case 1:
                    DrawKoha();
                    break;
                case 2:
                    DrawCarpet();
                    break;
                case 3:
                    DrawTriangle();
                    break;
                case 4:
                    DrawKantor();
                    break;
            }
        }

        /// <summary>
        /// Обработчик смены глубины.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnDepthChanged(object sender, SelectionChangedEventArgs e) => DepthChanged();

        /// <summary>
        /// Метод, вызываемый при смене глубины.
        /// </summary>
        private void DepthChanged()
        {
            if (chooseFractal != null)
            {
                if ((chooseFractal.SelectedIndex == 2 && chooseDepth.SelectedIndex > 4) || ((chooseFractal.SelectedIndex == 1 ||
                    chooseFractal.SelectedIndex == 3) && chooseDepth.SelectedIndex > 6))
                {
                    MessageBox.Show("Выбран слишком крупный шаг для данного фрактала.\n Автоматически выбрана 1 итерация.");
                    chooseDepth.SelectedIndex = 0;
                    FractalChanged();
                    return;
                }
                depth = 9 - chooseDepth.SelectedIndex;
                FractalChanged();
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку сохранения.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnClick(object sender, EventArgs e) => Click();

        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопку.
        /// </summary>
        private void Click()
        {
            try
            {
                SaveFileDialog save = new();
                save.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg";
                save.Title = "Фрактал";
                save.ShowDialog();


                var rtb = new RenderTargetBitmap((int)canvas.Width, (int)canvas.Height, 96d, 96d, PixelFormats.Pbgra32);
                canvas.Measure(new Size(canvas.Width, canvas.Height));
                canvas.Arrange(new Rect(new Size(canvas.Width, canvas.Height)));
                rtb.Render(canvas);

                PngBitmapEncoder saveEncode = new();
                saveEncode.Frames.Add(BitmapFrame.Create(rtb));
                using var file = File.OpenWrite(save.FileName);
                saveEncode.Save(file);
            }
            catch (Exception)
            {
                return;
            }
        }


        /// <summary>
        /// Обработчик смены размера окна.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e) => DepthChanged();

        /// <summary>
        /// Обработчик смены размера левого угла.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnLeftChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => DepthChanged();

        /// <summary>
        /// Обработчик смены размера правого угла.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnRightChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => DepthChanged();

        /// <summary>
        /// Обработчик смены расстояния между итерациями.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnDiffChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => DepthChanged();

        /// <summary>
        /// Обработчик смены коэффициента отношений длин отрезков дерева.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e">Информация о событии.</param>
        private void OnLengthChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => DepthChanged();

        /// <summary>
        /// Вызов отрисовки дерева Пифагора.
        /// </summary>
        private void DrawTree()
        {
            canvas.Children.Clear();
            canvas.Width = Width;
            canvas.Height = Height;
            Tree tree = new();
            tree.Draw(Width / 2, Height - Height / 4, Math.PI / 2, Height / 3, canvas, depth,
                chooseLength.Value, chooseLeftCorner.Value, chooseRightCorner.Value, 0);
        }

        /// <summary>
        /// Вызов отрисовки кривой Коха.
        /// </summary>
        private void DrawKoha()
        {
            canvas.Children.Clear();
            canvas.Width = Width;
            canvas.Height = Height;
            if (chooseDepth.SelectedIndex > 6)
                chooseDepth.SelectedIndex = 0;
            Koha koha = new();
            koha.Draw(Width / 4, Height / 2, 0, Width / 2, canvas, depth, 0, 0, 0, 0);
        }

        /// <summary>
        /// Вызов отрисовки ковра Серпинского.
        /// </summary>
        private void DrawCarpet()
        {
            canvas.Children.Clear();
            canvas.Width = Width;
            canvas.Height = Height;
            if (chooseDepth.SelectedIndex > 4)
                chooseDepth.SelectedIndex = 0;
            Carpet carpet = new();
            carpet.Draw(Width / 3, -Height + Height / 3, 0, Width / 2, canvas, depth, 0, 0, 0, 0);
        }

        /// <summary>
        /// Вызов отрисовки треугольника Серпинского.
        /// </summary>
        private void DrawTriangle()
        {
            canvas.Children.Clear();
            canvas.Width = Width;
            canvas.Height = Height;
            if (chooseDepth.SelectedIndex > 6)
                chooseDepth.SelectedIndex = 0;
            Triangle triangle = new();
            triangle.Draw(Width / 3, Height - Height / 4, 0, Height - Height / 4, canvas, depth, 0, 0, 0, 0);
        }

        /// <summary>
        /// Вызов отрисовки множества Кантора.
        /// </summary>
        private void DrawKantor()
        {
            canvas.Children.Clear();
            canvas.Width = Width;
            canvas.Height = Height;
            Kantor kantor = new();
            kantor.Draw(Width / 3, Height / 8, 0, Width / 2, canvas, depth, 0, 0, 0, (int)chooseDiff.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
