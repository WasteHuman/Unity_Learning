using UnityEngine;

namespace Student
{
    public class EnemyHealth : MonoBehaviour
    {
        private float maxHealth = 100; // максимальное хп( как раз переменная) публичная, чтобы можно было менять в юнити
        private float currentHealth; // текущее хп, тоже публичная
        private Material material;
        private Color originalColor;  // сохраняю оригинальный цвет

        void Awake()
        {
            currentHealth = maxHealth;
        }

        void Start()
        {
            material = GetComponent<Renderer>().material;
            originalColor = material.color;  // ← запоминаем оригинальный цвет при старте
        }

        public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;
            material.color = Color.red; // краснеет при ударе
            Invoke("ResetColor", 0.1f); // через 0.1 сек вернуть цвет

            if (currentHealth <= 0) Die();
        }

        void ResetColor()
        {
            material.color = originalColor;  //  возвращаем сохраненный оригинальный цвет
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}