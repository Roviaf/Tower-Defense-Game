using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreBlocks : MonoBehaviour
{
    int block = 7;
    [SerializeField] Text blocknum;
    [SerializeField] GameObject block2;
    [SerializeField] GameObject block3;
    [SerializeField] GameObject block4;
    [SerializeField] GameObject block5;
    [SerializeField] public GameObject hello;
    private void Start()
    {
        blocknum.text = block.ToString();
    }

    public void AddingBlocks()
    {
        var trying = GameObject.Find("Base Crystal").GetComponent<CrystalEconomy>();
        var crystalcount = trying.currentcrystals;
        if (block == 11)
        {
            hello.GetComponent<Text>().text = "Maximum blocks achieved";
            hello.SetActive(true);
            StartCoroutine(BlockCount());
        }
        else
        {
            if (crystalcount >= 30)
            {
                trying.UpdateTextBlock();
                block = block + 1;
                blocknum.text = block.ToString();
                if (block == 8) { block2.SetActive(true); }
                if (block == 9) { block3.SetActive(true); }
                if (block == 10) { block4.SetActive(true); }
                if (block == 11) { block5.SetActive(true); }
            }
            else 
            {
                hello.GetComponent<Text>().text = "Not enough crystals.";
                hello.SetActive(true);
                StartCoroutine(BlockCount());
            }
        }

    }
    IEnumerator BlockCount()
    {
        yield return new WaitForSeconds(2.5f);
        hello.SetActive(false);
    }
}
