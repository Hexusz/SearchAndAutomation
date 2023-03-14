using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndAutomation.ViewModels.Dialogs
{
    internal class AddActionDialogViewModel : BindableBase
    {
        private string _title = "Add Action";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
