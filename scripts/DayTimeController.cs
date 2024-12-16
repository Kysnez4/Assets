using UnityEngine;

public class DayTimeController : MonoBehaviour
{
  private const float secondInDay = 86400f;

  [SerializeField] private Color nightLightColor;
  [SerializeField] private AnimationCurve nightTimeCurve;
  [SerializeField] private Color dayLightColor;
  
  float time;
  
}
