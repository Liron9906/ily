using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_GridManager : MonoBehaviour
{
	[SerializeField] GameObject[] Tarr;
	private void Start()
	{
		Tiles[] tiles = new Tiles[Tarr.Length];

		for (int i = 0; i < Tarr.Length; i++)
		{
			for(int j = 0;j<=i;j++)
			{
				tiles[i]=new Tiles(Tarr[i],i,j);
				Debug.Log(tiles[i].ToString());
			}
		}
	}
}
