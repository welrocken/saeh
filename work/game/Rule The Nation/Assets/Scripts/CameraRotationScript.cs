using UnityEngine;

public class CameraRotationScript : MonoBehaviour {
    private bool started = false;
    
    public Camera targetCamera;
    public float targetRotationY;
    public float stepSize = 0.05f;

    private void Update()
    {
        var difference = Mathf.Abs(targetCamera.transform.rotation.eulerAngles.y - targetRotationY);
        
        if (started)
        {
            if (difference <= stepSize)
            {
                targetCamera.transform.rotation = Quaternion.Euler(
                    targetCamera.transform.rotation.eulerAngles.x,
                    targetRotationY,
                    targetCamera.transform.rotation.eulerAngles.z);
                started = false;
            }
            else
                targetCamera.transform.rotation = Quaternion.Euler(
                    targetCamera.transform.rotation.eulerAngles.x,
                    targetCamera.transform.rotation.eulerAngles.y + stepSize,
                    targetCamera.transform.rotation.eulerAngles.z);
        }
    }

    public void Rotate()
    {
        started = true;
    }
}