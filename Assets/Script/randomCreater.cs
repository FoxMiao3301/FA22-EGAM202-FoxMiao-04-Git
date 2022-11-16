using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCreater : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> GameObjects;
    public GameObject cube;
    public int Rnumber;

    public float SwitchTime;
    public float timer;

    void Start()
    {
        SwitchTime = 1f;
        timer = 0;
        RandomGameObject();
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= SwitchTime)
        {
            RandomGameObject();
            timer = 0;
            Time.fixedDeltaTime = timer;
        }
    }


    void RandomGameObject()
    {

        int randomIndex = Random.Range(0, GameObjects.Count);
        Rnumber = randomIndex;

        for (int i = 0; i < 1; i++)
        {
            Spawn();
            //GameObjects[i].SetActive(false);
        }

        //GameObjects[randomIndex].SetActive(true);
    }

    void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-7,7),10,0);
        cube = Instantiate(GameObjects[Random.Range(0,GameObjects.Count)], position, Quaternion.identity);

    }
}
