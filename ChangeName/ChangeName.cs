﻿using System;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using System.Collections.Generic;
using System.ComponentModel;

namespace ChangeName
{
    [ApiVersion(1, 14)]

    public class ChangeName : TerrariaPlugin
    {
        public override Version Version
        {
            get { return new Version("1.2.2"); }
        }
        public override string Name
        {
            get { return "ChangeName"; }
        }
        public override string Author
        {
            get { return "Simon311"; }
        }
        public override string Description
        {
            get { return "Changing names"; }
        }
        Dictionary<string, string> oldNames = new Dictionary<string, string>();
        public ChangeName(Main game)
            : base(game)
        {
            Order = -1;
        }
        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("changenames", ChanName, "chname"));
            Commands.ChatCommands.Add(new Command("oldnames", OldName, "oldname"));
            Commands.ChatCommands.Add(new Command("selfname", SelfName, "selfname"));
            Commands.ChatCommands.Add(new Command("tshock.canchat", Chat, "chat"));
        }
        private void ChanName(CommandArgs args)
        {
            if( args.Player != null )
            {
                if (args.Parameters.Count < 2)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Proper syntax: /chname [player] [newname]");
                    return;
                }
                var foundplr = TShock.Utils.FindPlayer(args.Parameters[0]);
                if (foundplr.Count == 0)
                {
                    args.Player.SendErrorMessage("Invalid player!");
                    return;
                }
                else if (foundplr.Count > 1)
                {
                    args.Player.SendErrorMessage(string.Format("More than one ({0}) player matched!", args.Parameters.Count));
                    return;
                }
                string newName = args.Parameters[1];
                bool hidden;
                if (args.Parameters.Count<3) { hidden = false; } else { hidden = true; }
                var plr = foundplr[0];
                string oldName = plr.TPlayer.name;
                if (!hidden)
                {
                    TShock.Utils.Broadcast(string.Format("{0} has changed {1}'s name to {2}.", args.Player.Name, oldName, newName), Color.DeepPink);
                    if (TShock.Config.EnableChatAboveHeads) { TShock.Utils.Broadcast("It will take a while before new name appears", Color.DeepPink); }
                }
                else
                {
                    args.Player.SendMessage(string.Format("You have secretly changed {0}'s name to {1}.", oldName, newName), Color.DeepPink);
                    if (TShock.Config.EnableChatAboveHeads) { args.Player.SendMessage("It will take a while before new name appears", Color.DeepPink); }
                }
                plr.TPlayer.name = newName;
                oldNames[newName] = oldName;
            }
        }
        private void SelfName(CommandArgs args)
        {
            if (args.Player != null)
            {
                var plr = args.Player;
                if (args.Parameters.Count < 1)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Proper syntax: /selfname [newname]");
                    return;
                }
                string newName = String.Join(" ", args.Parameters);
                string oldName = plr.TPlayer.name;
                plr.TPlayer.name = newName;
                oldNames[newName] = oldName;
                TShock.Utils.Broadcast(string.Format("{0} has changed his name to {1}.", oldName, newName), Color.DeepPink);
                if (TShock.Config.EnableChatAboveHeads) { args.Player.SendMessage("It will take a while before changes apply", Color.DeepPink); }
            }
        }
        private void OldName(CommandArgs args)
        {
            if (args.Player != null)
            {
                if (args.Parameters.Count < 1)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Proper syntax: /oldname [player]");
                    return;
                }
                if(oldNames.ContainsKey(args.Parameters[0])){
                    args.Player.SendMessage(string.Format("{0}'s old name is {1}.", args.Parameters[0], oldNames[args.Parameters[0]]), Color.DeepPink);
                } else {
                    args.Player.SendMessage(string.Format("{0}'s name has not been changed.", args.Parameters[0]), Color.DeepPink);
                }
            }
        }
        private void Chat(CommandArgs args)
        {
            if (args.Player != null)
            {
                if (args.Parameters.Count < 1)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Proper syntax: /chat [message]");
                    return;
                }
                string text = String.Join(" ", args.Parameters);
                var tsplr = args.Player;
                if (!tsplr.mute)
                {
                    TShock.Utils.Broadcast(
                        String.Format(TShock.Config.ChatFormat, tsplr.Group.Name, tsplr.Group.Prefix, tsplr.Name, tsplr.Group.Suffix, text),
                        tsplr.Group.R, tsplr.Group.G, tsplr.Group.B);
                }
                else
                {
                    tsplr.SendErrorMessage("You are muted!");
                }
            }
        }

    }
}
