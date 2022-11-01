using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{

    [SerializeField] float shooterHealth;
    [SerializeField] float runnerHealth;
    private float iterationHealth;






    // Start is called before the first frame update
    void Start()
    {
        determineEnemie();
        Destroy(gameObject, 15f);
        if(this.gameObject.transform.position.z > 3.5)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void determineEnemie()
    {
        string tag = this.gameObject.tag;
        switch (tag)
        {
            case "Shooter":
                iterationHealth = shooterHealth;
                print("Gave Enemie Shooter health");
                break;
            case "Runner":
                iterationHealth = runnerHealth;
                print("Gave Enemie Runner health");
                break;
        }
    }
    public void damageEnemie(float damage)
    {
        iterationHealth -= damage;
        if(iterationHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
