
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of health to hurt player on pickup")]
    public float HurtAmount;
    public float LostSpeed;

    #endregion

    #region Class

    protected override void OnPicked(Character player)
    {
        // Ice icePickup = player.GetComponent<Ice>();

        // if (icePickup && icePickup.CanPickup())
        // {
        // icePickup.TakeDamage(HurtAmount, gameObject);
        PlayPickupFeedback();
        Destroy(gameObject);
        // }
    }

    protected override void HandleBobbing()
    {
        // Nothing to do here, because we don't want the object to bob up and down when it's floating in the air
    }

    protected override void HandleRotation()
    {
        // Nothing to do here, because we don't want the object to rotate when it's floating in the air
    }

    #endregion
}
