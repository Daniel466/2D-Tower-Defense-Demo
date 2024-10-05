using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfiguration.asset", 
                menuName = "TowerDefense/Tower Configuration", 
                order = 2)]
public class TowerConfiguration : ScriptableObject
{
    public Sprite towerImage;
    public int price;
    public GameObject towerPrefab;
}