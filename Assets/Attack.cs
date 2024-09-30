using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _button.onClick?.RemoveListener(TakeDamage);
    }

    private void TakeDamage()
    {
        int damage = 15;

        _health.TakeDamage(damage);
    }
}
