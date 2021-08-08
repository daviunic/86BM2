using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static _86BM2.VMManager;

namespace _86BM2
{
    public class VirtualMachine
    {
        private BackgroundWorker worker;

        public Guid Guid { get; set; }
        public IntPtr Handle { get; set; } //Window handle for the main 86Box window once it's started
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; } //Full path of the VM folder
        public VMState State { get; set; } //Current state of the VM
        public int ProcessID { get; set; } //Process ID of 86box.exe running the VM
        public bool EnableLogging { get; set; } //Enable 86Box logging to file
        public string LogPath { get; set; } //Path where the log file will be saved

        public VirtualMachine()
        {
            Guid = new Guid();
            Name = "New virtual machine";
            Description = "";
            Path = "";
            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
            EnableLogging = false;
            LogPath = "";

            worker = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public VirtualMachine(string name, string desc, string path, bool enableLogging, string logPath)
        {
            Guid = new Guid();
            Name = name;
            Description = desc;
            Path = path;
            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
            EnableLogging = enableLogging;
            LogPath = logPath;

            worker = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        /// <summary>
        /// Starts the VM
        /// </summary>
        public void Start()
        {
            if (State == VMState.Stopped)
            {
                frmMain mainForm = (frmMain)Application.OpenForms["frmMain"]; //Instance of frmMain

                Process p = new Process();
                p.StartInfo.FileName = "";//Settings.CurrentSettings.ExePath;
                p.StartInfo.Arguments = $"-P \"{Path}\" -H {ZEROID},{mainForm.handle}";

                if (EnableLogging)
                {
                    p.StartInfo.Arguments += $" -L \"{LogPath}\"";
                }

                p.Start();
                ProcessID = p.Id;

                if (!p.MainWindowHandle.Equals(IntPtr.Zero))
                {
                    Handle = p.MainWindowHandle; //Get the window handle of the newly created process
                    State = VMState.Running;

                    //Start the worker which will wait for the VM's window to close
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync(ProcessID);
                    else
                        throw new Exception("The background worker for this VM is busy");
                }
                else
                {
                    throw new Exception("86Box process failed to initialize");
                }
            }
        }

        /// <summary>
        /// Instructs a running VM to pause
        /// </summary>
        public void Pause()
        {
            if (State == VMState.Running)
            {
                Interop.PostMessage(Handle, 0x8890, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Paused;
            }
        }

        /// <summary>
        /// Instructs a paused VM to resume
        /// </summary>
        public void Resume()
        {
            if (State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x8890, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Running;
            }
        }

        /// <summary>
        /// Instructs the VM to stop by asking for user confirmation first and focuses its window
        /// </summary>
        public void RequestStop()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x8893, IntPtr.Zero, IntPtr.Zero);
                Interop.SetForegroundWindow(Handle);
            }
        }

        /// <summary>
        /// Instructs the VM to stop without asking for user confirmation first
        /// </summary>
        public void ForceStop()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x0002, IntPtr.Zero, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Sends the CTRL+ALT+DELETE keystrokes to the VM
        /// </summary>
        public void SendCtrAltDel()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x8894, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Running;
            }
        }

        /// <summary>
        /// Hard resets the VM by asking the user for confirmation first
        /// </summary>
        public void HardReset()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x8892, IntPtr.Zero, IntPtr.Zero);
                Interop.SetForegroundWindow(Handle);
            }
        }

        /// <summary>
        /// Kills the associated 86Box process for this VM
        /// </summary>
        public void Kill()
        {
            Process p = Process.GetProcessById(ProcessID);
            p.Kill();

            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
        }

        /// <summary>
        /// Instructs the VM to open the Settings dialog, either standalone if the VM is stopped or as a modal if it's running
        /// </summary>
        public void Configure()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                Interop.PostMessage(Handle, 0x8889, IntPtr.Zero, IntPtr.Zero);
                Interop.SetForegroundWindow(Handle);
            }
            else if (State == VMState.Stopped)
            {
                frmMain mainForm = (frmMain)Application.OpenForms["frmMain"]; //Instance of frmMain

                Process p = new Process();
                p.StartInfo.FileName = "";//Settings.CurrentSettings.ExePath;
                p.StartInfo.Arguments = $"-S -P \"{Path}\" -H {ZEROID},{mainForm.handle}";

                if (EnableLogging)
                {
                    p.StartInfo.Arguments += $" -L \"{LogPath}\"";
                }

                p.Start();

                if (!p.MainWindowHandle.Equals(IntPtr.Zero))
                {
                    State = VMState.Waiting;
                    Handle = p.MainWindowHandle;
                    ProcessID = p.Id;

                    //Start the worker which will wait for the VM's window to close
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync(ProcessID);
                    else
                        throw new Exception("The background worker for this VM is busy");
                }
                else
                {
                    throw new Exception("86Box process failed to initialize");
                }
            }
        }

        /// <summary>
        /// Wipes the VM's config file and NVR folder
        /// </summary>
        public void Wipe()
        {
            File.Delete(System.IO.Path.Combine(Path, "86box.cfg"));
            Directory.Delete(System.IO.Path.Combine(Path, "nvr"), true);
        }

        /// <summary>
        /// Opens the VM's folder in File Explorer
        /// </summary>
        public void OpenFolder()
        {
            Process.Start(Path);
        }

        /// <summary>
        /// Instructs the shell to attempt to open the config file in the associated program, if there is one
        /// </summary>
        public void OpenConfig()
        {
            Process.Start(System.IO.Path.Combine(Path, "86box.cfg"));
        }

        /// <summary>
        /// Opens the VM's screenshots folder in File Explorer
        /// </summary>
        public void OpenScreenshotsFolder()
        {
            string screenshotsDir = System.IO.Path.Combine(Path, "screenshots");

            if (!Directory.Exists(screenshotsDir))
                Directory.CreateDirectory(screenshotsDir);

            Process.Start(screenshotsDir);
        }

        /// <summary>
        /// Opens the VM's printer output folder in File Explorer
        /// </summary>
        public void OpenPrinterFolder()
        {
            string printerDir = System.IO.Path.Combine(Path, "printer");

            if (!Directory.Exists(printerDir))
                Directory.CreateDirectory(printerDir);

            Process.Start(printerDir);
        }

        /// <summary>
        /// Opens the VM's nvr folder in File Explorer
        /// </summary>
        public void OpenNvrFolder()
        {
            string nvrDir = System.IO.Path.Combine(Path, "nvr");

            if (!Directory.Exists(nvrDir))
                Directory.CreateDirectory(nvrDir);

            Process.Start(nvrDir);
        }

        /// <summary>
        /// Creates a shortcut for the VM on current user's desktop.
        /// </summary>
        public void CreateDesktopShortcut()
        {
            throw new NotImplementedException();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int ProcessID = (int)e.Argument;
            try
            {
                //Finds the 86Box process associated with the VM and waits for it to exit
                Process p = Process.GetProcessById(ProcessID);
                p.WaitForExit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) 
            {
                throw e.Error;
            }
            else
            {
                Handle = IntPtr.Zero;
                ProcessID = -1;
                State = VMState.Stopped;
            }
        }
    }
}
