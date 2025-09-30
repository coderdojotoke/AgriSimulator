using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MoveSun : MonoBehaviour
{
    public Slider slider;
    public GameObject targetObject;
    private float InputValue;
    private float InputValue2;

    void Update()
    {
        float scaleValue = slider.value;
        MoveSunSun(scaleValue);

    }

    private void MoveSunSun(float InputValue)
    {
        InputValue2 = InputValue * 15;
        targetObject.transform.rotation = Quaternion.Euler(InputValue2, 100, 0);
    }
    
} 
       
 