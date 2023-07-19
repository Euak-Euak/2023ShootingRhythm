using System;
using UnityEngine;

public enum EnemyType
{
    Monter01,
    Monter02,
    Monter03,
    Monter11,
    Monter12,
    Monter13,
    Monter21,
    Monter22,
    Monter23,
    Monter31,
    Monter32,
    Monter33,
    Monter41,
    Monter42,
    Monter43
}

[Serializable]
public class EnemyData
{
    public EnemyType EnemyType;

    public float MoveTime;
    public float StopTime;
    public float DelayTime;
    public float BulletShootTime;

    public int StartPosition;
    public int EndPosition;

    public float HandleX;
    public float HandleY;

    public int DropItemCount;
    public int DropItemPersent;
}