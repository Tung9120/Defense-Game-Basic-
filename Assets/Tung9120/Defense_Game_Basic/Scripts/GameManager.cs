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
        public ShopManager shopMng;
        private Player m_curPlayer;
        private bool m_isGameOver;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
            if (IsComponentsNull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();
        }

        public bool IsComponentsNull()
        {
            return guiMng == null || shopMng == null;
        }

        public void ActivePlayer()
        {
            if (IsComponentsNull()) return;

            if (m_curPlayer)
                Destroy(m_curPlayer.gameObject);

            var shopItems = shopMng.items;

            if (shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPb = shopItems[Pref.curPlayerId].playerPrefabs;

            if (newPlayerPb)
                m_curPlayer = Instantiate(newPlayerPb, new Vector3(-6.72f, 7.82f, 0), Quaternion.identity);
        }

        public void GameOver()
        {
            if (m_isGameOver) return;

            m_isGameOver = true;

            Pref.bestSore = m_score;

            if(guiMng.gameoverDialog)
                guiMng.gameoverDialog.Show(true);
        }

        public void PlayGame()
        {
            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();

            ActivePlayer();
            StartCoroutine(SpawnEnemy());
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

