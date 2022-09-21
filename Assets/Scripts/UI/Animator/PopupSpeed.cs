using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpeed : MonoBehaviour
{
    #region Variables
    [Tooltip("Popup Speed")]
    [HideInInspector] private GameObject _SpeedUp;
    [HideInInspector] private GameObject _SpeedDown;

    [Tooltip("Position")]
    [SerializeField] private Transform _TransformParent;
    [SerializeField] private float x_Axis;
    [SerializeField] private float y_Axis;

    [Header("Popup Objects")]
    [SerializeField] private GameObject _SpeedUpEnable;
    [SerializeField] private GameObject _SpeedDownEnable;

    [Tooltip("Time")]
    [SerializeField] private float _Time;

    [Tooltip("Check Enable")]
    [HideInInspector] private bool _SpeedUpCheck;
    [HideInInspector] private bool _SpeedDownCheck;

    #endregion

    #region Unity Method
    private void Start()
    {
        _SpeedUpEnable.gameObject.SetActive(false);
        _SpeedDownEnable.gameObject.SetActive(false);
    }
    #endregion

    #region Function
    public void PopupSpeedUp()
    {
        GameObject SpeedUp = Instantiate(_SpeedUp, _SpeedUp.transform.localPosition, Quaternion.identity, _TransformParent);
        RectTransform rt = SpeedUp.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(.5f, 1f);
        rt.anchorMax = new Vector2(.5f, 1f);
        rt.pivot = new Vector2(.5f, .5f);
        rt.localPosition = new Vector3(0, 200f, 0);
    }
    public void PopupSpeedDown()
    {
        GameObject SpeedDown = Instantiate(_SpeedDown, _SpeedDown.transform.localPosition, Quaternion.identity, _TransformParent);
        RectTransform rt = SpeedDown.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(.5f, 1f);
        rt.anchorMax = new Vector2(.5f, 1f);
        rt.pivot = new Vector2(.5f, .5f);
        rt.localPosition = new Vector3(0, 200f, 0);
    }

    public void EnableSpeedUp()
    {
        if (_SpeedDownCheck)
        {
            _SpeedDownEnable.gameObject.SetActive(false);
        }
        StartCoroutine(SpeedUP());
    }

    IEnumerator SpeedUP()
    {
        _SpeedUpCheck = true;
        _SpeedUpEnable.gameObject.SetActive(true);
        yield return new WaitForSeconds(_Time);
        _SpeedUpCheck = false;
        _SpeedUpEnable.gameObject.SetActive(false);
    }

    public void EnableSpeedDown()
    {
        if (_SpeedUpCheck)
        {
            _SpeedUpEnable.gameObject.SetActive(false);
        }
        StartCoroutine(SpeedDown());
    }

    IEnumerator SpeedDown()
    {
        _SpeedDownCheck = true;
        _SpeedDownEnable.gameObject.SetActive(true);
        yield return new WaitForSeconds(_Time);
        _SpeedDownCheck = false;
        _SpeedDownEnable.gameObject.SetActive(false);
    }
    #endregion
}
