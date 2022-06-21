
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowingCamera : MonoBehaviour
{

    #region Variables

    // Constant Fields

    // Static Fields

    // Fields

    // Constructors

    // Properties

    // Events / Delegates

    // Public Methods

    // Private Methods
    [SerializeField] Vector3 m_MoveOffset;
    [SerializeField] Vector3 m_RotationOffset;
    [SerializeField] float m_SmoothSpeed;
    [SerializeField] float m_RotationSpeed;
    [SerializeField] Transform m_Target;
    // Nested types


    #endregion

    #region Life Cycle

    // LifeCycle Methods (Awake, OnEnable, OnDisable, OnDestroy)

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Target = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
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
