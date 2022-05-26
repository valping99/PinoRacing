/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stick : MonoBehaviour
{

    #region Variables
    [Tooltip("Maximum amount of Hurt")] public float MaxHurt = 10f;

    [Tooltip("Hurt ratio at which the critical Hurt vignette starts appearing")]
    public float CriticalHurtRatio = 0.3f;

    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction<float> OnHealed;
    public UnityAction OnDie;

    public float CurrentHurt { get; set; }
    public bool Invincible { get; set; }
    public bool CanPickup() => CurrentHurt < MaxHurt;

    public float GetRatio() => CurrentHurt / MaxHurt;
    public bool IsCritical() => GetRatio() <= CriticalHurtRatio;

    bool m_IsDead;
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

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (Invincible)
            return;

        float healthBefore = CurrentHurt;
        CurrentHurt -= damage;
        CurrentHurt = Mathf.Clamp(CurrentHurt, 0f, MaxHurt);

        // call OnDamage action
        float trueDamageAmount = healthBefore - CurrentHurt;
        if (trueDamageAmount > 0f)
        {
            OnDamaged?.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        CurrentHurt = 0f;

        // call OnDamage action
        OnDamaged?.Invoke(MaxHurt, null);

        HandleDeath();
    }

    void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (CurrentHurt <= 0f)
        {
            m_IsDead = true;
            OnDie?.Invoke();
        }
    }
    #endregion
}
