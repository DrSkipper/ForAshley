using UnityEngine;

public class SceneProgressElement : VoBehavior
{
    public GameObject SceneProgressor;

    public virtual void Start()
    {
        if (this.SceneProgressor != null)
            this.SceneProgressor.GetComponent<SceneProgressor>().SceneProgressCallbacks.Add(this.UpdateSceneProgress);
    }

    public virtual void UpdateSceneProgress(float progress)
    {
    }
}
