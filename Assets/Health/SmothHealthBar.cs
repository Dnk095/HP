using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _barStep;

    private Slider _slider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ChangeHeath += SmoothHeal;
    }

    private void OnDisable()
    {
        _health.ChangeHeath -= SmoothHeal;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void SmoothHeal(int currentHealth, int maxHealth)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmothDraw(currentHealth, maxHealth));
    }

    private IEnumerator SmothDraw(int currentHealth, int maxHealth)
    {
        float health = (float)currentHealth / maxHealth;

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _barStep * Time.deltaTime);
            yield return null;
        }
    }
}