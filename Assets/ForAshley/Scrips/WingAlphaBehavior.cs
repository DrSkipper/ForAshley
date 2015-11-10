using UnityEngine;

public class WingAlphaBehavior : SceneProgressElement
{
    public float MinAlpha = 0.0f;
    public float MaxAlpha = 0.7f;
    public float Frequency = 1.0f;

    public float MaxAlphaIncrease = 0.3f;
    public float FrequencyIncrease = 1.0f;

    public override void Start()
    {
        base.Start();

        _initialFrequency = this.Frequency;
        _initialMaxAlpha = this.MaxAlpha;
    }

    public override void UpdateSceneProgress(float progress)
    {
        base.UpdateSceneProgress(progress);

        this.MaxAlpha = _initialMaxAlpha + this.MaxAlphaIncrease * progress;
        this.Frequency = _initialFrequency + this.FrequencyIncrease * progress;

        Color color = this.spriteRenderer.color;
        color.a = this.MinAlpha + ((this.MaxAlpha - this.MinAlpha) * Mathf.Sin(progress * this.Frequency));
        this.spriteRenderer.color = color;
    }

    /**
     * Private
     */
    private float _initialMaxAlpha;
    private float _initialFrequency;
}

