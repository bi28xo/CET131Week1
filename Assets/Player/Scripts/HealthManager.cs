using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 100f;

    void Hit(float RawDamage)
    {
        hitPoints -= RawDamage;

        Debug.Log("OUCH:" + hitPoints.ToString());

        if (hitPoints<=0)
        {
            Debug.Log("TODO: Game Over-You Died");
        }
    }
    public void SetHP(float HP)
    {
        hitPoints -= HP;
        Debug.Log("Hit From Trap"+HP.ToString());
    }
    
}
