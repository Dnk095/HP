using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class Heal : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(GetHeal);
    }

    private void OnDisable()
    {
        _button.onClick?.RemoveListener(GetHeal);
    }

    private void GetHeal()
    {
        int heal = 10;

        _health.Heal(heal);
    }
}
