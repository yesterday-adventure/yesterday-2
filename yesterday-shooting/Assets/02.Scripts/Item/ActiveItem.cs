using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _renderer.sprite = Resources.Load<Sprite>(gameObject.name);
    }
}
