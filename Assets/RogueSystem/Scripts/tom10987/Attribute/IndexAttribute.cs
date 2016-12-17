
using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class IndexAttribute : UnityEngine.PropertyAttribute
{
  public IndexAttribute() { }
  public int selected = 0;
}
