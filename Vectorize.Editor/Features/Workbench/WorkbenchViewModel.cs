using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectorize.Editor.Features.Workbench
{
    public class WorkbenchViewModel : Conductor<IScreen>.Collection.AllActive
    {
        private readonly Interpreter.Interpreter interpreter = new Interpreter.Interpreter();

        private string errors;

        public WorkbenchViewModel(CodeEditorViewModel editor, PreviewViewModel preview)
        {
            Editor = editor;
            Preview = preview;

            ActivateItem(Editor);
            ActivateItem(Preview);

            Editor.PropertyChanged += (s, e) =>
            {
                NotifyOfPropertyChange(nameof(CanRun));
            };
        }

        public CodeEditorViewModel Editor { get; }
        public PreviewViewModel Preview { get; }

        public string Errors {
            get => errors;
            set => Set(ref errors, value);
        }

        public async Task Open()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Vectorize files (*.vec)|*.vec";
            dialog.InitialDirectory = Environment.CurrentDirectory;

            if (dialog.ShowDialog() == true)
            {
                await Editor.LoadFromFile(new FileInfo(dialog.FileName));
            }
        }

        public Task Save()
            => Editor.Save();

        public Task SaveAs()
            => Editor.SaveAs();

        public Task SaveSVG()
            => Preview.SaveSvgToFile();

        public bool CanRun
            => !string.IsNullOrWhiteSpace(Editor.Code);
        public void Run()
        {
            var result = interpreter.Run(Editor.Code);
            if (result.IsSuccess)
            {
                Preview.Update(result.Output);
                Errors = "";
            }
            else
            {
                Errors = string.Join(Environment.NewLine, result.Errors);
            }
        }
    }
}
