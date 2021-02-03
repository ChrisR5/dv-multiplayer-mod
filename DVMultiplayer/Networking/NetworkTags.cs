﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVMultiplayer.Networking
{
    public enum NetworkTags:ushort
    {
        TEST_TAG,
        PLAYER_SPAWN,
        PLAYER_LOCATION_UPDATE,
        PLAYER_DISCONNECT,
        PLAYER_WORLDMOVED,
        TRAIN_LEVER,
        TRAIN_SWITCH,
        TRAIN_LOCATION_UPDATE,
        TRAIN_DERAIL,
        TRAIN_COUPLE,
        TRAIN_COUPLE_HOSE,
        TRAIN_COUPLE_COCK,
        TRAIN_UNCOUPLE,
        SWITCH_CHANGED,
        SAVEGAME_UPDATE,
        SAVEGAME_GET,
        PLAYER_MODS_MISMATCH,
        TRAIN_SYNC_ALL,
        TRAIN_RERAIL,
        TURNTABLE_ANGLE_CHANGED,
        TURNTABLE_SYNC,
        PLAYER_SPAWN_SET,
        PLAYER_INIT,
        TRAIN_HOSTSYNC,
        SWITCH_SYNC,
        SWITCH_HOSTSYNC,
    }
}
