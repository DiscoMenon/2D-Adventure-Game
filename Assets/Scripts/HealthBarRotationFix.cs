using UnityEngine;

public class HealthbarFixRotation : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 euler = transform.parent.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
