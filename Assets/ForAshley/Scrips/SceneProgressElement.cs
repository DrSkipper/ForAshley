using UnityEngine;

public class SceneProgressElement : VoBehavior
{
    public GameObject SceneProgressor;

    public virtual void Start()
    {
        if (this.SceneProgressor != null)
        {
            this.SceneProgressor.GetComponent<SceneProgressor>().SceneProgressCallbacks.Add(this.UpdateSceneProgress);
            _progressModifiers = this.GetComponents<ProgressModifier>();
        }
    }

    public void UpdateSceneProgress(float progress)
    {
        foreach (ProgressModifier modifier in _progressModifiers)
            progress *= modifier.Modifier;
        this.UpdateProgress(progress);
    }

    protected virtual void UpdateProgress(float progress)
    {
    }

    /**
     * Private
     */
    private ProgressModifier[] _progressModifiers;
}
