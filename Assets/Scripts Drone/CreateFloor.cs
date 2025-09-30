//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateFloor : MonoBehaviour
{
    //public GameObject cubePrefab;
    //public GameObject cube2Prefab;
    public int width = 10;
    public int height = 10;
    public float spacing = 1.0f;
    public GameObject[] prefabs;
    public static float countField;
    public static Slider tuihinokori;

    void Start()
    {
        GenerateFloor();
    }

    void GenerateFloor()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                if (randomIndex == 0)
                {
                    countField += 1;
                }
                GameObject selectedPrefab = prefabs[randomIndex];
                GameObject newCube = Instantiate(selectedPrefab);
                newCube.transform.position = new Vector3(x * spacing, 0, y * spacing);
                newCube.tag = "FloorCube";
                newCube.transform.parent = this.transform;
            }
        }
        tuihinokori.maxValue = countField;
        tuihinokori.value = countField;
    }
    void Update()
    {
        if (countField <= 0)
        {
            SceneManager.LoadScene("DroneClear");
        }
        if (CreateFloor.tuihinokori == null)
        {
            CreateFloor.tuihinokori = FindObjectOfType<Slider>();
        }

    }
}