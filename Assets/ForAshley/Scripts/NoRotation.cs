using UnityEngine;

[ExecuteInEditMode]
public class NoRotation : VoBehavior
{
	void Start()
    {
        this.transform.rotation = Quaternion.identity;
	}

    void Update()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
