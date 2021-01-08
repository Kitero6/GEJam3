using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSpriteEntry
    {
        public ETypeShoot type;
        public Sprite value;
    }

    [System.Serializable]
    public class PlayerShootEntry
    {
        public ETypeShoot type;
        public GameObject value;
    }

    public static TypeManager Instance = null;

    [SerializeField] PlayerSpriteEntry[] PlayerSprite = null;
    [SerializeField] PlayerShootEntry[] PlayerShoot = null;

    void Start()
    {
        if (Instance)
        {
            Destroy(this);
        }
        Instance = this;
    } 

    public Sprite GetPlayerSprite(ETypeShoot t)
    {
        foreach (PlayerSpriteEntry e in PlayerSprite)
        {
            if (e.type == t)
            {
                return e.value;
            }
        }

        return null;
    }

    public GameObject GetPlayerShoot(ETypeShoot t)
    {
        foreach (PlayerShootEntry e in PlayerShoot)
        {
            if (e.type == t)
            {
                return e.value;
            }
        }

        return null;
    }
}
