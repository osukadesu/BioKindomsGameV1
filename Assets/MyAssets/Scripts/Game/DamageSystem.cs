using UnityEngine;
public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] protected internal int daño;
    protected internal abstract void SubtractLife(Collider other);
}