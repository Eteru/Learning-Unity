using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public bool gameOver;

    protected Vector3 lastPos;
    protected float size;

    protected const int NO_PLATFORMS = 20;

	// Use this for initialization
	void Start ()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        gameOver = false;

        for (int i = 0; i < NO_PLATFORMS; ++i) {
            SpawnPlatform();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameOver) {
            CancelInvoke("SpawnPlatform");
        }
    }

    private void SpawnPlatform()
    {
        

        int r = Random.Range(0, 6);

        if (r < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;

        Instantiate(platform, pos, Quaternion.identity);
    }

    private void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos.z += size;

        Instantiate(platform, pos, Quaternion.identity);
    }
}
