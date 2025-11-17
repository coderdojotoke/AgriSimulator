using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextToTMPConverter : EditorWindow
{
    [MenuItem("Tools/Convert All Text to TextMeshPro")]
    public static void ConvertAllText()
    {
        var texts = Resources.FindObjectsOfTypeAll<Text>();
        int count = 0;

        foreach (var text in texts)
        {
            if (text == null || text.gameObject == null) continue;

            GameObject go = text.gameObject;
            string content = text.text;
            Font font = text.font;
            Color color = text.color;
            TextAnchor alignment = text.alignment;

            Undo.RecordObject(go, "Convert Text to TMP");

            Object.DestroyImmediate(text, true);

            var tmp = go.AddComponent<TextMeshProUGUI>();
            tmp.text = content;
            tmp.color = color;
            tmp.alignment = (TextAlignmentOptions)(int)alignment;
            tmp.fontSize = 24; // 適宜調整
            count++;
        }

        Debug.Log($"TextコンポーネントをTextMeshProUGUIに変換しました（{count}個）！");
    }
}