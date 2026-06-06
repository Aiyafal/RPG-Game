using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    const string NEW = "NEW";

    [Header("Progress details")]
    [SerializeField] private Slider progerssBar;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private GameObject loading;

    public void LoadSync()
    {
        SceneManager.LoadScene(NEW);
    }

    public void LoadAsync()
    {
        StartCoroutine(LoadSceneAsync(NEW));
    }


    float fakeProgress = 0;
    IEnumerator LoadSceneAsync(string scenename)
    {
        loading.SetActive(true);
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            fakeProgress += Time.deltaTime*0.5f;
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            progerssBar.value = fakeProgress;
            progressText.text = fakeProgress.ToString("P2");

            if (progress>=1f && fakeProgress>=1f)
            {
                asyncLoad.allowSceneActivation = true;
            }
       
            yield return null;
        }
    }

   
}
