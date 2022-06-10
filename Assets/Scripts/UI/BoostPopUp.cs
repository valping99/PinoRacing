using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostPopUp : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }
    public void Setup(int boostNumber)
    {
        textMesh.SetText(boostNumber.ToString());
    }
}
