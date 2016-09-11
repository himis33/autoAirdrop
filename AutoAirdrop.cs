using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System;
using UnityEngine;

namespace AutoAirdrop
{
    public class AutoAirdrop : RocketPlugin<AutoAirdropConfiguration>
    {
        public static AutoAirdrop Instance;
        private DateTime? lastdrop = null;
        private DateTime? lastdropn = null;
        private DateTime? started = null;
        private bool dropNow = false;
        public int time;
        public int timen;
        public bool mtr = false;
        public bool tdr = false;
        internal object nextLocation;

        void FixedUpdate()
        {
            if (Configuration.Instance.MassAirdropTimeRangeEnabled == false)
            {
                mtr = false;
            }
            else
            {
                mtr = true;
            }
            if (Configuration.Instance.TimedDropTimeRangeEnabled == false)
            {
                tdr = false;
            }
            else
            {
                tdr = true;
            }
            if (Configuration.Instance.TimedDropEnabled == true && Level.isLoaded)
            {
                CheckTimeDrop();
            }
            if (Configuration.Instance.MassAirdropEnabled == true && Level.isLoaded)
            {
                if (Configuration.Instance.MassAirdropDuration > 2f)
                {
                    Configuration.Instance.MassAirdropDuration = 2f;
                }
                if (dropNow == true)
                {
                    if ((DateTime.Now - started.Value).TotalSeconds < Configuration.Instance.MassAirdropDuration)
                    {
                        LevelManager.airdropFrequency = 0;
                    }
                    else
                    {
                        dropNow = false;
                    }
                }
                else
                {
                    CheckMassDrop();
                }
            }
        }

        internal void runFeast()
        {
            throw new NotImplementedException();
        }

        protected override void Load()
        {
            Instance = this;
            Logger.LogWarning("AutoAirdrop by Marek44 has been loaded");
        }

        protected override void Unload()
        {
            Logger.LogWarning("AutoAirdrop by Marek44 has been Unloaded");
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList(){
                {"massdrop Coming.Catch it","Mass Airdrop Incomming!"},
                {"Timed Airdrop Coming","Airdrop Incomming!"},
                };
            }
        }

        public void MassDrop()
        {
            UnturnedChat.Say(Translate("massdrop coming. Catch it!"), UnturnedChat.GetColorFromName(Configuration.Instance.MassDropColor, Color.green));
            Logger.Log(Translate("massdrop_comming"));
            started = DateTime.Now;
            dropNow = true;
        }

        private void CheckMassDrop()
        {
            try
            {
                if (mtr == true)
                {
                    time = UnityEngine.Random.Range(Configuration.Instance.MassAirdropTimeMin, Configuration.Instance.MassAirdropTimeMax);
                }
                else
                {
                    time = Configuration.Instance.MassAirdropInterval;
                }
                if (State == Rocket.API.PluginState.Loaded && (lastdrop == null || ((DateTime.Now - lastdrop.Value).TotalSeconds > time)))
                {
                    lastdrop = DateTime.Now;
                    MassDrop();
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
        private void CheckTimeDrop()
        {
            try
            {
                if (tdr == true)
                {
                    timen = UnityEngine.Random.Range(Configuration.Instance.TimedDropTimeMin, Configuration.Instance.TimedDropTimeMax);
                }
                else
                {
                    timen = Configuration.Instance.TimedDropInterval;
                }
                if (State == Rocket.API.PluginState.Loaded && (lastdropn == null || ((DateTime.Now - lastdropn.Value).TotalSeconds > timen)))
                {
                    lastdropn = DateTime.Now;
                    LevelManager.airdropFrequency = 0;
                    UnturnedChat.Say(Translate("timedrop_comming"), UnturnedChat.GetColorFromName(Configuration.Instance.TimedDropColor, Color.green));
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
