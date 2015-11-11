using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class FireProgressor : SceneProgressElement
{
    public float MinProgressForFire = 0.2f;
    public float LifetimeMaxIncrease = 0.8f;
    public float SpeedMaxIncrease = 2.0f;
    public float SizeMaxIncrease = 0.5f;
    public float RateIncrease = 8;

    public override void Start()
    {
        base.Start();

        _particles = this.GetComponent<ParticleSystem>();
        _initialLifetimeMax = _particles.startLifetime;
        _initialSpeedMax = _particles.startSpeed;
        _initialSizeMax = _particles.startSize;
        _initialRate = _particles.emissionRate;
    }

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        if (progress < this.MinProgressForFire)
        {
            _particles.enableEmission = false;
        }
        else
        {
            float remainingProgress = (progress - this.MinProgressForFire) / (1.0f - this.MinProgressForFire);
            _particles.startLifetime = _initialLifetimeMax + this.LifetimeMaxIncrease * remainingProgress;
            _particles.startSpeed = _initialSpeedMax + this.SpeedMaxIncrease * remainingProgress;
            _particles.startSize = _initialSizeMax + this.SizeMaxIncrease * remainingProgress;
            _particles.emissionRate = _initialRate + this.RateIncrease * remainingProgress;

            if (!_particles.enableEmission)
                _particles.enableEmission = true;
        }
    }

    /**
     * Private
     */
    private ParticleSystem _particles;
    private float _initialLifetimeMax;
    private float _initialSpeedMax;
    private float _initialSizeMax;
    private float _initialRate;
}
