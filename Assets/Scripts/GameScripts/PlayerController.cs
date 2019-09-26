using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int CoinScore;
    public GameManager Gm;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Gm.AddCoin();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            Gm.GameStop("Finish");
        }
    }
}