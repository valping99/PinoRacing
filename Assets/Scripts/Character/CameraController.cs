
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region Variables

    [SerializeField] Vector3 m_MoveOffset;
    [SerializeField] Vector3 m_RotationOffset;
    [SerializeField] float m_SmoothSpeed = 1f;
    [SerializeField] float m_RotationSpeed = 1f;
    [SerializeField] Transform m_Target;
    CharacterController m_Player;


    #endregion

    #region Unity Methods

    void Start()
    {
        m_Player = m_Target.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    #endregion

    #region Class


    void HandleTranslation()
    {
        Vector3 _TargetPos = new Vector3();
        _TargetPos = m_Target.TransformPoint(m_MoveOffset);

        //if user collect 6 crystal, camera will move to crystal position 
        // if (m_Player.IsFullCrystal)
        // {
        //     //Boost effect
        //     transform.position = Vector3.Lerp(transform.position, _TargetPos, m_SmoothSpeed * Time.deltaTime);
        // }
        transform.position = Vector3.Lerp(transform.position, _TargetPos, m_SmoothSpeed * Time.deltaTime);

    }

    void HandleRotation()
    {
        var _Direction = m_Target.position - transform.position;
        var _Rotation = new Quaternion();

        _Rotation = Quaternion.LookRotation(_Direction + m_RotationOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, _Rotation, m_RotationSpeed * Time.deltaTime);
    }

    #endregion
}
