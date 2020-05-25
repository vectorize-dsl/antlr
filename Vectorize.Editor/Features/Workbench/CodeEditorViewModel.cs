using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vectorize.Editor.Features.Workbench
{
    public class CodeEditorViewModel : Screen
    {
        private string code;
        private FileInfo file;
        private bool codeWasChanged;

        public string Code {
            get => code;
            set {
                if (Set(ref code, value))
                {
                    CodeWasChanged = true;
                }
            }
        }
        public bool CodeWasChanged {
            get => codeWasChanged;
            set => Set(ref codeWasChanged, value);
        }

        public string Path => file?.FullName;

        public async Task LoadFromFile(FileInfo vecFile)
        {
            if (!vecFile.Exists)
                throw new ArgumentException($"File '{vecFile}' does not exists!", nameof(vecFile));

            using (var stream = vecFile.OpenRead())
            using (var reader = new StreamReader(stream))
            {
                var code = await reader.ReadToEndAsync();

                Code = code;
                file = vecFile;
                CodeWasChanged = false;

                NotifyOfPropertyChange(nameof(Path));
            }
        }

        public async Task Save()
        {
            if (file == null)
            {
                file = await SaveAs();
                NotifyOfPropertyChange(nameof(Path));
                return;
            }

            using (var stream = file.OpenWrite())
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteLineAsync(Code);
                CodeWasChanged = false;
            }
        }

        public async Task<FileInfo> SaveAs()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Vectorize files (*.vec)|*.vec";
            dialog.InitialDirectory = Environment.CurrentDirectory;

            if (dialog.ShowDialog() == true)
            {
                var file = new FileInfo(dialog.FileName);
                using (var stream = file.OpenWrite())
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteLineAsync(Code);
                }
            }
            return null;
        }

        public override async void CanClose(Action<bool> callback)
        {
            if (CodeWasChanged)
            {
                var shouldSave = MessageBox.Show(
                    "Code was changed. Save changes?",
                    "Unsaved changes",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Exclamation
               );
                switch (shouldSave)
                {
                    case MessageBoxResult.Yes:
                        await Save();
                        callback(true);
                        break;
                    case MessageBoxResult.No:
                        callback(true);
                        break;
                    case MessageBoxResult.Cancel:
                        callback(false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                callback(true);
            }
        }
    }
}
