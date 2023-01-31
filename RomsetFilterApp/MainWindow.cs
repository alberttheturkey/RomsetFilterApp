using System.Reflection;

namespace RomsetFilterApp
{
    public partial class MainWindow : Form
    {
        private readonly FolderBrowserDialog dialog = new();

        public MainWindow()
        {

            InitializeComponent();
        }

        #region Event Handlers
        private void MainWindow_Load(object sender, EventArgs e)
        {
            RevisionSelectionCombobox.SelectedIndex = 0;
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                Text = $"Romset Filter App v{version.ToString(2)}";
            }
        }

        private void RomsetFolderBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(RomsetFolderPathTextbox);
        }
        private void OutputFolderBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(OutputFolderTextbox);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            CopyButton.Enabled = false;

            var romsetFolder = RomsetFolderPathTextbox.Text;
            if (romsetFolder.EndsWith("\\"))
            {
                romsetFolder = romsetFolder[..^1];
            }

            var outputFolder = OutputFolderTextbox.Text;
            if (outputFolder.EndsWith("\\"))
            {
                outputFolder = outputFolder[..^1];
            }

            // Check to see if our folder exist
            if(!Directory.Exists(romsetFolder))
            {
                MessageBox.Show("This Romset folder doesn't exist");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                if (MessageBox.Show("Output folder doesn't exist, Create it?", "Create output folder", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                Directory.CreateDirectory(outputFolder);
            }

            // Get our filter from the user interface
            var filter = new RomFilter
            {
                Beta = BetaCheckbox.Checked,
                Bios = BiosCheckbox.Checked,
                Demo = DemoCheckbox.Checked,
                NoFlag = NoFlagCheckbox.Checked,
                MultiRegion = MultiRegionCheckbox.Checked,
                Phaser = PhaserCheckbox.Checked,
                Prototype = PrototypeCheckbox.Checked,
                RevisionSelection = RevisionSelectionCombobox.SelectedIndex switch
                {
                    0 => RomFilter.RevisionSelectionMode.Latest,
                    1 => RomFilter.RevisionSelectionMode.Earliest,
                    _ => RomFilter.RevisionSelectionMode.All,
                },
                Sample = SampleCheckbox.Checked,
                Unlicensed = UnlicensedCheckbox.Checked
            };

            AddFilterRegionList(filter);

            // Get the rom files and figure out which ones to copy
            var romsFiles = Directory.GetFiles(RomsetFolderPathTextbox.Text);
            var roms = new List<Rom>();

            foreach (var romsFile in romsFiles)
            {
                roms.Add(new Rom(romsFile));
            }

            var copyRoms = new List<Rom>();

            foreach (var rom in roms)
            {
                if (Rom.MatchRom(rom, filter))
                {
                    copyRoms.Add(rom);
                }
            }

            RomFilter.SetRomVersionSkips(copyRoms, filter.RevisionSelection);

            // Start our move or copy operations
            Rom.StartOperation(copyRoms, outputFolder, MoveRadioButton.Checked, AlphabetSplitCheckbox.Checked);

            MessageBox.Show($"{(MoveRadioButton.Checked ? "Move": "Copy")} operation complete. {(MoveRadioButton.Checked ? "Moved" : "Copied")} {copyRoms.Count} rom{(copyRoms.Count == 1 ? "" : "s")}");
            CopyButton.Enabled = true;
        }

        private void FolderTextbox_TextChanged(object sender, EventArgs e)
        {
            CopyButton.Enabled = Directory.Exists(OutputFolderTextbox.Text) && Directory.Exists(RomsetFolderPathTextbox.Text);
        }

        private void FlagsSelectAllButton_Click(object sender, EventArgs e)
        {
            SetAllFlags(true);
        }

        private void RegionsSelectAllButton_Click(object sender, EventArgs e)
        {
            SetAllRegions(true);
        }

        private void DeselectAllFlagsButton_Click(object sender, EventArgs e)
        {
            SetAllFlags(false);
        }

        private void DeselectAllRegionsButton_Click(object sender, EventArgs e)
        {
            SetAllRegions(false);
        }
        #endregion

        #region Interface Methods
        private void AddFilterRegionList(RomFilter filter)
        {
            if (AsiaCheckbox.Checked)           filter.Regions.Add(RegionCode.Asia);
            if (AustraliaCheckbox.Checked)      filter.Regions.Add(RegionCode.Australia);
            if (BrazilCheckbox.Checked)         filter.Regions.Add(RegionCode.Brazil);            
            if (CanadaCheckbox.Checked)         filter.Regions.Add(RegionCode.Canada);            
            if (ChinaCheckbox.Checked)          filter.Regions.Add(RegionCode.China);            
            if (EuropeCheckbox.Checked)         filter.Regions.Add(RegionCode.Europe);            
            if (FranceCheckbox.Checked)         filter.Regions.Add(RegionCode.France);            
            if (GermanyCheckbox.Checked)        filter.Regions.Add(RegionCode.Germany);            
            if (HongKongCheckbox.Checked)       filter.Regions.Add(RegionCode.HongKong);            
            if (ItalyCheckbox.Checked)          filter.Regions.Add(RegionCode.Italy);            
            if (JapanCheckbox.Checked)          filter.Regions.Add(RegionCode.Japan);            
            if (KoreaCheckbox.Checked)          filter.Regions.Add(RegionCode.Korea);            
            if (NetherlandsCheckbox.Checked)    filter.Regions.Add(RegionCode.Netherlands);            
            if (SpainCheckbox.Checked)          filter.Regions.Add(RegionCode.Spain);            
            if (USACheckbox.Checked)            filter.Regions.Add(RegionCode.USA);            
            if (WorldCheckbox.Checked)          filter.Regions.Add(RegionCode.World);            
        }                                                          

        private void OpenFolderDialog(TextBox textbox)
        {
            if (!string.IsNullOrEmpty(textbox.Text))
            {
                dialog.SelectedPath = textbox.Text;
            }
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textbox.Text = dialog.SelectedPath;
            }
        }

        private void SetAllRegions(bool check)
        {
            foreach(CheckBox checkbox in RegionsGroupBox.Controls.OfType<CheckBox>())
                checkbox.Checked = check;
        }

        private void SetAllFlags(bool check)
        {
            foreach (CheckBox checkbox in FlagsGroupbox.Controls.OfType<CheckBox>())
                checkbox.Checked = check;
        }
        #endregion

    }
}