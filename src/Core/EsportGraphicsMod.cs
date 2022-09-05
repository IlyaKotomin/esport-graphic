using EsportGraphics.src;

namespace DuckGame.src
{
    public class EsportGraphicsMod : DisabledMod
    {
        public override Priority priority => base.priority;
        protected override void OnPreInitialize()
        {
            base.OnPreInitialize();
            ModInitialize.PreInitialize();
        }
        protected override void OnPostInitialize()
        {
            ModInitialize.PostInitialize();

            base.OnPostInitialize();
        }
    }
}
