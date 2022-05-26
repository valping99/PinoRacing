/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : Pickup
{

    #region Variables

    [Header("Parameters")]

    [Tooltip("Amount of crystal to get on pickup")]
    public int amountCrystal;
    
    [Tooltip("Amount of time to wait before reboosting")]
    public float m_TimeBoost;
    #endregion

    #region Class
    protected override void OnPicked(CharacterCollider player)
    {
        Crystal playerCrystalable = player.GetComponent<Crystal>();
        if (playerCrystalable && playerCrystalable.CanPickup())
        {
            playerCrystalable.Collect(amountCrystal);
            Destroy(gameObject);
        }
    }
    #endregion
}
