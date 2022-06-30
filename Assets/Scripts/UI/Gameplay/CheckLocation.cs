using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLocation : MonoBehaviour
{
    public CharacterController charInput;
    public GameObject spawner;
    public bool CheckSpawn;
    void Start()
    {
        charInput = FindObjectOfType<CharacterController>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void Update()
    {
        CheckSpawn = charInput.m_Stuns;
        this.transform.position = spawner.transform.position;
        this.transform.eulerAngles = spawner.transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("SpawnX"))
        {
            Debug.Log("test X");
        }
    }
}
