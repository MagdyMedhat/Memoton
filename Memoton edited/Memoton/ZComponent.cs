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

namespace Memoton
{
    /// <summary>
    /// This Class can be used as a Concrete Component or a Container Component
    /// - Concerete Component Case : override the 4 Methods with your logic.
    /// - Container Component Case : use AddtoList() Method to add children to this class.
    ///     => Note that you will need to override the Initialize Method in order to add your logic (declare children and add them to the list).
    ///     => Note that you would sometimes need to extend any of the Methods to add more logic with respect to the regular behavior.
    /// </summary>
    abstract public class ZComponent
    {
        protected float m_drawOrder; // 0 = front
        protected ZEngine m_gameReference;
        List<ZComponent> m_components;

        public ZComponent(ZEngine p_gameReference)
        {
            m_gameReference = p_gameReference;
            m_drawOrder = 0;
        }

        public virtual void Initialize()
        {
            if (m_components != null)
            {
                foreach (ZComponent child in m_components)
                    child.Initialize();
            }
        }
        public virtual void LoadContent()
        {
            if (m_components != null)
            {
                foreach (ZComponent child in m_components)
                    child.LoadContent();
            }
        }
        public virtual void Draw()
        {
            if (m_components != null)
            {
                foreach (ZComponent child in m_components)
                    child.Draw();
            }
        }
        public virtual void Update()
        {
            if (m_components != null)
            {
                foreach (ZComponent child in m_components)
                    child.Update();
            }
        }

        public void AddToList(ZComponent p_component)
        {
            if (m_components == null)
                m_components = new List<ZComponent>();

            m_components.Add(p_component);
        }
    }
}