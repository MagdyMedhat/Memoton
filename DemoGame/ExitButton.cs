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
using Memoton.BasicComponents;
using Memoton.Helpers;

namespace DemoGame
{
    class ExitButton : ZButton
    {
        public ExitButton(ZEngine p_gameReference) : base(p_gameReference) { }

        public override void Initialize()
        {
            CommonState normalState = new CommonState();
            normalState.filePath = "btn";
            normalState.color = Color.White;
            normalState.position = new Vector2(450, 400);
            normalState.origin = Vector2.Zero;
            normalState.scale = 1f;
            normalState.rotation = 0;
            m_normalTexture = new ZTexture(m_gameReference, normalState);

            CommonState highlightedState = new CommonState(normalState);
            highlightedState.filePath = "btnhover";

            m_highlightedTexture = new ZTexture(m_gameReference, highlightedState);

            base.Initialize();
        }

        protected override void Press()
        {
            m_gameReference.Exit();
        }
    }
}
