using System;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite Sprite0;
    [SerializeField]
    private Sprite Sprite1;
    private bool i = false;
    private void Start()
    {
        image = GetComponent<Image>();

    }
    public void AnimTrigger()
    {
        if (!i) {
            image.sprite = Sprite1;
            Invoke(nameof(AnimTrigger), 0.1f);
        } else {
            image.sprite = Sprite0;
        }
        i = !i;
        
    }
}