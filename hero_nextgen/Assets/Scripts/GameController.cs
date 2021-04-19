using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int maxPlanes = 10;
    private int numberOfPlanes = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
#if UNITY_EDITOR
            // Application.Quit() does not work in editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if(numberOfPlanes < maxPlanes)
        {
            //GameObject s = Camera.main.GetComponent<CameraSupport>();
            //Bounds myBound = GetComponent<Renderer>().bounds;
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();

            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject); // PreFabs must be in the Resources Folder
            Vector3 pos = transform.position;
            pos.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x; //Random.value*50;
            pos.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y; //Random.value*50;
            pos.z = 0;
            e.transform.localPosition = pos;
            ++numberOfPlanes;
        }
    }
    
    public void EnemyDestroyed(){
        --numberOfPlanes;
    }
}
