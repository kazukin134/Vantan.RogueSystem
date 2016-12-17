using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerRotater))]
/// <summary>
/// Playerの情報を管理するスクリプト
/// </summary>
public class PlayerState : MonoBehaviour {

    [SerializeField]
    private CameraRotater _camera = null;
    public CameraRotater cameraObj
    {
        get { return _camera; }
    }

    private float _moveTime = 1.0f;
    public float moveTime
    {
        get { return _moveTime; }
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }

    /// <summary>
    /// Playerの向き
    /// </summary>
    public Direction playerDirection
    {
        get; private set;
    }

    /// <summary>
    /// 横の入力
    /// </summary>
    public int horizontal
    {
        get; private set;
    }

    /// <summary>
    /// 縦の入力
    /// </summary>
    public int vertical
    {
        get; private set;
    }

    /// <summary>
    /// Playerの向きを指定する関数
    /// </summary>
    /// <param name="direction"></param>
    public void setPlayerState(Direction direction)
    {
        playerDirection = direction;
    }

    void Update()
    {
        horizontal = InputAxisManager.x;
        vertical = InputAxisManager.z;

    }

}
