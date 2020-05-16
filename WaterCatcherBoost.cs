using System;
using System.Collections.Generic;
using Oxide.Core;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("Water Catcher Boost", "Substrata", "1.0.1")]
    [Description("Boosts the collection rate of water catchers")]

    class WaterCatcherBoost : RustPlugin
    {
        private HashSet<WaterCatcher> wCatchers = new HashSet<WaterCatcher>();

        private void Init()
        {
            LoadVariables();
        }

        private void OnServerInitialized()
        {
            var rnd = new System.Random();

            int lMin = configData.LargeCatchers.MinBoost;
            int lMax = configData.LargeCatchers.MaxBoost;
            int sMin = configData.SmallCatchers.MinBoost;
            int sMax = configData.SmallCatchers.MaxBoost;

            if (lMin > lMax || sMin > sMax)
            {
                if (lMin > lMax) lMin = lMax;
                if (sMin > sMax) sMin = sMax;
                PrintWarning("Warning! Maximum values must be greater than or equal to minimum values.\nSee the documentation for more info.");
            }

            foreach (var wCatcher in UnityEngine.Object.FindObjectsOfType<WaterCatcher>())
            {
                if (wCatcher != null) wCatchers.Add(wCatcher);
            }

            timer.Every(60f, () =>
            {
                if (wCatchers == null || wCatchers.Count == 0) return;
                foreach (var wCatcher in wCatchers)
                {
                    if (wCatcher != null && !wCatcher.IsFull())
                    {
                        if (wCatcher.ShortPrefabName == "water_catcher_large")
                        {
                            int lrg;
                            if (lMin == lMax) lrg = lMin;
                            else lrg = rnd.Next(lMin, lMax + 1);

                            if (lrg >= 1){
                                ItemManager.CreateByName("water", lrg)?.MoveToContainer(wCatcher.inventory);
                            }
                        }
                        if (wCatcher.ShortPrefabName.Contains("water_catcher_small"))
                        {
                            int sml;
                            if (sMin == sMax) sml = sMin;
                            else sml = rnd.Next(sMin, sMax + 1);

                            if (sml >= 1){
                                ItemManager.CreateByName("water", sml)?.MoveToContainer(wCatcher.inventory);
                            }
                        }
                    }
                }
            });
        }

        void OnEntitySpawned(WaterCatcher wCatcher)
        {
            if (wCatcher != null && !wCatchers.Contains(wCatcher)) wCatchers.Add(wCatcher);
        }

        void OnEntityKill(WaterCatcher wCatcher)
        {
            if (wCatcher != null && wCatchers.Contains(wCatcher)) wCatchers.Remove(wCatcher);
        }

        #region Config
        private ConfigData configData;

        class ConfigData
        {
            [JsonProperty(PropertyName = "Large Water Catchers")]
            public LargeCatchers LargeCatchers { get; set; }
            [JsonProperty(PropertyName = "Small Water Catchers")]
            public SmallCatchers SmallCatchers { get; set; }
        }

        class LargeCatchers
        {
            [JsonProperty(PropertyName = "Minimum Boost (per minute)")]
            public int MinBoost { get; set; }
            [JsonProperty(PropertyName = "Maximum Boost (per minute)")]
            public int MaxBoost { get; set; }
        }

        class SmallCatchers
        {
            [JsonProperty(PropertyName = "Minimum Boost (per minute)")]
            public int MinBoost { get; set; }
            [JsonProperty(PropertyName = "Maximum Boost (per minute)")]
            public int MaxBoost { get; set; }
        }

        private void LoadVariables()
        {
            LoadConfigVariables();
            SaveConfig();
        }

        protected override void LoadDefaultConfig()
        {
            var config = new ConfigData
            {
                LargeCatchers = new LargeCatchers
                {
                    MinBoost = 0,
                    MaxBoost = 60
                },
                SmallCatchers = new SmallCatchers
                {
                    MinBoost = 0,
                    MaxBoost = 20
                }
            };
            SaveConfig(config);
        }

        private void LoadConfigVariables() => configData = Config.ReadObject<ConfigData>();

        private void SaveConfig(ConfigData config) => Config.WriteObject(config, true);
        #endregion
    }
}