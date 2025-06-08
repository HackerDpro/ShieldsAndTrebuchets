using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;
    public float dayLength = 60f;

    private float time;

    void Update()
    {
        time += Time.deltaTime;
        float angle = (time / dayLength) * 360f;
        directionalLight.transform.rotation = Quaternion.Euler(angle, 170, 0);
    }
}