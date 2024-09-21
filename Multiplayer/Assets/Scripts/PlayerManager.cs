using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;
    private GameObject controller;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
   void CreateController()
    {
        Transform spawnpoint = SpawnManager.instance.GetSpawnPoint();
        controller=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "PlayerController"), spawnpoint.position, spawnpoint.rotation,0,new object[] { PV.ViewID });
    }

    public void die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
