using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// First pass on basic logic for exploding footman
/// Need abstracted enemy base class
/// should have enemies that don't explode, but rather wait at objective & just start doing damage till killed
/// </summary>
public class Enemy_Footman : MonoBehaviour
{
    [SerializeField]
    int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tower = GameObject.Find("WizardTower");

        if (tower)
            GetComponent<NavMeshAgent>().destination = tower.transform.position;
    }

    //function to trigger on hitting wizard's tower, dealing damage & destroying self.
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit on Tower: " + other.name);
        if (other.name == "WizardTower")
        {
            other.GetComponentInChildren<UnitHealth>().AdjustCurrentHealth(damage * -1);
            Destroy(gameObject);
        }
    }
}
