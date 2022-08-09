using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Media.Imaging;
using System.Diagnostics;


namespace SearchAndAutomation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private BitmapImage _currentImage = new BitmapImage();
        public BitmapImage CurrentImage
        {
            get { return _currentImage; }
            set { SetProperty(ref _currentImage, value); }
        }

        private Process _currentProcess = new Process();
        public Process CurrentProcess
        {
            get { return _currentProcess; }
            set { SetProperty(ref _currentProcess, value); }
        }
        #region Commands
        
        public DelegateCommand<object> SelectProcessCommand { get; private set; }

        void OnSelectProcess(object p)
        {
            if(p as string =="") { return; }

            var procId = int.Parse(p as string);
            try
            {
                CurrentProcess = Process.GetProcessById(procId);
            }
            catch (System.Exception)
            {

            }
        }

        bool CanSelectProcess(object p) => true;



        public DelegateCommand<object> RefreshImageCommand { get; private set; }

        void OnRefreshImage(object p)
        {
            
        }

        bool CanRefreshImage(object p) 
        {
            if (_currentProcess != null)
            {
                return true;
            }

            return false;
        }

        #endregion

        public MainWindowViewModel()
        {

            SelectProcessCommand = new DelegateCommand<object>(OnSelectProcess, CanSelectProcess);

        }
    }
}
