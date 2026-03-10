using UnityEngine;

namespace Student
{
    public class PlayerDamage : MonoBehaviour
    {
        // Теперь у нас два поля вместо одного
        private float minDamage = 1;    // минимальный урон
        private float maxDamage = 5;    // максимальный урон

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryDamageEnemy();
            }
        }

        void TryDamageEnemy()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    // Генерируем случайное число между minDamage и maxDamage
                    float randomDamage = Random.Range(minDamage, maxDamage + 1);
                    // +1 нужен, потому что Random.Range для int не включает последнее число
                    

                    enemyHealth.TakeDamage(randomDamage);

                    // Для отладки — выведем в консоль, какой урон выпал
                    Debug.Log("Нанесён урон: " + randomDamage);
                }
            }
        }
    }
}