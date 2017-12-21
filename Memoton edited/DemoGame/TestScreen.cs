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
    class TestScreen : ZComponent
    {
        ZTexture m_texture;
        ZText m_welcomeMsg;
        ZTimer m_timer;
        ZSound m_sound;
        ZAnimation m_animation;
        ExitButton m_exitBtn;
        ZLoadingBar m_loadingBar;

        public TestScreen(ZEngine p_gameReference) : base(p_gameReference) {}

        public override void Initialize()
        {
            m_texture = new ZTexture(m_gameReference, new CommonState("texture", Color.White, new Vector2(30, 100), Vector2.Zero, 1f, 0, 0));
            this.AddToList(m_texture);


            CommonState textState = new CommonState();
            textState.filePath = "spritefont";
            textState.color = Color.Black;
            textState.position = new Vector2(400, 100);
            textState.origin = Vector2.Zero;
            textState.scale = 1f;
            textState.rotation = 0;
            
            m_welcomeMsg = new ZText(m_gameReference, textState, "Hello, iam a text bounded in a box trying to achieve the purpose for which i was created.", 300);
            this.AddToList(m_welcomeMsg);
            

            m_timer = new ZTimer(20);
            this.AddToList(m_timer);

            m_sound = new ZSound(m_gameReference, "sound", false);
            this.AddToList(m_sound);


            CommonState animationState = new CommonState();
            animationState.filePath = "animation";
            animationState.color = Color.White;
            animationState.position = new Vector2(450, 250);
            animationState.scale = 1f;
            animationState.rotation = 0;
            animationState.origin = Vector2.Zero;

            m_animation = new ZAnimation(m_gameReference, animationState, 75, 75, 2);
            this.AddToList(m_animation);

            m_exitBtn = new ExitButton(m_gameReference);
            m_exitBtn.OnButtonPress += new Action(m_exitBtn_OnButtonPress);
            this.AddToList(m_exitBtn);

            ZTexture bar = new ZTexture(m_gameReference, new CommonState("bar", Color.White, new Vector2(400, 500), Vector2.Zero, 1f, 0, 0));
            ZTexture progress = new ZTexture(m_gameReference, new CommonState("progress", Color.White, new Vector2(400, 500), Vector2.Zero, 1f, 0, 0));
            m_loadingBar = new ZLoadingBar(m_gameReference, bar, progress);
            this.AddToList(m_loadingBar);

            base.Initialize();
        }

        void m_exitBtn_OnButtonPress()
        {
            m_gameReference.Exit();
        }

        public override void Update()
        {
            if (m_timer.IsTimedOut())
            {
                m_loadingBar.Percentage += 0.10f;

                if (m_loadingBar.Percentage - 0.10 > 1)
                {
                    m_sound.Play();
                    m_loadingBar.Percentage = 0f;
                }
            }

            base.Update();
        }
    }
}
