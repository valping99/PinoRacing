using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpeed : MonoBehaviour
{
    [SerializeField] private GameObject _SpeedUp;
    [SerializeField] private GameObject _SpeedDown;
    [SerializeField] private Transform _TransformParent;
    [SerializeField] private float x_Axis;
    [SerializeField] private float y_Axis;

    public void PopupSpeedUp()
    {
        GameObject SpeedUp = Instantiate(_SpeedUp, _SpeedUp.transform.localPosition, Quaternion.identity, _TransformParent);
        RectTransform rt = SpeedUp.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 600, 0);
    }
    public void PopupSpeedDown()
    {
        GameObject SpeedDown = Instantiate(_SpeedDown, _SpeedDown.transform.localPosition, Quaternion.identity, _TransformParent);
        RectTransform rt = SpeedDown.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 600, 0);
    }
}
