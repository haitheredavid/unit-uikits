using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ReflectionHelper
{
  public static IEnumerable<T> FindType<T>(bool skipBaseObj = false)
  {
    var objs = new List<T>();
    if (!skipBaseObj && !typeof(T).IsAbstract)
      objs.Add((T)Activator.CreateInstance(typeof(T)));

    objs.AddRange(Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                    .Select(type => (T)Activator.CreateInstance(type)));
    return objs;
  }

}