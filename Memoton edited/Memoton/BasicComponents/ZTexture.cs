using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Memoton.Helpers;

namespace Memoton.BasicComponents
{
    public class ZTexture : ZComponent
    {
        Texture2D m_texture;

        CommonState m_state;


        public ZTexture(ZEngine p_gameReference, CommonState p_state)
            : base(p_gameReference)
        {
            m_state = p_state;
        }


        public Vector2 Position
        {
            set
            {
                m_state.position = value;
            }
            get
            {
                return m_state.position;
            }
        }

        public int Width
        {
            get
            {
                return m_texture.Width;
            }
        }

        public int Height
        {
            get
            {
                return m_texture.Height;
            }
        }

        public Texture2D Texture
        {
            get { return m_texture; }
            set { m_texture = value; }
        }


        public override void LoadContent()
        {
            m_texture = m_gameReference.Content.Load<Texture2D>(m_state.filePath);
        }

        public override void Draw()
        {
            m_gameReference.SpriteBatch.Draw(m_texture,
                m_state.position,
                null,
                m_state.color,
                m_state.rotation,
                m_state.origin,
                m_state.scale,
                SpriteEffects.None,
                m_state.drawOrder);
        }

        /// <summary>
        /// Draws a certain percentage from 0.0 to 1.0 in width.
        /// </summary>
        public void DrawPercentage(float Percentage)
        {
            float widthToDraw = m_texture.Width * Percentage;
            Rectangle rectangleToDraw = new Rectangle(0, 0, (int) widthToDraw, m_texture.Height);

            m_gameReference.SpriteBatch.Draw(m_texture,
                m_state.position,
                rectangleToDraw,
                m_state.color,
                m_state.rotation,
                m_state.origin,
                m_state.scale,
                SpriteEffects.None,
                0);
        }
    }
}
