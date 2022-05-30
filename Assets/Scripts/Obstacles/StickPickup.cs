/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StickPickup : Pickup
{

    #region Variables

    [Header("Parameters")]
    [Tooltip("Amount of health to hurt player on pickup")]
    public float HurtAmount;
    public int StickAmount;

    [Tooltip("Distance form player to object")]
    public float m_Distance;
    public float m_DropSpeed;

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

    protected override void CheckDistance(Transform m_PlayerPosition)
    {
        try
        {
            if (Vector3.Distance(transform.position, m_PlayerPosition.position) < m_Distance)
            {
                Debug.Log("Distance: SOS ");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
    }

    #endregion
}
