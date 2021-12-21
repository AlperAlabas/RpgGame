using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField]
    private int pointCount;
    [SerializeField]
    private float force;
    [SerializeField]
    private int areaCount;
    private Vector2[] points;
    private int sector;
    PolygonCollider2D ColliderArc;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle=360/areaCount;
        ColliderArc = gameObject.AddComponent<PolygonCollider2D>();
        ColliderArc.isTrigger=true;
        points=new Vector2[pointCount];
        
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        findPoints(pointCount,areaCount,keyControl());
        createPolygonColliders(pointCount);
    }

    void findPoints(int points,int areas,int sector)
    {
        this.points[0]=new Vector2(0,0);
        for (int i = 0; i < points-1; i++)
        {
            this.points[i+1]=new Vector2(Mathf.Cos(Mathf.Deg2Rad*(((angle/(points-2))*i)+sector*45)),Mathf.Sin(Mathf.Deg2Rad*(((angle/(points-2))*i)+sector*45)));

            
        }
    }

    void createPolygonColliders(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ColliderArc.points=this.points;
        }

    }

    int keyControl()
    {       
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.D))
            {
                sector=0;
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1,1)*force,ForceMode2D.Impulse);
                return sector;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                sector=2;
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-1,1)*force,ForceMode2D.Impulse);
                return sector;
            }
            else
            {
                sector=1;
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1)*force,ForceMode2D.Impulse);
                return sector;
            }
            
            
        }        
        if(Input.GetKey(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.S))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-1,-1)*force,ForceMode2D.Impulse);
                sector=4;
                return sector;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-1,1)*force,ForceMode2D.Impulse);
                sector=2;
                return sector;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-1,0)*force,ForceMode2D.Impulse);
                sector=3;
                return sector;
            }
            
        }        
        if(Input.GetKey(KeyCode.S))
        {
            if(Input.GetKey(KeyCode.D))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1,-1)*force,ForceMode2D.Impulse);
                sector=6;
                return sector;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-1,-1)*force,ForceMode2D.Impulse);
                sector=4;
                return sector;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,-1)*force,ForceMode2D.Impulse);
                sector=5;
                return sector;
            }
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.S))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1,-1)*force,ForceMode2D.Impulse);
                sector=6;
                return sector;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1,1)*force,ForceMode2D.Impulse);
                sector=0;
                return sector;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1,0)*force,ForceMode2D.Impulse);
                sector=7;
                return sector;
            }
            
        }
        
        return sector;
    }
}
