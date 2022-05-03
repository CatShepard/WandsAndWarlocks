using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Ray : Tower_Base
{
    // TEMPORARY - Variables for controlling tower motion 
    [SerializeField] float sinAmplitude = .007f;
    [SerializeField] float cycleTime = 0.5f;
    private Vector3 tmpPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        tmpPosition = transform.position; // TEMPORARY - remove once we have permanent tower art
    }

    // Update is called once per frame
    void Update()
    {
        TowerMotion(); // TEMPORARY - remove once we have permanent tower art

        if (!onCooldown)
        {
            if (currentTarget != null)
            {
                FireWeapon();
            }
            else
            {
                TargetNearestEnemy(); // NOTE - once we have multiple targetting methods, we'll have method chosen by a customizable tower data field
            }
        }
    }

    // TEMPORARY - Rotating & bouncing the tower for a temporary visual till we have assets
    public void TowerMotion()
    {
        tmpPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * cycleTime) * sinAmplitude;
        transform.position = tmpPosition;
    }

    // Firing Mechanism
    public void FireWeapon()
    {
        if (currentTarget != null)
        {
            currentTarget.GetComponent<UnitHealth>().AdjustCurrentHealth(baseDamage * -1);
            StartCoroutine(Cooldown());
        }
    }

}
