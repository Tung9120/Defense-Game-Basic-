using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tung9120.DefenseBasic
{
    public class GameManager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        private bool m_isGameOver;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnEnemy()
        {
            while (!m_isGameOver)
            {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int randomIdx = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab = enemyPrefabs[randomIdx];

                    if (enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 2, 0), Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}

