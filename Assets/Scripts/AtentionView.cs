using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtentionView : MonoBehaviour
{
    [SerializeField]
    private Image attentionLight;
    [SerializeField]
    private float timeRed = 1f;
    [SerializeField]
    private float timeWhite = 2f;

    [SerializeField]
    private Color colorRed = Color.red;
    [SerializeField]
    private Color colorWhite = Color.white;

    IEnumerator attentionCoroutine;
    private void OnEnable()
    {
        UnStableManager.OnUnStableStarted += OnAtention;
        UnStableManager.OnStableWork += OffAtention;
    }

    private void OnDisable()
    {
        UnStableManager.OnUnStableStarted -= OnAtention;
        UnStableManager.OnStableWork -= OffAtention;
    }

    private void OnAtention()
    {
        attentionLight.gameObject.SetActive(true);
        attentionCoroutine = Attention();
        StartCoroutine(attentionCoroutine);
    }

    private IEnumerator Attention()
    {
        while (true)
        {
            attentionLight.color = colorRed;
            yield return new WaitForSeconds(timeRed);
            attentionLight.color = colorWhite;
            yield return new WaitForSeconds(timeWhite);
        }
    }
    private void OffAtention()
    {
        attentionLight.gameObject.SetActive(false);
        StopCoroutine(attentionCoroutine);
    }
}
