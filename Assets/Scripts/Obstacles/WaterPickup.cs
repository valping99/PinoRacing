/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of health to hurt player on pickup")]
    public float HurtAmount;
    public float LostSpeed;

    #endregion

    #region Class

    protected override void OnPicked(CharacterCollider player)
    {
        Water waterPickup = player.GetComponent<Water>();
        if (waterPickup && waterPickup.CanPickup())
        {
            waterPickup.TakeDamage(HurtAmount, gameObject);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }

    #endregion
}
