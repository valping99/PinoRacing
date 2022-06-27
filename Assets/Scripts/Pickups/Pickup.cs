
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

    [Header("Effects")]

    [Tooltip("Frequency at which the item will move up and down")]
    public float VerticalBobFrequency = 1f;

    [Tooltip("Distance the item will move up and down")]
    public float BobbingAmount = 1f;

    [Tooltip("Rotation angle per second")] public float RotatingSpeed = 360f;

    [Tooltip("Sound played on pickup")] public AudioClip PickupSfx;
    [Tooltip("VFX spawned on pickup")] public GameObject PickupVfxPrefab;

    public Rigidbody PickupRigidbody { get; private set; }

    public GameObject m_RootModel;
    public float m_Distance;

    Collider m_Collider;
    Vector3 m_StartPosition;
    bool m_HasPlayedFeedback;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    protected virtual void Start()
    {
        PickupRigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();

        m_CharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        m_CharacterCollider = m_CharacterController.GetComponentInChildren<Character>();

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

        if (pickingPlayer != null)
        {
            OnPicked(pickingPlayer);
        }
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
        if (m_HasPlayedFeedback)
            return;

        if (PickupSfx)
        {
            AudioUtility.CreateSFX(PickupSfx, m_RootModel.transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        if (PickupVfxPrefab)
        {
            var pickupVfxInstance = Instantiate(PickupVfxPrefab, m_RootModel.transform.position, Quaternion.identity);
        }

        m_HasPlayedFeedback = true;
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
