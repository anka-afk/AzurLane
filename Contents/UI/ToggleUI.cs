using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AzurLane.Contents.UI
{
    public class ToggleUI : UIState
    {
        public bool IsVisible; // 用于标记 UI 界面是否可见

        public override void OnInitialize()
        {
            // 在这里添加你的 UI 元素的初始化代码
            // 例如创建按钮、标签等
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                // 在这里绘制你的 UI 元素
            }
        }

        public void ToggleUIState()
        {
            IsVisible = !IsVisible; // 切换 UI 界面的可见性
        }
    }
}