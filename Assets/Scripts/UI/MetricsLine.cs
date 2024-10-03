using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MetricsLine : MonoBehaviour
    {
        [SerializeField] private string prefix;
        [SerializeField] private Text text;

        public void SetValue(string value)
        {
            text.text = prefix + value;
        }
    }
}
