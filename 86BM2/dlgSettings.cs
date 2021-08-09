using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _86BM2
{
    public partial class dlgSettings : Form
    {
        private bool settingsChanged = false; //Keeps track of unsaved changes

        public dlgSettings()
        {
            InitializeComponent();
        }

        private void dlgSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            Get86BoxVersion();

            lblVersion1.Text = Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);

            #if DEBUG
                lblVersion1.Text += " (Debug)";
            #endif
        }

        private void dlgSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Unsaved changes, ask the user to confirm
            if (settingsChanged == true)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Would you like to save the changes you've made to the settings?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                }
                if (result != DialogResult.Cancel)
                {
                    e.Cancel = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            bool success = SaveSettings();
            if (!success)
            {
                return;
            }
            settingsChanged = CheckForChanges();
            btnApply.Enabled = settingsChanged;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (settingsChanged)
            {
                SaveSettings();
            }
            Close();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEXEdir.Text) || string.IsNullOrWhiteSpace(txtCFGdir.Text) ||
                string.IsNullOrWhiteSpace(txtLaunchTimeout.Text))
            {
                btnApply.Enabled = false;
            }
            else
            {
                settingsChanged = CheckForChanges();
                btnApply.Enabled = settingsChanged;
            }
        }

        //Obtains the 86Box version from 86Box.exe
        private void Get86BoxVersion()
        {
            try
            {
                FileVersionInfo vi = FileVersionInfo.GetVersionInfo(txtEXEdir.Text + @"\86Box.exe");
                if (vi.FilePrivatePart >= 2008) //Officially supported builds
                {
                    lbl86BoxVer1.Text = vi.FileMajorPart.ToString() + "." + vi.FileMinorPart.ToString() + "." + vi.FileBuildPart.ToString() + "." + vi.FilePrivatePart.ToString() + " - supported";
                    lbl86BoxVer1.ForeColor = Color.ForestGreen;
                }
                else if (vi.FilePrivatePart >= 1763 && vi.FilePrivatePart < 2008) //Should mostly work...
                {
                    lbl86BoxVer1.Text = vi.FileMajorPart.ToString() + "." + vi.FileMinorPart.ToString() + "." + vi.FileBuildPart.ToString() + "." + vi.FilePrivatePart.ToString() + " - partially supported";
                    lbl86BoxVer1.ForeColor = Color.Orange;
                }
                else //Completely unsupported, since version info can't be obtained anyway
                {
                    lbl86BoxVer1.Text = "Unknown - not supported";
                    lbl86BoxVer1.ForeColor = Color.Red;
                }
            }
            catch(FileNotFoundException)
            {
                lbl86BoxVer1.Text = "86Box.exe not found";
                lbl86BoxVer1.ForeColor = Color.Gray;
            }
        }
        
        //TODO: Rewrite
        //Save the settings to the registry
        private bool SaveSettings(bool silent = false)
        {
            if (!silent && cbxLogging.Checked && string.IsNullOrWhiteSpace(txtLogPath.Text))
            {
                DialogResult result = MessageBox.Show("Using an empty or whitespace string for the log path will prevent 86Box from logging anything. Are you sure you want to use this path?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            if (!silent && !File.Exists(txtEXEdir.Text + "86Box.exe") && !File.Exists(txtEXEdir.Text + @"\86Box.exe"))
            {
                DialogResult result = MessageBox.Show("86Box.exe could not be found in the directory you specified, so you won't be able to use any virtual machines. Are you sure you want to use this path?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            try
            {
                using var regkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\86Box");

                //Store the new values, close the key, changes are saved
                regkey.SetValue("EXEdir", txtEXEdir.Text, RegistryValueKind.String);
                regkey.SetValue("CFGdir", txtCFGdir.Text, RegistryValueKind.String);
                regkey.SetValue("MinimizeOnVMStart", cbxMinimize.Checked, RegistryValueKind.DWord);
                regkey.SetValue("ShowConsole", cbxShowConsole.Checked, RegistryValueKind.DWord);
                regkey.SetValue("MinimizeToTray", cbxMinimizeTray.Checked, RegistryValueKind.DWord);
                regkey.SetValue("CloseToTray", cbxCloseTray.Checked, RegistryValueKind.DWord);
                regkey.SetValue("LaunchTimeout", Convert.ToInt32(txtLaunchTimeout.Text), RegistryValueKind.DWord);
                regkey.SetValue("EnableLogging", cbxLogging.Checked, RegistryValueKind.DWord);
                regkey.SetValue("LogPath", txtLogPath.Text, RegistryValueKind.String);
                regkey.SetValue("EnableGridLines", cbxGrid.Checked, RegistryValueKind.DWord);

                settingsChanged = CheckForChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred. Please provide the following information to the developer:\n" + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Get86BoxVersion(); //Get the new exe version in any case
            }
            return true;
        }

        //TODO: Rewrite
        //Read the settings from the registry
        private void LoadSettings()
        {
            using var regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\86Box", false); // Open the key as read only

            // Load values, and if they don't exist, grab the defaults.
            txtEXEdir.Text = regkey?.GetValue("EXEdir")?.ToString() ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\86Box VMs\";
            txtCFGdir.Text = regkey?.GetValue("CFGdir")?.ToString() ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\86Box\";
            txtLaunchTimeout.Text = regkey?.GetValue("LaunchTimeout")?.ToString() ?? "5000";
            txtLogPath.Text = regkey?.GetValue("LogPath")?.ToString() ?? string.Empty;
            cbxMinimize.Checked = Convert.ToBoolean(regkey?.GetValue("MinimizeOnVMStart") ?? false);
            cbxShowConsole.Checked = Convert.ToBoolean(regkey?.GetValue("ShowConsole") ?? true);
            cbxMinimizeTray.Checked = Convert.ToBoolean(regkey?.GetValue("MinimizeToTray") ?? false);
            cbxCloseTray.Checked = Convert.ToBoolean(regkey?.GetValue("CloseToTray") ?? false);
            cbxLogging.Checked = Convert.ToBoolean(regkey?.GetValue("EnableLogging") ?? false);
            cbxGrid.Checked = Convert.ToBoolean(regkey?.GetValue("EnableGridLines") ?? false);

            txtLogPath.Enabled = cbxLogging.Checked;
            btnBrowse3.Enabled = cbxLogging.Checked;

            // We don't know whether we actually used any default settings, so better save either way.
            SaveSettings(true);
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Select a folder where 86Box program files and the roms folder are located",
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEXEdir.Text  = dialog.SelectedPath;
                if (!txtEXEdir.Text.EndsWith(@"\")) //Just in case
                {
                    txtEXEdir.Text += @"\";
                }
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Select a folder where your virtual machines (configs, nvr folders, etc.) will be located",
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtCFGdir.Text = dialog.SelectedPath;
                if (!txtCFGdir.Text.EndsWith(@"\")) //Just in case
                {
                    txtCFGdir.Text += @"\";
                }
            }
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All settings will be reset to their default values. Do you wish to continue?", "Settings will be reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetSettings();
            }
        }

        //Resets the settings to their default values
        private void ResetSettings()
        {
            var regkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\86Box");

            txtCFGdir.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\86Box VMs\";
            txtEXEdir.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\86Box\";
            cbxMinimize.Checked = false;
            cbxShowConsole.Checked = true;
            cbxMinimizeTray.Checked = false;
            cbxCloseTray.Checked = false;
            cbxLogging.Checked = false;
            txtLaunchTimeout.Text = "5000";
            txtLogPath.Text = "";
            cbxGrid.Checked = false;
            txtLogPath.Enabled = false;
            btnBrowse3.Enabled = false;

            settingsChanged = CheckForChanges();
        }

        //Checks if all controls match the currently saved settings to determine if any changes were made
        private bool CheckForChanges()
        {
            using var regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\86Box");

            btnApply.Enabled = (
                txtEXEdir.Text != (regkey?.GetValue("EXEdir")?.ToString() ?? string.Empty) ||
                txtCFGdir.Text != (regkey?.GetValue("CFGdir")?.ToString() ?? string.Empty) ||
                txtLogPath.Text != (regkey?.GetValue("LogPath")?.ToString() ?? string.Empty) ||
                txtLaunchTimeout.Text != (regkey?.GetValue("LaunchTimeout")?.ToString() ?? string.Empty) ||
                cbxMinimize.Checked != Convert.ToBoolean(regkey?.GetValue("MinimizeOnVMStart")) ||
                cbxShowConsole.Checked != Convert.ToBoolean(regkey?.GetValue("ShowConsole")) ||
                cbxMinimizeTray.Checked != Convert.ToBoolean(regkey?.GetValue("MinimizeToTray")) ||
                cbxCloseTray.Checked != Convert.ToBoolean(regkey?.GetValue("CloseToTray")) || 
                cbxLogging.Checked != Convert.ToBoolean(regkey?.GetValue("EnableLogging")) ||
                cbxGrid.Checked != Convert.ToBoolean(regkey?.GetValue("EnableGridLines")));

            return btnApply.Enabled;
        }

        private void cbx_CheckedChanged(object sender, EventArgs e)
        {
            settingsChanged = CheckForChanges();
        }

        private void cbxLogging_CheckedChanged(object sender, EventArgs e)
        {
            settingsChanged = CheckForChanges();
            txt_TextChanged(sender, e); //Needed so the Apply button doesn't get enabled on an empty logpath textbox. Too lazy to write a duplicated empty check...
            txtLogPath.Enabled = cbxLogging.Checked;
            btnBrowse3.Enabled = cbxLogging.Checked;
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.DefaultExt = "log";
            ofd.Title = "Select a file where 86Box logs will be saved";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            ofd.Filter = "Log files (*.log)|*.log";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtLogPath.Text = ofd.FileName;
            }

            ofd.Dispose();
        }

        private void lnkGithub2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkGithub2.LinkVisited = true;
            Process.Start("https://github.com/86Box/86Box");
        }

        private void lnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkGithub.LinkVisited = true;
            Process.Start("https://github.com/86Box/86BoxManager");
        }
    }
}