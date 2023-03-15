using System;
using Firebase.RemoteConfig;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ABTest : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private void Start() => StartCoroutine(ChangeColor());

    IEnumerator ChangeColor()
    {
        var config = FirebaseRemoteConfig.DefaultInstance;
        var task = config.FetchAsync(TimeSpan.Zero);

        yield return new WaitUntil(() => task.IsCompleted);

        config.ActivateAsync();
        _text.text = FirebaseRemoteConfig.DefaultInstance.GetValue("Text").StringValue;
    }
}