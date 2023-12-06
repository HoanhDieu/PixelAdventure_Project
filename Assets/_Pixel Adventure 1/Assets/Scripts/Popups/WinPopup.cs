using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopup : BaseUI
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private float startScale = 0f;
    [SerializeField] private float endScale = 1f;
    [SerializeField] private Image blockClickImg;
    private void OnEnable()
    {
        AudioManager.Instance.PauseMusic();
        AudioManager.Instance.Shot(eSoundName.Win_Level);
        blockClickImg.transform.localScale = new Vector3(startScale, startScale, startScale);
        transform.localScale = new Vector3(startScale, startScale, startScale);
        blockClickImg.transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true);
        
        transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            blockClickImg.gameObject.SetActive(false);
        });
        
        closeButton.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Choose Level");
        });
        
        restartButton.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadCurrentScene();
        });

        if (SceneManager.GetActiveScene().name == "Level " + GameData.Instance.maxLevel)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
        
        nextLevelButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }
}
