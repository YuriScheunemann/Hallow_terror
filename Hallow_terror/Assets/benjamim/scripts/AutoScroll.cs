using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float speed = 0.1f;

    void Update()
    {
        scrollbar.value += speed * Time.deltaTime;
    }
}
