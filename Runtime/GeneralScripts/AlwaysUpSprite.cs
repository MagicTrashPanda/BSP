using UnityEngine;

public class AlwaysUpSprite : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.eulerAngles = Vector3.up;
    }
}