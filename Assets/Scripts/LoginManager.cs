using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private TextMeshProUGUI errorText;

    private void Start()
    {
        // ボタンのクリックイベントを設定
        loginButton.onClick.AddListener(OnLoginButtonClick);
        
        // エラーテキストを初期化
        if (errorText != null)
        {
            errorText.text = "";
        }
    }

    private void OnLoginButtonClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        // 簡単な入力チェック
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("ユーザー名とパスワードを入力してください");
            return;
        }

        // ここで実際の認証処理を実装
        // 例として、単純なチェックを行う
        if (ValidateCredentials(username, password))
        {
            // 認証成功
            Debug.Log("ログイン成功");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ShowError("ユーザー名またはパスワードが正しくありません");
        }
    }

    private bool ValidateCredentials(string username, string password)
    {
        // ここで実際の認証ロジックを実装
        // デモとして、単純なチェックを行う
        return username == "user" && password == "password";
    }

    private void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
        }
        Debug.LogWarning(message);
    }
}