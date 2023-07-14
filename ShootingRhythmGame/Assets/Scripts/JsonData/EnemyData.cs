using System;
using UnityEngine;

public enum EnemyType
{
    Circle,
    Straight
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