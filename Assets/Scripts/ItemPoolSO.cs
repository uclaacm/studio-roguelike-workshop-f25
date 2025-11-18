using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemPoolSO", menuName = "Scriptable Objects/ItemPoolSO")]
public class ItemPoolSO : ScriptableObject
{
    [SerializeField] public List<ItemSO> items;
}
