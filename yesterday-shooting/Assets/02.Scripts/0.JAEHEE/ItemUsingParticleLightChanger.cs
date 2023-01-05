using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ItemUsingParticleLightChanger : MonoBehaviour
{
    [SerializeField] Light2D _light;

    private void OnEnable()
    {
        Sequence seq = DOTween.Sequence()
        .Append(DOTween.To(() => _light.pointLightOuterRadius, x => _light.pointLightOuterRadius = x, 10, 1f))
        .Append(DOTween.To(() => _light.pointLightOuterRadius, x => _light.pointLightOuterRadius = x, 0, 0.5f))
        .AppendCallback(() =>
        {
            Destroy(gameObject);
        });
    }
}
