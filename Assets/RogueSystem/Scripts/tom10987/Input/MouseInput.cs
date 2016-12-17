
using UnityEngine;

public enum Mouse
{
  Left,
  Right,
}

public static class MouseInput
{
  public static bool IsPush(this Mouse mouse)
  {
    return Input.GetMouseButtonDown( (int)mouse );
  }

  public static bool IsPull(this Mouse mouse)
  {
    return Input.GetMouseButtonUp( (int)mouse );
  }

  public static bool IsPress(this Mouse mouse)
  {
    return Input.GetMouseButton( (int)mouse );
  }
}
