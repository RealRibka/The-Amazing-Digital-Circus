using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;

    public void Loading()
    {
        // ��������� ������ �������
        DisableOtherObjects();
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    void DisableOtherObjects()
    {
        // �������� ��� �������� ������� � �����
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        // ��������� ��� �������� �������, ����� ������
        foreach (GameObject rootObject in rootObjects)
        {
            if (rootObject != gameObject && rootObject.GetComponent<Camera>() == null)
            {
                rootObject.SetActive(false);
            }
        }
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(1);
        loadingOperation.allowSceneActivation = false;
        float targetValue = 0.9f;
        float currentValue = 0f;

        while (currentValue < targetValue)
        {
            currentValue += Time.deltaTime * 0.5f; // ����� ����� ��������� ��������
            scale.value = currentValue;
            yield return null;
        }

        yield return new WaitForSeconds(2.2f); // �������������� ��������
        loadingOperation.allowSceneActivation = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}