using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FIreBaseInit : MonoBehaviour
{

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync()
        .ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Firebase ready !");
            }
            else
            {
                Debug.LogError("Firebase error: " + dependencyStatus);
            }
        });
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
