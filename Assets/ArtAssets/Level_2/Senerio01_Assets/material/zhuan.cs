using UnityEngine;
public class ObjectRotation : MonoBehaviour
{
public float rotationSpeed = 1.0f; // 旋转速度
void Update()
{
// 获取物体的Transform组件
Transform objectTransform = transform;
// 以物体的上方向(Z轴)旋转
objectTransform.Rotate(Vector3.forward, rotationSpeed* Time.deltaTime);
}
}