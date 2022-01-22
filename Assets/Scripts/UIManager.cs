using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text winText;

    public void ShowGameOverPanel(string _winningPlayer) {
        gameOverPanel.SetActive(true);
        winText.text = $"{_winningPlayer} has won!!!";
    }

    public void LoadScene(int _sceneIndex) {
        SceneManager.LoadScene(_sceneIndex);
        Time.timeScale = 1f;
    }
}
