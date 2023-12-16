using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public GameObject towerObj;
    public Tower tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit() 
    { 
        sr.color = startColor;
    }

    private void OnMouseDown()
    {

        if (UIManager.main.IsHoweringUI()) return; 

        if (towerObj != null)
        {
            tower.OpenUpgradeUI();
            return;
        }

        TowerSetting towerToBuild = BuildManager.main.GetSelectedTower();
        if (towerToBuild.cost > LevelManager.main.IQ)
        {
            Debug.Log("CAnt afford");
            return;
        }

        LevelManager.main.SpendIQ(towerToBuild.cost);

        towerObj = Instantiate (towerToBuild.prefab,transform.position,Quaternion.identity);
        tower = towerObj.GetComponent<Tower>();
    }
}
