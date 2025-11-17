using UnityEngine;
using UnityEngine.UI;

public class GameClearScripts : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject homeButton;
    public Text timerText; // UIのTextコンポーネントをアタッチ
    private float elapsedTime = 0f; // 経過時間
    private bool isRunning = false; // ストップウォッチの状態


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    // Update is called once per frame
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
        if (other.gameObject.tag == "GameClear")
        {
            isRunning = false;
            panel.SetActive(true);
            homeButton.SetActive(true);
        }
    }
}

