using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ResourceManager resourceManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}