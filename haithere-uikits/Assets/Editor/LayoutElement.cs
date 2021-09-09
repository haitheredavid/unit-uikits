using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LayoutElement : VisualElement
{

  public LayoutElement(SimpleLayout simpleLayout)
  {
    var item = simpleLayout ?? new SimpleLayout();

    var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/SimpleLayout.uxml");
    var ui = uxmlTemplate.CloneTree();

    var layoutText = ui.Q<TextField>("layoutText");
    layoutText.value = item.layoutName;
    Add(layoutText);
  }

}