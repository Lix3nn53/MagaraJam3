using UnityEngine;

[CreateAssetMenu(menuName = "DelegateEvents/OnPlayerDamageEnemy")]
public class OnPlayerDamageEnemy : ScriptableObject
{
    public delegate void OnPlayerDamageEnemyDelegate(int damage);
    public OnPlayerDamageEnemyDelegate Delegate;

}
