using UnityEngine;
using UnityEngine.UI;

public class GrassDelete : MonoBehaviour
{
    public float grassClearRadius = 5f;
    public int detailLayer = 0;
    private Terrain terrain;
    public Canvas canvas;
    public Slider nokori;
    public Text nokoriText;
    public int nokoriTextText;
    public int pasent = 100;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        TerrainData runtimeData = Instantiate(terrain.terrainData);
        terrain.terrainData = runtimeData;
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            nokori.value -= 5;
            ClearGrass(transform.position, grassClearRadius);
            Destroy(other);
        }
        else if (other.gameObject.tag == "GameClear")
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void ClearGrass(Vector3 pos, float radius)
    {
        if (terrain == null) return;
        TerrainData data = terrain.terrainData;
        int detailResolution = data.detailResolution;

        Vector3 terrainPos = pos - terrain.transform.position;
        int centerX = (int)(terrainPos.x / data.size.x * detailResolution);
        int centerY = (int)(terrainPos.z / data.size.z * detailResolution);
        int size = Mathf.CeilToInt(radius / data.size.x * detailResolution);

        int[,] cleared = new int[size, size];
        data.SetDetailLayer(centerX - size / 2, centerY - size / 2, detailLayer, cleared);
    }
}


