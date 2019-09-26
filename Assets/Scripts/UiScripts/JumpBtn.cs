using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpBtn : MonoBehaviour,IPointerClickHandler
{
    public GameManager Gm;

    public void OnPointerClick(PointerEventData eventData)
    {
        Gm.Player.GetComponent<PlayerMove>().JumpPlayer();
    }

}
