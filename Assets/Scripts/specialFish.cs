using System;
using UnityEngine;

public class specialFish : MonoBehaviour
{
    public int points;
    public int speed;
    public int duration;

    public AudioSource nyom;
    private void OnBecameVisible()
    {
        if (nyom != null)
        {
            nyom.Play();
        }
    }
}
