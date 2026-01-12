using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject toFollowObject;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = toFollowObject.transform.position + offset;
    }
}
