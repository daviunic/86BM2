namespace _86BM2
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lstVMs = new System.Windows.Forms.ListView();
            this.clmName = new System.Windows.Forms.ColumnHeader();
            this.clmStatus = new System.Windows.Forms.ColumnHeader();
            this.clmDesc = new System.Windows.Forms.ColumnHeader();
            this.clmPath = new System.Windows.Forms.ColumnHeader();
            this.cmsVM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlAltDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createADesktopShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.img86box = new System.Windows.Forms.ImageList(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.imgStatus = new System.Windows.Forms.ImageList(this.components);
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.btnCtrlAltDel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.open86BoxManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblVMCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsVM.SuspendLayout();
            this.cmsTrayIcon.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Location = new System.Drawing.Point(72, 15);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 38);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.toolTip.SetToolTip(this.btnEdit, "Edit the properties of this virtual machine");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(136, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Remove";
            this.toolTip.SetToolTip(this.btnDelete, "Remove this virtual machine");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Enabled = false;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartStop.Location = new System.Drawing.Point(246, 15);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(56, 38);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.toolTip.SetToolTip(this.btnStartStop, "Start this virtual machine");
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lstVMs
            // 
            this.lstVMs.AllowColumnReorder = true;
            this.lstVMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVMs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmStatus,
            this.clmDesc,
            this.clmPath});
            this.lstVMs.ContextMenuStrip = this.cmsVM;
            this.lstVMs.FullRowSelect = true;
            this.lstVMs.HideSelection = false;
            this.lstVMs.Location = new System.Drawing.Point(15, 60);
            this.lstVMs.Margin = new System.Windows.Forms.Padding(4);
            this.lstVMs.Name = "lstVMs";
            this.lstVMs.ShowGroups = false;
            this.lstVMs.ShowItemToolTips = true;
            this.lstVMs.Size = new System.Drawing.Size(824, 515);
            this.lstVMs.SmallImageList = this.img86box;
            this.lstVMs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVMs.TabIndex = 10;
            this.lstVMs.UseCompatibleStateImageBehavior = false;
            this.lstVMs.View = System.Windows.Forms.View.Details;
            this.lstVMs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVMs_ColumnClick);
            this.lstVMs.SelectedIndexChanged += new System.EventHandler(this.lstVMs_SelectedIndexChanged);
            this.lstVMs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstVMs_KeyDown);
            this.lstVMs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstVMs_MouseDoubleClick);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 184;
            // 
            // clmStatus
            // 
            this.clmStatus.Text = "Status";
            this.clmStatus.Width = 107;
            // 
            // clmDesc
            // 
            this.clmDesc.Text = "Description";
            this.clmDesc.Width = 144;
            // 
            // clmPath
            // 
            this.clmPath.Text = "Path";
            this.clmPath.Width = 217;
            // 
            // cmsVM
            // 
            this.cmsVM.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsVM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStopToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.pauseResumeToolStripMenuItem,
            this.CtrlAltDelToolStripMenuItem,
            this.hardResetToolStripMenuItem,
            this.toolStripSeparator3,
            this.killToolStripMenuItem,
            this.wipeToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.openConfigFileToolStripMenuItem,
            this.createADesktopShortcutToolStripMenuItem});
            this.cmsVM.Name = "cmsVM";
            this.cmsVM.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsVM.Size = new System.Drawing.Size(248, 328);
            this.cmsVM.Opening += new System.ComponentModel.CancelEventHandler(this.cmsVM_Opening);
            // 
            // startStopToolStripMenuItem
            // 
            this.startStopToolStripMenuItem.Name = "startStopToolStripMenuItem";
            this.startStopToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.startStopToolStripMenuItem.Text = "Start";
            this.startStopToolStripMenuItem.ToolTipText = "Start this virtual machine";
            this.startStopToolStripMenuItem.Click += new System.EventHandler(this.startStopToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.ToolTipText = "Change configuration for this virtual machine";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // pauseResumeToolStripMenuItem
            // 
            this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
            this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.pauseResumeToolStripMenuItem.Text = "Pause";
            this.pauseResumeToolStripMenuItem.ToolTipText = "Pause this virtual machine";
            this.pauseResumeToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeToolStripMenuItem_Click);
            // 
            // CtrlAltDelToolStripMenuItem
            // 
            this.CtrlAltDelToolStripMenuItem.Name = "CtrlAltDelToolStripMenuItem";
            this.CtrlAltDelToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.CtrlAltDelToolStripMenuItem.Text = "Send CTRL+ALT+DEL";
            this.CtrlAltDelToolStripMenuItem.ToolTipText = "Send the CTRL+ALT+DEL keystroke to this virtual machine";
            this.CtrlAltDelToolStripMenuItem.Click += new System.EventHandler(this.CtrlAltDelToolStripMenuItem_Click);
            // 
            // hardResetToolStripMenuItem
            // 
            this.hardResetToolStripMenuItem.Name = "hardResetToolStripMenuItem";
            this.hardResetToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.hardResetToolStripMenuItem.Text = "Hard reset";
            this.hardResetToolStripMenuItem.ToolTipText = "Reset this virtual machine by simulating a power cycle";
            this.hardResetToolStripMenuItem.Click += new System.EventHandler(this.hardResetToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(244, 6);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.ToolTipText = "Kill this virtual machine";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // wipeToolStripMenuItem
            // 
            this.wipeToolStripMenuItem.Name = "wipeToolStripMenuItem";
            this.wipeToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.wipeToolStripMenuItem.Text = "Wipe";
            this.wipeToolStripMenuItem.ToolTipText = "Delete configuration and nvr for this virtual machine";
            this.wipeToolStripMenuItem.Click += new System.EventHandler(this.wipeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.ToolTipText = "Edit the properties of this virtual machine";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.ToolTipText = "Clone this virtual machine";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.ToolTipText = "Remove this virtual machine";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.openFolderToolStripMenuItem.Text = "Open folder in Explorer";
            this.openFolderToolStripMenuItem.ToolTipText = "Open the folder for this virtual machine in Windows Explorer";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openConfigFileToolStripMenuItem
            // 
            this.openConfigFileToolStripMenuItem.Name = "openConfigFileToolStripMenuItem";
            this.openConfigFileToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.openConfigFileToolStripMenuItem.Text = "Open config file";
            this.openConfigFileToolStripMenuItem.ToolTipText = "Open the config file for this virtual machine";
            this.openConfigFileToolStripMenuItem.Click += new System.EventHandler(this.openConfigFileToolStripMenuItem_Click);
            // 
            // createADesktopShortcutToolStripMenuItem
            // 
            this.createADesktopShortcutToolStripMenuItem.Name = "createADesktopShortcutToolStripMenuItem";
            this.createADesktopShortcutToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.createADesktopShortcutToolStripMenuItem.Text = "Create a desktop shortcut";
            this.createADesktopShortcutToolStripMenuItem.ToolTipText = "Create a shortcut for this virtual machine on the desktop";
            this.createADesktopShortcutToolStripMenuItem.Click += new System.EventHandler(this.createADesktopShortcutToolStripMenuItem_Click);
            // 
            // img86box
            // 
            this.img86box.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.img86box.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img86box.ImageStream")));
            this.img86box.TransparentColor = System.Drawing.Color.Transparent;
            this.img86box.Images.SetKeyName(0, "86box_16x16.png");
            this.img86box.Images.SetKeyName(1, "86box_16x16_green.png");
            this.img86box.Images.SetKeyName(2, "86box_16x16_yellow.png");
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNew.Location = new System.Drawing.Point(15, 15);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 38);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.toolTip.SetToolTip(this.btnNew, "Add a new or an existing virtual machine");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Enabled = false;
            this.btnConfigure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConfigure.Location = new System.Drawing.Point(310, 15);
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(88, 38);
            this.btnConfigure.TabIndex = 4;
            this.btnConfigure.Text = "Configure";
            this.toolTip.SetToolTip(this.btnConfigure, "Change the configuration of this virtual machine");
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // imgStatus
            // 
            this.imgStatus.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgStatus.ImageSize = new System.Drawing.Size(16, 16);
            this.imgStatus.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Enabled = false;
            this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPauseResume.Location = new System.Drawing.Point(405, 15);
            this.btnPauseResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(69, 38);
            this.btnPauseResume.TabIndex = 5;
            this.btnPauseResume.Text = "Pause";
            this.toolTip.SetToolTip(this.btnPauseResume, "Pause this virtual machine");
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // btnCtrlAltDel
            // 
            this.btnCtrlAltDel.Enabled = false;
            this.btnCtrlAltDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCtrlAltDel.Location = new System.Drawing.Point(481, 15);
            this.btnCtrlAltDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCtrlAltDel.Name = "btnCtrlAltDel";
            this.btnCtrlAltDel.Size = new System.Drawing.Size(107, 38);
            this.btnCtrlAltDel.TabIndex = 6;
            this.btnCtrlAltDel.Text = "Ctrl+Alt+Del";
            this.toolTip.SetToolTip(this.btnCtrlAltDel, "Send the CTRL+ALT+DEL keystroke to this virtual machine");
            this.btnCtrlAltDel.UseVisualStyleBackColor = true;
            this.btnCtrlAltDel.Click += new System.EventHandler(this.btnCtrlAltDel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Location = new System.Drawing.Point(596, 14);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 38);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Hard reset";
            this.toolTip.SetToolTip(this.btnReset, "Reset this virtual machine by simulating a power cycle");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.cmsTrayIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "86Box Manager";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // cmsTrayIcon
            // 
            this.cmsTrayIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open86BoxManagerToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.cmsTrayIcon.Name = "cmsVM";
            this.cmsTrayIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsTrayIcon.Size = new System.Drawing.Size(223, 82);
            // 
            // open86BoxManagerToolStripMenuItem
            // 
            this.open86BoxManagerToolStripMenuItem.Name = "open86BoxManagerToolStripMenuItem";
            this.open86BoxManagerToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.open86BoxManagerToolStripMenuItem.Text = "Show 86Box Manager";
            this.open86BoxManagerToolStripMenuItem.ToolTipText = "Restore the 86Box Manager window";
            this.open86BoxManagerToolStripMenuItem.Click += new System.EventHandler(this.open86BoxManagerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.ToolTipText = "Open 86Box Manager settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(219, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Close 86Box Manager";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVMCount});
            this.statusBar.Location = new System.Drawing.Point(0, 593);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusBar.Size = new System.Drawing.Size(855, 26);
            this.statusBar.TabIndex = 11;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblVMCount
            // 
            this.lblVMCount.BackColor = System.Drawing.Color.Transparent;
            this.lblVMCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblVMCount.Name = "lblVMCount";
            this.lblVMCount.Size = new System.Drawing.Size(150, 20);
            this.lblVMCount.Text = "# of virtual machines:";
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSettings.Location = new System.Drawing.Point(759, 15);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(81, 38);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Settings";
            this.toolTip.SetToolTip(this.btnSettings, "Open 86Box Manager settings");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 619);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCtrlAltDel);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lstVMs);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(870, 613);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "86Box Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmsVM.ResumeLayout(false);
            this.cmsTrayIcon.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmStatus;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.ColumnHeader clmPath;
        private System.Windows.Forms.ContextMenuStrip cmsVM;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseResumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CtrlAltDelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList img86box;
        private System.Windows.Forms.ImageList imgStatus;
        public System.Windows.Forms.ListView lstVMs;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnCtrlAltDel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createADesktopShortcutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem open86BoxManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem wipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblVMCount;
        private System.Windows.Forms.ToolStripMenuItem openConfigFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader clmDesc;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

