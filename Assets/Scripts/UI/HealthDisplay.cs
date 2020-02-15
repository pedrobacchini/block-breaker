using Sirenix.OdinInspector;
using TMPro;
using UniRx;

namespace UI
{
    public class HealthDisplay : SerializedMonoBehaviour
    {
        private void Start()
        {
            var textMeshProUgui = GetComponent<TextMeshProUGUI>();
            GameMaster.CurrentLives.Subscribe(health => textMeshProUgui.text = health.ToString()).AddTo(this);
        }
    }
}
