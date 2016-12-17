
using UnityEngine;

[System.Serializable]
public class InputAxis
{
  public class AxisIndexAttribute : IndexAttribute { }

  [SerializeField, AxisIndex]
  string _name = string.Empty;

  public string name { get { return _name; } }

  public int axis { get { return (int)Input.GetAxisRaw(_name); } }

  public bool isPush { get { return Input.GetButtonDown(_name); } }
  public bool isPull { get { return Input.GetButtonUp(_name); } }
  public bool isPress { get { return Input.GetButton(_name); } }
}
