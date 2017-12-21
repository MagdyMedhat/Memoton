using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Memoton.Helpers;
using Microsoft.Xna.Framework.Audio;
using Memoton;

namespace Memoton.BasicComponents
{
    public class ZAnimation : ZComponent
    {
        CommonState m_state;
        bool m_isRunning;

        Texture2D m_spriteSheet;
        Point m_currentFrame;
        ZTimer m_framesTimer;

        int m_frameHeight;
        int m_frameWidth;   
        int m_framesPerRow;
        int m_framesPerColumn;
        int m_ticksBetweenFrames;

        public ZAnimation(ZEngine p_gameReference, CommonState p_state, int p_frameHeight, int p_frameWidth, int p_ticksBetweenFrames)
            : base(p_gameReference)
        {
            this.m_state = p_state;
            this.m_frameHeight = p_frameHeight;
            this.m_frameWidth = p_frameWidth;
            this.m_ticksBetweenFrames = p_ticksBetweenFrames;
        }


        public override void Initialize()
        {
            m_framesTimer = new ZTimer(m_ticksBetweenFrames);
            m_currentFrame = new Point(0, 0);
            m_isRunning = true;
        }

        public override void LoadContent()
        {
            m_spriteSheet = m_gameReference.Content.Load<Texture2D>(m_state.filePath);
            m_framesPerRow = m_spriteSheet.Width / m_frameWidth;
            m_framesPerColumn = m_spriteSheet.Height / m_frameHeight;
        }

        public override void Draw()
        {
            m_gameReference.SpriteBatch.Draw(m_spriteSheet,
                m_state.position,
                new Rectangle ( m_currentFrame.X * m_frameWidth, m_currentFrame.Y*m_frameHeight, m_frameWidth, m_frameHeight),
                m_state.color,
                m_state.rotation,
                m_state.origin,
                m_state.scale,
                SpriteEffects.None,
                m_state.drawOrder);
        }

        public override void Update()
        {
            if (m_isRunning)
            {
                m_framesTimer.Update();

                if (m_framesTimer.IsTimedOut())
                {
                    m_currentFrame.X++;
                    if (m_currentFrame.X >= m_framesPerRow)
                    {
                        m_currentFrame.X = 0;
                        m_currentFrame.Y++;
                    }
                    
                    if (m_currentFrame.Y >= m_framesPerColumn)
                        m_currentFrame.Y = 0;
                }
            }
        }


        public void Pause()
        {
            m_isRunning = false;
        }

        public void Continue()
        {
            m_isRunning = true;
        }
    }
}
