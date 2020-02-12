using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OnObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Vector3 pos;
    public GameObject spawnee;
    public Transform spawnPos;
    Vector3 vec = new Vector3(7,0,0);
    int nb = 0;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.gameObject != null)
                {
                    Destroy(hit.collider.gameObject);
                }

            }
        }
        if (Input.GetMouseButtonDown(0))
        {

           /* if (Physics.Raycast(ray, out hit))
            {*/
                Instantiate(spawnee);
                spawnee.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
          


        }

        
    }
}
