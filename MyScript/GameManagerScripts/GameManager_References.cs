using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_References : MonoBehaviour {

    public string playerTag;
    public static string _playerTag;

    public string enemyTag;
    public static string _enemyTag;

    public static GameObject _player;

    private void OnEnable()
    {
        if (playerTag == "") {
            Debug.LogWarning("GameManager_References: player tag needed");
        }
        if (enemyTag == "") {
            Debug.LogWarning("GameManager_References: enemy tag needed");
        }

        _playerTag = playerTag;
        _enemyTag = enemyTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    private void OnDisable()
    {
        
    }
}
