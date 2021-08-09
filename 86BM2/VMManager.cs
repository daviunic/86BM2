﻿using System;
using System.Collections.Generic;
using System.IO;

namespace _86BM2
{
    public static class VMManager
    {
        private static List<VirtualMachine> VMs;

        public enum VMState
        {
            Stopped = 0,
            Running = 1,
            Waiting = 2,
            Paused  = 3,
        }

        public static string vmListDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "86BM2");
        public static string vmListFile = Path.Combine(vmListDir, "vmlist.json");

        static VMManager()
        {
            Load();
        }

        /// <summary>
        /// Returns the VM with the specified Guid, if it exists.
        /// </summary>
        /// <param name="Guid">The Guid of the VM to return.</param>
        /// <returns>The VM with the specified Guid if it exists, otherwise null.</returns>
        public static VirtualMachine GetById(int Id)
        {
            foreach(VirtualMachine vm in VMs)
            {
                if (vm.Id == Id)
                    return vm;
            }

            return null;
        }

        /// <summary>
        /// Returns the VM with the specified process ID, if it exists.
        /// </summary>
        /// <param name="Pid">The process ID of the VM to return. Must be more than 0.</param>
        /// <returns>The VM with the specified process ID if it exists, otherwise null.</returns>
        public static VirtualMachine GetByPid(int Pid)
        {
            if (Pid <= 0)
                return null;

            foreach (VirtualMachine vm in VMs)
            {
                if (vm.ProcessID == Pid)
                    return vm;
            }

            return null;
        }

        /// <summary>
        /// Returns the VM with the specified window handle, if it exists.
        /// </summary>
        /// <param name="Handle">The window handle of the VM to return. Must not be a zero pointer.</param>
        /// <returns>The VM with the specified window handle if it exists, otherwise null.</returns>
        public static VirtualMachine GetByHandle(IntPtr Handle)
        {
            if (Handle == IntPtr.Zero)
                return null;

            foreach (VirtualMachine vm in VMs)
            {
                if (vm.Handle == Handle)
                    return vm;
            }

            return null;
        }

        /// <summary>
        /// Adds a VM to the VM list.
        /// </summary>
        /// <param name="vm">The VM to be added to the VM list.</param>
        public static void Add(VirtualMachine vm)
        {
            VMs.Add(vm);

            //Also write the change to vmlist.json file!
        }

        /// <summary>
        /// Removes the VM with the specified Guid from the VM list, if it exists.
        /// </summary>
        /// <param name="Guid">The Guid of the VM to be removed from the VM list.</param>
        public static void Remove(int Id)
        {
            foreach(VirtualMachine vm in VMs)
            {
                if(vm.Id == Id)
                {
                    VMs.Remove(vm);

                    //Also write the change to vmlist.json file!

                    return;
                }
            }
        }

        /// <summary>
        /// Removes all VMs from the VM list.
        /// </summary>
        public static void RemoveAll()
        {
            VMs.Clear();

            //Also write the change to vmlist.json file!
        }

        /// <summary>
        /// Forces all running VMs to stop.
        /// </summary>
        public static void ForceStopAll()
        {
            foreach(VirtualMachine vm in VMs)
            {
                if(vm.State != VMState.Stopped)
                {
                    vm.ForceStop();
                }
            }
        }

        /// <summary>
        /// Adds all VMs from the vmlist.json file to the VM list.
        /// </summary>
        public static void Load()
        {
            //If the file doesn't exist (yet), load default values and create the file
            if (!File.Exists(vmListFile))
            {
                //Also create the directory if even that doesn't exist (yet)
                if (!Directory.Exists(vmListDir))
                {
                    Directory.CreateDirectory(vmListDir);
                }

                VMs = new List<VirtualMachine>();
            }
            else
            {
                var json = File.ReadAllText(vmListFile);

            }
        }
    }
}
