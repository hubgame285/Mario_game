using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int count = 3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count-- > 0) 
        {
            float position = Random.Range(-1f, 10f);
            GameObject qv = (GameObject) Instantiate(Resources.Load("Prefabs/quaivat"),
                new Vector3(position, -3.15f, 0), Quaternion.identity);
            qv.GetComponent<EnemyScript>().SetStart(position - 5);
            qv.GetComponent<EnemyScript>().SetEnd(position + 6);
            qv.GetComponent<EnemyScript>().SetPlayer(player);
        }
        
    }
}
