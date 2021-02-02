using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] Wave waveText;

    public float rngWaveType = 1;
    public float rngTimeBetweenSpawn = 1;
    public float rngNbEnemies = 1;
    public float multiplier = 0.95f;
    void Start()
    {
        StartCoroutine(EnemySpawning());
    }

    // Update is called once per frame
    void spawnEnemyL()
    {
        GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        enemy.transform.position = new Vector2(transform.position.x - 25, 5);
        // Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void spawnEnemyR()
    {
        GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        enemy.transform.position = new Vector2(transform.position.x + 25, 5);
        enemy.transform.localScale = new Vector2(-0.6f, 0.6f);
    }

    void spawnEnemyT()
    {
        GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        enemy.transform.position = new Vector2(transform.position.x, transform.position.y + 25);
    }

    IEnumerator EnemySpawning()
    {
        waveText.UpdateWave();
        int wave1 = 0;
        do
        {
            spawnEnemyR();
            wave1++;
            yield return new WaitForSeconds(3);   
        } while (wave1 < 3);

        int wave2 = 0;
        do
        {
            spawnEnemyL();
            spawnEnemyR();
            wave2++;
            yield return new WaitForSeconds(1);
        } while (wave2 < 2);

        int wave3 = 0;
        do
        {
            spawnEnemyT();
            wave3++;
            yield return new WaitForSeconds(2);
        } while (wave3 < 2);

        float wave4andOver = 1;
        do
        {
            waveText.UpdateWave();
            int i = 0;
            do
            {
                rngWaveType = Random.Range(1, 7);
                rngTimeBetweenSpawn = Random.Range(1, 4); // 1 to 3 seconds
                rngNbEnemies = Random.Range(1, 4); // 1 to 6 enemies
                float delay = rngTimeBetweenSpawn * wave4andOver;

                // 1: wave to the left
                // 2: wave to the right
                // 3: wave from both sides
                // 4: wave from the top
                // 5: wave from top and left
                // 6: wave from top and right

                int j = 0;
                switch (rngWaveType)
                {
                    case 1: // left

                        do
                        {
                            spawnEnemyL();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;

                    case 2: // right
                        do
                        {
                            spawnEnemyR();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;

                    case 3: // left, right
                        do
                        {
                            spawnEnemyL();
                            spawnEnemyR();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;

                    case 4: // top
                        do
                        {
                            spawnEnemyT();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;

                    case 5: // top, left
                        do
                        {
                            spawnEnemyT();
                            spawnEnemyL();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;

                    case 6: // top, right
                        do
                        {
                            spawnEnemyT();
                            spawnEnemyR();
                            j++;
                            yield return new WaitForSeconds(delay);
                        } while (j < rngNbEnemies);
                        break;
                }

                i++;
            } while (i < 10);

            wave4andOver *= multiplier;
        } while (true);

        
    }
}
