using System.Collections;
using DG.Tweening;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

public class FollowMouseMovement : MonoBehaviour
{
    [HideInInspector]public bool followMouse = false;
    [HideInInspector]public bool IsPhoto = false;
    //public Camera myCam;
    private Vector3 MousePosInWorld;
    public PlayMakerFSM CharacterFSM;

    public float rotSpeed = 50;
    private float smoother = 100;

    // Update is called once per frame
    void Update()
    {
        
        if (followMouse)
        {
            if (!IsPhoto)
            {
                RotateObject(); 
               
            }
//            else
//            {
//                CharacterFSM.SendEvent("UserExit");
//            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape) ||  Input.GetMouseButtonDown(0) )
            {
                CharacterFSM.SendEvent("UserExit");
               
            }

        }

        void RotateObject()
        {

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            Vector3 RotateAmount = Vector3.up * rotX + Vector3.right * rotY;
            Tween rotateEase = transform.DORotate(RotateAmount, 0.5f, RotateMode.WorldAxisAdd);
            rotateEase.SetEase(Ease.OutQuint);
            
//            transform.Rotate(Vector3.up,-rotX);
//            transform.Rotate(Vector3.right,rotY);

        }

//        void FollowMouse()
//        {
//            Vector3 MousePos = Input.mousePosition;
//            MousePos.z = 0.6f;
//       
//            Vector3 myPos = transform.position;
//            myPos = myCam.ScreenToWorldPoint(MousePos);
//            //myPos.y = transform.position.y;
//            transform.position = Vector3.Lerp(transform.position,myPos,Time.deltaTime * 5f);
//        }

    }

    
}