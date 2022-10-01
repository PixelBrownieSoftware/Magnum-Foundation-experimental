using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class s_move2d : MonoBehaviour, i_movemnet2d
{
    Rigidbody2D _rbody;
    public float speed;
    Vector2 _velVector;

    public void MoveVelocity(Vector2 moveVec)
    {
        _velVector = moveVec;
    }

    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rbody.velocity = _velVector * speed;
    }
}
