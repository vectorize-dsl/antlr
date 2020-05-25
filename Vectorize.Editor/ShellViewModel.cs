using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Vectorize.Editor.Features.Workbench;

namespace Vectorize.Editor
{
    public class ShellViewModel : Conductor<Screen>.Collection.AllActive
    {
        public ShellViewModel(WorkbenchViewModel workbench)
        {
            Workbench = workbench;

            ActivateItem(Workbench);
        }

        public WorkbenchViewModel Workbench { get; }

        public Task Open()
            => Workbench.Open();
        public void Save()
            => Workbench.Save();
        public void SaveAs()
            => Workbench.SaveAs();
        public void SaveSVG()
            => Workbench.SaveSVG();

        public void CloseApp()
            => TryClose();
    }
}
