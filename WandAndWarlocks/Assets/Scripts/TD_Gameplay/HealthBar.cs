using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kludgy quick & dirty health bar UI display system above enemies heads
/// linked to a textmesh for discrete health units for now
/// Jonathan has some UI ideas, work with him to replace this with that
/// also, poisoning/freezing/fire will be a thing, bring UI health display color under control to tweak that for status effects
/// </summary>
public class HealthBar : MonoBehaviour
{
    TextMesh tm;
    UnitHealth uh;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        uh = GetComponentInParent<UnitHealth>();
        SetHealthCells((int)uh.GetHealth());
    }

    // Update is called once per frame
    // Used to keep text bar facing forwards.
    void Update()
    {
        //used to keep health bar oriented towards player through turns
        transform.forward = Camera.main.transform.forward;

        //quick & dirty textbased health bars. (REPLACE WITH JONATHAN'S AWESOME UI STUFF)
        if (gameObject.name == "HealthBar_Max")
        {
            SetHealthCells((int)uh.GetMaxHealth());
        }
        else
        {
            SetHealthCells((int)uh.GetHealth());
        }
    }

    void SetHealthCells(int cellCount)
    {
        tm.text = "";

        for(int i = 0; i < cellCount; i++)
        {
            tm.text += "-";
        }
    }

    
}
