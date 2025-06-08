using UnityEngine;

public class Crop : MonoBehaviour
{
    public float growTime = 10f;
    private float timer = 0f;
    private bool isGrown = false;

    void Update()
    {
        if (isGrown) return;
        timer += Time.deltaTime;
        if (timer >= growTime)
        {
            isGrown = true;
            Debug.Log("Crop fully grown!");
        }
    }
}