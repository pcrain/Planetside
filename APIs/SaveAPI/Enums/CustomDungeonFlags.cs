﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaveAPI
{
    public enum CustomDungeonFlags
    {
        //Add your custom flags here
        //You can remove any flags here (except NONE, don't remove it)
        NONE, 
        EXAMPLE_FLAG,
        EXAMPLE_BLUEPRINTMETA_1,
        EXAMPLE_BLUEPRINTMETA_2,
        EXAMPLE_BLUEPRINTMETA_3,
        EXAMPLE_BLUEPRINTBEETLEE,
        EXAMPLE_BLUEPRINTGOOP,
        EXAMPLE_BLUEPRINTTRUCK,
        EXAMPLE_HUNT,
        EXAMPLE_HUNT_REWARD,
        EXAMPLE_ENEMY_DEATH_FLAG,
        EXAMPLE_ENEMY_ACTIVATION_FLAG,
        
        LOOPING_ON,

        JAMMED_GUARD_DEFEATED,
        BROKEN_CHAMBER_RUN_COMPLETED,
        HIGHER_CURSE_DRAGUN_KILLED,
        SHELLRAX_DEFEATED,
        BULLETBANK_DEFEATED,
        BEAT_LOOP_1,
        BEAT_A_BOSS_UNDER_A_SECOND,

        DEFEAT_FUNGANNON,
        DEFEAT_OPHANAIM,
        DEFEAT_ANNIHICHAMBER,
        DECURSE_HELL_SHRINE_UNLOCK,

        DEJAM,
        DEPETRIFY,
        DEBOLSTER,
        DEDARKEN,

        TRESPASS_INTO_OTHER_PLACE,
        HAS_TREADED_DEEPER,

        HM_PRIME_DEFEATED,

        HM_PRIME_DEFEATED_T4,

        //Wanderer Flags
        HAS_EVER_TALKED,
        HAS_FIRED_GTEE,
        HAS_COMMITED_HERESY,
        CONFUSED_THE_CHAMBER,
        SHATTER_GLASSGUON,
        PLATE_DIAMOND_CHAMBER,
        HASDONEEVRYTHING,

        HAS_COMPLETED_SOMETHING_WICKED,

        SHIPMENT_TICKET_HAD,

        INFECTED_FLOOR_COMPLETED,
        NEMESIS_KILLED,

        SPECIAL_LOCK,

        ALLSEEINGEYE_FLAG_ROOMDROP,
        ALLSEEINGEYE_FLAG_CHEST_STACK,

        EXPLOSIVEBIRTH_FLAG_STACK,

        CHAOTICSHIFT_FLAG_STACK,

        CONTRACT_FLAG_STACK,

        CORRUPTEDWEALTH_FLAG_STACK,
        CORRUPTEDWEALTH_FLAG_HP,
        CORRUPTEDWEALTH_FLAG_GUON,
        CORRUPTEDWEALTH_FLAG_BLANK,
        CORRUPTEDWEALTH_FLAG_AMMO,
        CORRUPTEDWEALTH_FLAG_ARMOR,
        CORRUPTEDWEALTH_FLAG_KEY,

        GLASS_FLAG_STACK,
        GLASS_FLAG_OVERHEAL,

        GREEDY_FLAG_STACK,

        GUNSLINGER_FLAG_STACK,
        GUNSLINGER_FLAG_MAGDUMP,

        PATIENCE_FLAG_STACK,

        PITLORDPACT_FLAG_STACK,
        PITLORDPACT_FLAG_TABLE,
        PITLORDPACT_FLAG_FALLLIVING,
        PITLORDPACT_FLAG_FALLPLAYER_AMULET,
        PITLORDPACT_FLAG_ITEM,

        UNBREAKABLESPIRIT_FLAG_STACK,

    }
}
