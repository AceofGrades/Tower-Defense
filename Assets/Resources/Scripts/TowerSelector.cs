using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public int currentTower = 1;

    public void SpawnTower(Vector3 position)
    {
        // Load the Tower Resource
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/Tower " + currentTower);
        // Spawn new Instance
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Perform Raycast from ScreenPointToRay
        RaycastHit hit;
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit))
        {
            // If we hit a 'Placeable' & spot not taken
            Placeable p = hit.collider.GetComponent<Placeable>();
            if (p && !p.isOccupied)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Place tower on 'Placeable'
                    currentTower = 1;
                    SpawnTower(hit.transform.position);
                    p.isOccupied = true;
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    currentTower = 2;
                    SpawnTower(hit.transform.position);
                    p.isOccupied = true;
                }
            }
        }
    }

}
