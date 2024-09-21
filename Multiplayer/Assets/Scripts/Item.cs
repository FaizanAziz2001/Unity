using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public ItemInfo itemInfo;
    [SerializeField] public GameObject itemGameObject;

    public abstract void Use();
}
