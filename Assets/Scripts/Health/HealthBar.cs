using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void OnEnable()
    {
        _health.ChangeHeath += OnChangeHealth;
    }

    private void OnDisable()
    {
        _health.ChangeHeath -= OnChangeHealth;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnChangeHealth(int currentHealth, int maxHealth)
    {
        _slider.value = (float)currentHealth / maxHealth;
    }
}
