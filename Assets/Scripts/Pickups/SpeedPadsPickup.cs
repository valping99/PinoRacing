
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>  
/// Brief summary of what the class does
/// </summary>
public class SpeedPadsPickup : Pickup
{

    #region Variables

    [Header("Parameters")]

    public int amountSpeedPads = 1;
    [Tooltip("Time boost when pick up")]
    public float timeSpeedPads = 1f;

    #endregion

    #region Class
    protected override void OnPicked(Character player)
    {
        // SpeedPads speedPadsPickup = player.GetComponent<SpeedPads>();
        // if (speedPadsPickup && speedPadsPickup.CanPickup())
        // {
        //     speedPadsPickup.Collect(amountSpeedPads);
        //     Destroy(gameObject);
        // }
        PlayPickupFeedback();
        Destroy(gameObject);
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
