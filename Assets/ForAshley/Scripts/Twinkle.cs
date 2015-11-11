using UnityEngine;

public class Twinkle : VoBehavior
{
    public Color TwinkleColor = Color.white;
    public float TwinkleOnDuration = 0.2f;
    public float TwinkleOffDuration = 0.3f;
    public float TwinkleOnWiggle = 0.1f;
    public float TwinkleOffWiggle = 0.1f;
    
	void Start()
    {
        _twinkleTimer = Random.Range(0.0f, this.TwinkleOffDuration + this.TwinkleOffWiggle);
        _normalColor = this.spriteRenderer.color;
	}
	
	void Update()
    {
        if (_twinkleTimer <= 0.0f)
        {
            if (_twinkleOn)
            {
                _twinkleOn = false;
                this.spriteRenderer.color = _normalColor;
                _twinkleTimer = Random.Range(this.TwinkleOffDuration - this.TwinkleOffWiggle, this.TwinkleOffWiggle + this.TwinkleOffWiggle);
            }
            else
            {
                _twinkleOn = true;
                this.spriteRenderer.color = this.TwinkleColor;
                _twinkleTimer = Random.Range(this.TwinkleOnDuration - this.TwinkleOnWiggle, this.TwinkleOnWiggle + this.TwinkleOnWiggle);
            }
        }

        _twinkleTimer -= Time.deltaTime;
	}

    /**
     * Private
     */
    private float _twinkleTimer;
    private bool _twinkleOn;
    private Color _normalColor;
}
