
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crystal : MonoBehaviour
{

    #region Variables
    [Tooltip("Maximum amount of Crystal")] public float MaxCrystalable = 10f;

    [Tooltip("Crystalable ratio at which the critical Crystal vignette starts appearing")]
    public float CriticalCrystalableRatio = 0.3f;

    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction<float> OnGot;
    public UnityAction OnDie;

    public float CurrentCrystalable { get; set; }
    public bool Invincible { get; set; }
    public bool CanPickup() => CurrentCrystalable < MaxCrystalable;

    public float GetRatio() => CurrentCrystalable / MaxCrystalable;
    public bool IsCritical() => GetRatio() <= CriticalCrystalableRatio;

    bool m_IsDead;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        CurrentCrystalable = MaxCrystalable;
    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class
    public void Collect(int amountCrystal)
    {
        float crystalAmountBefore = CurrentCrystalable;
        CurrentCrystalable += amountCrystal;
        CurrentCrystalable = Mathf.Clamp(CurrentCrystalable, 0f, MaxCrystalable);

        // call OnHeal action
        float trueMilkBottleAmount = CurrentCrystalable - crystalAmountBefore;
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
        if (CurrentCrystalable <= 0f)
        {
            m_IsDead = true;
            OnDie?.Invoke();
        }
    }
    #endregion
}
