using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject WallPrefab;
    public GameObject EndPanel;

    void GenerateCOins()
    {
        for (int i = 0; i < 120; i++)
        {
            Instantiate(CoinPrefab, new Vector3(Random.Range(30, 300), 1, Random.Range(30, 300)), Quaternion.identity);
        }
    }

    void GenerateWall()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(WallPrefab, new Vector3(Random.Range(60, 250), 1, Random.Range(60, 250)), new Quaternion(0, Random.Range(0, 360), 0, 360));
        }
    }


    public void EndPanelCreator(int Score, string text)
    {
        GameObject Panel = Instantiate(EndPanel);
        Panel.transform.Find("Text").GetComponent<Text>().text = text + Score.ToString() + " Монет";
        Panel.transform.parent = GameObject.Find("Canvas").transform;
        Panel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        Panel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    void Start()
    {
        GenerateCOins();
        GenerateWall();

    }

}
