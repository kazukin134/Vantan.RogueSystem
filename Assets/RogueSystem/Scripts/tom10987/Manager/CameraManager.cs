
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
  [SerializeField]
  Camera _camera = null;

  public static Transform cameraObject { get { return _instance.transform; } }
  public static Camera mainCamera { get { return _instance._camera; } }
}
