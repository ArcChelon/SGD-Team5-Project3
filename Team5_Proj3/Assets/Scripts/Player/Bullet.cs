using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3 shootDir;

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        //transform.eulerAngles = new Vector3(rotation.x, rotation.y, 90);
        Destroy(gameObject, 5f);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
}
