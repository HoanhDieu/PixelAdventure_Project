using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private TextMeshProUGUI itemText;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            ++cherries;
            itemText.text = "SCORE: " + cherries.ToString();
            PoolingManager.Instance.GetObject(NamePrefabPool.CollectVFX, null, other.transform.position).Disable(0.75f);
            AudioManager.Instance.Shot(eSoundName.Collect_Item);
        }
    }
}