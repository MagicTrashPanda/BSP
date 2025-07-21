using UnityEngine;

public class AlwaysUpSprite : MonoBehaviour
{
    void Start()
    {
    }
    
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = 0f; // Lock Y rotation to 0
        currentRotation.z = 0f; // Lock Z rotation to 0
        transform.eulerAngles = currentRotation;
    }
}