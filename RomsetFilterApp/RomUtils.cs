using System.Text.RegularExpressions;

namespace RomsetFilterApp
{
    public enum FlagType { None, Bios, Title, Region, Language, Revision, Version, DevStatus, Additional, Special, License, Status }

    public enum RegionCode
    {
        None, World, Europe, Asia, Australia, Brazil, Canada, China, France,
        Germany, HongKong, Italy, Japan, Korea, Netherlands, Spain, Sweden, USA
    }

    public static class NameDataDictionary
    {
        public static string? GetValue<FlagType>(this Dictionary<FlagType, string> dictionary, FlagType key) where FlagType : notnull
            => dictionary.TryGetValue(key, out string? value) ? value : null;
    }

    public class Rom
    {
        public static readonly Dictionary<RegionCode, string> MultiRegionNames = new() {
            { RegionCode.Europe,    "Europe" },
            { RegionCode.Asia,      "Asia" },
            { RegionCode.World,     "World" }
        };

        public static readonly Dictionary<RegionCode, string> RegionNames = new() {
            { RegionCode.Australia,     "Australia" },
            { RegionCode.Brazil,        "Brazil" },
            { RegionCode.Canada,        "Canada" },
            { RegionCode.China,         "China" },
            { RegionCode.France,        "France" },
            { RegionCode.Germany,       "Germany" },
            { RegionCode.HongKong,      "Hong Kong" },
            { RegionCode.Italy,         "Italy" },
            { RegionCode.Japan,         "Japan" },
            { RegionCode.Korea,         "Korea" },
            { RegionCode.Netherlands,   "Netherlands" },
            { RegionCode.Spain,         "Spain" },
            { RegionCode.Sweden,        "Sweden" },
            { RegionCode.USA,           "USA" }
        };

        public static readonly List<string> LanguageCodes = new()
        {
            "ab","aa","af","ak","sq","am","ar","an","hy","as","av","ae","ay","az","bm","ba","eu","be","bn","bi","bs","br","bg",
            "my","ca","ch","ce","ny","zh","cu","cv","kw","co","cr","hr","cs","da","dv","nl","dz","en","eo","et","ee","fo","fj",
            "fi","fr","fy","ff","gd","gl","lg","ka","de","el","kl","gn","gu","ht","ha","he","hz","hi","ho","hu","is","io","ig",
            "id","ia","ie","iu","ik","ga","it","ja","jv","kn","kr","ks","kk","km","ki","rw","ky","kv","kg","ko","kj","ku","lo",
            "la","lv","li","ln","lt","lu","lb","mk","mg","ms","ml","mt","gv","mi","mr","mh","mn","na","nv","nd","nr","ng","ne",
            "no","nb","nn","ii","oc","oj","or","om","os","pi","ps","fa","pl","pt","pa","qu","ro","rm","rn","ru","se","sm","sg",
            "sa","sc","sr","sn","sd","si","sk","sl","so","st","es","su","sw","ss","sv","tl","ty","tg","ta","tt","te","th","bo",
            "ti","to","ts","tn","tr","tk","tw","ug","uk","ur","uz","ve","vi","vo","wa","cy","wo","xh","yi","yo","za","zu",
        };

        public List<RegionCode> Regions { get; set; } = new();

        public float VersionNumber { get; set; } = 1;

        public bool IsUnlicensed { get; set; } = false;
        public bool IsDemo { get; set; } = false;
        public bool IsPrototype { get; set; } = false;
        public bool IsBeta { get; set; } = false;
        public bool IsSample { get; set; } = false;
        public bool IsMultiRegion { get; set; } = false;
        public bool IsBIOS { get; set; } = false;
        public bool IsPhaser { get; set; } = false;
        public bool NoFlag { get; set; } = false;

        public bool VersionSkip { get; set; } = false;

        public string Name { get; set; } = "";
        public string Title { get; set; } = "";
        public string FilePath { get; set; } = "";

        public Dictionary<FlagType, string> NameData { get; set; } = new();

        public Rom(string filePath)
        {
            Name = Path.GetFileName(filePath); ;
            FilePath = filePath;

            ExtractNameData();

            ExtractVersionNumber();
            ExtractRegions();
            ExtractFlags();
        }

        #region Name Data Parsing
        private void ExtractNameData()
        {
            // Load all the data from the name into a list
            var nameDataStrings = Regex.Matches(Name, @"[(](?<=\()[^()]*(?=\))[)]|[[](?<=\[)[^()]*(?=\])[]]", RegexOptions.IgnoreCase).Cast<Match>().Select(match => match.Value).ToList();
            string title = Path.GetFileNameWithoutExtension(Name);

            foreach (var data in nameDataStrings)
            {
                title = title.Replace(data, "");
                var type = GetNameDataType(data);
                if (!NameData.ContainsKey(type))
                {
                    NameData.Add(GetNameDataType(data), data);
                }
            }

            title = title.Trim();
            NameData.Add(GetNameDataType(title), title);
            Title = title;
        }

        private void ExtractFlags()
        {
            var devStatuses = NameData.Where(x => x.Key == FlagType.DevStatus).Select(x => x.Value).ToList();
            var additional = NameData.Where(x => x.Key == FlagType.Additional).Select(x => x.Value).ToList();

            // Setup our flags
            IsUnlicensed = NameData.GetValue(FlagType.Language) != null;
            IsBIOS = NameData.GetValue(FlagType.Bios) != null;

            IsDemo = devStatuses.Where(x => x.ToLower().Contains("demo")).Any();
            IsPrototype = devStatuses.Where(x => x.ToLower().Contains("proto")).Any();
            IsBeta = devStatuses.Where(x => x.ToLower().Contains("beta")).Any();
            IsSample = devStatuses.Where(x => x.ToLower().Contains("sample")).Any();
            IsPhaser = additional.Where(x => x.ToLower().Contains("phaser")).Any();

            IsMultiRegion = Regions.Count > 1;

            if (!IsUnlicensed && !IsDemo && !IsPrototype && !IsBeta && !IsSample && !IsBIOS && !IsPhaser)
            {
                NoFlag = true;
            }
        }

        private void ExtractVersionNumber()
        {

            // Find out revision number and set it
            var revisionString = NameData.GetValue(FlagType.Revision);
            if (!string.IsNullOrEmpty(revisionString))
            {
                _ = float.TryParse($"{VersionNumber}.{GetRevisionNumber(revisionString)}", out float combinedVersion);
                VersionNumber = combinedVersion;
            }

            // Revision numbers can also be in the form of a float
            var versionString = NameData.GetValue(FlagType.Version);
            if (!string.IsNullOrEmpty(versionString))
            {
                _ = float.TryParse(versionString.Replace("v", ""), out float versionFloat);
                VersionNumber = versionFloat;
            }
        }

        private void ExtractRegions()
        {
            // Region sorting
            var regionNameData = NameData.Where(x => x.Key == FlagType.Region).Select(x => x.Value).FirstOrDefault();
            if (regionNameData != null)
            {
                IsMultiRegion = MultiRegionNames.Values.Any(s => regionNameData.Contains(s));

                var allRegions = RegionNames.Concat(MultiRegionNames).ToDictionary(r => r.Key, r => r.Value);
                var regions = regionNameData.Replace("(", "").Replace(")", "").Split(",");
                Regions.AddRange(from region in regions
                                 let regionMatch = allRegions.Where(r => r.Value == region.Trim()).Select(r => r.Key).FirstOrDefault(RegionCode.None)
                                 where !Regions.Contains(regionMatch)
                                 select regionMatch);
            }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Unl:{Convert.ToInt32(IsUnlicensed)}," +
                $"Dem:{Convert.ToInt32(IsDemo)}," +
                $"Pro:{Convert.ToInt32(IsPrototype)}," +
                $"Bet:{Convert.ToInt32(IsBeta)}," +
                $"Sam:{Convert.ToInt32(IsSample)}," +
                $"Mul:{Convert.ToInt32(IsMultiRegion)}," +
                $"BIO:{Convert.ToInt32(IsBIOS)}," +
                $"Pha:{Convert.ToInt32(IsPhaser)}," +
                $"Ver:{VersionNumber}. " +
                $"NameData:{string.Join(",", NameData)}, filename:{Name}";
        }
        #endregion

        #region Name Data Processing
        private static FlagType GetNameDataType(string data)
        {

            if (data.ToLower().Equals("(unl)", StringComparison.OrdinalIgnoreCase))
            {
                return FlagType.License;
            }
            else if (data.ToLower().Equals("[bios]", StringComparison.OrdinalIgnoreCase))
            {
                return FlagType.Bios;
            }
            else if (data.ToLower().StartsWith("(proto", StringComparison.OrdinalIgnoreCase) ||
                data.ToLower().StartsWith("(beta", StringComparison.OrdinalIgnoreCase) ||
                data.ToLower().StartsWith("(sample", StringComparison.OrdinalIgnoreCase) ||
                data.ToLower().StartsWith("(demo", StringComparison.OrdinalIgnoreCase)
                )
            {
                return FlagType.DevStatus;
            }
            else if (Regex.Match(data, @"\(rev *[a-z1-9]\d*\)", RegexOptions.IgnoreCase).Success)
            {
                return FlagType.Revision;
            }
            else if (Regex.Match(data, @"^[(][v] *[1-9]\d*\.[1-9]\d*[)]", RegexOptions.IgnoreCase).Success)
            {
                return FlagType.Version;
            }
            else if (data.Contains('(') && data.Contains(')') && RegionNames.Concat(MultiRegionNames).ToDictionary(r => r.Key, r => r.Value).Values.Any(x => data.Contains(x)))
            {
                return FlagType.Region;
            }
            else if (!data.StartsWith("(") && !data.StartsWith("["))
            {
                return FlagType.Title;
            }

            return FlagType.None;
        }

        public static int GetRevisionNumber(string revisionString)
        {
            bool letterRevision = Regex.Match(revisionString, @"\(rev *[a-z]*\)", RegexOptions.IgnoreCase).Success;

            var noBracketsRevision = revisionString.Replace("(",string.Empty).Replace(")",string.Empty);

            if (letterRevision)
            {
                return char.ToUpper(noBracketsRevision[noBracketsRevision.Length-1]) - 64;
            }

            var stack = new Stack<char>();

            for (var i = noBracketsRevision.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(noBracketsRevision[i]))
                {
                    break;
                }

                stack.Push(noBracketsRevision[i]);
            }

            _ = int.TryParse(new string(stack.ToArray()), out int result);
            return result;
        }

        public static bool MatchRom(Rom rom, RomFilter filter)
        {
            var isRegionMatch = rom.Regions.Where(x => filter.Regions.Contains(x)).Any();

            var isFlagMatch = (filter.MultiRegion && rom.IsMultiRegion) ||
                (filter.Phaser && rom.IsPhaser) ||
                (filter.Bios && rom.IsBIOS) ||
                (filter.Sample && rom.IsSample) ||
                (filter.Beta && rom.IsBeta) ||
                (filter.Prototype && rom.IsPrototype) ||
                (filter.Demo && rom.IsDemo) ||
                (filter.Unlicensed && rom.IsUnlicensed) ||
                (filter.NoFlag && rom.NoFlag);

            return isRegionMatch && isFlagMatch;
        }
        #endregion

        #region File Operations
        public static void StartOperation(List<Rom> copyRoms, string outputFolder, bool move, bool alphabetSplit)
        {
            // Duck out for no alphabet split
            if (!alphabetSplit)
            {
                TransferRoms(copyRoms, move, outputFolder);
                return;
            }

            // Grab our letters and start making folders
            var letters = copyRoms.Select(x => x.Title[..1]).Distinct().ToList();

            foreach (var letter in letters)
            {
                if (letter == null)
                {
                    continue;
                }

                // We need to make sure that number are all put into the same folder
                var letterFolder = letter;
                if (int.TryParse(letter, out _))
                {
                    letterFolder = "#";
                }

                // Create our path if it doesn't already exist
                var letterPath = $"{outputFolder}/{letterFolder}";
                if (!Directory.Exists(letterPath))
                {
                    Directory.CreateDirectory(letterPath);
                }

                // Copy only the roms for this letter
                var letterRoms = copyRoms.Where(x => x.Title.StartsWith(letter)).ToList();

                TransferRoms(letterRoms, move, letterPath);
            }
        }

        public static void TransferRoms(List<Rom> copyRoms, bool move, string path)
        {
            foreach (var rom in copyRoms)
            {
                // Duck out for not needed version
                if (rom.VersionSkip) continue;

                if (move)
                {
                    File.Move(rom.FilePath, $"{path}\\{rom.Name}", true);
                }
                else
                {
                    File.Copy(rom.FilePath, $"{path}\\{rom.Name}", true);
                }
            }
        }
        #endregion

    }

    public class RomFilter
    {
        // Enums
        public enum RevisionSelectionMode { None, Latest, Earliest, All }
        public RevisionSelectionMode RevisionSelection { get; set; }

        // Flags
        public bool Phaser { get; set; }
        public bool Bios { get; set; }
        public bool MultiRegion { get; set; }
        public bool Sample { get; set; }
        public bool Beta { get; set; }
        public bool Prototype { get; set; }
        public bool Demo { get; set; }
        public bool Unlicensed { get; set; }
        public bool NoFlag { get; set; }

        // Regions
        public List<RegionCode> Regions { get; set; } = new List<RegionCode>();

        public static void SetRomVersionSkips(List<Rom> copyRoms, RevisionSelectionMode mode)
        {
            if (mode == RevisionSelectionMode.All)
            {
                return;
            }

            var duplicates = copyRoms.GroupBy(x => x.Title + string.Join("|", x.NameData.Where(x => (!x.Key.Equals(FlagType.Revision) && !x.Key.Equals(FlagType.Version))).ToArray()), x => x).Where(g => g.Count() > 1);

            foreach (var group in duplicates)
            {
                // Store the version so we can tell which one is the latest or earliest
                float storedVersion = mode == RevisionSelectionMode.Latest ? 0 : float.MaxValue;
                foreach (var rom in group)
                {
                    // Set our stored version based on selection mode
                    if ((rom.VersionNumber > storedVersion && mode == RevisionSelectionMode.Latest) ||
                        (rom.VersionNumber < storedVersion && mode == RevisionSelectionMode.Earliest))
                    {
                        storedVersion = rom.VersionNumber;
                    }
                }

                // Iterate through all roms in the group again to set their skip now that we know the 
                foreach (var rom in group)
                {
                    rom.VersionSkip = !(rom.VersionNumber == storedVersion);
                }

            }
        }
    }
}
