using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class KeyButton : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip note;
	public KeyCode key;

	public Button button {get; private set;}

	Graphic targetGraphic;
	Color normalColor;

	void Awake() {
		button = GetComponent<Button>();
		button.interactable = false;
		targetGraphic = GetComponent<Graphic>();

		ColorBlock cb = button.colors;
		cb.disabledColor = cb.normalColor;
		button.colors = cb;
	}

	void Start() {
		button.targetGraphic = null;
		Up();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key)) {
			Down();
		} else if (Input.GetKeyUp(key)) {
			Up();
		}
	}

    void Up()
    {
        StartColorTween(button.colors.normalColor, false);
        audioSource.Stop();
	}

    void Down()
    {
        StartColorTween(button.colors.pressedColor, false);
        button.onClick.Invoke();
        audioSource.clip = note;
        audioSource.Play();
	}

	void StartColorTween(Color targetColor, bool instant) {
		if (targetGraphic == null)
			return;
		
		targetGraphic.CrossFadeColor(targetColor, instant ? 0f : button.colors.fadeDuration, true, true);
	}
	
	void OnApplicationFocus(bool focus) {
		Up();
	}

	public void LogOnClick() {
		Debug.Log ("LogOnClick() - " + GetComponentInChildren<Text>().text);
	}
}