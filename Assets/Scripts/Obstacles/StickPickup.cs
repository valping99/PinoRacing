/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of health to hurt player on pickup")]
    public float HurtAmount;
    public int StickAmount;

    #endregion

    #region Class

    protected override void OnPicked(CharacterCollider player)
    {
        Stick stickPickup = player.GetComponent<Stick>();
        if (stickPickup && stickPickup.CanPickup())
        {
            stickPickup.TakeDamage(HurtAmount, gameObject);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }

    #endregion
}
