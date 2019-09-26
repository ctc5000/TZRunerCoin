﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //Рабочие переменные
    public bool GameOver;

    //Объекты
    public GameObject Player;
    public GameObject PlayerPrefab;
    public Transform StartPosition;
    public VariableJoystick Joystick;
    public VariableJoystick CamJoystick;
    public GameObject jumpBtn;
    public Text TimerText;
    public Text ScoreText;
    public int CurrientScore;
    public GameObject EndPanel;


    //TimeWork
     public float StartTime = 60;
     float LetTime;


    void Start()
    {
        Player = Instantiate(PlayerPrefab, StartPosition.position, Quaternion.identity);
        Player.GetComponent<PlayerMove>().Gm = GetComponent<GameManager>();
        Player.GetComponent<PlayerController>().Gm = GetComponent<GameManager>();
        Player.GetComponent<PlayerMove>().Joystic = Joystick;
        Player.GetComponent<PlayerMove>().CamJoystic = CamJoystick;
        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        LetTime = StartTime;
    }
    public void AddCoin()
    {
        CurrientScore += 1;
        ScoreText.text = CurrientScore.ToString();
    }

    public void GameStop(string type)
    {
        if (type == "Lose")
        {
            GameOver = true;
            Player.GetComponent<Animator>().SetTrigger("Death");
            GameObject Panel =   Instantiate(EndPanel);
            Panel.transform.Find("Text").GetComponent<Text>().text = "Вы проиграли со счетом: " + CurrientScore.ToString() + " Монет";
            Panel.transform.parent = GameObject.Find("Canvas").transform;
            Panel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            Panel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        }
        if (type == "Finish")
        {
            GameObject Panel = Instantiate(EndPanel);
            Panel.transform.Find("Text").GetComponent<Text>().text = "Вы выиграли со счетом: "+ CurrientScore.ToString()+" Монет";
            Panel.transform.parent = GameObject.Find("Canvas").transform;
            Panel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            Panel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        }
        
    }

    void FixedUpdate()
    {
        if (!GameOver)
        {
            LetTime -= Time.deltaTime;
            TimerText.text = LetTime.ToString("0") + " sec";
            if (LetTime <= 0)
            {
                TimerText.text = "0";
                GameStop("Lose");
            }
            if (Player.transform.position.y < -2) GameStop("Lose");
        }
      
    }

}
