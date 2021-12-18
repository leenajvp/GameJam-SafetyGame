using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectable", menuName = "New Collectable")]
public class CollectableData : ScriptableObject
{
    public new string name = "ObjectName";
    public Sprite image;

}
