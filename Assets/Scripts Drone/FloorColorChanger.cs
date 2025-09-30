using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloorColorChange : MonoBehaviour
{
    public GameObject DownPrefub;
    public GameObject rakkaseiPrefub;
    public float rotatex = -90.0f;
    public float rotatey = 19.3f;
    public float rotatez = 121.6f;
    public static bool gameClearbool;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FloorCube")
        {
            CreateFloor.countField -= 1;
            CreateFloor.tuihinokori.value = CreateFloor.countField;
            Vector3 currentPosition = transform.position;
            Destroy(gameObject);
            Instantiate(rakkaseiPrefub, currentPosition, quaternion.Euler(rotatex, rotatey, rotatez));
        }
    }
}
