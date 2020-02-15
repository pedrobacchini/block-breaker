using TMPro;
using UniRx;
using UnityEngine;

namespace UI
{
    public class VelocityDisplay : MonoBehaviour
    {
        private Ball _ball;

        private void Start()
        {
            _ball = FindObjectOfType<Ball>();
            var textMeshProUgui = GetComponent<TextMeshProUGUI>();
            _ball.CurrentVelocity.Subscribe(currentScore => textMeshProUgui.text = currentScore.ToString()).AddTo(this);
        }
    }
}