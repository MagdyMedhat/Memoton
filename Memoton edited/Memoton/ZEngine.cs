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
using Memoton.Fundamentals;

namespace Memoton
{
    /// <summary>
    /// Your Game Should extend ZEngine Class with respect to the following manner:
    /// - If you will override Initialize() Method, make sure you call the base.Initialize() Method on top of anything.
    /// - LoadContent() Method is left empty for you, to be used instead of extending Initialize (To save the reserved Order).
    /// - You can add more logic to your Class by adding a GameManager and extend the Update() Method to call GameManager.Update()
    /// </summary>
    abstract public class ZEngine : Game
    {
        GraphicsDeviceManager m_graphics;
        SpriteBatch m_spriteBatch;
        //Content

        ScreenManager m_screenManager;
        InputManager m_inputManager;
        XMLManager m_XMLManager;

        Color m_defaultColor;


        public ZEngine()
        {
            m_graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        public SpriteBatch SpriteBatch
        {
            get { return m_spriteBatch; }
        }

        public ScreenManager ScreenManager
        {
            get { return m_screenManager; }
        }

        public InputManager InputManager
        {
            get { return m_inputManager; }
        }
        
        public XMLManager XMLManager
        {
            get { return m_XMLManager; }
        }


        protected override void Initialize()
        {
            m_screenManager = new ScreenManager();
            m_inputManager = new InputManager();
            m_XMLManager = new XMLManager();
            m_defaultColor = Color.White;
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            m_inputManager.Update();
            m_screenManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(m_defaultColor);

            m_spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.None);
            {
                m_screenManager.Draw();
            }
            m_spriteBatch.End();

            base.Draw(gameTime);
        }


        protected void ChangeWindowSize(int width, int height)
        {
            m_graphics.PreferredBackBufferHeight = height;
            m_graphics.PreferredBackBufferWidth = width;
            m_graphics.ApplyChanges();
        }

        protected void ChangeDefaultColor(Color color)
        {
            m_defaultColor = color;
        }
    }
}
