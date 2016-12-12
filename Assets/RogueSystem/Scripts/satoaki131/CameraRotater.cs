using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの回転の処理
/// </summary>
public class CameraRotater : MonoBehaviour {

    enum Direction
    {
        Left,
        Right
    }

    private Direction _direction = Direction.Left;

    public enum RotateState
    {
        Vertical,
        Horizontal
    }

    public RotateState cameraState
    {
        get; private set;
    }

    [SerializeField]
    private float _rotateMoveTime = 2.0f;

    private bool _isRotate = false;

    void Start()
    {

    }

    void Update()
    {
        if (_isRotate) return;
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            _direction = Direction.Left;
            StartCoroutine(Rotate());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            _direction = Direction.Right;
            StartCoroutine(Rotate());
        }

    }

    private IEnumerator Rotate()
    {
        _isRotate = true;
        cameraState = cameraState == RotateState.Horizontal ? RotateState.Vertical : RotateState.Horizontal;
        var time = 0.0f;
        var rotation = transform.eulerAngles;
        float endRotationY = _direction == Direction.Right ? transform.eulerAngles.y - 90 : transform.eulerAngles.y + 90;
        while (time < _rotateMoveTime)
        {
            time += Time.deltaTime;
            rotation.y = Mathf.Lerp(rotation.y, endRotationY, time / _rotateMoveTime);
            transform.eulerAngles = rotation;
            yield return null;
        }
        _isRotate = false;

    }
}
