
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of speed to boost on pickup")]
    public int amountMilkBottle;

    #endregion

    #region Class
    protected override void OnPicked(Character player)
    {
        SpeedUp();
        PlayPickupFeedback();
        Destroy(gameObject);
    }
    #endregion
}
