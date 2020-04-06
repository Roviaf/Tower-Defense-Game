using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerprefab;
    Queue<Tower> queue = new Queue<Tower>();
    [SerializeField] Text towerlimit;
    [SerializeField] public GameObject hello;

    private void Start()
    {
        towerlimit.text = towerLimit.ToString();
    }



    public void ButtonPressUpgradeLimit()
    {
        var trying = GameObject.Find("Base Crystal").GetComponent<CrystalEconomy>();
        var crystalcount = trying.currentcrystals;
        if (towerLimit == 11)
        {
            hello.GetComponent<Text>().text = "Maximum towers achieved";
            hello.SetActive(true);
            StartCoroutine(TowerCounts());
        }
        else
        {
            if (crystalcount >= 70)
            {
                trying.UpdateTextLimit();
                towerLimit = towerLimit + 1;
                towerlimit.text = towerLimit.ToString();
            }
            else 
            {
                hello.GetComponent<Text>().text = "Not enough crystals.";
                hello.SetActive(true);
                StartCoroutine(TowerCounts());
            }
        }
    }


    public void AddTower(Waypoint baseWaypoint)
    {
        var trying = GameObject.Find("Base Crystal").GetComponent<CrystalEconomy>();
        var crystalcount = trying.currentcrystals;
        print(crystalcount);
        if (crystalcount >= 50)
        {
            trying.UpdateText();
            if (queue.Count < towerLimit)
            {
                InstantiateNewTower(baseWaypoint);
            }
            else
            {
                MoveExistingTower(baseWaypoint);
            }
        }
        else
        {
            hello.GetComponent<Text>().text = "Not enough crystals.";
            hello.SetActive(true);
            StartCoroutine(TowerCounts());
        }
    }

    IEnumerator TowerCounts()
    {
        yield return new WaitForSeconds(2.5f);
        hello.SetActive(false);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newtower = Instantiate(towerprefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        var group = GameObject.Find("Towers");
        newtower.transform.SetParent(group.transform);
        newtower.baseWaypoint = baseWaypoint;
        queue.Enqueue(newtower);

    }

    private void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        var oldTower = queue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;

        newBaseWayPoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWayPoint;
        oldTower.transform.position = newBaseWayPoint.transform.position;
        queue.Enqueue(oldTower);

    }
}
