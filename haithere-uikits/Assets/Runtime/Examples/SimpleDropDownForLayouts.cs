using System;
using UnityEngine.UIElements;
using haithere;

public class SimpleDropDownForLayouts : SimpleDropForObjects<SimpleLayout>
{
  public new class UxmlTraits : VisualElement.UxmlTraits
  { }

  public new class UxmlFactory : UxmlFactory<SimpleDropDownForLayouts, UxmlTraits>
  { }

  
 
}