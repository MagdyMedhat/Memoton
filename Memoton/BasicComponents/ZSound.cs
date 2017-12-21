using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Memoton.Helpers;
using Microsoft.Xna.Framework.Audio;

namespace Memoton.BasicComponents
{
    public class ZSound : ZComponent
    {
        string m_filePath;
        SoundEffect m_soundEffect;
        SoundEffectInstance m_soundEffectInstance;
        bool m_isLooping;

        
        public ZSound(ZEngine p_gameReference, string p_filePath, bool p_isLooping)
            : base(p_gameReference)
        {
            m_gameReference = p_gameReference;
            m_filePath = p_filePath;
            m_isLooping = p_isLooping;
        }

        
        public override void LoadContent()
        {
            m_soundEffect = m_gameReference.Content.Load<SoundEffect>(m_filePath);
            m_soundEffectInstance = m_soundEffect.Play(1, 0, 0, m_isLooping);
            m_soundEffectInstance.Stop();
        }


        public void Play()
        {
            m_soundEffectInstance.Play();
        }

        public void Pause()
        {
            m_soundEffectInstance.Pause();
        }

        public void Stop()
        {
            m_soundEffectInstance.Stop();
        }
    }
}
