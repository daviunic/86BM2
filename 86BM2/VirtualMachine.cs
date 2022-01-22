using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Windows.Forms;
using static _86BM2.Interop;
using static _86BM2.VMManager;

namespace _86BM2
{
    public class VirtualMachine
    {
        private BackgroundWorker worker;

        public int Id { get; set; }
        [JsonIgnore]
        public IntPtr Handle { get; set; } //Window handle for the main 86Box window once it's started
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; } //Full path of the VM folder
        [JsonIgnore]
        public VMState State { get; set; } //Current state of the VM
        [JsonIgnore]
        public int ProcessID { get; set; } //Process ID of 86box.exe running the VM
        public bool EnableLogging { get; set; } //Enable 86Box logging to file
        public string LogPath { get; set; } //Path where the log file will be saved
        public bool DumpConfigFile { get; set; } //Display the config file after it's loaded
        public bool EnableDebugOutput { get; set; } //Enable debug output
        public bool StartFullscreen { get; set; } //Start the VM in fullscreen mode
        public bool NoQuitConfirmation { get; set; } //Do not ask for confirmation when closing the emulator
        public bool EnableCrashDump { get; set; } //Enable crash dump on exceptions

        public VirtualMachine()
        {
            Random rand = new Random();
            Id = rand.Next();

            while (CheckId(Id))
                Id = rand.Next();

            Name = "New virtual machine";
            Description = "";
            Path = "";
            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
            EnableLogging = false;
            LogPath = "";
            DumpConfigFile = false;
            EnableDebugOutput = false;
            StartFullscreen = false;
            NoQuitConfirmation = false;
            EnableCrashDump = false;

            worker = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public VirtualMachine(string name, string desc, string path, bool enableLogging, string logPath, bool dumpConfig, bool enableDebug,
            bool startFullscreen, bool noQuitConfirm, bool enableCrashDump)
        {
            Random rand = new Random();
            Id = rand.Next();

            while (GetById(Id) != null)
                Id = rand.Next();

            Name = name;
            Description = desc;
            Path = path;
            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
            EnableLogging = enableLogging;
            LogPath = logPath;
            DumpConfigFile = dumpConfig;
            EnableDebugOutput = enableDebug;
            StartFullscreen = startFullscreen;
            NoQuitConfirmation = noQuitConfirm;
            EnableCrashDump = enableCrashDump;

            worker = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        /// <summary>
        /// Starts the VM with the main window or with the settings window.
        /// </summary>
        /// <param name="showSettings">If true, the VM will be started with the settings window, otherwise with the main window.</param>
        public void Start(bool showSettings)
        {
            if (State == VMState.Stopped)
            {
                frmMain mainForm = (frmMain)Application.OpenForms["frmMain"]; //Instance of frmMain

                Process p = new Process();
                p.StartInfo.FileName = @"C:\Users\David\Desktop\86Box\86Box.exe";//Settings.CurrentSettings.ExePath;

                string idString = string.Format("{0:X}", Id).PadLeft(16, '0');
                StringBuilder sb = new StringBuilder($"-P \"{Path}\" -H {idString},{mainForm.handle}");

                if (EnableLogging)
                    sb.Append($" -L \"{LogPath}\"");
                if (DumpConfigFile)
                    sb.Append(" -C");
                if (EnableDebugOutput)
                    sb.Append(" -D");
                if (StartFullscreen)
                    sb.Append(" -F");
                if (NoQuitConfirmation)
                    sb.Append(" -N");
                if (EnableCrashDump)
                    sb.Append(" -R");
                if (showSettings)
                    sb.Append(" -S");

                Debug.WriteLine($"VirtualMachine.Start: arguments are {sb}");
                p.StartInfo.Arguments = sb.ToString();
                p.Start();
                ProcessID = p.Id;

                State = VMState.Running;

                //Start the worker which will wait for the VM's window to close
                if (!worker.IsBusy)
                    worker.RunWorkerAsync(ProcessID);
                else
                    throw new Exception("The background worker for this VM is busy");
            }
        }

        /// <summary>
        /// Pauses a running VM.
        /// </summary>
        public void Pause()
        {
            if (State == VMState.Running)
            {
                PostMessage(Handle, 0x8890, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Paused;
            }
        }

        /// <summary>
        /// Resumes a paused VM.
        /// </summary>
        public void Resume()
        {
            if (State == VMState.Paused)
            {
                PostMessage(Handle, 0x8890, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Running;
            }
        }

        /// <summary>
        /// Stops a running or paused VM by asking for user confirmation first and focuses its window.
        /// </summary>
        public void RequestStop()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                PostMessage(Handle, 0x8893, IntPtr.Zero, IntPtr.Zero);
                SetForegroundWindow(Handle);
            }
        }

        /// <summary>
        /// Stops a running or paused VM without asking for user confirmation first.
        /// </summary>
        public void ForceStop()
        {
            if (State == VMState.Running || State == VMState.Paused)
                PostMessage(Handle, 0x0002, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Sends the CTRL+ALT+DELETE keystrokes to the VM.
        /// </summary>
        public void SendCtrAltDel()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                PostMessage(Handle, 0x8894, IntPtr.Zero, IntPtr.Zero);
                State = VMState.Running;
            }
        }

        /// <summary>
        /// Hard resets a running or paused VM by asking the user for confirmation first.
        /// </summary>
        public void HardReset()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                PostMessage(Handle, 0x8892, IntPtr.Zero, IntPtr.Zero);
                SetForegroundWindow(Handle);
            }
        }

        /// <summary>
        /// Kills the associated 86Box process for this VM.
        /// </summary>
        public void Kill()
        {
            Process p = Process.GetProcessById(ProcessID);
            p.Kill();
            p.Close();

            State = VMState.Stopped;
            Handle = IntPtr.Zero;
            ProcessID = -1;
        }

        /// <summary>
        /// Instructs the VM to open the Settings dialog, either standalone if the VM is stopped or as a modal if it's running.
        /// </summary>
        public void Configure()
        {
            if (State == VMState.Running || State == VMState.Paused)
            {
                PostMessage(Handle, 0x8889, IntPtr.Zero, IntPtr.Zero);
                SetForegroundWindow(Handle);
            }
            else if (State == VMState.Stopped)
                Start(true);
        }

        /// <summary>
        /// Wipes the VM's config file and NVR folder.
        /// </summary>
        public void Wipe()
        {
            File.Delete(System.IO.Path.Combine(Path, "86box.cfg"));
            Directory.Delete(System.IO.Path.Combine(Path, "nvr"), true);
        }

        /// <summary>
        /// Opens the VM's folder in File Explorer.
        /// </summary>
        public void OpenFolder()
        {
            Process.Start(Path);
        }

        /// <summary>
        /// Instructs the shell to attempt to open the config file in the associated program, if there is one.
        /// </summary>
        public void OpenConfig()
        {
            Process.Start(System.IO.Path.Combine(Path, "86box.cfg"));
        }

        /// <summary>
        /// Opens the VM's screenshots folder in File Explorer.
        /// </summary>
        public void OpenScreenshotsFolder()
        {
            string screenshotsDir = System.IO.Path.Combine(Path, "screenshots");

            if (!Directory.Exists(screenshotsDir))
                Directory.CreateDirectory(screenshotsDir);

            Process.Start(screenshotsDir);
        }

        /// <summary>
        /// Opens the VM's printer output folder in File Explorer.
        /// </summary>
        public void OpenPrinterFolder()
        {
            string printerDir = System.IO.Path.Combine(Path, "printer");

            if (!Directory.Exists(printerDir))
                Directory.CreateDirectory(printerDir);

            Process.Start(printerDir);
        }

        /// <summary>
        /// Opens the VM's nvr folder in File Explorer.
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

        /// <summary>
        /// Waits for the associated process to exit.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int ProcessID = (int)e.Argument;
            try
            {
                //Finds the 86Box process associated with the VM and waits for it to exit
                Process p = Process.GetProcessById(ProcessID);
                p.WaitForExit();
                p.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the VM state when the associated process exits.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw e.Error;
            else
            {
                Handle = IntPtr.Zero;
                ProcessID = -1;
                State = VMState.Stopped;
            }
        }
    }
}