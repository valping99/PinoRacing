
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Pickup : MonoBehaviour
{

    #region Variables

    [Header("Scripts")]
    public Character m_CharacterCollider;
    public CharacterController m_CharacterController;
    public SoundManagers m_SoundManager;

    [Header("Effects")]

    [Tooltip("Frequency at which the item will move up and down")]
    public float VerticalBobFrequency = 1f;

    [Tooltip("Distance the item will move up and down")]
    public float BobbingAmount = 1f;

    [Tooltip("Rotation angle per second")]
    public float RotatingSpeed = 360f;


    [Header("Variables")]
    [Tooltip("Sound played on pickup")]
    public AudioClip PickupSfx;

    public Rigidbody PickupRigidbody { get; private set; }

    public GameObject m_RootModel;
    public float m_Distance;

    Collider m_Collider;
    Vector3 m_StartPosition;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    protected virtual void Start()
    {
        PickupRigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();

        // Get scripts from Hirarchy
        m_CharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        m_CharacterCollider = m_CharacterController.GetComponentInChildren<Character>();
        m_SoundManager = GameObject.FindGameObjectWithTag("SoundManagers").GetComponent<SoundManagers>();

        // ensure the physics setup is a kinematic rigidbody trigger
        PickupRigidbody.isKinematic = true;
        m_Collider.isTrigger = true;

        // Remember start position for animation
        m_StartPosition = m_RootModel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBobbing();
        HandleRotation();

        CheckDistance(m_CharacterCollider.gameObject.transform, m_RootModel);
        CheckDistanceToDestroy(m_CharacterCollider.gameObject.transform, m_RootModel);
    }

    void OnTriggerEnter(Collider other)
    {
        Character pickingPlayer = other.GetComponent<Character>();

        if (other.gameObject.tag == "RootObject")
            OnPicked(pickingPlayer);
    }


    #endregion

    #region Class

    protected virtual void HandleBobbing()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
        m_RootModel.transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;
    }
    protected virtual void HandleRotation()
    {
        // Handle rotating
        m_RootModel.transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.World);
    }
    protected virtual void OnPicked(Character playerController)
    {
        // Play pickup sound
        PlayPickupFeedback();
    }

    protected virtual void CheckDistance(Transform m_PlayerPosition, GameObject _RootModel)
    {
        // Check distance
    }

    public void PlayPickupFeedback()
    {
        if (PickupSfx.name == "No19")
            m_SoundManager.PlaySound(SoundType.Damaged); // ice
        else if (PickupSfx.name == "No4")
            m_SoundManager.PlaySound(SoundType.Milk); // milk
        else if (PickupSfx.name == "No11")
            m_SoundManager.PlaySound(SoundType.DashBoost); // dash
        else if (PickupSfx.name == "No12")
            m_SoundManager.PlaySound(SoundType.Stick); // stick

    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (m_RootModel == null)
            return;

        Color c = Gizmos.color;
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(m_RootModel.transform.position, m_Distance);
    }
#endif

    void CheckDistanceToDestroy(Transform m_PlayerPosition, GameObject _RootModel)
    {
        if (Vector3.Distance(m_PlayerPosition.position, _RootModel.transform.position) <= 0.5f)
        {
            StartCoroutine(DestroyPickup());
        }
    }
    IEnumerator DestroyPickup()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    #endregion
}
