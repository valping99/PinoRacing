using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCount : MonoBehaviour
{
    public int boostCount = 0;
    // Start is called before the first frame update

    public void Count()
    {
        if (boostCount >= 16)
        {
            boostCount = 16;
        }
        else
        {
            boostCount += 1;
        }
    }
}
