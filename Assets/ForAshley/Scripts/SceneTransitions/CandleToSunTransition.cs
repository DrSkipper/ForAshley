using UnityEngine;

public class CandleToSunTransition : TransitionHandler
{
    public GameObject CandleBlowoutSoundSource;
    public Texture2D ScreenCover;
    public Color ScreenCoverColor;
    public int DrawDepth = -1000;

    public override void HandleLockOver()
    {
        base.HandleLockOver();
        this.CandleBlowoutSoundSource.GetComponent<AudioSource>().Play();
    }

    void OnGUI()
    {
        if (_lockOver)
        {
            GUI.color = this.ScreenCoverColor;
            GUI.depth = this.DrawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.ScreenCover);
        }
    }
}
