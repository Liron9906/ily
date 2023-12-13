using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_GridManager : MonoBehaviour
{
	[SerializeField] GameObject[] tiles;
	private void Start()
	{
		L_PrefabScript[] Tarr= new L_PrefabScript[tiles.Length];
		for (int i = 0; i < tiles.Length; i++)
		{
			Tarr[i]= new L_PrefabScript(i);
		}
	}
	
}
