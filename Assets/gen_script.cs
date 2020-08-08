using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen_script : MonoBehaviour
{
	public int width;
	public int height;
	public GameObject grassCube;
	public GameObject StoneCube;
	public float scale;
	public float multiply;
    // Start is called before the first frame update
    void Start()
    {
    	if (scale < 0.0001f) scale = 0.0001f;
        float[,] map = new float[width, height];
        for (int z = 0; z < height; z++){
        	for (int x = 0; x < width; x++){
        		float sX = x/scale;
        		float sZ = z/scale;
        		float perlinValue = Mathf.PerlinNoise(sX, sZ);
        		map[x,z] = perlinValue * multiply;
        	}
    	}
    	for (int z = 0; z < height; z++){
        	for (int x = 0; x < width; x++){
        		int y = Mathf.RoundToInt(map[x,z]);
        		Instantiate(grassCube, new Vector3(x, y, z), Quaternion.identity);
        		if (y > 1){
        			for (int i = y; i > 1; i--){
        			Instantiate(StoneCube, new Vector3(x, i, z), Quaternion.identity);
        			}
        		}
        	}
        }
    }
}
