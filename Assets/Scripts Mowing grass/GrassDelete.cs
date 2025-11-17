using TMPro;
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
    //public TextMeshPro timerText; // UIのTextコンポーネントをアタッチ
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f; // 経過時間
    private bool isRunning = false; // ストップウォッチの状態
    public TextMeshProUGUI Timetext;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        TerrainData runtimeData = Instantiate(terrain.terrainData);
        terrain.terrainData = runtimeData;
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
         if (isRunning)
        {
            elapsedTime += Time.deltaTime; // 経過時間を加算
            int seconds = Mathf.FloorToInt(elapsedTime); // 秒単位に変換
            timerText.text = seconds.ToString(); // テキストに表示
        }
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
            isRunning = false;
            //Timetext = timerText;
            canvas.gameObject.SetActive(true);
            Timetext.text = "今回のタイム:" + elapsedTime.ToString("F0") + "秒";
            Debug.Log(timerText);
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


