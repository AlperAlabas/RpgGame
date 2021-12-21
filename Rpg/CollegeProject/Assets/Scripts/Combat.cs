using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D arcCollider;
    [SerializeField]
    private Collider2D enemyCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(arcCollider==null)
        {
            arcCollider=gameObject.GetComponent<PolygonCollider2D>();
            
        }
        collideControl(enemyCollider);
    }

    void collideControl(Collider2D enemy)
    {   
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(arcCollider.IsTouching(enemy))
            {
                print("touching");
                enemy.gameObject.GetComponent<SpriteRenderer>().enabled=false;
            }
        }
        
    }

    
}
