using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの回転の処理
/// </summary>
public class CameraRotater : MonoBehaviour {

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
    public bool isRotate
    {
        get { return _isRotate; }
    }

    void Start()
    {

    }

    void Update()
    {
        if (_isRotate) return;
        if(InputAxisManager.cameraRotateDirection != 0 && InputAxisManager.isDiagonal)
        {
            StartCoroutine(Rotate());
        }
    }

    private IEnumerator Rotate()
    {
        _isRotate = true;
        cameraState = cameraState == RotateState.Horizontal ? RotateState.Vertical : RotateState.Horizontal;
        var time = 0.0f;
        var rotation = transform.eulerAngles;
        float endRotationY = transform.eulerAngles.y + (90 * InputAxisManager.cameraRotateDirection);
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
