using UnityEngine;
using System.Collections.Generic;

public class SceneProgressor : VoBehavior
{
    public delegate void SceneProgressCallback(float progress);

    public float ProgressSpeed = 0.2f;
    public float RegressSpeed = 0.1f;
    public float CurrentProgress = 0.0f;
    public List<SceneProgressCallback> SceneProgressCallbacks = new List<SceneProgressCallback>();
    public float HoldTimeAtEndForLock = 1.0f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (!_interactionLocked)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                if (this.CurrentProgress < 1.0f)
                {
                    this.CurrentProgress = Mathf.Min(this.CurrentProgress + (this.ProgressSpeed * Time.deltaTime), 1.0f);
                    foreach (SceneProgressCallback callback in this.SceneProgressCallbacks)
                        callback(this.CurrentProgress);
                }
                else
                {
                    if (_holdTimer >= this.HoldTimeAtEndForLock)
                    {
                        this.GetComponent<TransitionHandler>().HandleLockEntered();
                        _interactionLocked = true;
                    }
                    else
                    {
                        _holdTimer += Time.deltaTime;
                    }
                }
            }
            else
            {
                _holdTimer = 0.0f;

                if (this.CurrentProgress >= 0.0f)
                {
                    this.CurrentProgress = Mathf.Max(this.CurrentProgress - (this.RegressSpeed * Time.deltaTime), 0.0f);
                    foreach (SceneProgressCallback callback in this.SceneProgressCallbacks)
                        callback(this.CurrentProgress);
                }
            }
        }
    }

    /**
     * Private
     */
    private float _holdTimer;
    private bool _interactionLocked;
}
