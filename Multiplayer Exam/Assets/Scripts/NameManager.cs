using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField username;


    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = username.text;
    }
}
