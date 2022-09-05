using DuckGame;
using ModName.src.Core;

namespace ModName.src
{
    internal class TestUpdate : UpdateMe
    {
        public override void Update()
        {
            if (Keyboard.Pressed(Keys.T))
                DevConsole.Log("Mod test update");
        }
    }
    internal class TestDraw : DrawMe
    {
        public override void Draw()
        {
            Layer.Blocks.Begin(true);

            foreach (Profile profile in Profiles.active)
                if (profile != null && profile.duck != null && !profile.duck.dead)
                {
                    Vec2 position = GetDuckPosition(profile.duck);
                    Graphics.DrawString(profile.nameUI, position, Color.White);
                }

            Layer.Blocks.End(true);
        }
        public static Vec2 GetDuckPosition(Duck duck)
        {
            if (duck.ragdoll != null)
            {
                return duck.ragdoll.part2.position;
            }
            else
            {
                return duck.position;
            }
        }
    }
}
