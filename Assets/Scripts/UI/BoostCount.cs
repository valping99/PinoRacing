using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCount : MonoBehaviour
{
    public int boostCount = 16;
    protected UIManager uiManagers;
    // Start is called before the first frame update

    public void Count()
    {
        if (boostCount <= 0)
        {
            boostCount = 0;
        }
        else
        {
            boostCount -= 1;
        }
    }
}
