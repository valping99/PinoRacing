using UnityEngine;

public class DashBoostCamera : MonoBehaviour
{
    [SerializeField]
    private CharacterInputController charInput;

    [SerializeField]
    private CharacterCollider charColl;

    public bool checkSpeed = false;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        charInput = FindObjectOfType<CharacterInputController>();
        charColl = FindObjectOfType<CharacterCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldCamera();
    }

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

        if (charInput.m_IsRemainBoost || charInput.m_PadsIsBoosting)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 100, 3f * Time.deltaTime);
        }
        else if (charInput.m_PadsIsBoosting && checkSpeed)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 120, 3f * Time.deltaTime);
        }
        else if (checkSpeed)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 100, .5f * Time.deltaTime);
        }
        else if (charInput.m_Stuns)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 50, 2.5f * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70, 1.5f * Time.deltaTime);
        }

    }
}

