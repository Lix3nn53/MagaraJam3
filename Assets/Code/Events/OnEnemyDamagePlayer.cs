using UnityEngine;

[CreateAssetMenu(menuName = "DelegateEvents/OnEnemyDamagePlayer")]
public class OnEnemyDamagePlayer : ScriptableObject
{
    public delegate void OnEnemyDamagePlayerDelegate(int damage);
    public OnEnemyDamagePlayerDelegate Delegate;

}
