using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class PausePopup : SingletonUI<PausePopup>
{
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button soundBtn;
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button chooseLvBtn;

    [SerializeField] private Image musicImg;
    [SerializeField] private Image soundImg;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    
    [SerializeField] private float startScale = 0f;
    [SerializeField] private float endScale = 1f;
    [SerializeField] private Image blockClickImg;

    private void OnEnable()
    {
        blockClickImg.transform.localScale = new Vector3(startScale, startScale, startScale);
        transform.localScale = new Vector3(startScale, startScale, startScale);
        blockClickImg.transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true);
        
        transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            blockClickImg.gameObject.SetActive(false);
        });
    }

    void Start()
    {
        musicBtn.onClick.AddListener(() =>
        {
            musicImg.sprite = GameData.Instance.MusicFX ? musicOff : musicOn;
            GameData.Instance.MusicFX = !GameData.Instance.MusicFX;
        });
        
        soundBtn.onClick.AddListener(() =>
        {            
            soundImg.sprite = GameData.Instance.SoundFX ? soundOff : soundOn;
            GameData.Instance.SoundFX = !GameData.Instance.SoundFX;
        });
        
        shopBtn.onClick.AddListener(() =>
        {
            
        });
        
        continueBtn.onClick.AddListener(() =>
        {
            DisablePopup();
        });
        
        restartBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadCurrentScene();
        });
        
        chooseLvBtn.onClick.AddListener(() =>
        {
            //LoadSceneManager.Instance.LoadScene("ChooseLevelScene");
        });
    }
    
    private void DisablePopup()
    {
        blockClickImg.gameObject.SetActive(true);
        blockClickImg.transform.DOScale(startScale, 1f).SetEase(Ease.Linear).SetUpdate(true);
        transform.DOScale(startScale, 1f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            blockClickImg.gameObject.SetActive(false);
            gameObject.SetActive(false);
        });
    }
}
