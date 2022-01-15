﻿using System;
using System.Collections.Generic;
using Gungeon;
using ItemAPI;
using UnityEngine;
using AnimationType = ItemAPI.EnemyBuilder.AnimationType;
using System.Collections;
using Dungeonator;
using System.Linq;
using Brave.BulletScript;

namespace Planetside
{
	public class WowBullet : AIActor
	{


		public static void Init()
		{
			string TemplatePath = "Planetside/Resources/Enemies/ModderBullets/";
			string folderName = "wow";
			string idleFrameName = "wowbullet_idle_00";
			string deathFrameName = "wowbullet_die_00";
			string[] spritePaths = new string[]
			{
			TemplatePath+folderName+"/"+idleFrameName+"1.png",
			TemplatePath+folderName+"/"+idleFrameName+"2.png",
			TemplatePath+folderName+"/"+idleFrameName+"3.png",
			TemplatePath+folderName+"/"+idleFrameName+"4.png",

			TemplatePath+folderName+"/"+deathFrameName+"1.png",
			TemplatePath+folderName+"/"+deathFrameName+"2.png",
			TemplatePath+folderName+"/"+deathFrameName+"3.png",
			TemplatePath+folderName+"/"+deathFrameName+"4.png",
			TemplatePath+folderName+"/"+deathFrameName+"5.png",
			TemplatePath+folderName+"/"+deathFrameName+"6.png",

			};
			AIActor sirWow= EnemyToolbox.CreateNewBulletBankerEnemy("wow_bullet", "SirWow", 18, 19, spritePaths[0], spritePaths, new List<int> { 0, 1, 2, 3 }, new List<int> { 4, 5, 6, 7, 8, 9 }, null, new SalamanderScript(), 5f);
			sirWow.gameObject.GetOrAddComponent<WowFireImmunity>();
		}
			

		private class WowFireImmunity : BraveBehaviour
		{
			private void Start()
			{
				if (base.aiActor != null)
                {
					base.aiActor.healthHaver.OnPreDeath += (obj) =>
					{
						DoFireGoop((base.aiActor.sprite.WorldCenter));
					};
					DamageTypeModifier fireRes = new DamageTypeModifier();
					fireRes.damageMultiplier = 0f;
					fireRes.damageType = CoreDamageTypes.Fire;
					base.aiActor.healthHaver.damageTypeModifiers.Add(fireRes);

					var nur = base.aiActor;
					nur.EffectResistances = new ActorEffectResistance[]
					{
					new ActorEffectResistance()
					{
						resistAmount = 1,
						resistType = EffectResistanceType.Fire
					},
					};
				}	
			}
			private void DoFireGoop(Vector2 v)
			{
				AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
				GoopDefinition goopDef = assetBundle.LoadAsset<GoopDefinition>("assets/data/goops/napalmgoopquickignite.asset");
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDef);
				goopManagerForGoopType.TimedAddGoopCircle(v, 5f, 1f, false);
				goopDef.damagesEnemies = false;
			}
		}



		public class SalamanderScript : Script 
		{
			protected override IEnumerator Top() 
			{
				if (this.BulletBank && this.BulletBank.aiActor && this.BulletBank.aiActor.TargetRigidbody)
				{
					base.BulletBank.Bullets.Add(EnemyDatabase.GetOrLoadByGuid("796a7ed4ad804984859088fc91672c7f").bulletBank.GetBullet("default"));
				}
				for (int i = 0; i < 4; i++)
				{
					base.Fire(new Direction(0 + (UnityEngine.Random.Range(-20,20)), DirectionType.Aim, -1f), new Speed(12f, SpeedType.Absolute), new WallBullet());
					yield return Wait(10);

				}

				yield break;
			}
		}


		public class WallBullet : Bullet
		{
			public WallBullet() : base("default", false, false, false)
			{

			}
			protected override IEnumerator Top()
			{
				yield return Wait(UnityEngine.Random.Range(30, 90));
				DoFireGoop((base.Projectile.sprite.WorldCenter));
				base.Vanish(false);
				yield break;
			}
			private void DoFireGoop(Vector2 v)
			{
				AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
				GoopDefinition goopDef = assetBundle.LoadAsset<GoopDefinition>("assets/data/goops/napalmgoopquickignite.asset");
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDef);
				goopManagerForGoopType.TimedAddGoopCircle(v, 2.5f, 0.35f, false);
				goopDef.damagesEnemies = false;
			}
		}
	}
}








