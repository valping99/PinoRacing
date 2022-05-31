using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public Vector3 velocity = Vector3.zero;
    public Camera camera;

    public CharacterInputController charInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBoost();
    }
    public void checkBoost()
    {
        if (charInput.m_IsBoosting)
        {
            camera.fieldOfView = 75f;
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

            Debug.Log("IsBoosting");
        }
    }

}
