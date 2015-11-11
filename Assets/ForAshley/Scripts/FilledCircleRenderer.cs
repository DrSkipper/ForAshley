using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class FilledCircleRenderer : VoBehavior
{
    public float InitialRadius = 1.0f;
    public int NumPoints = 16;
    public float Radius { get { return _radius; } set { _radius = value; _dirty = true; } }

    void Start()
    {
        _radius = this.InitialRadius;
        _meshFilter = this.GetComponent<MeshFilter>();
        _mesh = new Mesh();
        this.Reconstruct();
    }

    void Update()
    {
        if (_dirty)
        {
            _dirty = false;
            this.Reconstruct();
        }
    }

    public void Reconstruct()
    {
        Vector3[] verts = new Vector3[this.NumPoints + 1];
        Vector3[] norms = new Vector3[this.NumPoints + 1];
        Vector2[] uv = new Vector2[this.NumPoints + 1];
        int[] tris = new int[this.NumPoints * 3];

        Vector3 norm = new Vector3(0, 0, -1);
        for (int i = 0; i < norms.Length; ++i)
            norms[i] = norm;
        
        Vector2 firstUV = new Vector2(0, 1);
        Vector2 secondUV = new Vector2(1, 1);

        verts[0] = Vector3.zero;
        uv[0] = Vector2.zero;
        
        float thetaScale = (2.0f * Mathf.PI) / (float)this.NumPoints;
        
        // first vert
        verts[1] = new Vector3(_radius * Mathf.Cos(0), _radius * Mathf.Sin(0), 0);

        for (int i = 1; i < this.NumPoints; ++i)
        {
            int v = i + 1;
            int t = i * 3;
            verts[v] = new Vector3(_radius * Mathf.Cos(thetaScale * i), _radius * Mathf.Sin(thetaScale * i), 0);
            tris[t] = i;
            tris[t + 1] = v;
            tris[t + 2] = 0;
            uv[v] = i % 2 == 0 ? firstUV : secondUV;
        }

        // final triangle
        tris[0] = this.NumPoints;
        tris[1] = 1;
        tris[2] = 0;

        _mesh.vertices = verts;
        _mesh.normals = norms;
        _mesh.uv = uv;
        _mesh.triangles = tris;

        _meshFilter.mesh = _mesh;
    }

    /**
     * Private
     */
    private MeshFilter _meshFilter;
    private Mesh _mesh;
    private bool _dirty;
    private float _radius;
}
