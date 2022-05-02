using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//temporary test function to see if the buff function works
public class TEST_BuffField : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy_Footman>())
        {
            other.GetComponent<UnitHealth>().TmpHealthAdjustment(3f, 3);
        }
    }

}
