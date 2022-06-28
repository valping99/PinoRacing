using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsNumber : MonoBehaviour
{
    public List<GameObject> lapImages;
    public UIManager managers;
    public RaceCourse raceCrouses;
    public Transform transformParent;
    public GameObject selectLaps;
    int lapCourse;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lapImages[0], transformParent.transform.position, Quaternion.identity, transformParent);
    }

    // Update is called once per frame
    void Update()
    {
        selectLaps = GameObject.FindGameObjectWithTag("LapNumbers");
    }

    public void checkLaps() 
    {
        lapCourse = raceCrouses.lapCourse;
        if (lapCourse == 2)
        {
            Destroy(selectLaps);
            Instantiate(lapImages[1], transformParent.transform.position, Quaternion.identity, transformParent);
        }
        else if(lapCourse >2)
        {
            Destroy(selectLaps);
            Instantiate(lapImages[2], transformParent.transform.position, Quaternion.identity, transformParent);
        }
    }
}
