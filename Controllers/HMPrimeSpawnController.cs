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
using GungeonAPI;
using SaveAPI;


namespace Planetside
{
    public class HMPrimeSpawnController : MonoBehaviour
    {
        public void Start()
        {
            Debug.Log("Starting HMPrimeSpawnController setup...");
            try
            {              
                List<ProceduralFlowModifierData.FlowModifierPlacementType> flowModifierPlacementTypes = new List<ProceduralFlowModifierData.FlowModifierPlacementType>()
                { ProceduralFlowModifierData.FlowModifierPlacementType.END_OF_CHAIN};
                List<DungeonPrerequisite> dungeonPrerequisites = new List<DungeonPrerequisite>()
                {
                    new CustomDungeonPrerequisite
                    {
                        advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_STAT_COMPARISION,
                        customStatToCheck = CustomTrackedStats.HMPRIME_KILLS,
                        useSessionStatValue = true,
                        prerequisiteOperation = DungeonPrerequisite.PrerequisiteOperation.EQUAL_TO,
                        comparisonValue = 0,                        
                    },
                    new DungeonPrerequisite
                    {
                        saveFlagToCheck = GungeonFlags.BOSSKILLED_DRAGUN,
                        requireFlag = true,
                        prerequisiteType = DungeonPrerequisite.PrerequisiteType.FLAG,
                        prerequisiteOperation = DungeonPrerequisite.PrerequisiteOperation.EQUAL_TO,
                      
                    }
                };
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimeproperroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.07f);
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimeminesroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.1f);
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimehollowroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.12f);
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimeforgeroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.15f);
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimeoublietteroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.18f);
                RoomFactory.AddInjection(RoomFactory.BuildFromResource("Planetside/Resources/OtherSpecialRooms/hmprimeabbeyroom.room").room, "HM Prime Boss Room", flowModifierPlacementTypes, 0, dungeonPrerequisites, "HM Prime Boss Room", 1f, 0.18f);//0.2f
                Debug.Log("Finished HMPrimeSpawnController setup without failure!");
            }
            catch (Exception e)
            {
                Debug.Log("Unable to finish HMPrimeSpawnController setup!");
                Debug.Log(e);
            }
        }
    }
}
