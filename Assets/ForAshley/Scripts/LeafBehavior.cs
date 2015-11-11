using UnityEngine;

public class LeafBehavior : SceneProgressElement
{
    public float MaxRotation = 135.0f;
    public float Jitter = 0.0f;
    public float JitterIncrease = 10.0f;
    public float JitterCooldown = 0.5f;
    public float JitterCooldownDecrease = 0.4f;

    public override void Start()
    {
        base.Start();

        _initialJitter = this.Jitter;
        _initialJitterCooldown = this.JitterCooldown;
    }

    void Update()
    {
        if (_jitterCooldown <= 0.0f)
        {
            _jitterCooldown = this.JitterCooldown;

            _jitterAngle = Random.Range(-this.Jitter, this.Jitter) / 2.0f;
            this.transform.localRotation = Quaternion.AngleAxis(_angle + _jitterAngle, new Vector3(0, 0, -1));
        }

        _jitterCooldown -= Time.deltaTime;
    }

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        _angle = this.MaxRotation * progress;
        this.Jitter = _initialJitter + this.JitterIncrease * progress;
        this.JitterCooldown = _initialJitterCooldown + this.JitterCooldownDecrease * progress;
        this.transform.localRotation = Quaternion.AngleAxis(_angle + _jitterAngle, new Vector3(0, 0, -1));
    }

    /**
     * Private
     */
    private float _angle;
    private float _jitterAngle;
    private float _jitterCooldown;
    private float _initialJitter;
    private float _initialJitterCooldown;
}
