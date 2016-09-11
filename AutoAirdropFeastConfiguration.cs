using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Rocket.API;

namespace AutoAirdrop
{
    class AutoAirdropFeastConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public int MinDropTime;
        public int MaxDropTime;
        public byte DropRadius;
        public byte MinItemsDrop;
        public byte MaxItemsDrop;
        public bool SkyDrop;
        public ushort PlaneEffectId;
        public ushort SkydropEffectId;
        public string MessageColor;
        public List<FeastItem> Items;

        public void LoadDefaults()
        { 
            Enabled = true;
		    MinDropTime = 600;
		    MaxDropTime = 1200;
		    DropRadius = 20;
		    MinItemsDrop = 10;
		    MaxItemsDrop = 25;
            SkyDrop = false;
            PlaneEffectId = 1001;
            SkydropEffectId = 1006;
            MessageColor = "red";
            Items = new List<FeastItem>
		    {
			    new FeastItem(66, "Cloth", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(43, "Military Ammunition Box", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(44, "Civilian Ammunition Box", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(13, "Canned Beans", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(14, "Bottled Water", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(10, "Police Vest", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(251, "White Travelpack", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(223, "Police Top", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(224, "Police Bottom", 10, new List<string>
			    {
				    "all"
			    }),
			    new FeastItem(366, "Maple Crate", 10, new List<string>
			    {
				    "all"
			    })
		    };
        }
	}
}
