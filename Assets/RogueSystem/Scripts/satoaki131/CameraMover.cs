using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    [SerializeField]
    private PlayerState _state = null;

    void Update()
    {
        transform.position = new Vector3(_state.transform.position.x, 0, _state.transform.position.z);
    }

}
