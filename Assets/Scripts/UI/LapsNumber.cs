using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsNumber : MonoBehaviour
{
    public List<GameObject> lapImages;
    public UIManager managers;
    public RaceCourse raceCrouses;
    public Transform transformParent;
    int lapCourse;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lapImages[0], transformParent.transform.position, Quaternion.identity, transformParent);
    }

    // Update is called once per frame
    void LateUpdate()
    {
    }

    public void checkLaps() 
    {
        lapCourse = raceCrouses.lapCourse;
        if (lapCourse == 2)
        {
            Instantiate(lapImages[1], transformParent.transform.position, Quaternion.identity, transformParent);
            Destroy(GameObject.Find("Lap_1(Clone)"));
        }
        else 
        {
            Instantiate(lapImages[2], transformParent.transform.position, Quaternion.identity, transformParent);
            Destroy(GameObject.Find("Lap_2(Clone)"));
        }
    }
}
