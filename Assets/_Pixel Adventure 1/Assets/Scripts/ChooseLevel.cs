using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private List<Button> listLevelButton;

    private void OnEnable()
    {
        AudioManager.Instance.PlayMusic(eMusicName.ChooseLevel);
        for (int i = 0; i < listLevelButton.Count; i++)
        {
            var index = i;
            listLevelButton[i].onClick.AddListener(() =>
            {
                LoadSceneManager.Instance.LoadScene("Level " + (index + 1));
            });
        }
    }
}
