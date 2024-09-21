using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class _DisplayUsername : MonoBehaviour
{
    [SerializeField] PhotonView playerPOV;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        if(playerPOV.IsMine)
        {
            gameObject.SetActive(false);
        }
        text.text = playerPOV.Owner.NickName; 
    }
}
