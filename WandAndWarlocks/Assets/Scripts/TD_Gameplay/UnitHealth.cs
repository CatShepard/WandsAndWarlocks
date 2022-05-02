using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic Health System
/// Expansion: May convert health from ints to floats to allow for turret upgrades & incremental damage increases
/// </summary>

public class UnitHealth : MonoBehaviour
{

    [SerializeField]
    int healthCurr = 1; //represents current unit health
    [SerializeField]
    int healthMax = 1; //represents max health of unit. ADD HOOKS FOR ADJUST UP/DOWN VIA BUFFS/DEBUFFS

    //getter function for current health
    public int GetHealth()
    {
        return healthCurr;
    }

    public int GetMaxHealth()
    {
        return healthMax;
    }

    //setter function for adjusting current health
    public void AdjustCurrentHealth(int adjustAmount)
    {
        //Logic is to adjust first, then check for bounding conditions
        healthCurr += adjustAmount;

        //Can't go overhealth; pegs current to maxhealth        
        if (healthCurr > healthMax)
        {
            healthCurr = healthMax;
        }

        //if adjustment brings health to zero or lower, destroy (NEED ADD HOOKS LATER)
        else if (healthCurr <= 0)
        {
            Destroy(gameObject);
        }
    }

    //setter for adjusting maximum health by percentage (overloaded)
    //buff will adjust health up proportionally (rounded up)
    //debuff will adjust health down proportionally (rounded down; may kill)
    public void adjustMaxHealth(float adjPercent)
    {
        int healthBuff = 0;
        if (adjPercent > 1)
        {
            healthBuff = (int) Mathf.Ceil(adjPercent * healthMax) - healthMax;
        }
        else if (adjPercent < 1)
        {
            int healthDebuff = (int)Mathf.Floor(adjPercent * healthMax) - healthMax;
        }
        healthMax = healthMax + healthBuff;
        AdjustCurrentHealth(healthBuff);
    }

    //setter for adjusting maximum health by flat int (overloaded)

}
