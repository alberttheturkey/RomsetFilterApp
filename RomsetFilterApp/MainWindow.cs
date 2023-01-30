namespace RomsetFilterApp
{
    public partial class MainWindow : Form
    {
        private readonly FolderBrowserDialog dialog = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            RevisionSelectionCombobox.SelectedIndex = 0;
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
            var filter = new RomFilter
            {
                Asia = AsiaCheckbox.Checked,
                Australia = AustraliaCheckbox.Checked,
                Brazil = BrazilCheckbox.Checked,
                Canada = CanadaCheckbox.Checked,
                China = ChinaCheckbox.Checked,
                Europe = EuropeCheckbox.Checked,
                France = FranceCheckbox.Checked,
                Germany = GermanyCheckbox.Checked,
                HongKong = HongKongCheckbox.Checked,
                Italy = ItalyCheckbox.Checked,
                Japan = JapanCheckbox.Checked,
                Korea = KoreaCheckbox.Checked,
                Netherlands = NetherlandsCheckbox.Checked,
                NoRegion = NoRegionCheckbox.Checked,
                Spain = SpainCheckbox.Checked,
                Sweden = SwedenCheckbox.Checked,
                USA = USACheckbox.Checked,
                World = WorldCheckbox.Checked,

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

            foreach(var rom in copyRoms)
            {
                if (MoveRadioButton.Checked)
                {
                    File.Move(rom.FilePath, $"{OutputFolderTextbox.Text}\\{rom.Name}", true);
                }
                else
                {
                    File.Copy(rom.FilePath, $"{OutputFolderTextbox.Text}\\{rom.Name}", true);
                }
            }
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

        private void SetAllRegions(bool check)
        {
            AsiaCheckbox.Checked = check;
            AustraliaCheckbox.Checked = check;
            BrazilCheckbox.Checked = check;
            CanadaCheckbox.Checked = check;
            ChinaCheckbox.Checked = check;
            EuropeCheckbox.Checked = check;
            FranceCheckbox.Checked = check;
            GermanyCheckbox.Checked = check;
            HongKongCheckbox.Checked = check;
            ItalyCheckbox.Checked = check;
            JapanCheckbox.Checked = check;
            KoreaCheckbox.Checked = check;
            NetherlandsCheckbox.Checked = check;
            NoRegionCheckbox.Checked = check;
            SpainCheckbox.Checked = check;
            SwedenCheckbox.Checked = check;
            USACheckbox.Checked = check;
            WorldCheckbox.Checked = check;
        }

        private void SetAllFlags(bool check)
        {
            SampleCheckbox.Checked = check;
            UnlicensedCheckbox.Checked = check;
            BetaCheckbox.Checked = check;
            BiosCheckbox.Checked = check;
            DemoCheckbox.Checked = check;
            NoFlagCheckbox.Checked = check;
            MultiRegionCheckbox.Checked = check;
            PhaserCheckbox.Checked = check;
            PrototypeCheckbox.Checked = check;
        }

    }
}