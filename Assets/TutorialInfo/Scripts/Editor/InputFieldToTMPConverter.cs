using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldToTMPConverter : EditorWindow
{
    [MenuItem("Tools/Convert InputFields to TMP_InputFields")]
    public static void ConvertInputFields()
    {
        var inputFields = Resources.FindObjectsOfTypeAll<InputField>();
        int count = 0;

        foreach (var inputField in inputFields)
        {
            if (inputField == null || inputField.gameObject == null) continue;

            GameObject go = inputField.gameObject;
            Undo.RecordObject(go, "Convert InputField to TMP_InputField");

            // 保存しておく情報
            string text = inputField.text;
            string placeholderText = inputField.placeholder is Text placeholder ? placeholder.text : "";

            // 削除
            Object.DestroyImmediate(inputField, true);

            // TMP_InputField追加
            var tmpInput = go.AddComponent<TMP_InputField>();

            // Textオブジェクトの再構成
            Transform textArea = go.transform.Find("Text Area");
            if (textArea != null)
            {
                Transform textTransform = textArea.Find("Text");
                if (textTransform != null)
                {
                    var tmpText = textTransform.GetComponent<TextMeshProUGUI>();
                    if (tmpText == null)
                        tmpText = textTransform.gameObject.AddComponent<TextMeshProUGUI>();
                    tmpText.text = text;
                    tmpInput.textComponent = tmpText;
                }

                Transform placeholderTransform = textArea.Find("Placeholder");
                if (placeholderTransform != null)
                {
                    var tmpPlaceholder = placeholderTransform.GetComponent<TextMeshProUGUI>();
                    if (tmpPlaceholder == null)
                        tmpPlaceholder = placeholderTransform.gameObject.AddComponent<TextMeshProUGUI>();
                    tmpPlaceholder.text = placeholderText;
                    tmpInput.placeholder = tmpPlaceholder;
                }
            }

            tmpInput.text = text;
            tmpInput.interactable = true;
            count++;
        }

        Debug.Log($"InputFieldをTMP_InputFieldに変換しました（{count}個）！");
    }
}