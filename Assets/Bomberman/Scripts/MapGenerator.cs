using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public Vector2 mapSize;
	public GameObject blockUndestroyable;
	public GameObject blockDestroyable;
	public Vector3 mapPosition;

	private Vector3 startPos;
	private Vector3 posX;
	private Vector3 posY;


	// Use this for initialization
	void Start () {		
		CreateUndestroyableArena ();
	}
	
	void CreateUndestroyableArena()
	{
		startPos = transform.position;

		for (int x = 0; x < mapSize.x; x++) 
		{
			// Creates a block line on top
			posX = startPos + new Vector3(x, 0, 0);
			CreateBlockUndestroyable (posX);

			// Creates a block line on bottom
			posX = startPos + new Vector3(x, -mapSize.y, 0);
			CreateBlockUndestroyable (posX);


			for (int y = 1; y < mapSize.y; y++) 
			{
				// Creates a block line on left
				posY = startPos + new Vector3(0, y, 0);
				CreateBlockUndestroyable (-posY);

				// Creates a block line on right
				posY = startPos + new Vector3(-mapSize.x+1, y, 0);
				CreateBlockUndestroyable (-posY);
			}
		}

		transform.position = mapPosition;
	}

	void CreateBlockUndestroyable(Vector3 position){
		GameObject block = Instantiate (blockUndestroyable, position, Quaternion.identity);
		block.transform.SetParent (this.transform);
	}
}
