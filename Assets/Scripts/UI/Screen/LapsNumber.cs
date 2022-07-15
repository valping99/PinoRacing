using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsNumber : MonoBehaviour
{
    #region Variables
    public List<GameObject> lapImages;
    public UIManager managers;
    public RaceCourse raceCrouses;
    public Transform transformParent;
    public GameObject selectLaps;
    public bool checkIns = true;
    int lapCourse;

    #endregion
    // Start is called before the first frame update
    #region Unity Method
    void Start()
    {
        Instantiate(lapImages[0], transformParent.transform.position, Quaternion.identity, transformParent);
    }

    // Update is called once per frame
    void Update()
    {
        ReplaceLapBug();
    }
    #endregion

    #region Class
    public void checkLaps()
    {
        lapCourse = raceCrouses.lapCourse;
        if (lapCourse == 1)
        {
            Destroy(selectLaps);
            Instantiate(lapImages[0], transformParent.transform.position, Quaternion.identity, transformParent);
        }
        else if (lapCourse == 2)
        {
            Destroy(selectLaps);
            Instantiate(lapImages[1], transformParent.transform.position, Quaternion.identity, transformParent);
        }
        else if (lapCourse > 2)
        {
            Destroy(selectLaps);
            Instantiate(lapImages[2], transformParent.transform.position, Quaternion.identity, transformParent);
        }
    }

    void ReplaceLapBug()
    {
        selectLaps = GameObject.FindGameObjectWithTag("LapNumbers");
        if (checkIns)
        {
            //Force Delete
            if (managers.startScene)
            {
                Destroy(selectLaps);
            }
            else
            {
                checkIns = false;
                Destroy(selectLaps);
                raceCrouses.lapCourse = 1;
                Instantiate(lapImages[0], transformParent.transform.position, Quaternion.identity, transformParent);

            }
        }
    }
    #endregion
}
