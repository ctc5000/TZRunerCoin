using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject WallPrefab;

    void GenerateCOins()
    {
        for (int i = 0; i < 120; i++)
        {
            Instantiate(CoinPrefab, new Vector3(Random.Range(30, 300), 1, Random.Range(30, 300)),Quaternion.identity);
        }
    }

    void GenerateWall()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(WallPrefab, new Vector3(Random.Range(60, 250), 1, Random.Range(60, 250)), new Quaternion(0,Random.Range(0,360),0,360));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateCOins();
        GenerateWall();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
