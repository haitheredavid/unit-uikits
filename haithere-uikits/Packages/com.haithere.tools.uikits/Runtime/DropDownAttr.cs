using System;
using UnityEngine;


namespace haithere.toolkit
{
  [AttributeUsage(AttributeTargets.Field)]
  public class DropDownStringAttribute : PropertyAttribute
  {
    public string Name { get; }

    public DropDownStringAttribute(string value)
    {
      Name = value;
    }
  }

}