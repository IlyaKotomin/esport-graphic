using DuckGame;

namespace EsportGraphics.src.Config
{
    internal class SettingsData : DataClass
    {
        public SettingsData()
        {
            _nodeName = "SettingsData";
            Name = "Esport Duck";
            BulletColorChanger = true;
            DoorColorChanger = true;
            BlockColorChanger = true; 
            BackgroundColorChanger = true;
            SpikesColorChanger = true;
            AmmoCounter = true;
            AmmoCounterOffsetX = 0f;
            AmmoCounterOffsetY = 0f;
            AmmoCounterScaleX = 0f;
            AmmoCounterScaleY = 0f;
            DucksHitboxes = true;
        }
        public string Name { get; set; }
        #region Color Changers
        public bool BulletColorChanger { get; set; }
        public bool DoorColorChanger { get; set; }
        public bool BlockColorChanger { get; set; }
        public bool BackgroundColorChanger { get; set; }
        public bool SpikesColorChanger { get; set; }
        #endregion
        #region Ammo Counter
        public bool AmmoCounter { get; set; }
        public float AmmoCounterOffsetX { get; set; }
        public float AmmoCounterOffsetY { get; set; }
        public float AmmoCounterScaleX { get; set; }
        public float AmmoCounterScaleY { get; set; }
        #endregion 
        public bool DucksHitboxes { get; set; }
    }
}
