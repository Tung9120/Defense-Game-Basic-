using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tung9120.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public GUIManager guiMng;
        private bool m_isGameOver;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayGame()
        {
            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();
            StartCoroutine(SpawnEnemy());
        }

        public bool IsComponentsNull()
        {
            return guiMng == null;
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

