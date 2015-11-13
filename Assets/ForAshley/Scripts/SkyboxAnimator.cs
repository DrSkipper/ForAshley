using UnityEngine;
using System.Collections;

public class SkyboxAnimator : SceneProgressElement
{
    public Color TargetColor;
    public float HFlicker = 0.1f;
    public float SFlicker = 0.1f;
    public float VFlicker = 0.1f;
    public float HFlickerIncrease = 0.1f;
    public float SFlickerIncrease = 0.1f;
    public float VFlickerIncrease = 0.1f;
    public float FlickerCooldown = 0.3f;
    public float FlickerCooldownWiggle = 0.1f;
    public float FlickerCooldownDecrease = 0.2f;
    
	public override void Start()
    {
        base.Start();

        _camera = this.GetComponent<Camera>();
        _initialHsv = _camera.backgroundColor.GetHSV();
        _targetHsv = this.TargetColor.GetHSV();
        _hsv = _initialHsv;
        _initialHFlicker = this.HFlicker;
        _initialSFlicker = this.SFlicker;
        _initialVFlicker = this.VFlicker;
        _initialCooldown = this.FlickerCooldown;
        _initialCooldownWiggle = this.FlickerCooldownWiggle;
	}
	
	void Update()
    {
        if (_cooldownTimer <= 0.0f)
        {
            _cooldownTimer = this.FlickerCooldown + Random.Range(-this.FlickerCooldownWiggle, this.FlickerCooldownWiggle);

            _currentHFlicker = Random.Range(-this.HFlicker, this.HFlicker);
            _currentSFlicker = Random.Range(-this.SFlicker, this.SFlicker);
            _currentVFlicker = Random.Range(-this.VFlicker, this.VFlicker);
            _camera.backgroundColor = ColorExtensions.ColorFromHsv(_hsv.h + _currentHFlicker, _hsv.s + _currentSFlicker, _hsv.v + _currentVFlicker);
        }

        _cooldownTimer -= Time.deltaTime;
	}

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        this.HFlicker = _initialHFlicker + this.HFlickerIncrease * progress;
        this.SFlicker = _initialSFlicker + this.SFlickerIncrease * progress;
        this.VFlicker = _initialVFlicker + this.VFlickerIncrease * progress;
        this.FlickerCooldown = _initialCooldown - this.FlickerCooldownDecrease * progress;

        _hsv.h = _initialHsv.h + ((_targetHsv.h - _initialHsv.h) * progress);
        _hsv.s = _initialHsv.s+ ((_targetHsv.s - _initialHsv.s) * progress);
        _hsv.v = _initialHsv.v + ((_targetHsv.v - _initialHsv.v) * progress);
        _camera.backgroundColor = ColorExtensions.ColorFromHsv(_hsv.h + _currentHFlicker, _hsv.s + _currentSFlicker, _hsv.v + _currentVFlicker);
    }

    /**
     * Private
     */
    private Camera _camera;
    private float _cooldownTimer;
    private ColorExtensions.HSV _hsv;
    private ColorExtensions.HSV _targetHsv;
    private ColorExtensions.HSV _initialHsv;
    private float _initialHFlicker;
    private float _initialSFlicker;
    private float _initialVFlicker;
    private float _initialCooldown;
    private float _initialCooldownWiggle;
    private float _currentHFlicker;
    private float _currentSFlicker;
    private float _currentVFlicker;
}
