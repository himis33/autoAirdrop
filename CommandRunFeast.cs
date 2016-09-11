using System;
using System.Collections;
using System.Collections.Generic;

using Rocket.API;
using Rocket.Unturned.Chat;
using UnityEngine;

namespace AutoAirdrop
{
    class CommandRunFeast : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string> { "frun" };
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Both;
            }
        }

        public string Help
        {
            get
            {
                return "Immediately starts the feast by AutoAirdrop";
            }
        }

        public string Name
        {
            get
            {
                return "runfeast";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>();
            }
        }

        public string Syntax
        {
            get
            {
                return "";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedChat.Say(AutoAirdrop.Instance.Translate("Now_feast_msg", new object[] {
                AutoAirdropFeast.Instance.nextLocation.Name
                }), UnturnedChat.GetColorFromName(AutoAirdropFeast.Instance.Configuration.Instance.MessageColor , Color.red));
            AutoAirdrop.Instance.runFeast();
        }
    }
}
