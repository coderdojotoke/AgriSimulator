using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class SunMoveTest : MonoBehaviour
{
    public TMP_InputField dateInput;
    public TMP_InputField latitudeInput;
    public TMP_InputField longitudeInput;
    public Slider timeSlider;
    public Light sunLight;

    private DateTime selectedDate = DateTime.Now;
    private float latitude = 35.6895f;   // 初期値：東京
    private float longitude = 139.6917f; // 初期値：東京

    public void OnSubmit()
    {
        // 日付の入力を確認
        if (DateTime.TryParse(dateInput.text, out DateTime parsedDate))
            selectedDate = parsedDate;

        // 緯度・経度の入力を確認
        if (float.TryParse(latitudeInput.text, out float lat))
            latitude = lat;
        if (float.TryParse(longitudeInput.text, out float lon))
            longitude = lon;
        Debug.Log("日付は、" + parsedDate);
        Debug.Log("緯度は、" + lat);
        Debug.Log("経度は、" + lon);

        UpdateSunDirection();
    }

    public void UpdateSunDirection()
    {
        float timeOfDay = timeSlider.value;
        Vector3 sunDirection = CalculateSunDirection(selectedDate, timeOfDay, latitude, longitude);
        sunLight.transform.rotation = Quaternion.LookRotation(sunDirection);
    }

    Vector3 CalculateSunDirection(DateTime date, float time, float lat, float lon)
    {
        float dayOfYear = date.DayOfYear;
        float declination = 23.44f * Mathf.Cos((360f / 365f) * (dayOfYear + 10) * Mathf.Deg2Rad);
        float hourAngle = time * 15f;

        float altitude = Mathf.Asin(
            Mathf.Sin(lat * Mathf.Deg2Rad) * Mathf.Sin(declination * Mathf.Deg2Rad) +
            Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Cos(declination * Mathf.Deg2Rad) * Mathf.Cos(hourAngle * Mathf.Deg2Rad)
        );

        float azimuth = Mathf.Atan2(
            -Mathf.Sin(hourAngle * Mathf.Deg2Rad),
            Mathf.Tan(declination * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad) -
            Mathf.Sin(lat * Mathf.Deg2Rad) * Mathf.Cos(hourAngle * Mathf.Deg2Rad)
        );

        float x = Mathf.Cos(altitude) * Mathf.Sin(azimuth);
        float y = Mathf.Sin(altitude);
        float z = Mathf.Cos(altitude) * Mathf.Cos(azimuth);

        return new Vector3(x, y, z);
    }
}
