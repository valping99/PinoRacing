
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Milk : MonoBehaviour
{

    #region Variables
    [Tooltip("Maximum amount of Milk Bottle")] public float MaxMilkBottle = 10f;

    [Tooltip("MilkBottle ratio at which the critical Milk Bottle vignette starts appearing")]
    public float CriticalMilkBottleRatio = 0.3f;

    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction<float> OnGot;
    public UnityAction OnDie;

    public float CurrentMilkBottle { get; set; }
    public bool Invincible { get; set; }
    public bool CanPickup() => CurrentMilkBottle < MaxMilkBottle;

    public float GetRatio() => CurrentMilkBottle / MaxMilkBottle;
    public bool IsCritical() => GetRatio() <= CriticalMilkBottleRatio;

    bool m_IsDead;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        CurrentMilkBottle = MaxMilkBottle;
    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class

    public void Collect(int amountMilkBottle)
    {
        float milkBottleBefore = CurrentMilkBottle;
        CurrentMilkBottle += amountMilkBottle;
        CurrentMilkBottle = Mathf.Clamp(CurrentMilkBottle, 0f, MaxMilkBottle);

        // call OnHeal action
        float trueMilkBottleAmount = CurrentMilkBottle - milkBottleBefore;
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
        if (CurrentMilkBottle <= 0f)
        {
            m_IsDead = true;
            OnDie?.Invoke();
        }
    }
    #endregion
}
