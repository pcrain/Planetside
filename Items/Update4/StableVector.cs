﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using Dungeonator;
using System.Reflection;
using Random = System.Random;
using FullSerializer;
using System.Collections;
using Gungeon;
using MonoMod.RuntimeDetour;
using MonoMod;
using System.Collections.ObjectModel;

using UnityEngine.Serialization;
using Brave.BulletScript;
using SaveAPI;

namespace Planetside
{
	public class StableVector : PassiveItem
	{
		public static void Init()
		{
			string itemName = "The Anchor";
			string resourceName = "Planetside/Resources/stableVector.png";
			GameObject obj = new GameObject(itemName);
			var item = obj.AddComponent<StableVector>();
			ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
			string shortDesc = "See Beyond";
			string longDesc = "Certain entrances appear consistently.\n\nContains a very small blue orb.";
			ItemBuilder.SetupItem(item, shortDesc, longDesc, "psog");
			item.quality = PickupObject.ItemQuality.A;
			item.SetupUnlockOnCustomFlag(CustomDungeonFlags.TRESPASS_INTO_OTHER_PLACE, true);
			ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Curse, 1, StatModifier.ModifyMethod.ADDITIVE);
			AnchorID = item.PickupObjectId;
		}
		public static int AnchorID;
	}
}