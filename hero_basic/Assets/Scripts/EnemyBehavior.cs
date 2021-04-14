using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private int maxCollides = 4;
    private int numCollides = 0;

    private GameController mGameController = null;
    // Start is called before the first frame update
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is with egg
        Debug.Log("Something x Plane: OnTriggerEnter2D");
        if(collision.gameObject.tag == "eggBullet")
        {
            Debug.Log("Egg x Plane: OnTriggerEnter2D");
            numCollides++;
            //mEnemyCountText.text = "Planes Touched = " + mPlanesTouched;
            Destroy(collision.gameObject);//destroy egg
            if(numCollides == maxCollides)
            {
                Destroy(gameObject);//destroy plane
                mGameController.EnemyDestroyed();
            }
        }
    }
}
