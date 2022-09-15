using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CPU : MonoBehaviour
{
    public PathCreator m_PathCreator;
    [Range(0, 30000)] public float m_DistanceLength;
    public GameObject _CPU;
    [SerializeField] public float CurrentSpeed;
#if UNITY_EDITOR
    private void OnGUI()
    {
        float t = m_PathCreator.path.length;
        //Debug.Log(t);
        GUILayout.Label(t.ToString());
    }
#endif
    private void FixedUpdate()
    {
        CharacterMove();
    }
    void CharacterMove()
    {
        m_DistanceLength += (CurrentSpeed * Time.deltaTime) / 10;

        Vector3 _tempDistance = m_PathCreator.path.GetPointAtDistance(m_DistanceLength);
        Vector3 _tempDistanceClearLag = m_PathCreator.path.GetPointAtDistance(m_DistanceLength - 20f);
        Vector3 _tempDistanceSpawner = m_PathCreator.path.GetPointAtDistance(m_DistanceLength + 60f);

        //Quaternion _tempRotation = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength + 7f);
        //Quaternion _tempRotationSpawner = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength + 60f);
        //Quaternion _tempRotationClearLag = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength - 7f);

        _CPU.transform.localPosition = _tempDistance;


        //_CPU.transform.localRotation = Quaternion.Lerp(_CPU.transform.localRotation, _tempRotation, 7f * Time.deltaTime);
    }
}


