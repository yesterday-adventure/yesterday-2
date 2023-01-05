using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ItemUsingParticleLightChanger : MonoBehaviour
{
    [SerializeField] Light2D _light;

    private void OnEnable()
    {
        DOTween.To(() => _light.pointLightOuterRadius, x => _light.pointLightOuterRadius = x, 10, 1.5f);
        Destroy(gameObject, 2);
    }
}
