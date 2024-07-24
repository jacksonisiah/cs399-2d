using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float pSpeed = 1;

    private Transform cameraT;
    private float lastCamPosX;

    private void Start()
    {
        cameraT = Camera.main?.transform;
        lastCamPosX = cameraT.position.x;
    }

    private void LateUpdate()
    {
        var curCamPosX = cameraT.position.x;
        var deltaMov = curCamPosX - lastCamPosX;

        // move sprite opposite direction of character by pSpeed
        transform.position = new Vector3(transform.position.x + deltaMov * pSpeed * -0.1f, transform.position.y,
            transform.position.z);
        lastCamPosX = cameraT.position.x;
    }
}