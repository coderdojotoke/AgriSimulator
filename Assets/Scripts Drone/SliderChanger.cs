using UnityEngine;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    public  static Slider tuihinokori;
    public  static float maxtuihi;
    public static float waru = 20.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxtuihi = CreateFloor.countField / waru; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
