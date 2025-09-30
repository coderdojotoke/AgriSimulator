using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ClickPoint : MonoBehaviour
{
    public GameObject cube;
 
	void Update () {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(cube, hit.point, Quaternion.identity);
            }
        }
	}
 
}


