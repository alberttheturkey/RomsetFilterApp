using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomsetFilterApp
{
    public class Rom : IComparable<Rom>
    {
        public static Dictionary<Region, string> MultiRegionNames = new() {
            { Region.Europe,"Europe" },
            { Region.Asia,"Asia" },
            { Region.World,"World" }
        };

        public static Dictionary<Region, string> RegionNames = new() {
            { Region.Australia,"Australia" },
            { Region.Brazil,"Brazil" },
            { Region.Canada,"Canada" },
            { Region.China,"China" },
            { Region.France,"France" },
            { Region.Germany,"Germany" },
            { Region.HongKong,"Hong Kong" },
            { Region.Italy,"Italy" },
            { Region.Japan,"Japan" },
            { Region.Korea,"Korea" },
            { Region.Netherlands,"Netherlands" },
            { Region.Spain,"Spain" },
            { Region.Sweden,"Sweden" },
            { Region.USA,"USA" }
        };

        public static List<string> LanguageCodes = new()
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

        public enum Region { None, World, Europe, Asia, Australia, Brazil, Canada, China, France, Germany, HongKong,
            Italy, Japan, Korea, Netherlands, Spain, Sweden, USA }

        public List<Region> Regions { get; set; }

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

        public string Name { get; set; }
        public string FilePath { get; set; }

        public List<string> NameData { get; set; } = new List<string>();

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

        public Rom(string filePath)
        {
            Name = Path.GetFileName(filePath); ;
            FilePath = filePath;
            Regions = new List<Region>();

            // Load all the data from the name into a list
            NameData = Regex.Matches(Name, @"(?<=\()[^()]*(?=\))|(?<=\[)[^()]*(?=\])").Cast<Match>().Select(match => match.Value).ToList();

            // Find out revision number and set it
            var revisionString = NameData.Where(x => x.Contains("Rev", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (!string.IsNullOrEmpty(revisionString))
            {
                _ = float.TryParse($"{VersionNumber}.{GetRevisionNumber(revisionString)}", out float combinedVersion);
                VersionNumber = combinedVersion;
            }

            // Revision numbers can also be in the form of a float
            var versionString = NameData.Where(x => Regex.IsMatch(x, @"^[v][1-9]\d*\.[1-9]\d*")).FirstOrDefault();
            if (!string.IsNullOrEmpty(versionString))
            {
                _ = float.TryParse(versionString.Replace("v", ""), out float versionFloat);
                VersionNumber = versionFloat;
            }

            var allRegions = RegionNames.Concat(MultiRegionNames).ToDictionary(r => r.Key, r => r.Value);
            var allRegionsValues = allRegions.Values;

            // Region sorting
            var regionNameData = NameData.Where(x => allRegionsValues.Any(s => x.Contains(s))).FirstOrDefault();

            // Region matching
            if (!string.IsNullOrEmpty(regionNameData))
            {
                IsMultiRegion = MultiRegionNames.Values.Any(s => regionNameData.Contains(s));

                var regions = regionNameData.Split(",");
                Regions.AddRange(from region in regions
                                 let regionMatch = allRegions.Where(r => r.Value == region.Trim()).Select(r => r.Key).FirstOrDefault(Region.None)
                                 where !Regions.Contains(regionMatch)
                                 select regionMatch);
            }

            // Setup our flags
            IsUnlicensed = NameData.Where(x => x.Contains("unl", StringComparison.OrdinalIgnoreCase)).Any();
            IsDemo = NameData.Where(x => x.Contains("demo", StringComparison.OrdinalIgnoreCase)).Any();
            IsPrototype = NameData.Where(x => x.Contains("proto", StringComparison.OrdinalIgnoreCase)).Any();
            IsBeta = NameData.Where(x => x.Contains("beta", StringComparison.OrdinalIgnoreCase)).Any();
            IsSample = NameData.Where(x => x.Contains("sample", StringComparison.OrdinalIgnoreCase)).Any();
            IsBIOS = NameData.Where(x => x.Contains("bios", StringComparison.OrdinalIgnoreCase)).Any();
            IsPhaser = NameData.Where(x => x.Contains("phaser", StringComparison.OrdinalIgnoreCase)).Any();
            IsMultiRegion = Regions.Count > 1;

            if (!IsUnlicensed && !IsDemo && !IsPrototype && !IsBeta && !IsSample && !IsBIOS && !IsPhaser)
            {
                NoFlag = true;
            }
        }

        public static int GetRevisionNumber(string revisionString)
        {
            var stack = new Stack<char>();

            for (var i = revisionString.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(revisionString[i]))
                {
                    break;
                }

                stack.Push(revisionString[i]);
            }

            _ = int.TryParse(new string(stack.ToArray()), out int result);
            return result;
        }

        public static bool MatchRom(Rom rom, RomFilter filter)
        {
            return (
                (filter.Phaser && rom.IsPhaser) ||
                (filter.Bios && rom.IsBIOS) ||
                (filter.Sample && rom.IsSample) ||
                (filter.Beta && rom.IsBeta) ||
                (filter.Prototype && rom.IsPrototype) ||
                (filter.Demo && rom.IsDemo) ||
                (filter.Unlicensed && rom.IsUnlicensed) ||
                (filter.NoFlag && rom.NoFlag)
                );
        }

        public int CompareTo(Rom? other)
        {
            throw new NotImplementedException();
        }
    }

    public class RomFilter
    {
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
        public bool NoRegion { get; set; }
        public bool Sweden { get; set; }
        public bool Spain { get; set; }
        public bool Netherlands { get; set; }
        public bool Korea { get; set; }
        public bool Italy { get; set; }
        public bool HongKong { get; set; }
        public bool Germany { get; set; }
        public bool France { get; set; }
        public bool China { get; set; }
        public bool Canada { get; set; }
        public bool Brazil { get; set; }
        public bool Australia { get; set; }
        public bool Asia { get; set; }
        public bool Japan { get; set; }
        public bool Europe { get; set; }
        public bool USA { get; set; }
        public bool World { get; set; }

    }
}
