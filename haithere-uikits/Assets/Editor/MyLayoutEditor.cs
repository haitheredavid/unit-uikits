using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MyLayout))]
public class MyLayoutEditor : UnityEditor.Editor
{

  public override VisualElement CreateInspectorGUI()
  {
    var t = target as MyLayout;

    var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/MyLayout.uxml");
    var ui = uxmlTemplate.CloneTree();
    ui.Add(new LayoutElement(t.layout));
    ui.Add(new TextField("random"));

    var opts = new SimpleDropDownForLayouts();
    opts.SetValue(t.layout);

    opts.onSelectObj += (sender, layout1) =>
    {
      t.layout = layout1;
      Debug.Log($"{layout1}Value changed");
    };

    ui.Add(opts);

    return ui;
  }

}