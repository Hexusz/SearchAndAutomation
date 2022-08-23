using Prism.Mvvm;
using SAAlib;
using Prism.Commands;
using System.Drawing;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using SearchAndAutomation.Models;
using SAAlib;
using SearchAndAutomation.ViewModels.ImageHandler.Base;

namespace SearchAndAutomation.ViewModels
{
    public class MainWindowViewModel : BindableBase, IMouseCaptureProxy
    {
        public event EventHandler Capture;
        public event EventHandler Release;

        public void OnMouseDown(object sender, MouseCaptureArgs e) 
        {
            //var rect = new Struct.Rect();
            //WinFunc.GetWindowRect(CurrentProcess.MainWindowHandle, ref rect);
            //WinFunc.SetCursorPos(rect.Left+(int)e.X, rect.Top + (int)e.Y);
        }
        public void OnMouseMove(object sender, MouseCaptureArgs e) 
        { 

        }
        public void OnMouseUp(object sender, MouseCaptureArgs e) 
        {
        
        }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private BitmapImage _currentImage;
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
            //delete
            CurrentProcess = Process.GetProcesses().First(x => x.ProcessName.Contains("Banana "));
            ///////
            CurrentImage = ImageWorker.GetScreenShotFromHandler(_currentProcess.MainWindowHandle);
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

            RefreshImageCommand = new DelegateCommand<object>(OnRefreshImage, CanRefreshImage);

        }
    }
}
