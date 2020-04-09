using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    private float _xMov;
    private float _zMov;
    private float _yRot;
    private float _xRot;

    private Vector3 _movHorizontal;
    private Vector3 _movVertical;
    private Vector3 _velocity;
    private Vector3 _rotation;
    private Vector3 _camerarotation;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        _xMov = Input.GetAxisRaw("Horizontal");
        _zMov = Input.GetAxisRaw("Vertical");

        _movHorizontal = transform.right * _xMov; 
        _movVertical = transform.forward * _zMov;
        //Final movement vector
        _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (turing around)
        _yRot = Input.GetAxisRaw("Mouse X");
        _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turing around)
        _xRot = Input.GetAxisRaw("Mouse Y");
        _camerarotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_camerarotation);

    }

}
