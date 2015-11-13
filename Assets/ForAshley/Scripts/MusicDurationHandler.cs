using UnityEngine;

public class MusicDurationHandler : SceneProgressElement
{
    public float BeginFadeIn = 0.0f;
    public float EndFadeIn = 0.0f;
    public float BeginFadeOut = 1.0f;
    public float EndFadeOut = 1.0f;
    public float MinimalVolume = 0.0f;

    public override void Start()
    {
        base.Start();
        _audio = this.GetComponent<AudioSource>();
        _baseVolume = _audio.volume;
        _audio.Pause();
    }

    protected override void UpdateProgress(float progress)
    {
        base.UpdateProgress(progress);

        if (progress < this.BeginFadeIn || progress >= this.EndFadeOut)
        {
            _audio.Pause();
        }
        else
        {
            _audio.UnPause();

            if (progress < this.EndFadeIn)
                _audio.volume = this.MinimalVolume + (_baseVolume - this.MinimalVolume) * ((progress - this.BeginFadeIn) / (this.EndFadeIn - this.BeginFadeIn));
            else if (progress > this.BeginFadeOut)
                _audio.volume = this.MinimalVolume + (_baseVolume - this.MinimalVolume) * (1.0f - ((progress - this.BeginFadeOut) / (this.EndFadeOut - this.BeginFadeOut)));
            else
                _audio.volume = _baseVolume;
        }
    }

    /**
     * Private
     */
    private float _baseVolume;
    private AudioSource _audio;
}
