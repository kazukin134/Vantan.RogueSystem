using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの回転に関するスクリプト
/// </summary>
public class PlayerRotater : MonoBehaviour {

    private PlayerState _state = null;

    void Start()
    {
        _state = GetComponent<PlayerState>();
    }

    void Update()
    {
        RotationUpdate();
    }

    private void RotationUpdate()
    {
        if (_state.vertical > 0)
        {
            _state.setPlayerState(PlayerState.Direction.Up);
        }
        else if (_state.vertical < 0)
        {
            _state.setPlayerState(PlayerState.Direction.Down);
        }
        else if (_state.horizontal > 0)
        {
            _state.setPlayerState(PlayerState.Direction.Right);
        }
        else if (_state.horizontal < 0)
        {
            _state.setPlayerState(PlayerState.Direction.Left);
        }
    }

    /// <summary>
    /// Playerの向きを決める関数
    /// カメラの向きにあわせて回転
    /// </summary>
    public void PlayerRotate()
    {
        var cameraForward = Vector3.Scale(_state.cameraObj.transform.forward, new Vector3(1, 0, 1)).normalized;

        if (_state.playerDirection == PlayerState.Direction.Up)
        {
            transform.rotation = cameraForward == Vector3.forward ? Quaternion.identity :
                cameraForward == Vector3.right ? Quaternion.Euler(0, 90, 0) :
                cameraForward == Vector3.back ? Quaternion.Euler(0, 180, 0) :
                cameraForward == Vector3.left ? Quaternion.Euler(0, 270, 0) : transform.rotation;
        }
        else if (_state.playerDirection == PlayerState.Direction.Right)
        {
            transform.rotation = cameraForward == Vector3.forward ? Quaternion.Euler(0, 90, 0) :
                cameraForward == Vector3.right ? Quaternion.Euler(0, 180, 0) :
                cameraForward == Vector3.back ? Quaternion.Euler(0, 270, 0) :
                cameraForward == Vector3.left ? Quaternion.identity : transform.rotation;
        }
        else if (_state.playerDirection == PlayerState.Direction.Down)
        {
            transform.rotation = cameraForward == Vector3.forward ? Quaternion.Euler(0, 180, 0) :
                cameraForward == Vector3.right ? Quaternion.Euler(0, 270, 0) :
                cameraForward == Vector3.back ? Quaternion.identity :
                cameraForward == Vector3.left ? Quaternion.Euler(0, 90, 0) : transform.rotation;
        }
        else if (_state.playerDirection == PlayerState.Direction.Left)
        {
            transform.rotation = cameraForward == Vector3.forward ? Quaternion.Euler(0, 270, 0) :
                cameraForward == Vector3.right ? Quaternion.identity :
                cameraForward == Vector3.back ? Quaternion.Euler(0, 90, 0) :
                cameraForward == Vector3.left ? Quaternion.Euler(0, 180, 0) : transform.rotation;
        }

    }


}
