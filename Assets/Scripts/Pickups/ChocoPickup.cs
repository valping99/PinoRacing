/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoPickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public float HealAmount;

    #endregion

    #region Class

    protected override void OnPicked(CharacterCollider player)
    {
        Stamina playerStamina = player.GetComponent<Stamina>();
        if (playerStamina && playerStamina.CanPickup())
        {
            playerStamina.Heal(HealAmount);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
    #endregion
}
