using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    public void MoveRope(float time, float offset) {
        float mySin = 0.001f * (Mathf.Sin((float)(3f * time + offset)));
        transform.Translate(mySin, 0, 0, Space.World);
    }
}