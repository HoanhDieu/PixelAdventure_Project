using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    [SerializeField] private Image loadingBar;
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Button playButton;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(eMusicName.Splash);
        playButton.gameObject.SetActive(false);
        loadingBar.DOFillAmount(1f, 5f);
        DOTween.To(value => loadingText.text = "Loading... " + (int) value + "%",
            0f, 100f, 5f).OnComplete(() =>
        {
            playButton.gameObject.SetActive(true);
        });
        
        playButton.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Choose Level");
        });
    }
}