using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component1 : MonoBehaviour
{
    public Transform myTransform;
    public SpriteRenderer sp;
    public Component1 cpn;

    private void Awake() {
        sp = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(sp)
            sp.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
