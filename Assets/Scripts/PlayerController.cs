using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float controlSpeed = 10;
    [SerializeField] float xRange = 10;
    [SerializeField] float yRange = 7;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] InputAction movement;

    float horizontalThrow;
    float verticalThrow;

    float xThrow, yThrow;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
      /*  xThrow = movement.ReadValue<Vector2>().x;
       // Debug.Log(xThrow);
        yThrow = movement.ReadValue<Vector2>().y;
       // Debug.Log(yThrow);*/

        horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);

        verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);

        float xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        float rawXpos = transform.localPosition.x + xOffset;
        float ClampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float yOffset = verticalThrow * Time.deltaTime * controlSpeed;
        float rawYpos = transform.localPosition.y + yOffset;
        float ClampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(ClampedXpos, ClampedYpos, transform.localPosition.z);
    }
}
