
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Field)]
public class OpenFieldAttribute : PropertyAttribute
{
  public OpenFieldAttribute(string name) { fieldName = name; }
  public string fieldName { get; private set; }
}
