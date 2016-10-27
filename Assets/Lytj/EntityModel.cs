using UnityEngine;
using System.Collections;

public  abstract class EntityModel : MonoBehaviour {

    public abstract int Hp { get; set; }
    public abstract int Atk { get; set; }
    public abstract string Name { get; set; }

    public abstract void Attack();
    public abstract void Hurt();
    public abstract void SaveData(EntityData data);
    public abstract void RefreshHp();
}
