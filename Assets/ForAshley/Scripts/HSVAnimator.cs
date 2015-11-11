using UnityEngine;

public class HSVAnimator : SceneProgressElement
{
    public Color[] ColorFrames; // Assumes to be evenly split across animation period

    public override void Start()
    {
        base.Start();

        _startColor = this.spriteRenderer.color;
        _frameDuration = 1.0f / this.ColorFrames.Length;
    }

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        float frameCount = progress / _frameDuration;
        int targetIndex = (int)frameCount;
        float progressInFrame = frameCount - targetIndex;
        Color color = this.spriteRenderer.color;
        Color nextColor = targetIndex < this.ColorFrames.Length ? this.ColorFrames[targetIndex] : this.ColorFrames[this.ColorFrames.Length - 1];
        Color previousColor = targetIndex == 0 ? _startColor : this.ColorFrames[targetIndex - 1];

        ColorExtensions.HSV prevHSV = previousColor.GetHSV();
        ColorExtensions.HSV nextHSV = nextColor.GetHSV();
        float h = prevHSV.h + ((nextHSV.h - prevHSV.h) * progressInFrame);
        float s = prevHSV.s + ((nextHSV.s - prevHSV.s) * progressInFrame);
        float v = prevHSV.v + ((nextHSV.v - prevHSV.v) * progressInFrame);

        ColorExtensions.RGB rgb = ColorExtensions.HsvToRgb(h, s, v);
        color.r = rgb.r;
        color.g = rgb.g;
        color.b = rgb.b;
        this.spriteRenderer.color = color;
    }

    /**
     * Private
     */
    private Color _startColor;
    private float _frameDuration;
}
