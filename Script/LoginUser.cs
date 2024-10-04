using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LoginUser : MonoBehaviour
{
    public TMP_InputField edtUser, edtPass;
    public TMP_Text txtError;
    public Selectable first;
    private EventSystem eventSystem;
    public Button btnLogin;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        first.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            btnLogin.onClick.Invoke();
        }
    }

    public void CheckLogin()
    {
        var user = edtUser.text;
        var pass = edtPass.text;    

        if(user.Equals("dat123") && pass.Equals("123"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            txtError.text = "Login failed!";
        }
    }
}
