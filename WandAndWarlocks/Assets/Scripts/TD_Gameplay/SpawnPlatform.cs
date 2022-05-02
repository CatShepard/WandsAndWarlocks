using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public GameObject basicTowerPrefab;

    void OnMouseUpAsButton()
    {
        GameObject newTower = (GameObject)Instantiate(basicTowerPrefab);
        newTower.transform.position = transform.position + Vector3.up;
    }

}
