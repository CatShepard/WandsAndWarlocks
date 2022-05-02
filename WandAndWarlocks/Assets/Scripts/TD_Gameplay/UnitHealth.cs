using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic Health System
/// Converted from ints to floats
/// Quirk of behavior: as of now, temporary health buffs will defacto "heal" you due to the way I scripted flat max health debuffs. Can change if needed.
/// </summary>

public class UnitHealth : MonoBehaviour
{

    [SerializeField]
    float healthCurr = 1; //represents current unit health
    [SerializeField]
    float healthMax = 1; //represents max health of unit. ADD HOOKS FOR ADJUST UP/DOWN VIA BUFFS/DEBUFFS

    //getter function for current health
    public float GetHealth()
    {
        return healthCurr;
    }
    
    //getter function for maximum health
    public float GetMaxHealth()
    {
        return healthMax;
    }

    //setter function for adjusting current health
    public void AdjustCurrentHealth(float adjustAmount)
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
    //adjustments done proportionallyy
    public void AdjustMaxHealth(float adjPercent)
    {
        //casting to int in the below code + floor/ceiling are there to ensure at least one unit of health is lost on a buff or debuff (esp for low health enemies)
        int healthAlterationAmount = 0;
        if (adjPercent > 1)
        {
            healthAlterationAmount = (int)(Mathf.Ceil(adjPercent * healthMax) - healthMax);
        }
        else if (adjPercent < 1)
        {
            healthAlterationAmount = (int)(Mathf.Floor(adjPercent * healthMax) - healthMax);
        }
        healthMax += healthAlterationAmount;
        AdjustCurrentHealth(healthAlterationAmount);
    }

    //setter for adjusting maximum health by flat int (overloaded)
    //Doesn't do proportional adjustment
    public void AdjustMaxHealth(int adjAmount)
    {
        healthMax += adjAmount; 
        if (adjAmount > 0)
        {
            AdjustCurrentHealth(adjAmount);
        }
        else
        {
            AdjustCurrentHealth(0); //engages AdjustCurrentHealth to cut down health if the debuff has put the unit into a state of healthCurr above healthMax
        }
    }


    //THESE ARE TEMPORARY & REQUIRE TESTING
    //Temporary Health Buff/Debuff based on flat int buffs/debuffs)

    //I wrote this stupid, wanted to test functions NEED TO CLEAN THIS UP!
    public void TmpHealthAdjustment(float durationSeconds, int tmpHealthAdjust)
    {
        StartCoroutine(TmpHealthAdjust(durationSeconds, tmpHealthAdjust));
    }

    //Function to temporarily buff / debuff health, coroutine currently called above.
    private IEnumerator TmpHealthAdjust(float durationSeconds, int tmpHealthAdjust)
    {
        AdjustMaxHealth(tmpHealthAdjust);
        yield return new WaitForSeconds(durationSeconds);
        AdjustMaxHealth(tmpHealthAdjust * -1);
    }

    //Health Buff / Debuff over time system
    private IEnumerator HealthAdjustOverTime(float adjustmentMagnitude, float timePerTick, int tickCount)
    {
        for (int i = 0; i < tickCount; i++)
        {
            AdjustCurrentHealth(adjustmentMagnitude);
            yield return new WaitForSeconds(timePerTick);
        }
    }

}
