using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D enemy;
    [SerializeField]
    private Transform Target; 
    [SerializeField]
    private float force; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        motionOfEnemy();
    }

    void motionOfEnemy(){
        if(!this.gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            this.gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3(Random.Range(-9,9),Random.Range(-4,4),this.gameObject.GetComponent<Transform>().position.z),new Quaternion());
            this.gameObject.GetComponent<SpriteRenderer>().enabled=true;
        }
        else
        {
            Vector2 movementVector = new Vector2(Target.position.x,Target.position.y)- new Vector2(enemy.transform.position.x,enemy.transform.position.y);
            enemy.AddForce(movementVector.normalized*force);
        }
    }
}

