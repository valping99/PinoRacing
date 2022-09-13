
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
    public float m_DropSpeed = 7f;

    #endregion

    #region Class

    protected override void OnPicked(Character player)
    {
        //SpeedDown();
        PlayPickupFeedback();
        Destroy(gameObject);
    }

    protected override void CheckDistance(Transform _PlayerPosition, GameObject _RootModel)
    {
        float _speed = _PlayerPosition.GetComponent<Character>().m_CurrentSpeed;

        //Calculate distance and time to drop
        float _Distance = Vector3.Distance(transform.position, new Vector3(transform.position.x, 0, transform.position.z));
        // Time = Distance / Velocity
        float _tempTime = _Distance / m_DropSpeed;

        if (Vector3.Distance(transform.position, _PlayerPosition.position) < m_Distance)
        {
            // if distance of player to object is less than m_Distance, make object move down
            if (_RootModel.transform.position.y > 0)
            {
                //Move model down
                _RootModel.transform.position = Vector3.MoveTowards(_RootModel.transform.position,
                new Vector3(_RootModel.transform.position.x, 0, _RootModel.transform.position.z),
                (_tempTime * _speed) * Time.deltaTime);

                //Move collider down, must faster than model
                transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, 0, transform.position.z),
                (_tempTime * _speed) * 2 * Time.deltaTime);
            }
        }
    }

    protected override void HandleBobbing()
    {
        // Nothing to do here, because we don't want the object to bob up and down when it's floating in the air
    }

    #endregion
}
