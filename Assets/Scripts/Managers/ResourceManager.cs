using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;

    public void AddWood(int amount)
    {
        wood += amount;
    }

    public void AddStone(int amount)
    {
        stone += amount;
    }
}