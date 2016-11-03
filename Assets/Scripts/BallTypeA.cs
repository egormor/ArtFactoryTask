using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BallTypeA : FallingObjectBase {
    override protected void BottomReached()
    {
        GameManager.Instance.ReduceHealth(1);
        base.BottomReached();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
