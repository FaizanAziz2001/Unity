using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject Highlight;

    private void Start()
    {
        Highlight.SetActive(false);
    }
}
