
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCurver : MonoBehaviour
{

    #region Variables
    [Range(-0.1f, 0.1f)]
    public float curveStrength = 0.01f;

    int m_CurveStrengthID;
    #endregion

    #region Unity Methods
    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
    }

    private void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
    }


    #endregion

    #region Class

    #endregion
}
