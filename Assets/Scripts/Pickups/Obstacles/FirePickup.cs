
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePickup : Pickup
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
        Fire firePickup = player.GetComponent<Fire>();
        if (firePickup && firePickup.CanPickup())
        {
            firePickup.TakeDamage(HurtAmount, gameObject);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }

    #endregion
}
