using UnityEngine;

public class CameraSprintFOV_Nekor : MonoBehaviour
{
    [SerializeField] Camera camera;
    float normalFOV = 60;
    [SerializeField] float sprintFOV = 70;
    [SerializeField] float speedFOVChanging = 5;
    [SerializeField] PlayerMove_Neko playerMover;

    private void Awake()
    {
        normalFOV = camera.fieldOfView;
    }

    void Update()
    {
        if (playerMover.isSprinting)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, sprintFOV, speedFOVChanging * Time.deltaTime);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normalFOV, speedFOVChanging * Time.deltaTime);
        }
    }
}
