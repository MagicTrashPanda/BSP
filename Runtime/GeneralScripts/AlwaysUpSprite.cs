using UnityEngine;

public class AlwaysUpSprite : MonoBehaviour
{
    void Start()
    {
    }
    
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = 0f; // Lock X rotation to 0
        currentRotation.z = 0f; // Lock Z rotation to 0
        transform.eulerAngles = currentRotation;
    }
}