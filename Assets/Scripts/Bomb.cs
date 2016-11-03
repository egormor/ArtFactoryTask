using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Bomb : BallTypeB {
    protected override void BottomReached()
    {
       Destroy(gameObject);
    }

    void OnMouseDown()
    {
        GameManager.Instance.ReduceHealth(5);
    }    
}
