namespace RomsetFilterApp
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RomsetFolderBrowseButton = new System.Windows.Forms.Button();
            this.RomsetFolderPathTextbox = new System.Windows.Forms.TextBox();
            this.RomsetFolderLabel = new System.Windows.Forms.Label();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.RevisionSelectionCombobox = new System.Windows.Forms.ComboBox();
            this.RevisionLabel = new System.Windows.Forms.Label();
            this.FlagsGroupbox = new System.Windows.Forms.GroupBox();
            this.DeselectAllFlagsButton = new System.Windows.Forms.Button();
            this.FlagsSelectAllButton = new System.Windows.Forms.Button();
            this.NoFlagCheckbox = new System.Windows.Forms.CheckBox();
            this.PhaserCheckbox = new System.Windows.Forms.CheckBox();
            this.BiosCheckbox = new System.Windows.Forms.CheckBox();
            this.MultiRegionCheckbox = new System.Windows.Forms.CheckBox();
            this.SampleCheckbox = new System.Windows.Forms.CheckBox();
            this.BetaCheckbox = new System.Windows.Forms.CheckBox();
            this.PrototypeCheckbox = new System.Windows.Forms.CheckBox();
            this.DemoCheckbox = new System.Windows.Forms.CheckBox();
            this.UnlicensedCheckbox = new System.Windows.Forms.CheckBox();
            this.RegionsGroupBox = new System.Windows.Forms.GroupBox();
            this.DeselectAllRegionsButton = new System.Windows.Forms.Button();
            this.RegionsSelectAllButton = new System.Windows.Forms.Button();
            this.OtherRegionsCheckbox = new System.Windows.Forms.CheckBox();
            this.SwedenCheckbox = new System.Windows.Forms.CheckBox();
            this.SpainCheckbox = new System.Windows.Forms.CheckBox();
            this.NetherlandsCheckbox = new System.Windows.Forms.CheckBox();
            this.KoreaCheckbox = new System.Windows.Forms.CheckBox();
            this.ItalyCheckbox = new System.Windows.Forms.CheckBox();
            this.HongKongCheckbox = new System.Windows.Forms.CheckBox();
            this.GermanyCheckbox = new System.Windows.Forms.CheckBox();
            this.FranceCheckbox = new System.Windows.Forms.CheckBox();
            this.ChinaCheckbox = new System.Windows.Forms.CheckBox();
            this.CanadaCheckbox = new System.Windows.Forms.CheckBox();
            this.BrazilCheckbox = new System.Windows.Forms.CheckBox();
            this.AustraliaCheckbox = new System.Windows.Forms.CheckBox();
            this.AsiaCheckbox = new System.Windows.Forms.CheckBox();
            this.JapanCheckbox = new System.Windows.Forms.CheckBox();
            this.EuropeCheckbox = new System.Windows.Forms.CheckBox();
            this.USACheckbox = new System.Windows.Forms.CheckBox();
            this.WorldCheckbox = new System.Windows.Forms.CheckBox();
            this.OutputFolderBrowseButton = new System.Windows.Forms.Button();
            this.OutputFolderTextbox = new System.Windows.Forms.TextBox();
            this.OutputFolderLabel = new System.Windows.Forms.Label();
            this.OutputOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.MoveRadioButton = new System.Windows.Forms.RadioButton();
            this.CopyRadioButton = new System.Windows.Forms.RadioButton();
            this.AlphabetSplitCheckbox = new System.Windows.Forms.CheckBox();
            this.CopyButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FilterGroupBox.SuspendLayout();
            this.FlagsGroupbox.SuspendLayout();
            this.RegionsGroupBox.SuspendLayout();
            this.OutputOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RomsetFolderBrowseButton
            // 
            this.RomsetFolderBrowseButton.Location = new System.Drawing.Point(551, 55);
            this.RomsetFolderBrowseButton.Name = "RomsetFolderBrowseButton";
            this.RomsetFolderBrowseButton.Size = new System.Drawing.Size(43, 35);
            this.RomsetFolderBrowseButton.TabIndex = 0;
            this.RomsetFolderBrowseButton.Text = "...";
            this.RomsetFolderBrowseButton.UseVisualStyleBackColor = true;
            this.RomsetFolderBrowseButton.Click += new System.EventHandler(this.RomsetFolderBrowseButton_Click);
            // 
            // RomsetFolderPathTextbox
            // 
            this.RomsetFolderPathTextbox.Location = new System.Drawing.Point(19, 55);
            this.RomsetFolderPathTextbox.Name = "RomsetFolderPathTextbox";
            this.RomsetFolderPathTextbox.Size = new System.Drawing.Size(531, 35);
            this.RomsetFolderPathTextbox.TabIndex = 1;
            this.RomsetFolderPathTextbox.TextChanged += new System.EventHandler(this.FolderTextbox_TextChanged);
            // 
            // RomsetFolderLabel
            // 
            this.RomsetFolderLabel.AutoSize = true;
            this.RomsetFolderLabel.Location = new System.Drawing.Point(19, 22);
            this.RomsetFolderLabel.Name = "RomsetFolderLabel";
            this.RomsetFolderLabel.Size = new System.Drawing.Size(192, 30);
            this.RomsetFolderLabel.TabIndex = 2;
            this.RomsetFolderLabel.Text = "Romset Folder Path";
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.RevisionSelectionCombobox);
            this.FilterGroupBox.Controls.Add(this.RevisionLabel);
            this.FilterGroupBox.Controls.Add(this.FlagsGroupbox);
            this.FilterGroupBox.Controls.Add(this.RegionsGroupBox);
            this.FilterGroupBox.Location = new System.Drawing.Point(19, 101);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(575, 617);
            this.FilterGroupBox.TabIndex = 4;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Select Roms with the Following";
            // 
            // RevisionSelectionCombobox
            // 
            this.RevisionSelectionCombobox.FormattingEnabled = true;
            this.RevisionSelectionCombobox.Items.AddRange(new object[] {
            "Select Latest Revision",
            "Select Earliest Revision",
            "Select All Revisions"});
            this.RevisionSelectionCombobox.Location = new System.Drawing.Point(24, 566);
            this.RevisionSelectionCombobox.Name = "RevisionSelectionCombobox";
            this.RevisionSelectionCombobox.Size = new System.Drawing.Size(537, 38);
            this.RevisionSelectionCombobox.TabIndex = 4;
            // 
            // RevisionLabel
            // 
            this.RevisionLabel.AutoSize = true;
            this.RevisionLabel.Location = new System.Drawing.Point(18, 533);
            this.RevisionLabel.Name = "RevisionLabel";
            this.RevisionLabel.Size = new System.Drawing.Size(258, 30);
            this.RevisionLabel.TabIndex = 3;
            this.RevisionLabel.Text = "Revision Selection Method";
            // 
            // FlagsGroupbox
            // 
            this.FlagsGroupbox.Controls.Add(this.DeselectAllFlagsButton);
            this.FlagsGroupbox.Controls.Add(this.FlagsSelectAllButton);
            this.FlagsGroupbox.Controls.Add(this.NoFlagCheckbox);
            this.FlagsGroupbox.Controls.Add(this.PhaserCheckbox);
            this.FlagsGroupbox.Controls.Add(this.BiosCheckbox);
            this.FlagsGroupbox.Controls.Add(this.MultiRegionCheckbox);
            this.FlagsGroupbox.Controls.Add(this.SampleCheckbox);
            this.FlagsGroupbox.Controls.Add(this.BetaCheckbox);
            this.FlagsGroupbox.Controls.Add(this.PrototypeCheckbox);
            this.FlagsGroupbox.Controls.Add(this.DemoCheckbox);
            this.FlagsGroupbox.Controls.Add(this.UnlicensedCheckbox);
            this.FlagsGroupbox.Location = new System.Drawing.Point(371, 34);
            this.FlagsGroupbox.Name = "FlagsGroupbox";
            this.FlagsGroupbox.Size = new System.Drawing.Size(190, 496);
            this.FlagsGroupbox.TabIndex = 2;
            this.FlagsGroupbox.TabStop = false;
            this.FlagsGroupbox.Text = "Flags";
            // 
            // DeselectAllFlagsButton
            // 
            this.DeselectAllFlagsButton.Location = new System.Drawing.Point(20, 440);
            this.DeselectAllFlagsButton.Name = "DeselectAllFlagsButton";
            this.DeselectAllFlagsButton.Size = new System.Drawing.Size(151, 40);
            this.DeselectAllFlagsButton.TabIndex = 3;
            this.DeselectAllFlagsButton.Text = "Select None";
            this.DeselectAllFlagsButton.UseVisualStyleBackColor = true;
            this.DeselectAllFlagsButton.Click += new System.EventHandler(this.DeselectAllFlagsButton_Click);
            // 
            // FlagsSelectAllButton
            // 
            this.FlagsSelectAllButton.Location = new System.Drawing.Point(20, 394);
            this.FlagsSelectAllButton.Name = "FlagsSelectAllButton";
            this.FlagsSelectAllButton.Size = new System.Drawing.Size(150, 40);
            this.FlagsSelectAllButton.TabIndex = 3;
            this.FlagsSelectAllButton.Text = "Select All";
            this.FlagsSelectAllButton.UseVisualStyleBackColor = true;
            this.FlagsSelectAllButton.Click += new System.EventHandler(this.FlagsSelectAllButton_Click);
            // 
            // NoFlagCheckbox
            // 
            this.NoFlagCheckbox.AutoSize = true;
            this.NoFlagCheckbox.Checked = true;
            this.NoFlagCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoFlagCheckbox.Location = new System.Drawing.Point(20, 354);
            this.NoFlagCheckbox.Name = "NoFlagCheckbox";
            this.NoFlagCheckbox.Size = new System.Drawing.Size(120, 34);
            this.NoFlagCheckbox.TabIndex = 2;
            this.NoFlagCheckbox.Text = "No Flags";
            this.NoFlagCheckbox.UseVisualStyleBackColor = true;
            // 
            // PhaserCheckbox
            // 
            this.PhaserCheckbox.AutoSize = true;
            this.PhaserCheckbox.Location = new System.Drawing.Point(20, 314);
            this.PhaserCheckbox.Name = "PhaserCheckbox";
            this.PhaserCheckbox.Size = new System.Drawing.Size(101, 34);
            this.PhaserCheckbox.TabIndex = 2;
            this.PhaserCheckbox.Text = "Phaser";
            this.PhaserCheckbox.UseVisualStyleBackColor = true;
            // 
            // BiosCheckbox
            // 
            this.BiosCheckbox.AutoSize = true;
            this.BiosCheckbox.Location = new System.Drawing.Point(20, 274);
            this.BiosCheckbox.Name = "BiosCheckbox";
            this.BiosCheckbox.Size = new System.Drawing.Size(84, 34);
            this.BiosCheckbox.TabIndex = 2;
            this.BiosCheckbox.Text = "BIOS";
            this.BiosCheckbox.UseVisualStyleBackColor = true;
            // 
            // MultiRegionCheckbox
            // 
            this.MultiRegionCheckbox.AutoSize = true;
            this.MultiRegionCheckbox.Location = new System.Drawing.Point(20, 234);
            this.MultiRegionCheckbox.Name = "MultiRegionCheckbox";
            this.MultiRegionCheckbox.Size = new System.Drawing.Size(151, 34);
            this.MultiRegionCheckbox.TabIndex = 2;
            this.MultiRegionCheckbox.Text = "MultiRegion";
            this.MultiRegionCheckbox.UseVisualStyleBackColor = true;
            // 
            // SampleCheckbox
            // 
            this.SampleCheckbox.AutoSize = true;
            this.SampleCheckbox.Location = new System.Drawing.Point(20, 194);
            this.SampleCheckbox.Name = "SampleCheckbox";
            this.SampleCheckbox.Size = new System.Drawing.Size(107, 34);
            this.SampleCheckbox.TabIndex = 2;
            this.SampleCheckbox.Text = "Sample";
            this.SampleCheckbox.UseVisualStyleBackColor = true;
            // 
            // BetaCheckbox
            // 
            this.BetaCheckbox.AutoSize = true;
            this.BetaCheckbox.Location = new System.Drawing.Point(20, 154);
            this.BetaCheckbox.Name = "BetaCheckbox";
            this.BetaCheckbox.Size = new System.Drawing.Size(80, 34);
            this.BetaCheckbox.TabIndex = 2;
            this.BetaCheckbox.Text = "Beta";
            this.BetaCheckbox.UseVisualStyleBackColor = true;
            // 
            // PrototypeCheckbox
            // 
            this.PrototypeCheckbox.AutoSize = true;
            this.PrototypeCheckbox.Location = new System.Drawing.Point(20, 114);
            this.PrototypeCheckbox.Name = "PrototypeCheckbox";
            this.PrototypeCheckbox.Size = new System.Drawing.Size(129, 34);
            this.PrototypeCheckbox.TabIndex = 2;
            this.PrototypeCheckbox.Text = "Prototype";
            this.PrototypeCheckbox.UseVisualStyleBackColor = true;
            // 
            // DemoCheckbox
            // 
            this.DemoCheckbox.AutoSize = true;
            this.DemoCheckbox.Location = new System.Drawing.Point(20, 74);
            this.DemoCheckbox.Name = "DemoCheckbox";
            this.DemoCheckbox.Size = new System.Drawing.Size(95, 34);
            this.DemoCheckbox.TabIndex = 1;
            this.DemoCheckbox.Text = "Demo";
            this.DemoCheckbox.UseVisualStyleBackColor = true;
            // 
            // UnlicensedCheckbox
            // 
            this.UnlicensedCheckbox.AutoSize = true;
            this.UnlicensedCheckbox.Location = new System.Drawing.Point(20, 34);
            this.UnlicensedCheckbox.Name = "UnlicensedCheckbox";
            this.UnlicensedCheckbox.Size = new System.Drawing.Size(140, 34);
            this.UnlicensedCheckbox.TabIndex = 0;
            this.UnlicensedCheckbox.Text = "Unlicensed";
            this.UnlicensedCheckbox.UseVisualStyleBackColor = true;
            // 
            // RegionsGroupBox
            // 
            this.RegionsGroupBox.Controls.Add(this.DeselectAllRegionsButton);
            this.RegionsGroupBox.Controls.Add(this.RegionsSelectAllButton);
            this.RegionsGroupBox.Controls.Add(this.OtherRegionsCheckbox);
            this.RegionsGroupBox.Controls.Add(this.SwedenCheckbox);
            this.RegionsGroupBox.Controls.Add(this.SpainCheckbox);
            this.RegionsGroupBox.Controls.Add(this.NetherlandsCheckbox);
            this.RegionsGroupBox.Controls.Add(this.KoreaCheckbox);
            this.RegionsGroupBox.Controls.Add(this.ItalyCheckbox);
            this.RegionsGroupBox.Controls.Add(this.HongKongCheckbox);
            this.RegionsGroupBox.Controls.Add(this.GermanyCheckbox);
            this.RegionsGroupBox.Controls.Add(this.FranceCheckbox);
            this.RegionsGroupBox.Controls.Add(this.ChinaCheckbox);
            this.RegionsGroupBox.Controls.Add(this.CanadaCheckbox);
            this.RegionsGroupBox.Controls.Add(this.BrazilCheckbox);
            this.RegionsGroupBox.Controls.Add(this.AustraliaCheckbox);
            this.RegionsGroupBox.Controls.Add(this.AsiaCheckbox);
            this.RegionsGroupBox.Controls.Add(this.JapanCheckbox);
            this.RegionsGroupBox.Controls.Add(this.EuropeCheckbox);
            this.RegionsGroupBox.Controls.Add(this.USACheckbox);
            this.RegionsGroupBox.Controls.Add(this.WorldCheckbox);
            this.RegionsGroupBox.Location = new System.Drawing.Point(24, 34);
            this.RegionsGroupBox.Name = "RegionsGroupBox";
            this.RegionsGroupBox.Size = new System.Drawing.Size(341, 496);
            this.RegionsGroupBox.TabIndex = 1;
            this.RegionsGroupBox.TabStop = false;
            this.RegionsGroupBox.Text = "Regions";
            // 
            // DeselectAllRegionsButton
            // 
            this.DeselectAllRegionsButton.Location = new System.Drawing.Point(22, 440);
            this.DeselectAllRegionsButton.Name = "DeselectAllRegionsButton";
            this.DeselectAllRegionsButton.Size = new System.Drawing.Size(300, 40);
            this.DeselectAllRegionsButton.TabIndex = 3;
            this.DeselectAllRegionsButton.Text = "Select None";
            this.DeselectAllRegionsButton.UseVisualStyleBackColor = true;
            this.DeselectAllRegionsButton.Click += new System.EventHandler(this.DeselectAllRegionsButton_Click);
            // 
            // RegionsSelectAllButton
            // 
            this.RegionsSelectAllButton.Location = new System.Drawing.Point(22, 394);
            this.RegionsSelectAllButton.Name = "RegionsSelectAllButton";
            this.RegionsSelectAllButton.Size = new System.Drawing.Size(300, 40);
            this.RegionsSelectAllButton.TabIndex = 3;
            this.RegionsSelectAllButton.Text = "Select All";
            this.RegionsSelectAllButton.UseVisualStyleBackColor = true;
            this.RegionsSelectAllButton.Click += new System.EventHandler(this.RegionsSelectAllButton_Click);
            // 
            // OtherRegionsCheckbox
            // 
            this.OtherRegionsCheckbox.AutoSize = true;
            this.OtherRegionsCheckbox.Location = new System.Drawing.Point(162, 354);
            this.OtherRegionsCheckbox.Name = "OtherRegionsCheckbox";
            this.OtherRegionsCheckbox.Size = new System.Drawing.Size(171, 34);
            this.OtherRegionsCheckbox.TabIndex = 0;
            this.OtherRegionsCheckbox.Text = "Other Regions";
            this.OtherRegionsCheckbox.UseVisualStyleBackColor = true;
            // 
            // SwedenCheckbox
            // 
            this.SwedenCheckbox.AutoSize = true;
            this.SwedenCheckbox.Location = new System.Drawing.Point(162, 314);
            this.SwedenCheckbox.Name = "SwedenCheckbox";
            this.SwedenCheckbox.Size = new System.Drawing.Size(111, 34);
            this.SwedenCheckbox.TabIndex = 0;
            this.SwedenCheckbox.Text = "Sweden";
            this.SwedenCheckbox.UseVisualStyleBackColor = true;
            // 
            // SpainCheckbox
            // 
            this.SpainCheckbox.AutoSize = true;
            this.SpainCheckbox.Location = new System.Drawing.Point(162, 274);
            this.SpainCheckbox.Name = "SpainCheckbox";
            this.SpainCheckbox.Size = new System.Drawing.Size(90, 34);
            this.SpainCheckbox.TabIndex = 0;
            this.SpainCheckbox.Text = "Spain";
            this.SpainCheckbox.UseVisualStyleBackColor = true;
            // 
            // NetherlandsCheckbox
            // 
            this.NetherlandsCheckbox.AutoSize = true;
            this.NetherlandsCheckbox.Location = new System.Drawing.Point(162, 234);
            this.NetherlandsCheckbox.Name = "NetherlandsCheckbox";
            this.NetherlandsCheckbox.Size = new System.Drawing.Size(152, 34);
            this.NetherlandsCheckbox.TabIndex = 0;
            this.NetherlandsCheckbox.Text = "Netherlands";
            this.NetherlandsCheckbox.UseVisualStyleBackColor = true;
            // 
            // KoreaCheckbox
            // 
            this.KoreaCheckbox.AutoSize = true;
            this.KoreaCheckbox.Location = new System.Drawing.Point(162, 194);
            this.KoreaCheckbox.Name = "KoreaCheckbox";
            this.KoreaCheckbox.Size = new System.Drawing.Size(91, 34);
            this.KoreaCheckbox.TabIndex = 0;
            this.KoreaCheckbox.Text = "Korea";
            this.KoreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // ItalyCheckbox
            // 
            this.ItalyCheckbox.AutoSize = true;
            this.ItalyCheckbox.Location = new System.Drawing.Point(162, 154);
            this.ItalyCheckbox.Name = "ItalyCheckbox";
            this.ItalyCheckbox.Size = new System.Drawing.Size(78, 34);
            this.ItalyCheckbox.TabIndex = 0;
            this.ItalyCheckbox.Text = "Italy";
            this.ItalyCheckbox.UseVisualStyleBackColor = true;
            // 
            // HongKongCheckbox
            // 
            this.HongKongCheckbox.AutoSize = true;
            this.HongKongCheckbox.Location = new System.Drawing.Point(162, 114);
            this.HongKongCheckbox.Name = "HongKongCheckbox";
            this.HongKongCheckbox.Size = new System.Drawing.Size(143, 34);
            this.HongKongCheckbox.TabIndex = 0;
            this.HongKongCheckbox.Text = "Hong Kong";
            this.HongKongCheckbox.UseVisualStyleBackColor = true;
            // 
            // GermanyCheckbox
            // 
            this.GermanyCheckbox.AutoSize = true;
            this.GermanyCheckbox.Location = new System.Drawing.Point(162, 74);
            this.GermanyCheckbox.Name = "GermanyCheckbox";
            this.GermanyCheckbox.Size = new System.Drawing.Size(122, 34);
            this.GermanyCheckbox.TabIndex = 0;
            this.GermanyCheckbox.Text = "Germany";
            this.GermanyCheckbox.UseVisualStyleBackColor = true;
            // 
            // FranceCheckbox
            // 
            this.FranceCheckbox.AutoSize = true;
            this.FranceCheckbox.Location = new System.Drawing.Point(162, 34);
            this.FranceCheckbox.Name = "FranceCheckbox";
            this.FranceCheckbox.Size = new System.Drawing.Size(100, 34);
            this.FranceCheckbox.TabIndex = 0;
            this.FranceCheckbox.Text = "France";
            this.FranceCheckbox.UseVisualStyleBackColor = true;
            // 
            // ChinaCheckbox
            // 
            this.ChinaCheckbox.AutoSize = true;
            this.ChinaCheckbox.Location = new System.Drawing.Point(22, 354);
            this.ChinaCheckbox.Name = "ChinaCheckbox";
            this.ChinaCheckbox.Size = new System.Drawing.Size(92, 34);
            this.ChinaCheckbox.TabIndex = 0;
            this.ChinaCheckbox.Text = "China";
            this.ChinaCheckbox.UseVisualStyleBackColor = true;
            // 
            // CanadaCheckbox
            // 
            this.CanadaCheckbox.AutoSize = true;
            this.CanadaCheckbox.Location = new System.Drawing.Point(22, 314);
            this.CanadaCheckbox.Name = "CanadaCheckbox";
            this.CanadaCheckbox.Size = new System.Drawing.Size(109, 34);
            this.CanadaCheckbox.TabIndex = 0;
            this.CanadaCheckbox.Text = "Canada";
            this.CanadaCheckbox.UseVisualStyleBackColor = true;
            // 
            // BrazilCheckbox
            // 
            this.BrazilCheckbox.AutoSize = true;
            this.BrazilCheckbox.Location = new System.Drawing.Point(22, 274);
            this.BrazilCheckbox.Name = "BrazilCheckbox";
            this.BrazilCheckbox.Size = new System.Drawing.Size(89, 34);
            this.BrazilCheckbox.TabIndex = 0;
            this.BrazilCheckbox.Text = "Brazil";
            this.BrazilCheckbox.UseVisualStyleBackColor = true;
            // 
            // AustraliaCheckbox
            // 
            this.AustraliaCheckbox.AutoSize = true;
            this.AustraliaCheckbox.Location = new System.Drawing.Point(22, 234);
            this.AustraliaCheckbox.Name = "AustraliaCheckbox";
            this.AustraliaCheckbox.Size = new System.Drawing.Size(120, 34);
            this.AustraliaCheckbox.TabIndex = 0;
            this.AustraliaCheckbox.Text = "Australia";
            this.AustraliaCheckbox.UseVisualStyleBackColor = true;
            // 
            // AsiaCheckbox
            // 
            this.AsiaCheckbox.AutoSize = true;
            this.AsiaCheckbox.Location = new System.Drawing.Point(22, 194);
            this.AsiaCheckbox.Name = "AsiaCheckbox";
            this.AsiaCheckbox.Size = new System.Drawing.Size(78, 34);
            this.AsiaCheckbox.TabIndex = 0;
            this.AsiaCheckbox.Text = "Asia";
            this.AsiaCheckbox.UseVisualStyleBackColor = true;
            // 
            // JapanCheckbox
            // 
            this.JapanCheckbox.AutoSize = true;
            this.JapanCheckbox.Location = new System.Drawing.Point(22, 154);
            this.JapanCheckbox.Name = "JapanCheckbox";
            this.JapanCheckbox.Size = new System.Drawing.Size(93, 34);
            this.JapanCheckbox.TabIndex = 0;
            this.JapanCheckbox.Text = "Japan";
            this.JapanCheckbox.UseVisualStyleBackColor = true;
            // 
            // EuropeCheckbox
            // 
            this.EuropeCheckbox.AutoSize = true;
            this.EuropeCheckbox.Location = new System.Drawing.Point(22, 114);
            this.EuropeCheckbox.Name = "EuropeCheckbox";
            this.EuropeCheckbox.Size = new System.Drawing.Size(104, 34);
            this.EuropeCheckbox.TabIndex = 0;
            this.EuropeCheckbox.Text = "Europe";
            this.EuropeCheckbox.UseVisualStyleBackColor = true;
            // 
            // USACheckbox
            // 
            this.USACheckbox.AutoSize = true;
            this.USACheckbox.Location = new System.Drawing.Point(22, 74);
            this.USACheckbox.Name = "USACheckbox";
            this.USACheckbox.Size = new System.Drawing.Size(78, 34);
            this.USACheckbox.TabIndex = 0;
            this.USACheckbox.Text = "USA";
            this.USACheckbox.UseVisualStyleBackColor = true;
            // 
            // WorldCheckbox
            // 
            this.WorldCheckbox.AutoSize = true;
            this.WorldCheckbox.Location = new System.Drawing.Point(22, 34);
            this.WorldCheckbox.Name = "WorldCheckbox";
            this.WorldCheckbox.Size = new System.Drawing.Size(94, 34);
            this.WorldCheckbox.TabIndex = 0;
            this.WorldCheckbox.Text = "World";
            this.WorldCheckbox.UseVisualStyleBackColor = true;
            // 
            // OutputFolderBrowseButton
            // 
            this.OutputFolderBrowseButton.Location = new System.Drawing.Point(551, 763);
            this.OutputFolderBrowseButton.Name = "OutputFolderBrowseButton";
            this.OutputFolderBrowseButton.Size = new System.Drawing.Size(43, 35);
            this.OutputFolderBrowseButton.TabIndex = 0;
            this.OutputFolderBrowseButton.Text = "...";
            this.OutputFolderBrowseButton.UseVisualStyleBackColor = true;
            this.OutputFolderBrowseButton.Click += new System.EventHandler(this.OutputFolderBrowseButton_Click);
            // 
            // OutputFolderTextbox
            // 
            this.OutputFolderTextbox.Location = new System.Drawing.Point(19, 763);
            this.OutputFolderTextbox.Name = "OutputFolderTextbox";
            this.OutputFolderTextbox.Size = new System.Drawing.Size(531, 35);
            this.OutputFolderTextbox.TabIndex = 1;
            this.OutputFolderTextbox.TextChanged += new System.EventHandler(this.FolderTextbox_TextChanged);
            // 
            // OutputFolderLabel
            // 
            this.OutputFolderLabel.AutoSize = true;
            this.OutputFolderLabel.Location = new System.Drawing.Point(19, 730);
            this.OutputFolderLabel.Name = "OutputFolderLabel";
            this.OutputFolderLabel.Size = new System.Drawing.Size(189, 30);
            this.OutputFolderLabel.TabIndex = 2;
            this.OutputFolderLabel.Text = "Output Folder Path";
            // 
            // OutputOptionsGroupBox
            // 
            this.OutputOptionsGroupBox.Controls.Add(this.MoveRadioButton);
            this.OutputOptionsGroupBox.Controls.Add(this.CopyRadioButton);
            this.OutputOptionsGroupBox.Controls.Add(this.AlphabetSplitCheckbox);
            this.OutputOptionsGroupBox.Location = new System.Drawing.Point(19, 807);
            this.OutputOptionsGroupBox.Name = "OutputOptionsGroupBox";
            this.OutputOptionsGroupBox.Size = new System.Drawing.Size(575, 102);
            this.OutputOptionsGroupBox.TabIndex = 5;
            this.OutputOptionsGroupBox.TabStop = false;
            this.OutputOptionsGroupBox.Text = "Output Options";
            // 
            // MoveRadioButton
            // 
            this.MoveRadioButton.AutoSize = true;
            this.MoveRadioButton.Location = new System.Drawing.Point(471, 34);
            this.MoveRadioButton.Name = "MoveRadioButton";
            this.MoveRadioButton.Size = new System.Drawing.Size(90, 34);
            this.MoveRadioButton.TabIndex = 2;
            this.MoveRadioButton.Text = "Move";
            this.MoveRadioButton.UseVisualStyleBackColor = true;
            // 
            // CopyRadioButton
            // 
            this.CopyRadioButton.AutoSize = true;
            this.CopyRadioButton.Checked = true;
            this.CopyRadioButton.Location = new System.Drawing.Point(371, 34);
            this.CopyRadioButton.Name = "CopyRadioButton";
            this.CopyRadioButton.Size = new System.Drawing.Size(85, 34);
            this.CopyRadioButton.TabIndex = 1;
            this.CopyRadioButton.TabStop = true;
            this.CopyRadioButton.Text = "Copy";
            this.CopyRadioButton.UseVisualStyleBackColor = true;
            // 
            // AlphabetSplitCheckbox
            // 
            this.AlphabetSplitCheckbox.AutoSize = true;
            this.AlphabetSplitCheckbox.Location = new System.Drawing.Point(6, 34);
            this.AlphabetSplitCheckbox.Name = "AlphabetSplitCheckbox";
            this.AlphabetSplitCheckbox.Size = new System.Drawing.Size(244, 34);
            this.AlphabetSplitCheckbox.TabIndex = 0;
            this.AlphabetSplitCheckbox.Text = "Split into letter folders";
            this.AlphabetSplitCheckbox.UseVisualStyleBackColor = true;
            // 
            // CopyButton
            // 
            this.CopyButton.Enabled = false;
            this.CopyButton.Location = new System.Drawing.Point(463, 915);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(131, 40);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(19, 915);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(131, 40);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 975);
            this.Controls.Add(this.OutputOptionsGroupBox);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.OutputFolderLabel);
            this.Controls.Add(this.RomsetFolderLabel);
            this.Controls.Add(this.OutputFolderTextbox);
            this.Controls.Add(this.RomsetFolderPathTextbox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.OutputFolderBrowseButton);
            this.Controls.Add(this.RomsetFolderBrowseButton);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Romset Filter App";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.FlagsGroupbox.ResumeLayout(false);
            this.FlagsGroupbox.PerformLayout();
            this.RegionsGroupBox.ResumeLayout(false);
            this.RegionsGroupBox.PerformLayout();
            this.OutputOptionsGroupBox.ResumeLayout(false);
            this.OutputOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button RomsetFolderBrowseButton;
        private TextBox RomsetFolderPathTextbox;
        private Label RomsetFolderLabel;
        private GroupBox FilterGroupBox;
        private GroupBox RegionsGroupBox;
        private CheckBox AsiaCheckbox;
        private CheckBox JapanCheckbox;
        private CheckBox EuropeCheckbox;
        private CheckBox USACheckbox;
        private CheckBox WorldCheckbox;
        private CheckBox SwedenCheckbox;
        private CheckBox SpainCheckbox;
        private CheckBox NetherlandsCheckbox;
        private CheckBox KoreaCheckbox;
        private CheckBox ItalyCheckbox;
        private CheckBox HongKongCheckbox;
        private CheckBox GermanyCheckbox;
        private CheckBox FranceCheckbox;
        private CheckBox ChinaCheckbox;
        private CheckBox CanadaCheckbox;
        private CheckBox BrazilCheckbox;
        private CheckBox AustraliaCheckbox;
        private GroupBox FlagsGroupbox;
        private CheckBox BiosCheckbox;
        private CheckBox MultiRegionCheckbox;
        private CheckBox SampleCheckbox;
        private CheckBox BetaCheckbox;
        private CheckBox PrototypeCheckbox;
        private CheckBox DemoCheckbox;
        private CheckBox UnlicensedCheckbox;
        private CheckBox PhaserCheckbox;
        private ComboBox RevisionSelectionCombobox;
        private Label RevisionLabel;
        private Button OutputFolderBrowseButton;
        private TextBox OutputFolderTextbox;
        private Label OutputFolderLabel;
        private GroupBox OutputOptionsGroupBox;
        private Button CopyButton;
        private Button ExitButton;
        private RadioButton MoveRadioButton;
        private RadioButton CopyRadioButton;
        private CheckBox AlphabetSplitCheckbox;
        private CheckBox NoFlagCheckbox;
        private Button FlagsSelectAllButton;
        private Button RegionsSelectAllButton;
        private Button DeselectAllFlagsButton;
        private Button DeselectAllRegionsButton;
        private CheckBox OtherRegionsCheckbox;
    }
}