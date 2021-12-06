using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    int width, height;

    public GameObject grass;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x <= width; x++)
        {
            for (int y = 0; y <= height; y++)
            {
                Instantiate(grass, transform.position + new Vector3(x, y-0.4f, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
