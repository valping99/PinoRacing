
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPadsPickup : Pickup
{

    #region Class
    protected override void OnPicked(Character player)
    {
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
