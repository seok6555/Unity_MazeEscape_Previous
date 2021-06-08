using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator ani;

    public bool isOpen1;
    public bool isOpen2;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        isOpen1 = false;
        isOpen2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorAni();
    }

    void DoorAni()
    {
        if (isOpen1)
        {
            ani.SetBool("isOpen1", true);
        }
        if (isOpen2)
        {
            ani.SetBool("isOpen2", true);
        }
    }
}
