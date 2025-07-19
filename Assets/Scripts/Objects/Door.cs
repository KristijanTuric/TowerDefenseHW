using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorHinge;

    private bool isOpen;

    private Coroutine doorRotationCoroutine;
    
    public void OpenDoor(bool hasKey)
    {
        // Open the door
        //doorHinge.transform.rotation = Quaternion.Euler(0, 90, 0);
        
        if (!hasKey) return;
            
        if (doorRotationCoroutine != null) StopCoroutine(doorRotationCoroutine);
        
        isOpen = !isOpen;
        float targetAngle = isOpen ? -90f : 0f;

        doorRotationCoroutine = StartCoroutine(RotateDoor(targetAngle));
    }

    /// <summary>
    /// Rotates the door in 1 second
    /// </summary>
    /// <param name="targetAngle">The target angle on the y axis we want to rotate to</param>
    /// <returns></returns>
    private IEnumerator RotateDoor(float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        float timer = 0;

        while (timer < 1)
        {
            doorHinge.transform.rotation = Quaternion.Slerp(doorHinge.transform.rotation, targetRotation, timer);
            
            timer += Time.deltaTime;
            yield return null;
            
        }

        doorHinge.transform.rotation = targetRotation;
    }
}
