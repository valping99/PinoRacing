using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CurvedControls : MonoBehaviour
{
    #region Test Curved world
    [Range(-0.1f, 0.1f)]
	public float curveStrength = 0.0005f;

	int m_CurveStrengthID;

	private void OnEnable()
	{
		m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
	}

	void Update()
	{
		Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
	}
    #endregion
}
