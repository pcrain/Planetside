﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;

namespace Planetside
{
    public class StaticVFXStorage
    {
        public static void Init()
        {
            RadialRing = (GameObject)ResourceCache.Acquire("Global VFX/HeatIndicator");
            TeleportDistortVFX = (PickupObjectDatabase.GetById(573) as ChestTeleporterItem).TeleportVFX;
            TeleportVFX = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Teleport_Beam");

            var scarf = PickupObjectDatabase.GetById(436) as BlinkPassiveItem;
            ScarfObject = scarf.ScarfPrefab;

            var partObj = UnityEngine.Object.Instantiate(PlanetsideModule.ModAssets.LoadAsset<GameObject>("TheperkParticle"));//this is the name of the object which by default will be "Particle System"
            PerkParticleObject = partObj;
            FakePrefab.MarkAsFakePrefab(partObj);
            PerkParticleSystem = partObj.GetComponent<ParticleSystem>();
            FakePrefab.MarkAsFakePrefab(PerkParticleSystem.gameObject);
            var main = PerkParticleSystem.main;
            main.stopAction = ParticleSystemStopAction.None;
            main.maxParticles = 2000;
            main.duration = 1200;
            JammedDeathVFX = (GameObject)BraveResources.Load("Global VFX/VFX_BlackPhantomDeath", ".prefab");

            var PerfpartObj = UnityEngine.Object.Instantiate(PlanetsideModule.ModAssets.LoadAsset<GameObject>("PerfectedParticles"));
            FakePrefab.MarkAsFakePrefab(PerfpartObj);
            PerfectedParticleSystem = PerfpartObj.GetComponent<ParticleSystem>();
            FakePrefab.MarkAsFakePrefab(PerfectedParticleSystem.gameObject);


            var mainperf = PerkParticleSystem.main;
            mainperf.stopAction = ParticleSystemStopAction.None;
            mainperf.maxParticles = 2000;
            mainperf.duration = 1200;


            var ceramicObj = UnityEngine.Object.Instantiate(PlanetsideModule.ModAssets.LoadAsset<GameObject>("CeramicParticles"));
            FakePrefab.MarkAsFakePrefab(ceramicObj);
            CeramicParticleSystem = ceramicObj.GetComponent<ParticleSystem>();
            FakePrefab.MarkAsFakePrefab(CeramicParticleSystem.gameObject);

            var bloodSplatterObj = UnityEngine.Object.Instantiate(PlanetsideModule.ModAssets.LoadAsset<GameObject>("BloodSplatter"));
            FakePrefab.MarkAsFakePrefab(bloodSplatterObj);
            BloodSplatterParticleSystem = bloodSplatterObj.GetComponent<ParticleSystem>();
            FakePrefab.MarkAsFakePrefab(BloodSplatterParticleSystem.gameObject);

            var shamberParticlesObj = UnityEngine.Object.Instantiate(PlanetsideModule.ModAssets.LoadAsset<GameObject>("ShamberParticles"));
            ShamberParticleSystemGameObject = shamberParticlesObj;
            FakePrefab.MarkAsFakePrefab(shamberParticlesObj);
            ShamberParticleSystem = shamberParticlesObj.GetComponent<ParticleSystem>();
            FakePrefab.MarkAsFakePrefab(ShamberParticleSystem.gameObject);


            EnemySpawnVFX = (GameObject)ResourceCache.Acquire("Global VFX/VFX_SpawnEnemy_Reticle");
            ShootGroundVFX = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Bullet_Spawn");
            BlueSynergyPoofVFX = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Synergy_Poof_001");


        }
        public static ScarfAttachmentDoer ScarfObject;
        public static GameObject RadialRing;
        public static GameObject TeleportDistortVFX;
        public static GameObject TeleportVFX;
        public static GameObject EnemySpawnVFX;
        public static GameObject ShootGroundVFX;
        public static GameObject BlueSynergyPoofVFX;


        public static ParticleSystem PerkParticleSystem;
        public static ParticleSystem PerfectedParticleSystem;

        public static GameObject PerkParticleObject;

        public static ParticleSystem CeramicParticleSystem;
        public static ParticleSystem BloodSplatterParticleSystem;
        public static ParticleSystem ShamberParticleSystem;
        public static GameObject ShamberParticleSystemGameObject;


        public static GameObject JammedDeathVFX;

    }
}
