using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Memoton.Helpers;

namespace Memoton.BasicComponents
{
    public class ZText : ZComponent
    {
        SpriteFont m_spriteFont;
        string m_text;

        int m_width;
        CommonState m_state;

        public string Text
        {
            get { return m_text; }
            set { m_text = value; }
        }


        public ZText(ZEngine p_gameReference, CommonState p_state, string p_text)
            : base(p_gameReference)
        {
            m_state = p_state;
            m_text = p_text;
            m_width = -1;
        }

        public ZText(ZEngine p_gameReference, CommonState p_state, string p_text, int p_width)
            : base(p_gameReference)
        {
            m_state = p_state;
            m_text = p_text;
            m_width = p_width;
        }


        public override void LoadContent()
        {
            m_spriteFont = m_gameReference.Content.Load<SpriteFont>(m_state.filePath);
        }

        public override void Update()
        {
            if (m_width > 0)
                AdjustWidth();
        }

        public override void Draw()
        {
            m_gameReference.SpriteBatch.DrawString(m_spriteFont,
                m_text,
                m_state.position,
                m_state.color,
                m_state.rotation,
                m_state.origin,
                m_state.scale,
                SpriteEffects.None,
                m_state.drawOrder);
        }


        public void AdjustWidth()
        {
            string[] words = m_text.Split(' ');
            string line = "";
            string returnText = "";

            foreach (string word in words)
            {
                if (MeasureString(line + " " + word) >= m_width)
                {
                    returnText += line + "\n";
                    line = word;
                }
                else
                {
                    line += " " + word;
                }
            }

            m_text = returnText += line;
            m_width = 0;
        }

        private int MeasureString(string String)
        {
            return (int)m_spriteFont.MeasureString(String).Length();
        }
    }
}
