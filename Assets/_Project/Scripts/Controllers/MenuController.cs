using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	#region VARIABLES

	[SerializeField] private Button keyboardControlButton;
	[SerializeField] private Button mouseControlButton;

	#endregion

	#region MONOBEHAVIOUR_METHODS

	private void Start()
	{
		GameManager.Instance.controlType = ControlType.Keyboard;

		keyboardControlButton.onClick.AddListener(() =>
		{
			GameManager.Instance.controlType = ControlType.Keyboard;
		});

		mouseControlButton.onClick.AddListener(() =>
		{
			GameManager.Instance.controlType = ControlType.Mouse;
		});
	}

	#endregion
}