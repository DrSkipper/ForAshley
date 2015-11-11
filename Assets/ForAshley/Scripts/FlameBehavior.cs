using UnityEngine;

public class FlameBehavior : SceneProgressElement
{
    public float AvgAlpha = 0.5f;
    public float FlickerAlpha = 0.2f;
    public float FlickerScale = 0.1f;
    public float FlickerRotation = 10.0f;
    public float FlickerDuration = 0.1f;

    public float AlphaIncrease = 0.1f;
    public float DurationDecrease = 0.05f;
    public float RotationIncrease = 55.0f;
    public float ScaleIncrease = 1.5f;

    public override void Start()
    {
        base.Start();

        _targetAlpha = this.AvgAlpha;
        _targetDuration = this.FlickerDuration;
        _initialXScale = this.transform.localScale.x;
        _initialYScale = this.transform.localScale.y;
        _initialRotation = 0.0f;
    }

    void Update()
    {
        if (_flickerCooldown <= 0.0f)
        {
            _flickerCooldown = this.FlickerDuration;

            Color color = this.spriteRenderer.color;
            color.a = this.AvgAlpha + Random.Range(-this.FlickerAlpha, this.FlickerAlpha);
            this.spriteRenderer.color = color;

            this.transform.localRotation = Quaternion.AngleAxis(_targetRotation + Random.Range(-this.FlickerRotation, this.FlickerRotation), new Vector3(0, 0, -1));
            this.transform.localScale = new Vector3(_initialXScale + Random.Range(-this.FlickerScale, this.FlickerScale), _targetYScale + Random.Range(-this.FlickerScale, this.FlickerScale), this.transform.localScale.z);
        }
        else
        {
            _flickerCooldown -= Time.deltaTime;
        }
	}

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        this.AvgAlpha = _targetAlpha + this.AlphaIncrease * progress;
        this.FlickerDuration = _targetDuration - this.DurationDecrease * progress;

        _targetRotation = _initialRotation + this.RotationIncrease * progress;
        _targetYScale = _initialYScale + this.ScaleIncrease * progress;
    }

    /**
     * Private
     */
    private float _flickerCooldown;
    private float _targetAlpha;
    private float _targetDuration;
    private float _initialXScale;
    private float _initialYScale;
    private float _initialRotation;
    private float _targetRotation;
    private float _targetYScale;
}
