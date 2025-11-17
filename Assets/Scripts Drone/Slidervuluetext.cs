using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sliderculuetext : MonoBehaviour
{
    public Slider slider; // スライダーをアタッチ
    public TextMeshProUGUI valueText; // 値を表示するテキストをアタッチ

    void Start()
    {
        // 初期値を表示
        UpdateValueText(slider.value);

        // スライダーの値が変更されたときに呼ばれるイベントを設定
        slider.onValueChanged.AddListener(UpdateValueText);
    }

    void UpdateValueText(float value)
    {
        // スライダーの値をテキストに反映
        valueText.text = "残り" + value.ToString("F0") + "個"; // 小数点1桁まで表示
    }
}
