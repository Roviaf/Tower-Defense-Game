using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalEconomy : MonoBehaviour
{
    [SerializeField]int crystal = 10;
    [SerializeField] public int currentcrystals = 100;
    [SerializeField] Text crystaltext;
    [SerializeField] Text crystaltextwo;

    private void Start()
    {
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        currentcrystals += crystal;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }

    public void UpdateText()
    {
        currentcrystals = currentcrystals - 50;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }

    public void UpdateTextLimit()
    {
        currentcrystals = currentcrystals - 70;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }

    public void UpdateTextWorker()
    {
        currentcrystals = currentcrystals - 40;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }
    public void UpdateTextWorkerSpeed()
    {
        currentcrystals = currentcrystals - 40;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }
    public void UpdateTextBlock()
    {
        currentcrystals = currentcrystals - 30;
        crystaltext.text = currentcrystals.ToString();
        crystaltextwo.text = currentcrystals.ToString();
    }
}
