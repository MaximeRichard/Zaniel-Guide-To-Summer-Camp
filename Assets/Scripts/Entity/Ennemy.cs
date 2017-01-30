using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour
{
    public float maxLife;
    public float attackPower;
    float currentLife;

    public float CurrentLife { get { return currentLife; } }

    public void Setup()
    {
        currentLife = maxLife;
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
    }
}
