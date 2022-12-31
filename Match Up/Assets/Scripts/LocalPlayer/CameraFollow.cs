using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //public Transform target1;
    public Transform BG1;
    public Transform BG2;
    private float size;

    private Vector3 cameraTargetPos = new Vector3();
    private Vector3 BG1TargetPos = new Vector3();
    private Vector3 BG2TargetPos = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        size = BG1.GetComponent<BoxCollider2D>().size.y;
        size = BG2.GetComponent<BoxCollider2D>().size.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = SetPos(cameraTargetPos, target.position.x, target.position.y,transform.position.z);
        //Vector3 targetPos1 = SetPos(cameraTargetPos, target1.position.x, target1.position.y,transform.position.z);

        target.transform.position = Vector3.Lerp(target.transform.position, targetPos, 0.2f);
        //target1.transform.position = Vector3.Lerp(target1.transform.position, targetPos1, 0.2f);

        if (target.transform.position.y >= BG2.position.y)
        {
            BG1.position = SetPos(BG1TargetPos, BG1.position.x, BG2.position.y + size, BG1.position.z);
            SwitchingBG();
        }
        if (target.transform.position.y <= BG1.position.y)
        {
            BG1.position = SetPos(BG2TargetPos, BG1.position.x, BG2.position.y - size, BG1.position.z);
            SwitchingBG();
        }

    }

    private void SwitchingBG()
    {
        Transform temp = BG1;
        BG1 = BG2;
        BG2 = temp;
    }
    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
