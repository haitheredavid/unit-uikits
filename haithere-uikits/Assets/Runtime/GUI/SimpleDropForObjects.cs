using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;


public class SimpleDropForObjects<TObj> : VisualElement
{
  public event EventHandler<TObj> onSelectObj;

  private readonly DropdownField df;
  private Dictionary<string, TObj> _values;

  public SimpleDropForObjects()
  {
    df = CreateField;
    df.RegisterValueChangedCallback(Callback);
    Add(df);
  }

  public void SetValue(TObj obj)
  {
    if (obj == null) return;

    var index = 0;
    var input = FormatName(obj);
    foreach (var k in _values.Keys)
    {
      if (!k.Equals(input))
        index++;
      else
      {
        df.index = index;
        break;
      }
    }
  }

  private DropdownField CreateField
  {
    get
    {
      _values = new Dictionary<string, TObj>();
      foreach (var obj in ReflectionHelper.FindType<TObj>())
        _values[FormatName(obj)] = obj;

      return new DropdownField(_values.Keys.ToList(), 0);
    }
  }

  private void Callback(ChangeEvent<string> evt)
  {
    if (_values.TryGetValue(evt.newValue, out var obj))
      onSelectObj?.Invoke(this, obj);
  }

  protected virtual string FormatName(TObj obj)
  {
    return obj.ToString();
  }
}