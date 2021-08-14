using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset; //offset도 필요 없을 것 같긴한데
        
        void Start()
        {
            var camera = GetComponent<Camera>();

            float height = camera.orthographicSize;
            target = Player.instance.transform;

            offset = target.position - transform.position;
        }
        void Update()
        {
            var cameraPosY = GetComponent<Camera>().transform.position;
            cameraPosY.y = 0;
            transform.position = cameraPosY;
        }
    }
}
