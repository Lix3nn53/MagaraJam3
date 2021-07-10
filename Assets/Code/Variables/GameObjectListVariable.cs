using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GameObjectList")]
public class GameObjectListVariable : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public List<GameObject> value;

    public void AddGameObject(GameObject gameObject)
    {
        this.value.Add(gameObject);
    }

    public void AddGameObjects(GameObjectListVariable variable)
    {
        this.value.AddRange(variable.value);
    }

    public void RemoveGameObject(GameObject gameObject)
    {
        this.value.Remove(gameObject);
    }

    public void RemoveGameObjects(GameObjectListVariable variable)
    {
        this.value.RemoveAll(item => !variable.value.Contains(item));
    }

    public void Clear()
    {
        this.value.Clear();
    }

    public bool Contains(GameObject gameObject)
    {
        return this.value.Contains(gameObject);
    }
}
