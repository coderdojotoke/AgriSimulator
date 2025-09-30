using Unity.Mathematics;
//using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
//using UnityEngine.AI;
using UnityEngine.UI;

public class Controll : MonoBehaviour
{
    public InputField inputFieldx;
    public InputField inputFieldy;
    public InputField inputFieldz;
    private GameObject selectObject;
    private InputField setFieldx;
    private InputField setFieldy;
    private InputField setFieldz;
    private float setFieldFloatx;
    private float setFieldFloaty;
    private float setFieldFloatz;
    public Button btn;
    private string tagName;
    private bool isDragging;
    private float depth2;
    public GameObject myPrefub;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputFieldx = inputFieldx.GetComponent<InputField>();
        inputFieldy = inputFieldy.GetComponent<InputField>();
        inputFieldz = inputFieldz.GetComponent<InputField>();
        btn = btn.GetComponent<Button>();
        btn.interactable = false;
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
        setFieldx = inputFieldx.GetComponent<InputField>();
        setFieldy = inputFieldy.GetComponent<InputField>();
        setFieldz = inputFieldz.GetComponent<InputField>();
        setFieldFloatx = float.Parse(setFieldx.text);
        setFieldFloaty = float.Parse(setFieldy.text);
        setFieldFloatz = float.Parse(setFieldz.text);
        //Debug.Log(setFieldFloatx);
        Vector3 scale = selectObject.transform.localScale;
        float width = scale.x;
        float height = scale.y;
        float depth = scale.z;
        width = setFieldFloatx;
        height = setFieldFloaty;
        depth = setFieldFloatz;
        selectObject.transform.localScale = new Vector3(width, height, depth);
        btn.interactable = false;

    }

    public void ONButtonClick2()
    {
        Destroy(selectObject.gameObject);
    }
}
