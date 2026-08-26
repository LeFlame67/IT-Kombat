using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScreenController : MonoBehaviour
{
    [SerializeField] private Text introText;
    [SerializeField] private float fadeInDuration = 2f;
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private float fadeOutDuration = 2f;

    private void Start()
    {
        AudioManager.Instance.PlayIntroMusic();
        StartCoroutine(PlayIntro());
    }

    private IEnumerator PlayIntro()
    {
        // Fade in
        yield return StartCoroutine(FadeText(0, 1, fadeInDuration));

        // Esperar a que se muestre
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        yield return StartCoroutine(FadeText(1, 0, fadeOutDuration));

        // Ir al menú
        GameManager.Instance.ChangeState(GameManager.GameState.Menu);
    }

    private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = introText.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            introText.color = color;
            yield return null;
        }

        color.a = endAlpha;
        introText.color = color;
    }
}
