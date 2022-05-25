/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{

    #region Variables
    [Tooltip("Maximum amount of Stamina")] public float MaxStamina = 10f;

    [Tooltip("Stamina ratio at which the critical Stamina vignette starts appearing")]
    public float CriticalStaminaRatio = 0.3f;

    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction<float> OnHealed;
    public UnityAction OnDie;

    public float CurrentStamina { get; set; }
    public bool Invincible { get; set; }
    public bool CanPickup() => CurrentStamina < MaxStamina;

    public float GetRatio() => CurrentStamina / MaxStamina;
    public bool IsCritical() => GetRatio() <= CriticalStaminaRatio;

    bool m_IsDead;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        CurrentStamina = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class

    public void Heal(float healAmount)
    {
        float staminaBefore = CurrentStamina;
        CurrentStamina += healAmount;
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);

        // call OnHeal action
        float trueHealAmount = CurrentStamina - staminaBefore;
        if (trueHealAmount > 0f)
        {
            OnHealed?.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (Invincible)
            return;

        float healthBefore = CurrentStamina;
        CurrentStamina -= damage;
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);

        // call OnDamage action
        float trueDamageAmount = healthBefore - CurrentStamina;
        if (trueDamageAmount > 0f)
        {
            OnDamaged?.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        CurrentStamina = 0f;

        // call OnDamage action
        OnDamaged?.Invoke(MaxStamina, null);

        HandleDeath();
    }

    void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (CurrentStamina <= 0f)
        {
            m_IsDead = true;
            OnDie?.Invoke();
        }
    }
    #endregion
}
