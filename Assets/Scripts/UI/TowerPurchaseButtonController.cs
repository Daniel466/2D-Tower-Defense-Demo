using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerPurchaseButtonController : MonoBehaviour
{
    [SerializeField] private TowerConfiguration tower;
    [SerializeField] private Image towerPlacementImage;
    [SerializeField] private TMP_Text priceText;

    public event EventHandler<EventArgTemplate<TowerConfiguration>> TowerPurchased;

    private void Start()
    {
        towerPlacementImage.sprite = tower.towerImage;
        priceText.text = tower.price.ToString();
    }

    public void OnTowerSelect()
    {
        SafeEventHandler.SafelyBroadcastEvent(ref TowerPurchased, tower, this);
    }
}