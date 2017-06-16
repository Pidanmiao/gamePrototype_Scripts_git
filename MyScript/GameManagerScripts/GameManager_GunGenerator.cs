using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GunGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Guninfo generate_gun()
    {
        Guninfo gun = new Guninfo();
        int random_value = Random.Range(0, 100);
        if (random_value < 25) gun.guntype = Guninfo.Gun_Type.Gun_Pistol;
        else if (random_value < 45) gun.guntype = Guninfo.Gun_Type.Gun_Submachine;
        else if (random_value < 70) gun.guntype = Guninfo.Gun_Type.Gun_ShotGun;
        else if (random_value < 85) gun.guntype = Guninfo.Gun_Type.Gun_AR;
        else if (random_value < 95) gun.guntype = Guninfo.Gun_Type.Gun_Rifle;
        else gun.guntype = Guninfo.Gun_Type.Gun_RPG;
        float f, mod;
        int x;
        switch (gun.guntype)
        {
            case Guninfo.Gun_Type.Gun_Pistol:
                f = Random.Range(10.0f, 45.0f);
                gun.damage = f;
                mod = (f - 25f) / 25f;
                f = Random.Range(0.6f, 1.8f);
                gun.shotspeed = f + f * mod;
                mod = (f - 1.0f) / 1.0f;
                gun.accuracy = 90f + mod * 20f;
                x = Random.Range(5, 25);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 2.5f;
                break;
            case Guninfo.Gun_Type.Gun_Submachine:
                f = Random.Range(5.0f, 25.0f);
                gun.damage = f;
                mod = (f - 15f) / 15f;
                f = Random.Range(0.05f, 0.5f);
                gun.shotspeed = f + f * mod;
                mod = (f - 0.2f) / 0.2f;
                gun.accuracy = 60f + mod * 60f;
                x = Random.Range(45, 95);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 30f;
                break;
            case Guninfo.Gun_Type.Gun_AR:
                f = Random.Range(4.0f, 20.0f);
                gun.damage = f;
                mod = (f - 15f) / 15f;
                f = Random.Range(0.05f, 0.5f);
                gun.shotspeed = f + f * mod;
                mod = (f - 0.2f) / 0.2f;
                gun.accuracy = 80f + mod * 30f;
                x = Random.Range(30, 60);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 25f;
                break;
            case Guninfo.Gun_Type.Gun_ShotGun:
                f = Random.Range(15.0f, 35.0f);
                gun.damage = f;
                mod = (f - 20f) / 20f;
                f = Random.Range(1.5f, 3.5f);
                gun.shotspeed = f + f * mod;
                mod = (f - 2.5f) / 2.5f;
                gun.accuracy = 50f + mod * 40f;
                x = Random.Range(4, 10);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 2f;
                break;
            case Guninfo.Gun_Type.Gun_Rifle:
                f = Random.Range(45.0f, 70.0f);
                gun.damage = f;
                mod = (f - 50f) / 50f;
                f = Random.Range(3.0f, 5.0f);
                gun.shotspeed = f + f * mod;
                mod = (f - 4.0f) / 4.0f;
                gun.accuracy = 95f + mod * 10f;
                x = Random.Range(4, 10);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 2f;
                break;
            case Guninfo.Gun_Type.Gun_RPG:
                f = Random.Range(80.0f, 120.0f);
                gun.damage = f;
                mod = (f - 100f) / 100f;
                f = Random.Range(5f, 8f);
                gun.shotspeed = f + f * mod;
                mod = (f - 6.5f) / 6.5f;
                gun.accuracy = 50f + mod * 40f;
                x = Random.Range(3, 6);
                gun.maxAmmo = x;
                gun.rechargespeed = (float)x / 1f;
                break;
            default:
                break;
        }
        return gun;
    }
}
