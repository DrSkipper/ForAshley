using UnityEngine;

public class FilledCircleRenderer : VoBehavior
{
    public GameObject SlicePrefab;
    public float InitialRadius = 1.0f;
    public int NumPoints = 16;
    public float Adjustment = 0.1f;

    void Start()
    {
        _radius = this.InitialRadius;
        this.Reconstruct();
    }

    public void Reconstruct()
    {
        if (_lines != null)
        {
            foreach (LineRenderer line in _lines)
                Destroy(line.gameObject);
        }

        _lines = new LineRenderer[this.NumPoints];
        float angleIncrement = 360.0f / (float)this.NumPoints;

        float thetaScale = (2.0f * Mathf.PI) / ((float)this.NumPoints) + this.Adjustment;
        Vector2 first = new Vector2(_radius * Mathf.Cos(thetaScale * 2.5f), _radius * Mathf.Sin(thetaScale * 2.5f)); //Vector2.up;
        Vector2 second = new Vector2(_radius * Mathf.Cos(thetaScale * 1.5f), _radius * Mathf.Sin(thetaScale * 1.5f));
        float dist = Vector2.Distance(first, second);

        for (int i = 0; i < this.NumPoints; i += 1)
        {
            GameObject slice = Instantiate(SlicePrefab, Vector3.zero, Quaternion.identity) as GameObject;
            slice.transform.parent = this.transform;
            slice.transform.localPosition = Vector3.zero;
            slice.transform.localRotation = Quaternion.AngleAxis(angleIncrement * i, new Vector3(0, 0, 1));


            _lines[i] = slice.GetComponent<LineRenderer>();
            _lines[i].SetWidth(0.0f, dist);
        }
    }

    /**
     * Private
     */
    private LineRenderer[] _lines;
    private bool _dirty;
    private float _radius;
}
