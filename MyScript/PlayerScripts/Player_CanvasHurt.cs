using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CanvasHurt : MonoBehaviour {

    public GameObject hurtCanvas;
    //private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;
    private float secondsTillHide = 2;

    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventPlayerHealthDeduction += TurnOnHurtEffent;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= TurnOnHurtEffent;
    }

    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player_Master>();
    }

    void TurnOnHurtEffent(int dummy)
    {
        if (hurtCanvas != null) {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
        hurtCanvas.SetActive(false);
    }
}
