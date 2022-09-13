using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;

namespace EsportGraphics.src.Config
{
    public class ColorsData : DataClass
    {
        public ColorsData()
        {
            _nodeName = "ColorsData";
            EnemyBulletR = 255;
            EnemyBulletG = 0;
            EnemyBulletB = 0;
            EnemyBulletA = 255;

            LocalBulletR = 0;
            LocalBulletG = 255;
            LocalBulletB = 0;
            LocalBulletA = 255;

            EnemyHitBoxesR = 255;
            EnemyHitBoxesG = 0;
            EnemyHitBoxesB = 0;
            EnemyHitBoxesA = 255;

            LocalHitBoxesR = 255;
            LocalHitBoxesG = 255;
            LocalHitBoxesB = 255;
            LocalHitBoxesA = 255;

            BlocksR = 255;
            BlocksG = 255;
            BlocksB = 255;
            BlocksA = 255;

            ClosedDoorR = 255;
            ClosedDoorG = 255;
            ClosedDoorB = 255;
            ClosedDoorA = 255;

            OpenedDoorR = 150;
            OpenedDoorG = 150;
            OpenedDoorB = 150;
            OpenedDoorA = 255;

            FullAmmoR = 0;
            FullAmmoG = 255;
            FullAmmoB = 0;
            FullAmmoA = 255;

            MediumAmmoR = 255;
            MediumAmmoG = 255;
            MediumAmmoB = 0;
            MediumAmmoA = 255;

            LowAmmoR = 255;
            LowAmmoG = 0;
            LowAmmoB = 0;
            LowAmmoA = 255;

            AmmoCounterOutlineR = 0;
            AmmoCounterOutlineG = 0;
            AmmoCounterOutlineB = 0;
            AmmoCounterOutlineA = 255;

            BackColorR = 0;
            BackColorG = 0;
            BackColorB = 0;
            BackColorA = 255;
        }
        public int EnemyBulletR { get; set; }
        public int EnemyBulletG { get; set; }
        public int EnemyBulletB { get; set; }
        public int EnemyBulletA { get; set; }
        public int LocalBulletR { get; set; }
        public int LocalBulletG { get; set; }
        public int LocalBulletB { get; set; }
        public int LocalBulletA { get; set; }
        public int EnemyHitBoxesR { get; set; }
        public int EnemyHitBoxesG { get; set; }
        public int EnemyHitBoxesB { get; set; }
        public int EnemyHitBoxesA { get; set; }
        public int LocalHitBoxesR { get; set; }
        public int LocalHitBoxesG { get; set; }
        public int LocalHitBoxesB { get; set; }
        public int LocalHitBoxesA { get; set; }
        public int BlocksR { get; set; }
        public int BlocksG { get; set; }
        public int BlocksB { get; set; }
        public int BlocksA { get; set; }
        public int ClosedDoorR { get; set; }
        public int ClosedDoorG { get; set; }
        public int ClosedDoorB { get; set; }
        public int ClosedDoorA { get; set; }
        public int OpenedDoorR { get; set; }
        public int OpenedDoorG { get; set; }
        public int OpenedDoorB { get; set; }
        public int OpenedDoorA { get; set; }
        public int FullAmmoR { get; set; }
        public int FullAmmoG { get; set; }
        public int FullAmmoB { get; set; }
        public int FullAmmoA { get; set; }
        public int MediumAmmoR { get; set; }
        public int MediumAmmoG { get; set; }
        public int MediumAmmoB { get; set; }
        public int MediumAmmoA { get; set; }
        public int LowAmmoR { get; set; }
        public int LowAmmoG { get; set; }
        public int LowAmmoB { get; set; }
        public int LowAmmoA { get; set; }
        public int AmmoCounterOutlineR { get; set; }
        public int AmmoCounterOutlineG { get; set; }
        public int AmmoCounterOutlineB { get; set; }
        public int AmmoCounterOutlineA { get; set; }
        public int BackColorR { get; set; }
        public int BackColorG { get; set; }
        public int BackColorB { get; set; }
        public int BackColorA { get; set; }
    }
}
