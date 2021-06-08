using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : GenericSingleton<FadeController>
{
    #region Private variable
    [SerializeField] private Image _fade;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {
        if(Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(FadeIn(1));
    }
    #endregion

    #region Own Methods
    public void NewScene(int scene)
    {
        StartCoroutine(Fade(scene));
    }


    private IEnumerator Fade(int scene)
    {
        yield return StartCoroutine(FadeOut(1, SceneManager.LoadSceneAsync(scene)));  

        yield return StartCoroutine(FadeIn(1));
    }

    private IEnumerator FadeOut(float time, AsyncOperation callback)
    {
        Color Fadecolor = _fade.color;
        float timeElapsed = 0;
        callback.allowSceneActivation = false;
        while (true)
        {
            timeElapsed += Time.deltaTime;

            Color newColor = Color32.Lerp(Fadecolor, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 1), timeElapsed / time);

            _fade.color = newColor;

            if (_fade.color.a > 0.9f)
            {
                break;
            }
            yield return null;
        }
        _fade.color = new Color(_fade.color.r, _fade.color.g, _fade.color.b, 1);

        while (!callback.isDone)
        {
            callback.allowSceneActivation = true;

            if (callback.progress > 0.9f)
            {
                break;
            }
            yield return null;
        }
    }

    private IEnumerator FadeIn(float time)
    {
        Color32 Fadecolor = _fade.color;
        float timeElapsed = 0;
        while (true)
        {
            timeElapsed += Time.deltaTime;

            Color newColor = Color32.Lerp(Fadecolor, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 0), timeElapsed / time);

            _fade.color = newColor;

            if (_fade.color.a < 0.1f)
            {
                break;
            }
            yield return null;
        }
        _fade.color = new Color(_fade.color.r, _fade.color.g, _fade.color.b, 0);
    }
    #endregion

}
