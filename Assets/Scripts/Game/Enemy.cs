using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnActive()
    {
        gameObject.SetActive(true);
    }

    internal void OnRelease()
    {
        gameObject.SetActive(false);
    }
}
