using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class Shoot : MonoBehaviour
{

    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction shootAction;

    [SerializeField] Transform bullet;
    [SerializeField] Transform gunBarrel;
    [SerializeField] Transform targetPosition;

    private Vector3 positionStart;
    private Quaternion bulletRotation;


    




    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        shootAction = playerInput.actions["Shoot"];
    }
    private void Start()
    {
        positionStart = new Vector3(gunBarrel.position.x, gunBarrel.position.y, gunBarrel.position.z);
        bulletRotation = gunBarrel.rotation;
    }
    private void OnEnable()
    {
        shootAction.performed += _ => OnFire();
    }

    // Update is called once per frame
    void Update()
    {
        positionStart = new Vector3(gunBarrel.position.x, gunBarrel.position.y, gunBarrel.position.z);
    }


    private void OnFire()
    {
        print("Player has shot");
        Transform Shot = Instantiate(bullet, positionStart, bulletRotation);

        Vector3 shootDir = (targetPosition.position - positionStart).normalized;
        Shot.GetComponent<Bullet>().Setup(shootDir);





    }

}
