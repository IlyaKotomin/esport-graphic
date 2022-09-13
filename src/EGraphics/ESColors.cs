using DuckGame;
using static EsportGraphics.src.Config.ESOptions;

namespace EsportGraphics.src.EGraphics
{
    internal class ESColors
    {
        public static Color EnemyBullet => new Color(_colorsData.EnemyBulletR, _colorsData.EnemyBulletG, _colorsData.EnemyBulletB, _colorsData.EnemyBulletA);
        public static Color LocalBullet => new Color(_colorsData.LocalBulletR, _colorsData.LocalBulletG, _colorsData.LocalBulletB, _colorsData.LocalBulletA);
        public static Color EnemyHitBoxes => new Color(_colorsData.EnemyHitBoxesR, _colorsData.EnemyHitBoxesG, _colorsData.EnemyHitBoxesB, _colorsData.EnemyHitBoxesA);
        public static Color LocalHitBoxes => new Color(_colorsData.LocalHitBoxesR, _colorsData.LocalHitBoxesG, _colorsData.LocalHitBoxesB, _colorsData.LocalHitBoxesA);
        public static Color Blocks => new Color(_colorsData.BlocksR, _colorsData.BlocksG, _colorsData.BlocksB, _colorsData.BlocksA);
        public static Color ClosedDoor => new Color(_colorsData.ClosedDoorR, _colorsData.ClosedDoorG, _colorsData.ClosedDoorB, _colorsData.ClosedDoorA);
        public static Color OpenedDoor => new Color(_colorsData.OpenedDoorR, _colorsData.OpenedDoorG, _colorsData.OpenedDoorB, _colorsData.OpenedDoorA);
        public static Color FullAmmo => new Color(_colorsData.FullAmmoR, _colorsData.FullAmmoG, _colorsData.FullAmmoB, _colorsData.FullAmmoA);
        public static Color MediumAmmo => new Color(_colorsData.MediumAmmoR, _colorsData.MediumAmmoG, _colorsData.MediumAmmoB, _colorsData.MediumAmmoA);
        public static Color LowAmmo => new Color(_colorsData.LowAmmoR, _colorsData.LowAmmoG, _colorsData.LowAmmoB, _colorsData.LowAmmoA);
        public static Color AmmoCounterOutline => new Color(_colorsData.AmmoCounterOutlineR, _colorsData.AmmoCounterOutlineG, _colorsData.AmmoCounterOutlineB, _colorsData.AmmoCounterOutlineA);
        public static Color BackColor => new Color(_colorsData.BackColorR, _colorsData.BackColorG, _colorsData.BackColorB, _colorsData.BackColorA);
    }
}
