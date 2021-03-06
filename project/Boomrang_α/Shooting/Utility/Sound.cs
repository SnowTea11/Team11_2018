﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Shooting
{
    class Sound
    {
        private ContentManager contentManager;
        private Dictionary<string, Song> bgms;
        private Dictionary<string, SoundEffect> soundEffects;
        private Dictionary<string, SoundEffectInstance> SEInstances;

        public Sound(ContentManager content)
        {
            contentManager = content;
            MediaPlayer.IsRepeating = true;

            bgms = new Dictionary<string,Song>();
            soundEffects = new Dictionary<string,SoundEffect>();
            SEInstances = new Dictionary<string,SoundEffectInstance>();
        }
        public void LoadBGM(string name)
        {
            bgms.Add(name, contentManager.Load<Song>(name));
        }
        public bool IsNotPlayingBGM()
        {
            return (MediaPlayer.State != MediaState.Playing);
        }

        public void PlayBGM(string name)
        {
            if (IsNotPlayingBGM())
            {
                MediaPlayer.Play(bgms[name]);
            }
        }
        public void StopBGM()
        {
            MediaPlayer.Stop();
        }
        public void ChangeBGMLoopFlag(bool loopFlag)
        {
            MediaPlayer.IsRepeating = loopFlag;        
        }
        public void LoadSE(string name)
        {
            soundEffects.Add(name, contentManager.Load<SoundEffect>(name));
        }
        public void CreateSEInstance(string name)
        {
            SEInstances.Add(name, soundEffects[name].CreateInstance());
        }
        public void PlaySE(string name)
        {
            soundEffects[name].Play();
        }
        public bool IsNotPlayingSEInstance(string name)
        {
            return (SEInstances[name].State != SoundState.Playing);
        }
        public void PlaySEInstance(string name)
        {
            if (IsNotPlayingSEInstance(name))
            {
                SEInstances[name].Play();
            }
        }
        public void StopSEInstance(string name)
        {
            SEInstances[name].Stop();
        }
        public void UnloadContent()
        {
            bgms.Clear();
            soundEffects.Clear();
            SEInstances.Clear();
        }
    }
}
