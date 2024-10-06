using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(BoxCollider2D))]
public class TowerNode : MonoBehaviour
{
    [SerializeField] private TowerNodeUIController selectionUI;

    private GameObject placedTower;

    public GameObject PlacedTower
    {
        get { return placedTower; }
    }

    private void Awake()
    {
        Assert.IsNotNull(selectionUI);
    }

    private void Start()
    {
        selectionUI.gameObject.SetActive(false);
        selectionUI.ClosedButtonPressed += OnCloseRequested;
        selectionUI.PurchasedTower += OnTowerPurchased;
    }

    private void ToggleSelectionUI()
    {
        var uiGameObject = selectionUI.gameObject;
        uiGameObject.SetActive(!uiGameObject.activeSelf);
    }

    private void OnTowerPurchased(object sender, EventArgTemplate<TowerConfiguration> purchasedTower)
    {
        if (placedTower != null)
        {
            Destroy(placedTower);
        }

        var prefab = purchasedTower.Attachment.towerPrefab;
        placedTower = Instantiate(prefab);
        placedTower.transform.parent = transform;
        placedTower.transform.localPosition = new Vector3(0, 0);
        OnCloseRequested();
    }

    public void OnCloseRequested()
    {
        selectionUI.gameObject.SetActive(false);
    }

    public void OnNodeSelected()
    {
        ToggleSelectionUI();
    }
}