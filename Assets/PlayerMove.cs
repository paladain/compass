using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject Camera;
    public GameObject Skin;

    int pushKeyPre = 0;
    float speedTemp = 0;

    int pushW = 0;
    int pushA = 0;
    int pushS = 0;
    int pushD = 0;

    Vector3 plPosPre;

    private void Start()
    {
        speedTemp = Mathf.Sqrt(speed);
    }

    void Update()
    {
        pushW = 0;
        pushA = 0;
        pushS = 0;
        pushD = 0;

        // �O�̃��[�v�ňړ��L�[�������Ă�����
        if (pushKeyPre == 0)
        {
            // �ړ������߂Ɍ��������Z�b�g����
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Camera.transform.rotation;
                Camera.transform.rotation = transform.rotation;
            }
        }
        else
        {
            pushKeyPre = 0;
        }

        // W�L�[�i�O���ړ��j
        if (Input.GetKey(KeyCode.W))
        {
            pushW = 1;
            pushKeyPre = 1;
        }

        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S))
        {
            pushS = 1;
            pushKeyPre = 1;
        }

        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            pushD = 1;
            pushKeyPre = 1;
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            pushA = 1;
            pushKeyPre = 1;
        }

        if(pushW == 1 || pushS == 1)
        {
            if(pushA == 1 || pushD == 1)
            {
                transform.position += (speedTemp * (pushW - pushS)) * transform.forward * Time.deltaTime;
                transform.position += (speedTemp * (pushD -pushA)) * transform.right * Time.deltaTime;
            }
            else
            {
                transform.position += (speed * (pushW - pushS)) * transform.forward * Time.deltaTime;
            }
        }
        else if (pushA == 1 || pushD == 1)
        {
            if (pushW == 1 || pushS == 1)
            {
                transform.position += (speedTemp * (pushW - pushS)) * transform.forward * Time.deltaTime;
                transform.position += (speedTemp * (pushD - pushA)) * transform.right * Time.deltaTime;
            }
            else
            {
                transform.position += (speed * (pushD - pushA)) * transform.right * Time.deltaTime;
            }
        }

        Vector3 diff = transform.position - plPosPre;

        if (diff.magnitude != 0) //�x�N�g���̒�����0�łȂ��Ƃ��Ƀv���C���[�̌�����ς��鏈��������
        {
            Skin.transform.rotation = Quaternion.LookRotation(diff);  //�x�N�g���̏���Quaternion.LookRotation�Ɉ����n����]�ʂ��擾���v���C���[����]������
        }

        plPosPre = transform.position;

    }
}
