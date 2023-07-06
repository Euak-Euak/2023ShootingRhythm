using UnityEngine;

/// <summary>
/// 싱글톤. 상속을 통해 이루어짐
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 본인
    private static T _instance = null;

    //값 가져오기 (보안을 위한 속성)
    public static T Instance
    {
        get
        {
            if (_instance == null)
                return null;

            return _instance;
        }
    }

    // 초기화
    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}