/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public struct ThemeZone
{
    public int length;
    public AssetReference[] prefabList;
}
[CreateAssetMenu(fileName = "themeData", menuName = "Trash Dash/Theme Data")]
public class ThemeData : MonoBehaviour
{

    #region Variables
    [Header("Theme Data")]
    public string themeName;
    public int cost;
    public int premiumCost;
    public Sprite themeIcon;

    [Header("Objects")]
    public ThemeZone[] zones;
    public GameObject collectiblePrefab;
    public GameObject premiumCollectible;

    [Header("Decoration")]
    public GameObject[] cloudPrefabs;
    public Vector3 cloudMinimumDistance = new Vector3(0, 20.0f, 15.0f);
    public Vector3 cloudSpread = new Vector3(5.0f, 0.0f, 1.0f);
    public int cloudNumber = 10;
    public Mesh skyMesh;
    public Mesh UIGroundMesh;
    public Color fogColor;
    #endregion

}
