using UnityEngine;

public class SunBehavior : SceneProgressElement
{
    public GameObject CenterObject;
    public GameObject MidLayerObject;
    public GameObject OuterObject;

    public float CenterScaleIncrease = 3.0f;
    public float MidLayerScaleIncrease = 2.0f;
    public float OuterScaleIncrease = 1.0f;
    public Vector3 EndPosition;
    
	public override void Start()
    {
        base.Start();

        _initialCenterScale = CenterObject.transform.localScale.x;
        _initialMidLayerScale = MidLayerObject.transform.localScale.x;
        _initialOuterScale = OuterObject.transform.localScale.x;
        _initialPosition = this.transform.localPosition;
    }

    public override void UpdateSceneProgress(float progress)
    {
        base.UpdateSceneProgress(progress);

        float centerScale = _initialCenterScale + this.CenterScaleIncrease * progress;
        float midLayerScale = _initialMidLayerScale + this.MidLayerScaleIncrease * progress;
        float outerScale = _initialOuterScale + this.OuterScaleIncrease * progress;
        CenterObject.transform.localScale = new Vector3(centerScale, centerScale, centerScale);
        MidLayerObject.transform.localScale = new Vector3(midLayerScale, midLayerScale, midLayerScale);
        OuterObject.transform.localScale = new Vector3(outerScale, outerScale, outerScale);

        this.transform.position = _initialPosition + ((this.EndPosition - _initialPosition) * progress);
    }

    /**
     * Private
     */
    private float _initialCenterScale;
    private float _initialMidLayerScale;
    private float _initialOuterScale;
    private Vector3 _initialPosition;
}
