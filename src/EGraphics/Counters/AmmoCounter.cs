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
        //public BitmapFont _font = new BitmapFont(Fonts[Ints["AmmoCounterFont"]], 8);
        public override void Draw()
        {
            if (!Settings["AmmoCounter"])
                return;

            StartDraw(_layer);

            BitmapFont _font = new BitmapFont(Fonts[Ints["AmmoCounterFont"]], 8);

            _font.scale = new Vec2(Floats["AmmoCounterScale"]);

            HandleNormalGuns(_font);
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
        private void HandleNormalGuns(BitmapFont _font)
        {
            foreach (var gun in from Gun gun in AvailableThings<Gun>()
                                where !IsUncountebleGun(gun) && !gun.infinite && gun.canPickUp
                                select gun)
            {
                _font.DrawOutline(
                    gun.ammo.ToString(),
                    gun.position,
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
                                               ESColors["BarFront"],
                                               ESColors["BarBack"],
                                               ESColors["BarOutLine"],
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
