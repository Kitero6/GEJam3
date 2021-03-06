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

	/*[System.Serializable]
	public class PlayerColorEntry {
		public ETypeShoot type;
		public Color value;
	}*/

    [System.Serializable]
    public class PlayerShootEntry
    {
        public ETypeShoot type;
        public GameObject value;
		public GameObject value2;
    }

    public static TypeManager Instance = null;

    [SerializeField] PlayerSpriteEntry[] PlayerSprite = null;
	//[SerializeField] PlayerColorEntry[] PlayerColor = null; //Added to support color
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

	/*
	public Color GetPlayerColor(ETypeShoot t) {
		foreach (PlayerColorEntry e in PlayerColor) {
			if (e.type == t) {
				return e.value;
			}
		}
		//return a rendering error color.  Null can't be used because color is a struct.  Or something...
		return Color.magenta;
	}*/

    public GameObject GetPlayerShoot(ETypeShoot t, bool varient)
    {
        foreach (PlayerShootEntry e in PlayerShoot)
        {
            if (e.type == t)
            {

				if ( !varient ) return e.value;
				else return e.value2;
            }
        }

        return null;
    }
}
