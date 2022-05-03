using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic tower behavior w/ basic ray hit while within area
/// Make targeting system its own script, this is kludgy and dumb. as of now will only select new entries to sight radius
/// </summary>

public class BasicTower : MonoBehaviour
{

    //variables for controlling tower behavior
    [SerializeField]
    int rayDamage = 1; //basic damage per attack
    [SerializeField]
    float attackInterval = 1f; //basic interval between attacks (in seconds)
    [SerializeField]
    float turretSightRadius = 7f; //affects sphere collider of rigidBody; used to scale up & down sight radius via cards & upgrades

    bool hasTarget = false;
    bool onCooldown = false;
    Enemy_Footman currEnemy = null;

    //tmp floats for making tower capsule undulate up&down, (REPLACE WITH MORE ANIMATIONS) 
    public float sinAmplitude = 0.008f;
    public float cycleTime = .5f;
    private Vector3 tmpPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        tmpPosition = transform.position; //used for animating the capsulte up&down
        GetComponent<SphereCollider>().radius = turretSightRadius;
    }

    // Update is called once per frame
    void Update()
    {
        tmpPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * cycleTime) * sinAmplitude;
        transform.position = tmpPosition;

        //check to see if enemy is dead or just not selected
        if (currEnemy == null)
        {
            hasTarget = false;
        }
        //check to see if enemy has left turret sight radius
        else if (Vector3.Distance(currEnemy.GetComponent<Transform>().position, transform.position) > turretSightRadius + 1)
        {
            hasTarget = false;
            currEnemy = null;
        }


        if (hasTarget == true && onCooldown == false)
        {
            currEnemy.GetComponent<UnitHealth>().AdjustCurrentHealth(rayDamage * -1);
            //Debug.Log("Dist to Enemy: " + Vector3.Distance(currEnemy.GetComponent<Transform>().position, transform.position));
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(attackInterval);
        onCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTarget == false)
        {
            if (other.GetComponent<Enemy_Footman>())
            {
                hasTarget = true;
                currEnemy = other.GetComponent<Enemy_Footman>();
            }
        }
    }
}
