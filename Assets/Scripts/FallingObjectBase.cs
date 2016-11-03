using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public abstract class FallingObjectBase : MonoBehaviour
{
    protected float speed = 1f;
    private float _minY;
    
    protected virtual void Start()
    {
        _minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y - GetComponent<SpriteRenderer>().bounds.extents.y;
        speed=Random.Range(1f,3f);
    }

    
    protected virtual void Update()
    {
       
        if (transform.position.y <= _minY)
        {
           
            BottomReached();
        }
        Move();
    }

    protected virtual void Move()
    {
        transform.position += Vector3.down*Time.deltaTime*speed;
    }

    protected virtual void BottomReached()
    {
        Destroy(gameObject);
    }
    
}
