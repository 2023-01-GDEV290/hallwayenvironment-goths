using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    float scale = 0.05f;
    float decreaseTimer = 0.4f;
    float despawnTimer = 0.8f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= decreaseTimer)
        {
            scale += 0.22f;
            transform.localScale = new Vector2(scale, scale);
            
        }
        if(timer >= decreaseTimer)
        {
            scale += 0.22f * -1;
            transform.localScale = new Vector2(scale, scale);
        }

        if (timer >= despawnTimer)
        {
            Destroy(gameObject);
        }
           
    }
}
