using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using System;
using System.Reflection;
using System.Linq;

namespace EsportGraphics.src.EGraphics
{
    internal class AmmoCounter : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public BitmapFont _font = new BitmapFont(Fonts[Ints["AmmoCounterFont"]], 8);
        public override void Draw()
        {
            if (!Settings["AmmoCounter"])
                return;

            StartDraw(_layer);

            _font.scale = new Vec2(Floats["AmmoCounterScale"]);

            HandleNormalGuns();
            HandleFlameThrower();

            StopDraw(_layer);
        }
        public override void Update()
        {
            HandleTampigWeapon();
        }
        private void HandleTampigWeapon()
        {
            if (Settings["TampingWeapons"])
                foreach (TampingWeapon gun in AvailableThings<TampingWeapon>())
                    gun.material = gun._tamped ?
                        new ColorMaterial(ESColors["TampedGun"]) :
                        (Material)new ColorMaterial(ESColors["UnTampedGun"]);
        }
        private void HandleNormalGuns()
        {
            foreach (var gun in from Gun gun in AvailableThings<Gun>()
                                where !IsUncountebleGun(gun) && !gun.infinite
                                select gun)
            {
                Vec2 pos = (gun.offDir == 1) ?
                    new Vec2(gun.position.x + 4, gun.position.y) :
                    new Vec2(gun.position.x - (gun.topRight.x - gun.topLeft.x) + _font.GetWidth(gun.ammo.ToString()) - 4,
                        gun.position.y);

                _font.DrawOutline(
                    gun.ammo.ToString(),
                    pos,
                    ESColors["AmmoCounterFront"],
                    ESColors["AmmoCounterBack"]);
            }
        }
        private void HandleFlameThrower()
        {
            foreach (FlameThrower flameThrower in AvailableThings<FlameThrower>())
                if (!flameThrower.infinite)
                {
                    Vec2 pos = (flameThrower.offDir == 1) ? new Vec2(flameThrower.position.x, flameThrower.position.y + 5) : new Vec2(flameThrower.position.x - 10, flameThrower.position.y + 5);
                    ESProgressBars.DrawLineBar(pos,
                                               10,
                                               (float)flameThrower.ammo / 100,
                                               ESColors["BarFront"] * Floats["BarsAlpha"],
                                               ESColors["BarBack"] * Floats["BarsAlpha"],
                                               ESColors["BarOutLine"] * Floats["BarsAlpha"],
                                               2);
                }
        }
        private static bool IsUncountebleGun(Gun gun)
        {
            return gun switch
            {
                Musket
                or Bazooka
                or VirtualShotgun
                or RoomDefenceTurret
                or OldPistol
                or DuelingPistol
                or Blunderbuss
                or Chainsaw
                or Sword
                or SledgeHammer
                or EnergyScimitar
                or FlameThrower
                or Grenade
                or Mine
                or HugeLaser
                or Warpgun                
                => true,
                _ => false
            };
        }
    }
}
