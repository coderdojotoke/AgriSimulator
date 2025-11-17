using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class InputFieldConverter : EditorWindow
{
    [MenuItem("Tools/Convert InputFields to TMP")]
    public static void ConvertInputFields()
    {
        InputField[] legacyFields = GameObject.FindObjectsOfType<InputField>();

        foreach (InputField legacy in legacyFields)
        {
            GameObject go = legacy.gameObject;

            // 保存用の情報
            string placeholderText = legacy.placeholder?.GetComponent<Text>()?.text;
            string inputText = legacy.text;

            // 削除
            DestroyImmediate(legacy);

            // 追加
            TMP_InputField tmpField = go.AddComponent<TMP_InputField>();

            // Textオブジェクトの置き換え
            TextMeshProUGUI tmpText = go.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpField.textComponent = tmpText;
                tmpText.text = inputText;
            }

            // プレースホルダーの設定
            TextMeshProUGUI tmpPlaceholder = go.transform.Find("Placeholder")?.GetComponent<TextMeshProUGUI>();
            if (tmpPlaceholder != null)
            {
                tmpField.placeholder = tmpPlaceholder;
                tmpPlaceholder.text = placeholderText;
            }

            Debug.Log($"Converted: {go.name}");
        }
    }
}