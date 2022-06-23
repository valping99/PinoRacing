using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    public Transform transformParent;
    public CharacterCollider charColl;
    public GameObject waterDrop;
    public UIManager managers;
    public float timerSpawn;

    public bool enableSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        transformParent = GameObject.FindGameObjectWithTag("RootObject").transform;
        managers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<CharacterCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managers.timeValueUp > 10)
        {
            if (enableSpawn)
            {
                //StartCoroutine(spawnAnimationWaterDrop());
                enableSpawn = false;
            }

        }
    }
    IEnumerator spawnAnimationWaterDrop()
    {
        Debug.Log("Spawn");
        GameObject clone = Instantiate(waterDrop, charColl.transform.position, this.transform.rotation, transformParent);
        clone.transform.Rotate(0,Random.Range(0,360),0);
        GameObject clone1 = Instantiate(waterDrop, charColl.transform.position, this.transform.rotation, transformParent);
        clone1.transform.Rotate(0, Random.Range(0, 360), 0);
        GameObject clone2 = Instantiate(waterDrop, charColl.transform.position, this.transform.rotation, transformParent);
        clone2.transform.Rotate(0, Random.Range(0, 360), 0);
        yield return new WaitForSeconds(timerSpawn);
        StartCoroutine(spawnAnimationWaterDrop());
    }
}
