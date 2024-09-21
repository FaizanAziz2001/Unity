using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks, IDamagable
{
    [SerializeField] float Sensitivity = 15f;
    [SerializeField] GameObject CameraHolder;
    [SerializeField] Image HealthBar;
    [SerializeField] GameObject UI;
    float verticalLookRotation;

    [SerializeField] private float PlayerSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float jump = 1f;
    [SerializeField] private Transform Checkground;
    [SerializeField] Item[] items;
    const float maxHealth = 100f;

    PlayerManager playerManager;
    float currenthealth = maxHealth;
    int ItemIndex, prevIndex = -1;
    PhotonView view;
    CharacterController PC;
    private float GroundDistance = 0.4f;
    Vector3 Velocity;


    void Awake()
    {
        view = GetComponent<PhotonView>();
        PC = GetComponent<CharacterController>();
        playerManager = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<PlayerManager>();
    }
    void Start()
    {
        if (view.IsMine)
        {
            EquipItem(0);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(UI);
        }
    }


    void Update()
    {
        if (!view.IsMine)
            return;

        Move();
        Look();
        SwitchGun();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            items[ItemIndex].Use();
        }
    }
    void SwitchGun()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                EquipItem(i);
                break;
            }

        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (ItemIndex >= items.Length - 1)
            {
                EquipItem(0);
            }
            else
                EquipItem(ItemIndex + 1);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (ItemIndex <= 0)
            {
                EquipItem(items.Length - 1);
            }
            else
                EquipItem(ItemIndex - 1);
        }
    }
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * Sensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * Sensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        CameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    private void Move()
    {
        float rf = Input.GetAxis("Horizontal");
        float ff = Input.GetAxis("Vertical");


        Vector3 move = transform.right * rf + transform.forward * ff;
        PC.Move(move * PlayerSpeed * Time.deltaTime);

        if (IsGrounded() && Velocity.y < 0)
            Velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            Velocity.y = Mathf.Sqrt(jump * gravity * -2f);

        }

        Velocity.y += gravity * Time.deltaTime;
        PC.Move(Velocity * Time.deltaTime);
    }

    void EquipItem(int index)
    {
        if (index == prevIndex)
            return;
        ItemIndex = index;

        items[ItemIndex].itemGameObject.SetActive(true);

        if (prevIndex != -1)
        {

            items[prevIndex].itemGameObject.SetActive(false);
        }

        prevIndex = ItemIndex;

        if (view.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("ItemIndex", ItemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!view.IsMine && targetPlayer == view.Owner)
        {
            EquipItem((int)changedProps["ItemIndex"]);
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(Checkground.position, GroundDistance, Layer);

    }


    public void TakeDamage(float damage)
    {
        view.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {

        if (!view.IsMine)
            return;
        currenthealth -= damage;
        HealthBar.fillAmount = currenthealth / maxHealth;
        if (currenthealth <= 0)
        {
            Die();
        }

    }



    void Die()
    {
        playerManager.die();
    }
}

