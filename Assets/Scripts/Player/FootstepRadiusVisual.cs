using UnityEngine;
using UnityEngine.UI;

public class FootstepRadiusVisual : MonoBehaviour
{
    [SerializeField] private PlayerFootStep footStep;
    [SerializeField] private Image circleSprite;

    void Start()
    {
        draw();
    }

    void draw()
    {
        float diameterWorld = footStep.noiseRadius * 2f;

        circleSprite.rectTransform.sizeDelta = new Vector2(diameterWorld, diameterWorld);
    }

}
