using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace AzurLane.Contents.UI
{
    public class 互动 : UIState
    {
        private UIText label;
        private UIPanel panel;
        private UIImageButton button;
        private Texture2D backgroundTexture;

        public override void OnInitialize()
        {
            backgroundTexture = (Texture2D)ModContent.Request<Texture2D>("Azurlane/Contents/UI/互动");
            UIImage backgroundImage = new UIImage(backgroundTexture);
            backgroundImage.Width.Set(1280f, 0f);
            backgroundImage.Height.Set(720f, 0f);
            Append(backgroundImage);
            // 创建一个标签
            label = new UIText("Hello, World!");
            label.Left.Set(50f, 0f);
            label.Top.Set(50f, 0f);
            Append(label);

            // 创建一个面板
            panel = new UIPanel();
            panel.Left.Set(50f, 0f);
            panel.Top.Set(100f, 0f);
            panel.Width.Set(100f, 0f);
            panel.Height.Set(50f, 0f);
            Append(panel);

            // 在面板中创建一个按钮
            button = new UIImageButton(ModContent.Request<Texture2D>("Azurlane/Contents/UI/互动按钮"));
            button.Left.Set(0f, 0f);
            button.Top.Set(0f, 0f);
            button.Width.Set(100f, 0f);
            button.Height.Set(50f, 0f);
            button.OnLeftClick += ButtonClicked;
            panel.Append(button);
        }

        private void ButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            label.SetText("Button clicked!");
        }
    }
}