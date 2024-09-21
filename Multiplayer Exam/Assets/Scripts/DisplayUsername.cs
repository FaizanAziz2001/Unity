using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class DisplayUsername : MonoBehaviourPunCallbacks
{
  [SerializeField] private PhotonView view;
  [SerializeField] TMP_Text text;

     void Start()
    {
        text.text = view.Owner.NickName;
    }
}
