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

namespace Memoton.Fundamentals
{
    public class ScreenManager
    {
        ZComponent m_currentScreen;

        public ScreenManager()
        {
            m_currentScreen = null;
        }

        public ZComponent CurrentScreen
        {
            get { return m_currentScreen; }
            set { m_currentScreen = value; }
        }

        public void ChangeScreen(ZComponent p_nextScreen)
        {
            m_currentScreen = p_nextScreen;
            m_currentScreen.Initialize();
            m_currentScreen.LoadContent();
        }

        public void Update()
        {
            if (m_currentScreen != null)
                m_currentScreen.Update();
        }

        public void Draw()
        {
            if (m_currentScreen != null)
                m_currentScreen.Draw();
        }
    }
}
