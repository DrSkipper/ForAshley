using UnityEngine;

[ExecuteInEditMode]
public class ZIsY : VoBehavior
{
    public float Offset = 0.0f;

    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.Offset + this.transform.position.y);
    }

    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.Offset + this.transform.position.y);
    }
}
