using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LostInSpace
{
    public class Build : MonoBehaviour
    {
        public GameObject buildings;
        public GameObject buildPlace;
        public GameObject buildObject;

        private Vector3 buildVector;

        // Start is called before the first frame update
        void Start()
        {
            buildVector = transform.position;
            buildPlace = GameObject.Instantiate(buildPlace, transform.position, Quaternion.identity, transform);
            buildPlace.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                SetBuildVector();
                ShowBuildPlace();
                BuildObject();
            }
            if (transform.gameObject.GetComponent<MovePlayer>().IsMoving)
            {
                HideBuildPlace();
            }
    }

        private void SetBuildVector()
        {
            Vector3 currentBuildVector = transform.position;
            if (Input.GetKey(KeyCode.W))
            {
                currentBuildVector.z -= 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentBuildVector.x -= 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentBuildVector.z += 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentBuildVector.x += 1;
            }
            if(currentBuildVector != transform.position)
            {
                buildVector = currentBuildVector;
            }
        }
        private void BuildObject()
        {
            if (Input.GetKey(KeyCode.Return) && buildVector != transform.position)
            {
                GameObject.Instantiate(buildObject, buildVector, Quaternion.identity, buildings.transform);
                buildVector = transform.position;
                HideBuildPlace();
            }
        }
        private void HideBuildPlace()
        {
            buildPlace.SetActive(false);
            buildPlace.transform.position = transform.position;
        }
        private void ShowBuildPlace()
        {
            if(buildVector != transform.position)
            {
                buildPlace.SetActive(true);
                buildPlace.transform.position = buildVector;
            }
        }
    }
}


