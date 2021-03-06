﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sounds : MonoBehaviour {

    private Item_Master itemMaster;
    public float defaultVolume;
    public AudioClip throwSound;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectThrow += PlayThrowSound;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectThrow -= PlayThrowSound;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();

    }

    void PlayThrowSound()
    {
        if (throwSound != null) {
            AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
        }
    }
}
