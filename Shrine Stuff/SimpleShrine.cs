﻿using System;
using System.Collections;
using UnityEngine;
using Dungeonator;
namespace GungeonAPI
{
	public class SimpleShrine : SimpleInteractable, IPlayerInteractable
	{
		private void Start()
		{	
			SpriteOutlineManager.AddOutlineToSprite(base.sprite, Color.black, 1f, 0f, SpriteOutlineManager.OutlineType.NORMAL);
			this.talkPoint = base.transform.Find("talkpoint");
			this.m_isToggled = false;
		}

		public void Interact(PlayerController interactor)
		{
			bool flag = TextBoxManager.HasTextBox(this.talkPoint);
			bool flag2 = !flag;
			if (flag2)
			{
			
				this.m_canUse = ((this.CanUse != null) ? this.CanUse(interactor, base.gameObject) : this.m_canUse);
				base.StartCoroutine(this.HandleConversation(interactor));
			}
		}

		private IEnumerator HandleConversation(PlayerController interactor)
		{
			if (this.talkPoint == null) { ETGModConsole.Log("talkPoint is NULL"); }
			if (this.talkPoint.position == null) { ETGModConsole.Log("talkPoint.position is NULL"); }
			if (this.text == null) { ETGModConsole.Log("text is NULL"); }

			TextBoxManager.ShowStoneTablet(this.talkPoint.position, this.talkPoint, -1f, this.text, true, false);
			int selectedResponse = -1;
			interactor.SetInputOverride("shrineConversation");
			yield return null;
			bool flag = !this.m_canUse;
			bool flag5 = flag;
			if (flag5)
			{
				GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, null, this.declineText, string.Empty);
			}
			else
			{
				bool isToggle = this.isToggle;
				bool flag6 = isToggle;
				if (flag6)
				{
					bool isToggled = this.m_isToggled;
					bool flag7 = isToggled;
					if (flag7)
					{
						GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, null, this.declineText, string.Empty);
					}
					else
					{
						GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, null, this.acceptText, string.Empty);
					}
				}
				else
				{
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, null, this.acceptText, this.declineText);
				}
			}
			while (!GameUIRoot.Instance.GetPlayerConversationResponse(out selectedResponse))
			{
				yield return null;
			}
			interactor.ClearInputOverride("shrineConversation");
			TextBoxManager.ClearTextBox(this.talkPoint);
			if (!this.m_canUse)
			{
				yield break;
			}
			if (selectedResponse == 0 && this.isToggle)
			{
				Action<PlayerController, GameObject> action = this.m_isToggled ? this.OnDecline : this.OnAccept;
				if (action != null)
				{
					action(interactor, base.gameObject);
				}
				this.m_isToggled = !this.m_isToggled;
				yield break;
			}
			if (selectedResponse == 0)
			{
				Action<PlayerController, GameObject> onAccept = this.OnAccept;
				if (onAccept != null)
				{
					onAccept(interactor, base.gameObject);
				}
				onAccept = null;
			}
			else
			{
				Action<PlayerController, GameObject> onDecline = this.OnDecline;
				if (onDecline != null)
				{
					onDecline(interactor, base.gameObject);
				}
				onDecline = null;
			}
			yield break;
		}

		public void OnEnteredRange(PlayerController interactor)
		{
			SpriteOutlineManager.AddOutlineToSprite(base.sprite, Color.white, 1f, 0f, SpriteOutlineManager.OutlineType.NORMAL);
			base.sprite.UpdateZDepth();
		}

		public void OnExitRange(PlayerController interactor)
		{
			SpriteOutlineManager.AddOutlineToSprite(base.sprite, Color.black, 1f, 0f, SpriteOutlineManager.OutlineType.NORMAL);
		}

		public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
		{
			shouldBeFlipped = false;
			return string.Empty;
		}

		public float GetDistanceToPoint(Vector2 point)
		{
			bool flag = base.sprite == null;
			bool flag2 = flag;
			float result;
			if (flag2)
			{
				result = 100f;
			}
			else
			{
				Vector3 v = BraveMathCollege.ClosestPointOnRectangle(point, base.specRigidbody.UnitBottomLeft, base.specRigidbody.UnitDimensions);
				result = Vector2.Distance(point, v) / 1.5f;
			}
			return result;
		}

		public float GetOverrideMaxDistance()
		{
			return -1f;
		}
	}
}
