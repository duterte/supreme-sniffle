using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public string PlayerName;
    public GameObject PlayerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerObject, new Vector3(0, 2, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
