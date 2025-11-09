using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AbilitySprite : MonoBehaviour
{
    [SerializeField] private Ability _ability;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _ability.Toggled += Toggle;
    }

    private void OnDisable()
    {
        _ability.Toggled -= Toggle;
    }

    private void Start()
    {
        transform.localScale *= _ability.GetRange;
    }

    private void Toggle(bool newValue)
    {
        _renderer.enabled = newValue;
    }
}
