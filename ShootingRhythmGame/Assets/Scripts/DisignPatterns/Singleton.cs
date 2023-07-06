using UnityEngine;

/// <summary>
/// �̱���. ����� ���� �̷����
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ����
    private static T _instance = null;

    //�� �������� (������ ���� �Ӽ�)
    public static T Instance
    {
        get
        {
            if (_instance == null)
                return null;

            return _instance;
        }
    }

    // �ʱ�ȭ
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