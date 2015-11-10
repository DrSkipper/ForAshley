using UnityEngine;
using System.Collections.Generic;

public class SceneProgressor : VoBehavior
{
    public delegate void SceneProgressCallback(float progress);

    public float ProgressSpeed = 0.2f;
    public float RegressSpeed = 0.1f;
    public float CurrentProgress = 0.0f;
    public List<SceneProgressCallback> SceneProgressCallbacks = new List<SceneProgressCallback>();

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (this.CurrentProgress < 1.0f)
            {
                this.CurrentProgress = Mathf.Min(this.CurrentProgress + (this.ProgressSpeed * Time.deltaTime), 1.0f);
                foreach (SceneProgressCallback callback in this.SceneProgressCallbacks)
                    callback(this.CurrentProgress);
            }
        }
        else if (this.CurrentProgress >= 0.0f)
        {
            this.CurrentProgress = Mathf.Max(this.CurrentProgress - (this.RegressSpeed * Time.deltaTime), 0.0f);
            foreach (SceneProgressCallback callback in this.SceneProgressCallbacks)
                callback(this.CurrentProgress);
        }
    }
}
