using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SingleShot : Gun
{
    [SerializeField] Camera cam;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    public override void Use()
    {
        Shoot();
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.GetComponent<IDamagable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, hit.point,hit.normal);
        }
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition,Vector3 hitnormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            GameObject bulletImpactobj=Instantiate(bulletImpactPrefab, hitPosition + hitnormal * 0.001f, Quaternion.LookRotation(hitnormal, Vector3.up));
            Destroy(bulletImpactobj, 10f);
            bulletImpactobj.transform.SetParent(colliders[0].transform);
        }
    }


}
