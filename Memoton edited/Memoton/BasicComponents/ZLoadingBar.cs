using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Memoton.BasicComponents
{
    public class ZLoadingBar : ZComponent
    {
        ZTexture m_progress;
        ZTexture m_bar;
        float m_percentage;

        public ZLoadingBar(ZEngine p_gameReference) : base(p_gameReference) { }

        public ZLoadingBar(ZEngine p_gameReference, ZTexture p_bar, ZTexture p_progress)
            : base(p_gameReference)
        {
            m_progress = p_progress;
            m_bar = p_bar;
        }

        
        public float Percentage
        {
            get { return m_percentage; }
            set { m_percentage = value; }
        }

        
        public override void LoadContent()
        {
            m_progress.LoadContent();
            m_bar.LoadContent();
        }

        public override void Draw()
        {
            m_bar.Draw();
            m_progress.DrawPercentage(Percentage);
        }
    }
}
