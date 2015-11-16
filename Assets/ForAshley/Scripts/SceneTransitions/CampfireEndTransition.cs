using UnityEngine;

public class CampfireEndTransition : TransitionHandler
{
    public GameObject ShootingStars;
    public GameObject ClosingTrack;

    public override void HandleLockEntered()
    {
        base.HandleLockEntered();
        ShootingStars.GetComponent<ParticleSystem>().Play();
    }

    public override void HandleLockOver()
    {
        base.HandleLockOver();
        ClosingTrack.GetComponent<AudioSource>().Play();
    }
}
