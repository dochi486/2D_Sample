using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        public BoxCollider2D moveableArea;

        public float minX, maxX, minY, maxY;


        void Start()
        {
            var camera = GetComponent<Camera>();

            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;
            target = Player.instance.transform;

            offset = target.position - transform.position;
            offset.x = 0; //플레이어가 가장자리에 있더라도 카메라 위치는 중앙에서 시작?
            minX = width / 2 + moveableArea.transform.position.x + moveableArea.size.x - moveableArea.size.x / 2;
            maxX = -width / 2 + moveableArea.transform.position.x + moveableArea.size.x + moveableArea.size.x / 2;

            minY = height / 2 + moveableArea.transform.position.z + moveableArea.size.y - moveableArea.size.y / 2;
            maxY = -height / 2 + moveableArea.transform.position.z + moveableArea.size.y + moveableArea.size.y / 2;
            //센터에서 x값의 반을 뺀 것이 최소랑.. 더한 게 최대..!에서 시작
        }

        public float lerp = 0.05f;
        void LateUpdate()
        {

            var newPos = target.position - offset;

            newPos.x = Mathf.Min(newPos.x, maxX);
            newPos.x = Mathf.Max(newPos.x, minX);

            newPos.y = Mathf.Min(newPos.y, maxY);
            newPos.y = Mathf.Max(newPos.y, minY);
            transform.position = Vector3.Lerp(transform.position, newPos, lerp);

        }
        //    public Transform target;
        //    public float lerpSpeed = 1.0f;

        //    private Vector3 offset;

        //    private Vector3 targetPos;

        //    private void Start()
        //    {
        //        if (target == null) return;

        //        offset = transform.position - target.position;
        //    }

        //    private void Update()
        //    {
        //        if (target == null) return;

        //        targetPos = target.position + offset;
        //        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        //    }
        //    //카메라 컨파이너 만들어야 한다. 


        //    //스크린의 width, height를 구하고 

        //    //그 범위 밖으로 이동하지 않도록? 

        //    //카메라의 

        //}
    }
}
