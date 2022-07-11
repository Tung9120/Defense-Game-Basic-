using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    public GameObject heroPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (heroPrefab)
        {
            var heroClone = Instantiate(heroPrefab, new Vector3(3f, 1f, 0f), Quaternion.identity);
            Destroy(heroClone, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
