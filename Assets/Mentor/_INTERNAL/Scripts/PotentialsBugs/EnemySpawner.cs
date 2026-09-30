using System.Collections;
using UnityEngine;

namespace PotentialsBugs
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        private IEnumerator Start()
        {
            yield return StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                Instantiate(enemyPrefab);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}