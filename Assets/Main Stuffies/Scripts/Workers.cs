using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Workers : MonoBehaviour
{
    [SerializeField]int worker = 1;
    [SerializeField] Text workernum;
    [SerializeField] GameObject worker2;
    [SerializeField] GameObject worker3;
    [SerializeField] GameObject worker4;
    [SerializeField] GameObject worker5;
    [SerializeField]public GameObject hello;

    private void Start()
    {
        workernum.text = worker.ToString();
    }

    public void AddingWorkers()
    {
        var trying = GameObject.Find("Base Crystal").GetComponent<CrystalEconomy>();
        var crystalcount = trying.currentcrystals;
        if (worker == 5)
        {
            hello.GetComponent<Text>().text = "Maximum workers achieved";
            hello.SetActive(true);
            StartCoroutine(WorkerCount());
        }
        else
        {
            if (crystalcount >= 40)
            {
                trying.UpdateTextWorker();
                worker = worker + 1;
                workernum.text = worker.ToString();
                if (worker == 2) { worker2.SetActive(true); }
                if (worker == 3) { worker3.SetActive(true); }
                if (worker == 4) { worker4.SetActive(true); }
                if (worker == 5) { worker5.SetActive(true); }
            }
            else
            {
                hello.GetComponent<Text>().text = "Not enough crystals.";
                hello.SetActive(true);
                StartCoroutine(WorkerCount());
            }
        }

    }
    IEnumerator WorkerCount()
    {
        yield return new WaitForSeconds(2.5f);
        hello.SetActive(false);
    }
}
