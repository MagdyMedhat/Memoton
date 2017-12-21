using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Memoton;

namespace DemoGame
{
    public class DemoGame : ZEngine
    {
        protected override void LoadContent()
        {
            IsMouseVisible = true;
            TestScreen testScreen = new TestScreen(this);
            this.ScreenManager.ChangeScreen(testScreen);
        }

    }
}
