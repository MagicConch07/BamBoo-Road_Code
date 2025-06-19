using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform _mainCam;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpPower = 10f;
    [SerializeField] LayerMask _jumpLayer;
    [SerializeField] LayerMask _dieLayer;
    [SerializeField] private Color _rayColer;

    private Rigidbody _rigid;
    private bool _isGround;
    private float _maxDistance = 2f;
    private Vector3 _dir = Vector3.zero;
    private float _pos;
    private float _nextPos = 2.5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.z = Input.GetAxisRaw("Vertical");
        _dir = _dir.normalized;
        _pos = _dir.z;

        GroundCheak();
        PlayerMove();
        HitCheck();
        Debug.Log(_isGround);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        _rigid.velocity = _dir * _speed + Vector3.up * _rigid.velocity.y;
    }

    private void GroundCheak()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.down * 1f), Vector3.down, out hit, 0.6f, _jumpLayer))
        {
            _isGround = true;
        }

        else
        {
            _isGround = false;
        }
    }

    private void HitCheck()
    {
        if (Physics.BoxCast(transform.position, transform.lossyScale / 2.0f, transform.forward, out RaycastHit hit, transform.rotation, _maxDistance, _dieLayer))
        {
            GameManager.instance.GameOver();
        }
    }

    private void PlayerMove()
    {
        if (_pos == _nextPos)
        {
            _nextPos += _pos;
            GameManager.instance.ScorePlus();
        }
    }
}