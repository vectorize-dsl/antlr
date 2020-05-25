using Caliburn.Micro;
using Microsoft.Win32;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Vectorize.Editor.Features.Workbench
{
    public class PreviewViewModel : Screen
    {
        private string text;
        private ImageSource image;

        public string Text {
            get => text;
            private set => Set(ref text, value);
        }
        public ImageSource Image {
            get => image;
            private set => Set(ref image, value);
        }

        public void Update(string svg)
        {
            Text = svg;

            var drawSettings = new WpfDrawingSettings();
            using (var svgStream = new MemoryStream(Encoding.Default.GetBytes(svg)))
            using (var stream = new FileSvgReader(drawSettings))
            {
                Image = new DrawingImage(stream.Read(svgStream));
            }
        }

        public async Task SaveSvgToFile()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            var dialog = new SaveFileDialog();
            dialog.Filter = "SVG files (*.svg)|*.svg";
            dialog.InitialDirectory = Environment.CurrentDirectory;

            if (dialog.ShowDialog() == true)
            {
                var file = new FileInfo(dialog.FileName);
                using (var stream = file.OpenWrite())
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteLineAsync(Text);
                }
            }
        }
    }
}
