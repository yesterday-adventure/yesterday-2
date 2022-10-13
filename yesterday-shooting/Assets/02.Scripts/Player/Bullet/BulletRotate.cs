using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
    }
}
