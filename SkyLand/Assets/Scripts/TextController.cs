using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private Text lvlText;
    private void Start()
    {
        lvlText.text = "Level 1";
        StartCoroutine(DisableAfterTIme(2f));
    }

    private void Update()
    {
     
    }
    private IEnumerator DisableAfterTIme(float time)
    {
        yield return new WaitForSeconds(time);
        lvlText.text = "";
    }
}
