using UnityEngine;

public class Ball : ActiveItem
{
    [SerializeField] private BallSettings _ballSetttings;
    [SerializeField] private Renderer _renderer;

    public override void SetLevel(int level)
    {
        base.SetLevel(level);
        _renderer.material = _ballSetttings.BallMaterials[level];

        Projection.Setup(_ballSetttings.BallProjectionMaterials[level], _levelText.text, Radius);
    }
}
