using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BarChartBuilder
{
    public partial class BarChartBuilderForm : Form
    {
        #region Constants

        /// <summary>
        ///     Количество уровней яркости
        /// </summary>
        private const int BrightnessLevelsCount = 256;

        #endregion

        #region Private fields

        /// <summary>
        ///     Холст
        /// </summary>
        private Bitmap _bitmap;

        /// <summary>
        ///     Массив расчитанных значений яркости
        /// </summary>
        private int[] _brightnessArray = new int[BrightnessLevelsCount];

        #endregion

        #region Constructor

        public BarChartBuilderForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Нарисовать гистограмму
        /// </summary>
        private void DrawBarChart()
        {
            _bitmap = new Bitmap(BrightnessLevelsCount, BrightnessLevelsCount);

            //Отрисовщик графики
            var graphics = Graphics.FromImage(_bitmap);

            //Цвет отрисовки
            var pen = new Pen(Color.Black);

            //Отрисовка гистограммы на холсте
            for (var i = 0; i < BrightnessLevelsCount; i++)
            {
                graphics.DrawLine(pen, i, BrightnessLevelsCount, i,
                    BrightnessLevelsCount - _brightnessArray[i]);
            }

            BarChartPictureBox.Image = _bitmap;
        }

        /// <summary>
        ///     Расчет и подгонка значений яркости
        /// </summary>
        /// <param name="filePath">Расположение файла</param>
        private void BuildImageBarChart(string filePath)
        {
            var image = new Bitmap(filePath);

            CalculateBarChart(image);

            image.Dispose();

            FitBrightnessArrayValues();
        }

        /// <summary>
        ///     Расчет и отрисовка гистограммы
        /// </summary>
        /// <param name="filePath">Расположение файла</param>
        private void BuildAndDrawBarChart(string filePath)
        {
            try
            {
                ImageNameLabel.Text = Path.GetFileName(filePath);

                BuildImageBarChart(filePath);

                DrawBarChart();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                ImageNameLabel.Text = "Выберите или перетащите .png или .jpeg файл";
            }
        }

        /// <summary>
        ///     Расчитать гистограмму картинки
        /// </summary>
        /// <param name="image">Изображение для которого нужно расчитать гистограмму</param>
        private void CalculateBarChart(Bitmap image)
        {
            _brightnessArray = new int[BrightnessLevelsCount];

            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    pixel.GetBrightness();

                    //Получаем значение уровня яркости пикселя по формуле
                    var brightnessLevel = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;

                    //Округляем до целых чисел и конвертируем в int значение
                    var arrayLevel = Convert.ToInt32(Math.Round(brightnessLevel,
                        MidpointRounding.AwayFromZero));

                    //Добавляем одно значение
                    _brightnessArray[arrayLevel]++;
                }
            }
        }

        /// <summary>
        ///     Подогнать значения массива под размеры холста
        /// </summary>
        private void FitBrightnessArrayValues()
        {
            //Уменьшаем все значения в два раза пока максимальное не станет меньше высоты холста
            while (_brightnessArray.Max() > BarChartPictureBox.Height)
            {
                for (var i = 0; i < BrightnessLevelsCount; i++)
                {
                    _brightnessArray[i] /= 2;
                }
            }
        }

        /// <summary>
        ///     Обработка нажатия на BrowseImageButton
        /// </summary>
        private void BrowseImageButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                BuildAndDrawBarChart(OpenFileDialog.FileName);
            }
        }

        #endregion

        #region DragNDrop

        private void BarChartBuilderForm_DragEnter(object sender, DragEventArgs e)
        {
            //Изменение вида курсора при перетаскивании файла
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void BarChartBuilderForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Всегда оставляем только первый файл если их перетащили несколько
                var filePath = ((string[]) e.Data.GetData(DataFormats.FileDrop))[0];

                var fileExtension = Path.GetExtension(filePath)?.ToLower();
                if (fileExtension != ".jpeg" && fileExtension != ".jpg" &&
                    fileExtension != ".png")
                {
                    MessageBox.Show("Неверный формат файла.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BuildAndDrawBarChart(filePath);
                }
            }
        }

        #endregion
    }
}