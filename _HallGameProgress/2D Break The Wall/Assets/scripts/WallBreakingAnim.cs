using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakingAnim : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite hitOnce;
    public Sprite hitTwice;
    public Sprite hitThrice;

    //private float firstHitChangeTime = 1.25f;
    //private float secondHitChangeTime = 2.25f;
    //private float thirdHitChangeTime = 3.25f;
    //private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if(Health.hit1 == true)
        //{
        //    spriteRenderer.sprite = hitOnce;
        //}
        //if (Health.hit2 == true)
        //{
        //    spriteRenderer.sprite = hitTwice;
        //}
        //if (Health.hit3 == true)
        //{
        //    spriteRenderer.sprite = hitThrice;
        //}
    }
}
