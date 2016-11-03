using UnityEngine;
using System.Collections;

public class BallTypeB : BallTypeA
{
    private float _horDir;
    private float _spriteWidth;
    private Vector3 _spawnMinPos;
    private Vector3 _spawnMaxPos;
   
    override protected void Start () {
        base.Start();
        _horDir = Random.Range(0, 2) * 2 - 1;//excluding "0" from random
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        _spawnMinPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1)) +
                                  new Vector3(_spriteWidth, 0, 0);
        _spawnMaxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1)) -
                             new Vector3(_spriteWidth, 0, 0);
    }
	
    override protected void Move()
    {
        base.Move();
        //if edge of the screen reached switch horizontal direction
        if (transform.position.x > _spawnMaxPos.x || transform.position.x < _spawnMinPos.x)
            _horDir *= -1;
        transform.position+= new Vector3(_horDir,0,0) * Time.deltaTime * speed;
    }  
}
