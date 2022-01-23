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
    [SerializeField]
    private Animator gameOverPanelAnimator;

    [SerializeField]
    private Points points;
    [SerializeField]
    private TMP_Text p1_points, p2_points;

    private void Update() {
        ShowPointsP1();
        ShowPointsP2();
    }

    private void ShowPointsP1() {
        int maxLength = 6;

        p1_points.text = Mathf.RoundToInt(points.p1Points).ToString();

        for (int i = Mathf.RoundToInt(points.p1Points).ToString().Length; i < maxLength; i++) {

            p1_points.text = p1_points.text.Insert(0, "0");
        }
    }
    private void ShowPointsP2() {
        int maxLength = 6;

        p2_points.text = Mathf.RoundToInt(points.p2Points).ToString();

        for (int i = Mathf.RoundToInt(points.p2Points).ToString().Length; i < maxLength; i++) {

            p2_points.text = p2_points.text.Insert(0, "0");
        }
    }

    public void ShowGameOverPanel(string _winningPlayer) {
        gameOverPanel.SetActive(true);
        gameOverPanelAnimator.SetTrigger("show");
        winText.text = $"{_winningPlayer} has won!!!";
    }

    public void LoadScene(int _sceneIndex) {
        SceneManager.LoadScene(_sceneIndex);
        Time.timeScale = 1f;
    }
}
