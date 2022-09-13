using static EsportGraphics.src.Config.ESOptions;

namespace EsportGraphics.src.EGraphics
{
    public static class ESSettings
    {
        public static string Name = _settingsData.Name;
        #region Color Changers
        public static bool BulletColorChanger = _settingsData.BulletColorChanger;
        public static bool DoorColorChanger = _settingsData.DoorColorChanger;
        public static bool BlockColorChanger = _settingsData.BlockColorChanger;
        public static bool BackgroundColorChanger = _settingsData.BackgroundColorChanger;
        public static bool SpikesColorChanger = _settingsData.SpikesColorChanger;
        #endregion
        #region Ammo Counter
        public static bool AmmoCounter = _settingsData.AmmoCounter;
        public static float AmmoCounterOffsetX = _settingsData.AmmoCounterOffsetX;
        public static float AmmoCounterOffsetY = _settingsData.AmmoCounterOffsetY;
        public static float AmmoCounterScaleX = _settingsData.AmmoCounterScaleX;
        public static float AmmoCounterScaleY = _settingsData.AmmoCounterScaleY;
        #endregion 
        public static bool DucksHitboxes = _settingsData.DucksHitboxes;
    }
}
