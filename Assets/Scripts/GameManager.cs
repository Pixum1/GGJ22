using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private PlayerController p1, p2;
    [SerializeField]
    private UIManager uiManager;

    private void Awake() {
        p1.e_playerDies = new Action<PlayerController>(Die);
        p2.e_playerDies = new Action<PlayerController>(Die);
    }
    private void Die(PlayerController _p) {
        //Time.timeScale = 0f;
        if (_p.gameObject == null)
            return;
        if (_p.gameObject == p1.gameObject) {
            //player 2 wins
            Debug.Log("Player 2 wins");
            uiManager.ShowGameOverPanel("Player 2");
        }
        else if (_p.gameObject == p2.gameObject) {
            //player 1 wins
            Debug.Log("Player 1 wins");
            uiManager.ShowGameOverPanel("Player 1");
        }

        p1.e_playerDies -= Die;
        p2.e_playerDies -= Die;
    }
}
