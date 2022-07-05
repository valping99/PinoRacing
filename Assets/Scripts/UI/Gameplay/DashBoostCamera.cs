using UnityEngine;

public class DashBoostCamera : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private CharacterController charInput;

    [SerializeField]
    private Character charColl;

    public bool checkSpeed = false;
    public Camera mainCamera;
    #endregion
    #region Unity Method
    void Start()
    {
        charInput = FindObjectOfType<CharacterController>();
        charColl = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldCamera();
    }

    #endregion
    #region Class
    private void FieldCamera()
    {
        if (charColl.m_CurrentSpeed >= charColl.m_MaxSpeed)
        {
            checkSpeed = true;
        }
        else
        {
            checkSpeed = false;
        }
        if (charInput.m_IsRemainBoost && charInput.m_PadsIsBoosting)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 120, 3f * Time.deltaTime);
        }
        
        else if (charInput.m_IsRemainBoost || charInput.m_PadsIsBoosting)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 100, 3f * Time.deltaTime);
        }
        else if (charInput.m_PadsIsBoosting && checkSpeed)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 120, 3f * Time.deltaTime);
        }
        else if (charInput.m_Stuns)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 60, 2.5f * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70, 1.5f * Time.deltaTime);
        }

    }
    #endregion
}

