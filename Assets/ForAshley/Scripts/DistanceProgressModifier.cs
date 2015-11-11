using UnityEngine;

public class DistanceProgressModifier : ProgressModifier
{
    public Transform Target;
    public float MaxEffectRange = 0.0f;
    public float MinEffectRange = 10.0f;
    public float MaxEffectModifier = 1.0f;
    public float MinEffectModifier = 0.0f;

    public const float SMALL = 0.001f;

    void Start()
    {
        _prevPosition = this.transform.position;
        updateEffect();
    }

    void Update()
    {
        if ((this.transform.position - _prevPosition).magnitude > SMALL)
        {
            _prevPosition = this.transform.position;
            updateEffect();
        }
    }

    /**
     * Private
     */
    Vector3 _prevPosition;

    private void updateEffect()
    {
        float distance = Vector2.Distance(this.transform.position, Target.position);
        float distanceEffect = 1.0f;

        if (distance >= this.MinEffectRange)
            distanceEffect = 0.0f;
        else if (distance > this.MaxEffectRange)
            distanceEffect = 1.0f - ((distance - this.MaxEffectRange) / (this.MinEffectRange - this.MaxEffectRange));

        this.Modifier = this.MinEffectModifier + ((this.MaxEffectModifier - this.MinEffectModifier) * distanceEffect);
    }
}
