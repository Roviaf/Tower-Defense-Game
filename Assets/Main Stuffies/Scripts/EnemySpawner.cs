using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] public float secondsBetweenSpawns = 5f;
    [Range(0.1f, 120f)] [SerializeField] public float secondsBetweenSpawnsFast = 2f;
    [Range(0.1f, 120f)] [SerializeField] public float secondsBetweenSpawnsSlow = 2f;
    [SerializeField]EnemyMovement enemy;
    [SerializeField] EnemyMovement enemyfast;
    [SerializeField] EnemyMovement enemyboss;
    [SerializeField] EnemyMovement enemyboss2;
    [SerializeField] Text scoreUI;
    [SerializeField] AudioClip spawnedSFX;
    int countingenemies = 0;
    Vector2 m_NewPosition;
    bool finalwave = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawningEnemies());
        m_NewPosition = new Vector2(20.0f, 5.0f);
    }

    IEnumerator SpawningEnemies()
    {
        if (finalwave == false)
        {
            while (countingenemies <= 999)
            {
                float randomness = Random.value;
                scoreUI.text = countingenemies.ToString();
                yield return new WaitForSeconds(secondsBetweenSpawns);
                GetComponent<AudioSource>().PlayOneShot(spawnedSFX);
                countingenemies = countingenemies + 1;
                var newenemy = Instantiate(enemy, m_NewPosition, Quaternion.identity);
                var group = GameObject.Find("Enemies");
                
                newenemy.transform.SetParent(group.transform);
                
                if (countingenemies >= 6 && countingenemies <= 40)
                {
                    secondsBetweenSpawns = secondsBetweenSpawns - 0.1f;
                }
                if (countingenemies >= 4)
                {
                    if (randomness >= 0.5f)
                    {
                        scoreUI.text = countingenemies.ToString();
                        yield return new WaitForSeconds(secondsBetweenSpawnsFast);
                        GetComponent<AudioSource>().PlayOneShot(spawnedSFX);
                        countingenemies = countingenemies + 1;
                        secondsBetweenSpawnsFast = secondsBetweenSpawnsFast - 0.1f;
                        var newenemyfast = Instantiate(enemyfast, m_NewPosition, Quaternion.identity);
                        //var group = GameObject.Find("Enemies");
                        newenemyfast.transform.SetParent(group.transform);
                    }
                }
                if (countingenemies >= 20)
                {
                    if (randomness >= 0.6f)
                    {
                        scoreUI.text = countingenemies.ToString();
                        yield return new WaitForSeconds(secondsBetweenSpawnsSlow);
                        GetComponent<AudioSource>().PlayOneShot(spawnedSFX);
                        countingenemies = countingenemies + 1;
                        secondsBetweenSpawnsSlow = secondsBetweenSpawnsSlow - 0.1f;
                        var newenemyboss = Instantiate(enemyboss, m_NewPosition, Quaternion.identity);
                        newenemyboss.transform.SetParent(group.transform);
                    }
                }
                if (countingenemies >= 70 && countingenemies <= 90)
                {
                    if (randomness >= 0.7f)
                    {
                        scoreUI.text = countingenemies.ToString();
                        yield return new WaitForSeconds(2f);
                        GetComponent<AudioSource>().PlayOneShot(spawnedSFX);
                        countingenemies = countingenemies + 1;
                        var newenemyfast = Instantiate(enemyboss2, m_NewPosition, Quaternion.identity);
                        newenemyfast.transform.SetParent(group.transform);
                    }

                }
                else if (countingenemies >= 91)
                {
                    if (randomness >= 0.3f)
                    {
                        scoreUI.text = countingenemies.ToString();
                        yield return new WaitForSeconds(1f);
                        GetComponent<AudioSource>().PlayOneShot(spawnedSFX);
                        countingenemies = countingenemies + 1;
                        var newenemyfast = Instantiate(enemyboss2, m_NewPosition, Quaternion.identity);
                        newenemyfast.transform.SetParent(group.transform);
                    }
                }



            }
        }
    }
}
