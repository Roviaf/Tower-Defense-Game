using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalEmployeeMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> newpath;
    [SerializeField] public GameObject hello;
    float waitfor = 2f;
    float waitformove = 0.4f;
    int looping = 0;

    void Start()
    {
        StartCoroutine(PrintAllWaypoints());
        hello.SetActive(false);
    }


    IEnumerator PrintAllWaypoints()
    {
        
        while (looping <= 99)
        {
            yield return new WaitForSeconds(waitfor);
            foreach (Waypoint waypoint in newpath)
            {
                transform.position = waypoint.transform.position;
                yield return new WaitForSeconds(waitformove);

            }
            
            newpath.Reverse();
            foreach (Waypoint waypoint in newpath)
            {
                transform.position = waypoint.transform.position;
                yield return new WaitForSeconds(waitformove);

            }
            newpath.Reverse();
            looping++;
            yield return new WaitForSeconds(waitfor);
        }

    }

    public void ImprovingWorker()
    {
        var trying = GameObject.Find("Base Crystal").GetComponent<CrystalEconomy>();
        var crystalcount = trying.currentcrystals;
        if (waitfor <= 0.5f)
        {
            hello.GetComponent<Text>().text = "Maximum speed achieved.";
            hello.SetActive(true);
            StartCoroutine(CrystalCounts());
        }
        else
        {
            if (crystalcount >= 40)
            {
                trying.UpdateTextWorkerSpeed();
                waitfor = waitfor - 0.55f;
                waitformove = waitformove - 0.15f;
            }
            else 
            {
                
                hello.GetComponent<Text>().text = "Not enough crystals.";
                hello.SetActive(true);
                StartCoroutine(CrystalCounts());
            }
        }
    }
    IEnumerator CrystalCounts()
    {
        yield return new WaitForSeconds(2.5f);
        hello.SetActive(false);
    }

}
