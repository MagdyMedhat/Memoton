using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Memoton.Helpers;

namespace Memoton.BasicComponents
{
    /// <summary>
    /// - Need to extend the ZButton class to Implement the Press() Method to add the process it should do.
    /// - Normal and Highlighted Textures must be initialized in 2 cases:
    ///     => Reusability : pass them to the constructor.
    ///     => Single use  : extend and override the Initialize() Method to do the work.
    /// </summary>
    public abstract class ZButton : ZComponent
    {   
        protected ZTexture m_normalTexture;
        protected ZTexture m_highlightedTexture;
        protected ZTexture m_currentTexture;
        public event Action OnButtonPress;


        public ZButton(ZEngine p_gameReference)
            : base(p_gameReference)
        {

        }

        public ZButton(ZEngine p_gameReference, ZTexture p_normalTexture, ZTexture p_highLightedTexture)
            : base(p_gameReference)
        {
            m_normalTexture = p_normalTexture;
            m_highlightedTexture = p_highLightedTexture;
        }

        public override void Initialize()
        {
            m_currentTexture = m_normalTexture;
        }

        public override void LoadContent()
        {
            m_normalTexture.LoadContent();
            m_highlightedTexture.LoadContent();
        }

        public override void Draw()
        {
            m_currentTexture.Draw();
        }

        public override void Update()
        {
            HandleUserInput();
        }


        private void HandleUserInput()
        {
            if (CanHover())
            {
                Hover();

                if (CanPress())
                    Press();
            }

            else
                Reset();

        }

        private bool CanHover()
        {
            Point mousePosition = m_gameReference.InputManager.GetMousePosition();
            Vector2 texturePosition = m_currentTexture.Position;

            return ((texturePosition.X < mousePosition.X)
                    && (mousePosition.X < texturePosition.X + m_currentTexture.Width)
                    && (texturePosition.Y < mousePosition.Y)
                    && (mousePosition.Y < texturePosition.Y + m_currentTexture.Height));
        }

        private bool CanPress()
        {
            return ( m_gameReference.InputManager.IsLeftMouseButtonClicked() );
        }


        protected void Press()
        {
            if (OnButtonPress != null)
                OnButtonPress();
        }

        protected virtual void Hover()
        {
            m_currentTexture = m_highlightedTexture;
        }

        protected virtual void Reset()
        {
            m_currentTexture = m_normalTexture;
        }

    }
}
