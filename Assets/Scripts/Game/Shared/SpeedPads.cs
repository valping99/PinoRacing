/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>  
/// Brief summary of what the class does
/// </summary>
public class SpeedPads : MonoBehaviour
{

    #region Variables

    [Tooltip("Maximum amount of time")] public float MaxTime = 10f;

    [Tooltip("Hurt ratio at which the critical Hurt vignette starts appearing")]
    public float CriticalSpeedPadsRatio = 0.3f;
    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction<float> OnGot;
    public UnityAction OnDie;

    public float CurrentTime { get; set; }
    public bool Invincible { get; set; }
    public bool CanPickup() => CurrentTime < MaxTime;

    public float GetRatio() => CurrentTime / MaxTime;
    public bool IsCritical() => GetRatio() <= CriticalSpeedPadsRatio;

    bool m_IsDead;

    #endregion

    #region Life Cycle

    // LifeCycle Methods (Awake, OnEnable, OnDisable, OnDestroy)

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class
    public void Collect(int amountSpeedPads)
    {
        float milkBottleBefore = CurrentTime;
        CurrentTime += amountSpeedPads;
        CurrentTime = Mathf.Clamp(CurrentTime, 0f, MaxTime);

        // call OnHeal action
        float trueMilkBottleAmount = CurrentTime - milkBottleBefore;
        if (trueMilkBottleAmount > 0f)
        {
            OnGot?.Invoke(trueMilkBottleAmount);
        }
    }

    void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (CurrentTime <= 0f)
        {
            m_IsDead = true;
            OnDie?.Invoke();
        }
    }
    #endregion
}
