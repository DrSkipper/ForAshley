using UnityEngine;

public class TransitionHandler : VoBehavior
{
    public float LockTime = 0.0f;
    public float TransitionTime = 0.0f;
    public string NextScene = "";

    public virtual void HandleLockEntered()
    {
        _started = true;
        _phaseTimer = this.LockTime;
    }

    public virtual void HandleLockOver()
    {
        _lockOver = true;
        _phaseTimer = this.TransitionTime;
    }

    public virtual void CompleteTransition()
    {
        _done = true;

        if (this.NextScene == "")
            Application.Quit();
        else
            Application.LoadLevel(this.NextScene);
    }

    public virtual void Update()
    {
        if (_started && !_done)
        {
            if (_phaseTimer <= 0.0f)
            {
                if (!_lockOver)
                    this.HandleLockOver();
                else
                    this.CompleteTransition();
            }

            _phaseTimer -= Time.deltaTime;
        }
    }

    /**
     * Protected
     */
    protected float _phaseTimer;
    protected bool _started;
    protected bool _lockOver;
    protected bool _done;
}
