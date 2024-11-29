using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SkiaSharp;

namespace MinimapOverlay
{
    public partial class Form1 : Form
    {
        private SKBitmap currentImage;

        public Form1()
        {
            InitializeComponent();
        }


        private SKColor selectedColor = SKColors.Red.WithAlpha(100); 
        private int transparency = 100; 

        private void CoordinatesTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var input = coordinatesTextBox.Text;
                var coordinates = ParseCoordinates(input);

                currentImage = GenerateZoneImage(coordinates);

                ShowImage(currentImage);
            }
            catch
            {
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Files|*.png";
                    saveFileDialog.Title = "Exportar Imagem";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.OpenWrite(saveFileDialog.FileName))
                        {
                            currentImage.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
                        }
                        MessageBox.Show("Imagem exportada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma imagem gerada para exportar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var input = coordinatesTextBox.Text;
                var coordinates = ParseCoordinates(input);

                var referenceZone = new SKPoint[]
                {
                    new SKPoint(-320.26f, 7362.8f),
                    new SKPoint(-319.85f, 7406.23f),
                    new SKPoint(-321.07f, 7454.1f),
                    new SKPoint(-322.52f, 7462.43f),
                    new SKPoint(-326.98f, 7471.4f),
                    new SKPoint(-339.0f, 7485.05f),
                    new SKPoint(-357.14f, 7500.03f),
                    new SKPoint(-377.88f, 7514.02f),
                    new SKPoint(-530.5f, 7615.46f),
                    new SKPoint(-542.84f, 7596.83f),
                    new SKPoint(-561.05f, 7573.32f),
                    new SKPoint(-569.89f, 7562.73f),
                    new SKPoint(-586.31f, 7542.06f),
                    new SKPoint(-594.24f, 7529.08f),
                    new SKPoint(-597.21f, 7520.39f),
                    new SKPoint(-597.3f, 7507.44f),
                    new SKPoint(-597.35f, 7486.97f),
                    new SKPoint(-598.67f, 7483.44f),
                    new SKPoint(-601.51f, 7481.64f),
                    new SKPoint(-614.98f, 7481.39f),
                    new SKPoint(-620.37f, 7482.38f),
                    new SKPoint(-625.2f, 7485.44f),
                    new SKPoint(-629.46f, 7487.9f),
                    new SKPoint(-636.12f, 7489.47f),
                    new SKPoint(-642.52f, 7488.0f),
                    new SKPoint(-647.18f, 7484.24f),
                    new SKPoint(-649.44f, 7480.55f),
                    new SKPoint(-650.53f, 7464.12f),
                    new SKPoint(-668.33f, 7424.54f),
                    new SKPoint(-644.34f, 7414.67f),
                    new SKPoint(-619.38f, 7412.28f),
                    new SKPoint(-561.88f, 7418.21f),
                    new SKPoint(-505.01f, 7420.01f),
                    new SKPoint(-497.88f, 7401.87f),
                    new SKPoint(-494.83f, 7398.66f),
                    new SKPoint(-469.15f, 7380.21f),
                    new SKPoint(-445.61f, 7373.16f),
                    new SKPoint(-406.23f, 7372.72f),
                    new SKPoint(-380.14f, 7372.17f),
                    new SKPoint(-324.25f, 7363.75f)
                };

                float referenceXScale = 27.31034482758621f;
                float referenceYScale = 19.925867507886424f;

                var (xScale, yScale) = CalculateDynamicScale(coordinates, referenceZone, referenceXScale, referenceYScale);

                float minX = coordinates.Min(coord => coord.X);
                float maxX = coordinates.Max(coord => coord.X);
                float minY = coordinates.Min(coord => coord.Y);
                float maxY = coordinates.Max(coord => coord.Y);

                float xCenter = (minX + maxX) / 2;
                float yCenter = (minY + maxY) / 2;

                //string result = $"Centro da Zona:\nX: {xCenter:F2}, Y: {yCenter:F2}\n\n" +
                //                $"Escalas:\nXScale: {xScale:F2}, YScale: {yScale:F2}";

                string result = string.Format(CultureInfo.InvariantCulture,
                   "x = {0:F2}, y = {1:F2}, rotation = 0.0, xScale = {2:F2}, yScale = {3:F2}",
                   xCenter, yCenter, xScale, yScale);

                Clipboard.SetText(result);
                MessageBox.Show(result, "Resultados do Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (float xScale, float yScale) CalculateDynamicScale(SKPoint[] zone, SKPoint[] referenceZone, float referenceXScale, float referenceYScale)
        {
            (float width, float height) CalculateBoundingBox(SKPoint[] coordinates)
            {
                float minX = coordinates.Min(coord => coord.X);
                float maxX = coordinates.Max(coord => coord.X);
                float minY = coordinates.Min(coord => coord.Y);
                float maxY = coordinates.Max(coord => coord.Y);

                return (maxX - minX, maxY - minY);
            }

            var (refWidth, refHeight) = CalculateBoundingBox(referenceZone);
            var (width, height) = CalculateBoundingBox(zone);

            float scaleFactorX = refWidth / referenceXScale;
            float scaleFactorY = refHeight / referenceYScale;

            float xScale = width / scaleFactorX;
            float yScale = height / scaleFactorY;

            return (xScale, yScale);
        }


        private SKPoint[] ParseCoordinates(string input)
        {
            var matches = Regex.Matches(input, @"\((-?\d+\.?\d*),\s*(-?\d+\.?\d*)\)");

            if (matches.Count == 0)
            {
                throw new Exception("Nenhuma coordenada válida foi encontrada.");
            }

            var culture = CultureInfo.InvariantCulture;

            return matches.Cast<Match>()
                          .Select(match => new SKPoint(
                              float.Parse(match.Groups[1].Value, culture),
                              float.Parse(match.Groups[2].Value, culture)
                          )).ToArray();
        }

        private void ColorPickerButton_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    var chosenColor = colorDialog.Color;
                    selectedColor = new SKColor(chosenColor.R, chosenColor.G, chosenColor.B, (byte)transparency);
                    colorPickerButton.BackColor = chosenColor; 
                }
            }
        }

        private void TransparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            transparency = transparencyTrackBar.Value;
            selectedColor = new SKColor(selectedColor.Red, selectedColor.Green, selectedColor.Blue, (byte)transparency);
            transparencyLabel.Text = $"Transparência: {transparency}";
        }


        private SKBitmap GenerateZoneImage(SKPoint[] zoneCoordinates)
        {
            int imageWidth = 1276;
            int imageHeight = 1268;

            float minX = zoneCoordinates.Min(coord => coord.X);
            float maxX = zoneCoordinates.Max(coord => coord.X);
            float minY = zoneCoordinates.Min(coord => coord.Y);
            float maxY = zoneCoordinates.Max(coord => coord.Y);

            float xWidth = maxX - minX;
            float yHeight = maxY - minY;

            float xScale = imageWidth / xWidth;
            float yScale = imageHeight / yHeight;

            float offsetX = (imageWidth - (xWidth * xScale)) / 2;
            float offsetY = (imageHeight - (yHeight * yScale)) / 2;

            var bitmap = new SKBitmap(imageWidth, imageHeight);
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.Transparent);

                var fillPaint = new SKPaint
                {
                    Color = selectedColor,
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                };

                var borderPaint = new SKPaint
                {
                    Color = SKColors.IndianRed,
                    Style = SKPaintStyle.Stroke, 
                    StrokeWidth = 3, 
                    IsAntialias = true
                };

                var adjustedCoordinates = zoneCoordinates.Select(coord =>
                    new SKPoint(
                        offsetX + ((coord.X - minX) * xScale),
                        offsetY + ((maxY - coord.Y) * yScale)
                    )).ToArray();

                var zonePath = CreatePolygonPath(adjustedCoordinates);

                canvas.DrawPath(zonePath, fillPaint);

                canvas.DrawPath(zonePath, borderPaint);
            }

            return bitmap;
        }



        private SKPath CreatePolygonPath(SKPoint[] points)
        {
            var path = new SKPath();
            if (points.Length > 0)
            {
                path.MoveTo(points[0]);
                for (int i = 1; i < points.Length; i++)
                {
                    path.LineTo(points[i]);
                }
                path.Close();
            }
            return path;
        }

        private void ShowImage(SKBitmap image)
        {
            if (image != null)
            {
                using (var ms = new MemoryStream())
                {
                    var resizedImage = image.Resize(new SKImageInfo(1276, 1268), SKFilterQuality.High);

                    resizedImage.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }

        private void instructionsLabel_Click(object sender, EventArgs e)
        {

        }
        private void Label1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true 
            });
        }

    }
}
