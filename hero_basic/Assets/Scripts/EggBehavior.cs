using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    public const float kEggSpeed = 40f;
    public const int kLifetime = 300; // alive for this many cycles

    public int mLifeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        mLifeCount = kLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((kEggSpeed * Time.smoothDeltaTime) * transform.up);
        mLifeCount--;
        if(mLifeCount <= 0)
        {
            Destroy(transform.gameObject); // ends instance of self
        }
    }
}
