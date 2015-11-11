using UnityEngine;

public class VisibilityProgressRange : SceneProgressElement
{
    public float VisibilityStart = 0.0f;
    public float Duration = 1.0f;

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);
        this.gameObject.SetActive(progress >= this.VisibilityStart && progress <= this.VisibilityStart + this.Duration);
    }
}
