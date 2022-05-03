using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Base : MonoBehaviour
{
    // Tower Attributes (accessible in inspector for experimentation)
    [SerializeField] protected int baseDamage = 1; //basic per attaqck damage
    [SerializeField] protected float baseAttackInterval = 1f; //basic interval between attacks
    [SerializeField] protected float turretSightRadius = 7f; //basic sight radius of tower

    // Tower Behavioral Traits (used for governing behavior)
    protected GameObject currentTarget = null; //current active target
    protected List<GameObject> validTargets = new List<GameObject>(); //list of current valid targets
    protected bool hasTarget = false; //used to dictate whether tower currently has an active target
    protected bool onCooldown = false; //used to dictate whether the tower is cooling from last fire

    // Cooldown counter to be used to meter out attacks from tower.
    protected IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(baseAttackInterval);
        onCooldown = false;
    }

    // Used to adjust sight radius in case of tower buff / debuff
    public void ImplementSightRadius(float radius)
    {
        GetComponent<SphereCollider>().radius = radius;
    }

    // Used to tag valid targets & add them to target list
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("validEnemy"))
        {
            validTargets.Add(other.gameObject);
        }
    }

    // Used to remove targets when they exit scope
    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("validEnemy"))
        {
            validTargets.Remove(other.gameObject);
        }
    }

    //Function for selecting target out of target list
    // NOTE - clean this up & make multiple firing methods that is tower selectable (nearest enemy, closest to base, type specific prioritization)
    public void TargetNearestEnemy()
    {
        validTargets.RemoveAll(delegate (GameObject o) { return o == null; }); // NOTE Need to confirm computational cost of this operation, maybe find some efficiency

        if (validTargets.Count != 0)
        {
            if (currentTarget == null)
            {
                GameObject tmpObject = null;
                float tmpDistance = float.MaxValue;

                foreach (GameObject target in validTargets)
                {
                    if (tmpDistance > Vector3.Distance(target.GetComponent<Transform>().position, transform.position))
                    {
                        tmpObject = target;
                        tmpDistance = Vector3.Distance(target.GetComponent<Transform>().position, transform.position);
                    }
                }
                currentTarget = tmpObject;
            }
        }
    }

}
