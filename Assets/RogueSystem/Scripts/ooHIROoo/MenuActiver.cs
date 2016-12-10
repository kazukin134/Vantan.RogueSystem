using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActiver : MonoBehaviour {

    [SerializeField]
    GameObject _menuUI = null;

	
	void Update () {
        if (!Input.GetMouseButtonDown(1)) return;
        _menuUI.SetActive(!_menuUI.activeSelf);
	}
}
