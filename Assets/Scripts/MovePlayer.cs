using UnityEngine;
using System.Collections;

namespace LostInSpace
{

    public class MovePlayer : MonoBehaviour
    {
        public bool IsMoving = false;
        // Use this for initialization
        void Awake()
        {
        }

        // Update is called once per frame
        void Update()
        {
            IsMoving = false;
            Vector3 moveVector = Vector3.zero;
            if (Input.anyKeyDown)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    moveVector.z -= 1;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    moveVector.x -= 1;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    moveVector.z += 1;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    moveVector.x += 1;
                }
                if (moveVector != Vector3.zero)
                {
                    Ray ray = new Ray(transform.position, moveVector);
                    Physics.Raycast(ray, out RaycastHit hit);
                    if (hit.collider == null || hit.distance > 1)
                    {
                        IsMoving = true;
                        transform.position = transform.position + moveVector;
                    }
                }
            }
        }
    }

}
