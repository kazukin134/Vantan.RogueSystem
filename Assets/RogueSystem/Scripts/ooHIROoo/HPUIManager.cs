using UnityEngine;
using UnityEngine.UI;

public class HPUIManager : MonoBehaviour {

    [SerializeField]
    Image _image = null;
	
	void Update ()
    {
        // プレイヤーの情報から取得できるようにする
        // current_hp / max_hp
        _image.fillAmount = 1.0f;
	}
}