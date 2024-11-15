using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public Stat strength;
    public Stat maxHealth;
    public Stat damage;

    [SerializeField]private int currentHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DoDamage(CharacterStat targetStat)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();

        targetStat.TakeDamge(totalDamage);
    }

    protected virtual void TakeDamge(int damage)
    {
        currentHealth -= damage;

        Debug.Log(damage);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        
    }
}
