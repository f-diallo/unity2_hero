﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpBehavior : MonoBehaviour
{
    public Text mEnemyCountText = null;
    public Text mEggCountText = null;
    public Text mModeText = null;
    public float speed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; //90 degrees in 2 seconds
    public bool mFollowMousePosition = true;

    private int mPlanesTouched = 0;
    private int mEggCount = 0;

    private GameController mGameController = null;
    // Start is called before the first frame update
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;
            if(mFollowMousePosition){
                mModeText.text = "Mode: Mouse";
            }
            else{
                mModeText.text = "Mode: WASD";
            }
        }

        if (mFollowMousePosition)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("Position is " + pos);
            pos.z = 0f;  // <-- this is VERY IMPORTANT!
        }
        else{
            if (Input.GetKey(KeyCode.W))
            {
                pos += ((speed * Time.smoothDeltaTime) * transform.up);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pos -= ((speed * Time.smoothDeltaTime) * transform.up);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // PreFabs must be in the Resources Folder
            GameObject e = Instantiate(Resources.Load("PreFabs/Egg") as GameObject);
            ++mEggCount;
            mEggCountText.text = "Egg Count = " + mEggCount;
            e.transform.localPosition = transform.localPosition;
            e.transform.rotation = transform.rotation;
            Debug.Log("Spawn Eggs:" + e.transform.localPosition);
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is with plane
        //if(collision.gameObject.GetType() == typeof(Plane))
        if(collision.gameObject.tag == "planeEnemy")
        {
            Debug.Log("Here x Plane: OnTriggerEnter2D");
            mPlanesTouched++;
            mEnemyCountText.text = "Total Enemies: 10, Enemies Destroyed = " + mPlanesTouched;
            Destroy(collision.gameObject);
            mGameController.EnemyDestroyed();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Here x Plane: OnTriggerStay2D");
    }
}
