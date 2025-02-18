using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoShow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private int isSelectedPinos;

    public Transform transformParent;

    public List<GameObject> pinoShow;
    public GameObject pinoOnly;
    public CharacterSelected charSelect;

    public bool IsShowPinos;
    #endregion
    #region Unity Method
    void Start()
    {
        charSelect = FindObjectOfType<CharacterSelected>();
        isSelectedPinos = charSelect.isSelected;
        if (IsShowPinos)
        {
            ShowPinos();
        }
        else
        {
            OnlyOne();
        }
    }
    #endregion
    #region Class
    void OnlyOne()
    {
        GameObject pinos = Instantiate(pinoOnly, this.transform.position, Quaternion.identity, transformParent);
        pinos.transform.localPosition = new Vector3(0, 0, 0);
    }

    void ShowPinos()
    {
        for(int i = 0; i <= pinoShow.Count; i++)
        {
            if (i == isSelectedPinos)
            {
                GameObject pinos = Instantiate(pinoShow[i-1], this.transform.position, Quaternion.identity, transformParent);
                pinos.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    #endregion
}
