using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeadPopup : SingletonUI<DeadPopup>
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button rebornBtn;
    [SerializeField] private Image countDownImage;
    [SerializeField] private int countDownTime = 9;
    [SerializeField] private Image countDownCircle;
    [SerializeField] private TextMeshProUGUI countDownText;
    
    [SerializeField] private float startScale = 0f;
    [SerializeField] private float endScale = 1f;
    [SerializeField] private Image blockClickImg;

    private void OnEnable()
    {
        AudioManager.Instance.PauseMusic();
        AudioManager.Instance.Shot(eSoundName.Dead);
        blockClickImg.transform.localScale = new Vector3(startScale, startScale, startScale);
        transform.localScale = new Vector3(startScale, startScale, startScale);
        blockClickImg.transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true);
        
        transform.DOScale(endScale, 1f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            blockClickImg.gameObject.SetActive(false);
        });
        
        DOTween.To(value => countDownText.text = (Math.Ceiling(value)).ToString(), countDownTime, 
            -0.1f, countDownTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            countDownImage.gameObject.SetActive(false);
            rebornBtn.gameObject.SetActive(false);
        });
        
        countDownCircle.fillAmount = 1f;
        countDownCircle.DOFillAmount(0f, countDownTime).SetEase(Ease.Linear);
        
        rebornBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Choose Level");
        });
        
        restartBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadCurrentScene();
        });
        
        closeBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Choose Level");
        });
    }
}
