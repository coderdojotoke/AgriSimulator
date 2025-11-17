using Unity.Mathematics;
//using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
//using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Controll : MonoBehaviour
{
    public TMP_InputField inputFieldx;
    public TMP_InputField inputFieldy;
    public TMP_InputField inputFieldz;
    //public InputField inputRotate;
    private GameObject selectObject;
    private TMP_InputField setFieldx;
    private TMP_InputField setFieldy;
    private TMP_InputField setFieldz;
    //private InputField setRotate;
    private float setFieldFloatx;
    private float setFieldFloaty;
    private float setFieldFloatz;
    //private float setFloatRotate;
    public Button btn;
    private string tagName;
    private bool isDragging;
    private float depth2;
    public GameObject myPrefub;
    public TMP_InputField inputFieldRotateY; // ←【追加】Y軸回転用のInputField
    private TMP_InputField setFieldRotateY;  // ←【追加】Y軸回転用の内部参照
    private float setFloatRotateY;      // ←【追加】Y軸回転値


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputFieldx = inputFieldx.GetComponent<TMP_InputField>();
        inputFieldy = inputFieldy.GetComponent<TMP_InputField>();
        inputFieldz = inputFieldz.GetComponent<TMP_InputField>();
        //inputRotate = inputRotate.GetComponent<InputField>();
        btn = btn.GetComponent<Button>();
        btn.interactable = false;
        inputFieldRotateY = inputFieldRotateY.GetComponent<TMP_InputField>(); 
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                tagName = hit.collider.gameObject.tag;
                if (tagName == "Houce")
                {
                    selectObject = hit.collider.gameObject;
                    inputFieldx.text = selectObject.transform.localScale.x.ToString("F0");
                    inputFieldy.text = selectObject.transform.localScale.y.ToString("F0");
                    inputFieldz.text = selectObject.transform.localScale.z.ToString("F0");
                    inputFieldRotateY.text = selectObject.transform.eulerAngles.y.ToString("F0"); // ←【追加】Y軸回転値を表示
                    //inputRotate.text = selectObject.transform.rotation.ToString("F0");
                    isDragging = true;
                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(selectObject.transform.position);
                    depth2 = screenPoint.z;
                    btn.interactable = true;
                }
                else if (tagName == "Floor")
                {
                    Vector3 hitPoint = hit.point;
                    float x = hitPoint.x;
                    float y = hitPoint.y;
                    float z = hitPoint.z;
                    y = 0f;
                    Instantiate(myPrefub, new Vector3(x, y, z), quaternion.identity);
                }
            }
        }
        else if (Input.GetMouseButton(0) && isDragging && selectObject != null)
        {
            Vector3 moucePosition = Input.mousePosition;
            moucePosition.z = depth2;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(moucePosition);
            selectObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }   
    }
    
    public void ONButtonClick()
    {
        setFieldx = inputFieldx.GetComponent<TMP_InputField>();
        setFieldy = inputFieldy.GetComponent<TMP_InputField>();
        setFieldz = inputFieldz.GetComponent<TMP_InputField>();
        //setRotate = inputRotate.GetComponent<InputField>();
        setFieldFloatx = float.Parse(setFieldx.text);
        setFieldFloaty = float.Parse(setFieldy.text);
        setFieldFloatz = float.Parse(setFieldz.text);
        //setFloatRotate = float.Parse(setRotate.text);
        //Debug.Log(setFieldFloatx);
        Vector3 scale = selectObject.transform.localScale;
        float width = scale.x;
        float height = scale.y;
        float depth = scale.z;
        width = setFieldFloatx;
        height = setFieldFloaty;
        depth = setFieldFloatz;
        selectObject.transform.localScale = new Vector3(width, height, depth);
        //selectObject. = Quaternion.Euler(0, angle, 0);
        setFieldRotateY = inputFieldRotateY.GetComponent<TMP_InputField>(); // ←【追加】Y軸回転InputFieldの取得
        setFloatRotateY = float.Parse(setFieldRotateY.text);            // ←【追加】Y軸回転値の取得

        // ←【追加】回転処理（Y軸のみ変更）
        Vector3 currentRotation = selectObject.transform.eulerAngles;
        selectObject.transform.rotation = Quaternion.Euler(currentRotation.x, setFloatRotateY, currentRotation.z);


        btn.interactable = false;

    }

    public void ONButtonClick2()
    {
        Destroy(selectObject.gameObject);
    }
}
