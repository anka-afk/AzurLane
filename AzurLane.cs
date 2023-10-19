using AzurLane.Contents.UI;
using Terraria.ModLoader;

namespace AzurLane
{
    public class AzurLane : Mod
    {
        public static AzurLane Instance;
        public ToggleUI ToggleUI;

        public AzurLane()
        {
            Instance = this;
        }

        public override void Load()
        {
            ToggleUI = new ToggleUI();
        }
    }
}