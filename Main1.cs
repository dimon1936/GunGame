                    case 522:
                        Trigger.ClientEvent(player, "client::openmenu");
                        return;
  
  [RemoteEvent("inputCallback")]
        public void ClientEvent_inputCallback(Player player, params object[] arguments)
        {
            string callback = "";
            try
            {
                callback = arguments[0].ToString();
                string text = arguments[1].ToString();
                switch (callback)
                {
                    case "gun_enterpass":
                        if (!player.HasData("ARENAID") || !GunGame.Arenas.ContainsKey(player.GetData<int>("ARENAID"))) return;
                        Arena arena = GunGame.Arenas[player.GetData<int>("ARENAID")];

                        player.ResetData("ARENAID");

                        if (arena.Pass != text)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Не правильный пароль!", 3000);
                            return;
                        }

                        NAPI.ClientEvent.TriggerClientEvent(player, "client::openmenu");

                        arena.Players.Add(player);

                        arena.SetLobby(player);
                        arena.RefreshPlayers();

                        player.SetData("ARENA", arena);

                        Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, "Вы вошли в лобби!", 3000);
                        return;