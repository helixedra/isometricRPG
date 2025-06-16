using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class DiabloStyleController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // get the plane of the ground
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = (hitPoint - transform.position);
            direction.y = 0f;

            // if mouse button is pressed and direction is greater than 0.1f
            if (Input.GetMouseButton(0) && direction.magnitude > 0.1f)
            {
                Vector3 moveDir = direction.normalized;
                controller.Move(moveDir * moveSpeed * Time.deltaTime);

                // rotate player to cursor
                Quaternion lookRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }
    }
}
