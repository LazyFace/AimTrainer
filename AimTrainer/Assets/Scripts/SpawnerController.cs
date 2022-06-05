using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController Instance;

    [SerializeField] private GameObject target;

    [SerializeField] private Transform targetFirstPosX;
    [SerializeField] private Transform targetLastPosX;
    [SerializeField] private Transform targetFirstPosY;
    [SerializeField] private Transform targetLastPosY;
    [SerializeField] private Transform targetFirstPosZ;
    [SerializeField] private Transform targetLastPosZ;
    
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Instantiate(target, RandomPosition(), Quaternion.identity);
    }

    private void Update() {
        
    }

    public Vector3 RandomPosition(){
        Vector3 randomPosition = new Vector3(
            Random.Range(targetFirstPosX.position.x, targetLastPosX.position.x), 
            Random.Range(targetFirstPosY.position.y, targetLastPosY.position.y),
            Random.Range(targetFirstPosZ.position.z, targetLastPosZ.position.z)
        );
        return randomPosition;
    }
}
