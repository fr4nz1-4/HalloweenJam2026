using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    public GameObject[] fishPositions;
    public GameObject[] fishTypes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var t in fishPositions)
        {
            t.tag = "specialFish";
            var rand = Random.Range(0, fishTypes.Length);
            Instantiate(fishTypes[rand], t.transform.position, Quaternion.identity);
            Debug.Log("instantiate fish: " + t.name);
        }
    }
}
