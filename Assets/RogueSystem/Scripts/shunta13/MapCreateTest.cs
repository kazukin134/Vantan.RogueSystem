using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreateTest : MonoBehaviour {

    [SerializeField]
    int _x = 0;
    public int x { get { return _x; } }

    [SerializeField]
    int _y = 0;
    public int y { get { return _y; } }

    [SerializeField]
    GameObject _wall = null;

    [SerializeField]
    GameObject _floor = null;

    int[][] _map;

    // Use this for initialization
    void Start()
    {      
        // 配列生成
        _map = new int[x][];
        for (int i = 0; i < _map.Length; ++i)
        {
            if (i == 0 || i == _map.Length - 1)
            {
                _map[i] = new int[y];
            }
            else
            {
                _map[i] = new int[y];
            }
        }

        // マップのデータを入れる
        for (int x = 0; x < _map.Length; ++x)
        {
            for (int y = 0; y < _map[x].Length; ++y)
            {
                // 周りを壁にする
                if (x == 0 || x == _map.Length - 1 || y == 0 || y == _map[x].Length - 1)
                {
                    _map[x][y] = 1;
                }
                // 一部壁にする
                else if (y == _map[x].Length / 2 && x != _map.Length / 2)
                {
                    _map[x][y] = 1;
                }
                // 一部通れる壁
                else if (y == _map[x].Length / 2 && x == _map.Length / 2)
                {
                    _map[x][y] = 0;
                }
                // それ以外通れる
                else
                {
                    _map[x][y] = 0;
                }
            }
        }

        // マップ生成
        for (int x = 0; x < _map.Length; ++x)
        {
            for (int y = 0; y < _map[x].Length; ++y)
            {
                if(_map[x][y] == 0)
                {
                    var obj = Instantiate(_floor);
                    obj.transform.parent = transform;
                    obj.transform.position = new Vector3(x, 0, y);                
                }
                else if (_map[x][y] == 1)
                {
                    var obj = Instantiate(_wall);
                    obj.transform.parent = transform;
                    obj.transform.position = new Vector3(x, 0, y);
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
