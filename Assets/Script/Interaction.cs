using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    private GameObject raycastedObj;

    //���̾� ����
    [SerializeField]
    private int rayLength = 10;
    //Interact ���̾ ����� Raycast�� �Ҽ��ֵ���.
    [SerializeField]
    private LayerMask layerMaskInteract;
    //ũ�ν����
    [SerializeField]
    private Image uiCrosshair;
    [SerializeField]
    private TextMeshProUGUI interactMessage;

    public Enemy enemy;
    public DoorController door1;
    public DoorController door2;
    public Key key;

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    void Raycast()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Key"))
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("f"))
                {
                    if (!door1.isOpen1)
                    {
                        Debug.Log("�� ����");
                        door1.isOpen1 = true;
                        raycastedObj.SetActive(false);
                    }
                }
            }

            if (hit.collider.CompareTag("Key2"))
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("f"))
                {
                    if (!door2.isOpen2)
                    {
                        Debug.Log("�� ����");
                        door2.isOpen2 = true;
                        raycastedObj.SetActive(false);
                    }
                }
            }
        }
        else
        {
            CrosshairNormal();
        }
    }

    void CrosshairActive()
    {
        uiCrosshair.color = Color.red;
        interactMessage.text = ("F");
    }

    void CrosshairNormal()
    {
        uiCrosshair.color = Color.white;
        interactMessage.text = ("");
    }
}
